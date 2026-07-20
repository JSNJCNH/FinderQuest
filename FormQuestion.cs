using FinderQuest.FinderQuest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FinderQuest.QuestionBankBoss;

namespace FinderQuest
{
    public partial class FormQuestion : Form
    {
        public Finder_Quest_Game frmGame;

        // === Boss battle fields ===
        private bool isBossBattle = false;
        private Boss boss;
        private GeminiService aiService;
        private List<BossQuestion> bossQuestionPool;
        private BossQuestion currentBossQuestion;
        private Random rngBoss = new Random();

        public FormQuestion()
        {
            InitializeComponent();
        }

        private void FormQuestion_Load(object sender, EventArgs e)
        {
            frmGame = (Finder_Quest_Game)this.Owner;
            this.KeyPreview = true;
            UpdateJumlahItem();

            // Deteksi apakah lawan bicara ini Boss (NoPerson == 9, sesuai GenerateWalkArea di Finder_Quest_Game)
            if (frmGame.activePerson.NoPerson == 9)
            {
                isBossBattle = true;
                InitBossBattle();
            }
            else
            {
                isBossBattle = false;
                labelQuestion.Text = frmGame.activePerson.PersonQuestion.Question;
            }
        }

        // === Setup awal Boss Battle ===
        private void InitBossBattle()
        {
            boss = new Boss(Properties.Resources.Boss, new Size(150, 150), new Point(10, 10));
            boss.DisplayPicture(this);

            aiService = new GeminiService();
            bossQuestionPool = new List<BossQuestion>(QuestionBank.BossQuestions);

            UpdateBossHealthDisplay();
            LoadNextBossQuestion();

            // Timer boss: total 2 menit buat ngalahin boss
            labelBossHP.Visible = true;
            labelBossTimer.Visible = true;
            bossTimeLimit = new PunishmentTime(0, 2, 0);
            labelBossTimer.Text = bossTimeLimit.DisplayData();
            timerBossFight.Interval = 1000;
            timerBossFight.Start();

        }

        private void LoadNextBossQuestion()
        {
            if (bossQuestionPool.Count == 0)
            {
                bossQuestionPool = new List<BossQuestion>(QuestionBank.BossQuestions);
            }

            int index = rngBoss.Next(bossQuestionPool.Count);
            currentBossQuestion = bossQuestionPool[index];
            bossQuestionPool.RemoveAt(index);

            labelQuestion.Text = currentBossQuestion.Question;
            textBoxAnswer.Text = "";
        }

        private void UpdateBossHealthDisplay()
        {
            labelBossHP.Text = "Boss HP: " + boss.HP + " / " + boss.MaxHP;
        }

        private void UpdateJumlahItem()
        {
            labelNumberPotionHealth.Text = frmGame.player.JumlahBeliHealth.ToString();
            labelNumberAnswerKey.Text = frmGame.player.JumlahBeliAnswerKey.ToString();
            labelNumberPotionTime.Text = frmGame.player.JumlahBeliTime.ToString();
        }

        private async void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (isBossBattle)
            {
                await HandleBossAnswerSubmit();
            }
            else
            {
                // === Logic pertanyaan biasa, TIDAK diubah ===
                if (frmGame.activePerson.CheckAnswer(textBoxAnswer.Text, out int score) == true)
                {
                    MessageBox.Show("Your answer is correct! You get " + score.ToString() + " points.");
                    frmGame.player.AddScore(score);
                }
                else
                {
                    MessageBox.Show("Sorry.. your answer is incorrect!");
                    MessageBox.Show("Some consequences await!");
                    FormMiniGame form = new FormMiniGame();
                    form.Owner = this;
                    form.ShowDialog();
                }
                frmGame.ExitTalkArea();
                this.Close();
            }
        }

        // === Handler khusus jawaban Boss ===
        private async Task HandleBossAnswerSubmit()
        {
            string userAnswer = textBoxAnswer.Text;
            if (string.IsNullOrWhiteSpace(userAnswer))
            {
                MessageBox.Show("Jawaban belum diisi.");
                return;
            }

            buttonSubmit.Enabled = false;
            labelQuestion.Text = "Menilai jawaban...";

            try
            {
                AIEvaluationResult result = await aiService.EvaluateAnswerAsync(
                    currentBossQuestion.Question,
                    currentBossQuestion.ReferenceAnswer,
                    userAnswer
                );

                boss.TakeDamage(result.Score);
                UpdateBossHealthDisplay();

                MessageBox.Show("Skor: " + result.Score + "/10\nDamage ke boss: " + result.Score + "\nFeedback: " + result.Feedback);

                // Boss kalah -> selesai battle, balik ke Finder_Quest_Game
                if (boss.IsDead)
                {
                    MessageBox.Show("Boss kalah! Kamu menang!");
                    frmGame.ExitTalkArea();
                    this.Close();
                    return;
                }

                // Boss belum mati -> lanjut ke fase dodge (MiniGame)
                FormMiniGame miniGame = new FormMiniGame();
                miniGame.Owner = this;
                miniGame.ShowDialog(); // blocking, FormQuestion tetap terbuka di belakang

                // Kalau player mati pas dodge -> battle gagal, keluar total ke Finder_Quest_Game
                if (miniGame.PlayerSurvived == false)
                {
                    MessageBox.Show("Kamu kalah melawan Boss!");
                    frmGame.ExitTalkArea();
                    this.Close();
                    return;
                }

                // Player selamat -> lanjut ke pertanyaan boss berikutnya (loop)
                LoadNextBossQuestion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menilai jawaban: " + ex.Message);
            }
            finally
            {
                buttonSubmit.Enabled = true;
            }
        }

        // === Tambahan field di FormQuestion ===
        private PunishmentTime bossTimeLimit;

        // === Event Tick timer boss (hook manual lewat Designer) ===
        private void timerBossFight_Tick(object sender, EventArgs e)
        {
            bossTimeLimit.AddWithSecond(-1);
            labelBossTimer.Text = bossTimeLimit.DisplayData();

            if (bossTimeLimit.Hour == 0 && bossTimeLimit.Minute == 0 && bossTimeLimit.Second == 0)
            {
                timerBossFight.Stop();
                MessageBox.Show("Waktu habis! Boss berhasil kabur, kamu gagal mengalahkannya.");

                frmGame.ExitTalkArea();
                this.Close();
            }
        }

        private void FormQuestion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                buttonSubmit_Click((object)sender, e);
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void buttonEquipHealth_Click(object sender, EventArgs e)
        {
            if (frmGame.player.JumlahBeliHealth > 0)
            {
                frmGame.player.JumlahBeliHealth--;
                MessageBox.Show("Potion Health digunakan!");
                UpdateJumlahItem();
            }
            else
            {
                MessageBox.Show("Kamu tidak punya item ini!");
            }
        }

        private void buttonEquipAnswerKey_Click(object sender, EventArgs e)
        {
            if (frmGame.player.JumlahBeliAnswerKey > 0)
            {
                frmGame.player.JumlahBeliAnswerKey--;

                // Kalau lagi boss battle, Answer Key ngisi jawaban referensi boss, bukan jawaban Questions biasa
                if (isBossBattle)
                    textBoxAnswer.Text = currentBossQuestion.ReferenceAnswer;
                else
                    textBoxAnswer.Text = frmGame.activePerson.PersonQuestion.Answer;

                MessageBox.Show("Answer Key digunakan! Jawaban sudah terisi.");
                UpdateJumlahItem();
            }
            else
            {
                MessageBox.Show("Kamu tidak punya item ini!");
            }
        }

        private void buttonEquipPotionTime_Click(object sender, EventArgs e)
        {
            if (frmGame.player.JumlahBeliTime > 0)
            {
                frmGame.player.JumlahBeliTime--;
                MessageBox.Show("Potion Time digunakan!");
                UpdateJumlahItem();
            }
            else
            {
                MessageBox.Show("Kamu tidak punya item ini!");
            }
        }
    }
}