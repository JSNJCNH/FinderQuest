using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FinderQuest
{
    public class AIEvaluationResult
    {
        public int Score { get; set; }
        public string Feedback { get; set; }
    }

    public class GeminiService
    {
        private readonly HttpClient client;
        private readonly string apiKey;
        private const string model = "gemini-3.5-flash"; // sesuaikan dengan model yang mau kamu pakai
        private string apiUrl;

        public GeminiService()
        {
            apiKey = "AQ.Ab8RN6Kd2i9cO2kq1K2sUs7iIm_BImPTlJ876e0TAPu4p1e_IQ";

            if (string.IsNullOrEmpty(apiKey))
                throw new InvalidOperationException("GEMINI_API_KEY belum di-set di environment variable.");

            apiUrl = "https://generativelanguage.googleapis.com/v1beta/models/" + model + ":generateContent";

            client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-goog-api-key", apiKey);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<AIEvaluationResult> EvaluateAnswerAsync(string question, string referenceAnswer, string userAnswer)
        {
            string systemPrompt =
                "Kamu adalah penilai jawaban esai untuk sebuah game edukasi. " +
                "Kamu akan diberi pertanyaan, jawaban referensi (acuan benar), dan jawaban dari pemain. " +
                "Nilai seberapa akurat dan lengkap jawaban pemain dibanding jawaban referensi, skala 1 sampai 10 " +
                "(1 = sangat salah/tidak relevan, 10 = sangat akurat dan mencakup poin penting). " +
                "Balas HANYA dalam format JSON murni tanpa markdown, tanpa teks lain. " +
                "Formatnya persis seperti ini: {\"score\": <angka 1-10>, \"feedback\": \"<penjelasan singkat>\"}";

            string userPrompt =
                "Pertanyaan: " + question + "\n\n" +
                "Jawaban referensi: " + referenceAnswer + "\n\n" +
                "Jawaban pemain: " + userAnswer;

            // Format request Gemini beda total dari Claude: pakai "contents" + "parts", bukan "messages"
            var requestBody = new
            {
                systemInstruction = new
                {
                    parts = new[] { new { text = systemPrompt } }
                },
                contents = new[]
                {
                    new
                    {
                        role = "user",
                        parts = new[] { new { text = userPrompt } }
                    }
                },
                generationConfig = new
                {
                    maxOutputTokens = 500,           // dinaikkan dari 500, kasih ruang lebih
                    responseMimeType = "application/json",
                    thinkingConfig = new
                    {
                        thinkingBudget = 0            // matikan thinking, biar semua token dipakai buat output JSON langsung
                    }
                }
            };

            string responseJson = await SendRequestAsync(requestBody);
            string rawText = ExtractTextFromResponse(responseJson);

            return ParseEvaluation(rawText);
        }

        private async Task<string> SendRequestAsync(object requestBody)
        {
            string jsonBody = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(apiUrl, content);
            string responseString = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new Exception("Gemini API error (" + response.StatusCode + "): " + responseString);

            return responseString;
        }

        // Struktur response Gemini: candidates[0].content.parts[0].text
        private string ExtractTextFromResponse(string responseJson)
        {
            StringBuilder sb = new StringBuilder();

            using (JsonDocument doc = JsonDocument.Parse(responseJson))
            {
                var candidates = doc.RootElement.GetProperty("candidates");
                var firstCandidate = candidates[0];
                var content = firstCandidate.GetProperty("content");
                var parts = content.GetProperty("parts");

                foreach (var part in parts.EnumerateArray())
                {
                    if (part.TryGetProperty("text", out JsonElement textElement))
                    {
                        sb.Append(textElement.GetString());
                    }
                }
            }

            return sb.ToString();
        }

        private AIEvaluationResult ParseEvaluation(string rawText)
        {
            string cleaned = rawText.Trim();
            cleaned = cleaned.Replace("```json", "").Replace("```", "").Trim();

            try
            {
                using (JsonDocument doc = JsonDocument.Parse(cleaned))
                {
                    var root = doc.RootElement;

                    return new AIEvaluationResult
                    {
                        Score = root.GetProperty("score").GetInt32(),
                        Feedback = root.GetProperty("feedback").GetString()
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Gagal parsing hasil penilaian: " + ex.Message + "\nRaw response: " + rawText);
            }
        }
    }
}