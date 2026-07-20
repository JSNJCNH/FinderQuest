using FinderQuest.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Channels;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeApplication;
using WMPLib;

namespace FinderQuest
{
    public partial class Finder_Quest_Game : Form
    {
        //calon cumlaude
        Time maxTime, playTime;

        int numOfWalkArea = 5;
        int numOfWalkArea = 4;
        WalkAreas currentWalkArea = null;
        TalkAreas currentTalkArea = null;

        public Players player;

        public People activePerson;
        Point activePersonLastLocation;

        bool enterTalkArea = false;

        WindowsMediaPlayer backSoundPlayer = new WindowsMediaPlayer();
        WindowsMediaPlayer otherSoundPlayer;

        bool isWin, paused = false, started = false;

        public List<Record> listLeaderboard = new List<Record>();
        string fileDefLeaderboard = "Leaderboard.dat";

        public BindingList<Players> listPlayers = new BindingList<Players>();
        string fileDefPlayers = "Players.dat";

        public Time maxTime = new Time(0, 10, 0);
        public Time playTime = new Time(0, 0, 0);

        public List<Questions> DaftarSoal = new List<Questions>();
        private List<Questions> soalTersedia = new List<Questions>();

        public Finder_Quest_Game()
        {
            InitializeComponent();
        }

        private void Finder_Quest_Game_Load(object sender, EventArgs e)
        {
            panelHome.Visible = true;
            panelGame.Visible = false;
            labelTime.Visible = false;

            timerTime.Interval = 1000;
            timerPlayTime.Interval = 1000;

            this.KeyPreview = true;
            this.DoubleBuffered = true;

            panelTalkArea.Visible = false;

            buttonStart.FlatAppearance.BorderSize = 0;

            DaftarSoal.Add(new Questions("Berapa hasil dari 2 + 2?", "4", 20));
            DaftarSoal.Add(new Questions("Berapa hasil dari 10 - 5?", "5", 20));
            DaftarSoal.Add(new Questions("Berapa hasil dari 5 x 5?", "25", 20));
            DaftarSoal.Add(new Questions("Berapa hasil dari 100 / 10?", "10", 20));
            DaftarSoal.Add(new Questions("Berapa hasil dari 3 + 9?", "12", 20));
            DaftarSoal.Add(new Questions("Berapa hasil dari 20 - 8?", "12", 20));
            DaftarSoal.Add(new Questions("Berapa hasil dari 6 x 6?", "36", 20));
            DaftarSoal.Add(new Questions("Berapa hasil dari 15 + 15?", "30", 20));
            DaftarSoal.Add(new Questions("Berapa hasil dari 50 / 5?", "10", 20));
            DaftarSoal.Add(new Questions("Berapa hasil dari 7 + 8?", "15", 20));
            DaftarSoal.Add(new Questions("Apa ibu kota Indonesia?", "Jakarta", 20));
            DaftarSoal.Add(new Questions("Apa ibu kota Jepang?", "Tokyo", 20));
            DaftarSoal.Add(new Questions("Apa ibu kota Perancis?", "Paris", 20));
            DaftarSoal.Add(new Questions("Apa ibu kota Inggris?", "London", 20));
            DaftarSoal.Add(new Questions("Apa ibu kota Korea Selatan?", "Seoul", 20));

            DaftarSoal.Add(new Questions("Berapa hasil dari 12 x 8?", "96", 50));
            DaftarSoal.Add(new Questions("Berapa hasil dari akar kuadrat 81?", "9", 50));
            DaftarSoal.Add(new Questions("Berapa hasil dari 15% dari 200?", "30", 50));
            DaftarSoal.Add(new Questions("Berapa hasil dari 7 pangkat 2?", "49", 50));
            DaftarSoal.Add(new Questions("Berapa hasil dari 9 x 9?", "81", 50));
            DaftarSoal.Add(new Questions("Berapa hasil dari akar kuadrat 121?", "11", 50));
            DaftarSoal.Add(new Questions("Berapa hasil dari 144 / 12?", "12", 50));
            DaftarSoal.Add(new Questions("Berapa hasil dari 18 x 4?", "72", 50));
            DaftarSoal.Add(new Questions("Berapa hasil dari 25% dari 400?", "100", 50));
            DaftarSoal.Add(new Questions("Berapa hasil dari 11 x 11?", "121", 50));
            DaftarSoal.Add(new Questions("Gunung tertinggi di dunia adalah?", "Everest", 50));
            DaftarSoal.Add(new Questions("Benua terbesar di dunia adalah?", "Asia", 50));
            DaftarSoal.Add(new Questions("Samudra terluas di dunia adalah?", "Pasifik", 50));
            DaftarSoal.Add(new Questions("Sungai terpanjang di dunia adalah?", "Nil", 50));
            DaftarSoal.Add(new Questions("Negara dengan populasi terbanyak di dunia adalah?", "China", 50));

            DaftarSoal.Add(new Questions("Solve this math equation: \n x + y = 10 \n If x = 3, then y = ?", "7", 100));
            DaftarSoal.Add(new Questions("What is the capital city of Indonesia?", "Jakarta", 100));
            DaftarSoal.Add(new Questions("Berapa nilai phi (π) dibulatkan 2 desimal?", "3.14", 100));
            DaftarSoal.Add(new Questions("Berapa hasil dari 13 x 13?", "169", 100));
            DaftarSoal.Add(new Questions("Berapa hasil logaritma dari log 100 (basis 10)?", "2", 100));
            DaftarSoal.Add(new Questions("Berapa hasil dari 17 x 17?", "289", 100));
            DaftarSoal.Add(new Questions("Berapa hasil dari akar kuadrat 225?", "15", 100));
            DaftarSoal.Add(new Questions("Berapa hasil dari 2 pangkat 8?", "256", 100));
            DaftarSoal.Add(new Questions("Berapa hasil dari 19 x 19?", "361", 100));
            DaftarSoal.Add(new Questions("Berapa hasil dari 30% dari 750?", "225", 100));
            DaftarSoal.Add(new Questions("Palung laut terdalam di dunia adalah?", "Palung Mariana", 100));
            DaftarSoal.Add(new Questions("Candi Borobudur terletak di provinsi?", "Jawa Tengah", 100));
            DaftarSoal.Add(new Questions("Negara terkecil di dunia berdasarkan luas wilayah adalah?", "Vatikan", 100));
            DaftarSoal.Add(new Questions("What is the chemical compound name for sulfuric acid?", "H2SO4", 100));
            DaftarSoal.Add(new Questions("I have this pattern: \n 1  1  2  3  5  8 ... \nWhat is the next number?", "13", 100));

            DaftarSoal.Add(new Questions("Check this C# codes: \n int result = 10/100; \nMessageBox.Show(result); \nWhat is the output?", "0", 100));
            DaftarSoal.Add(new Questions("A product costs $100, discounted 10%, plus $5 shipping. \nHow much do you pay?", "95", 100));
            DaftarSoal.Add(new Questions("What is the 1st principle (sila ke-1) of Pancasila?", "Ketuhanan Yang Maha Esa", 100));
            DaftarSoal.Add(new Questions("Berapa nilai dari integral dari 2x dx?", "x^2 + C", 100));
            DaftarSoal.Add(new Questions("Berapa hasil dari 2 pangkat 10?", "1024", 100));
            DaftarSoal.Add(new Questions("Berapa turunan kedua dari fungsi x^3?", "6x", 100));
            DaftarSoal.Add(new Questions("Berapa nilai dari 5 faktorial (5!)?", "120", 100));

            soalTersedia = new List<Questions>(DaftarSoal);
        }

        private void TimerTime_Tick(object sender, EventArgs e)
        {
            maxTime.AddWithSecond(-1);

            labelTime.Text = maxTime.DisplayData();

            if(maxTime.Hour == 0 && maxTime.Minute == 0 && maxTime.Second == 0)
            {
                timerTime.Stop();
                isWin = false;

                backSoundPlayer.controls.stop();
                PlaySound("lose game");

                GameOver(isWin);

                DialogResult result = MessageBox.Show("Game Over. Time is up.");
                if(result == DialogResult.OK)
                {
                    otherSoundPlayer.controls.stop();
                }
            }
        }

        private void StartGame()
        {
            started = true;

            panelGame.Visible = true;
            panelGame.Focus();
            panelHome.Visible = false;

            timerPlayTime.Start();

            if (currentWalkArea != null)
                currentWalkArea.RemoveAllPeople();

            currentWalkArea = null;
            GenerateWalkArea();

            labelPlayer.Text = player.DisplayData();
            player.DisplayPicture(this);

            PlaySound("walk area");

            paused = false;

            this.ActiveControl = null;
            this.Focus();
        }

        private void GameOver(bool isWin)
        {
            started = false;

            timerPlayTime.Stop();

            if(isWin && player != null)
            {
                Record newRecord = new Record(player.Name, player.Score, player.PlayTime);
                listLeaderboard.Add(newRecord);

                listLeaderboard = listLeaderboard.OrderByDescending(record => record.Score).ThenByDescending(record => record.Time.ConvertToSecond()).ToList();
                SaveLeaderboard(fileDefLeaderboard);
            }

            enterTalkArea = false;
            panelTalkArea.Visible = false;
            activePerson = null;

            panelGame.Visible = false;
            labelTime.Visible = false;
            panelHome.Visible = true;

            this.BackgroundImage = Properties.Resources.background;

            if (currentWalkArea != null)
            {
                currentWalkArea.RemoveAllPeople();
                currentWalkArea = null;
            }

            if (player != null && player.Picture != null)
            {
                this.Controls.Remove(player.Picture);
                player.Picture.Dispose();
                player = null;
            }
        }

        private void Finder_Quest_Game_KeyDown(object sender, KeyEventArgs e)
        {
            int distance = 30;

            if (paused == false)
            {
                if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
                {
                    if (player.Picture.Location.X + player.Picture.Width >= Width - 20)
                    {
                        if (currentWalkArea.NoArea == 1)
                        {
                            currentWalkArea.NoArea++;
                            GenerateWalkArea();
                            labelTime.Visible = true;
                        }
                        else if (currentWalkArea.CheckFinishAllQuestions())
                        {
                            if (currentWalkArea.NoArea < numOfWalkArea)
                            {
                                currentWalkArea.NoArea++;
                                GenerateWalkArea();
                            }
                            else
                            {
                                backSoundPlayer.controls.stop();
                                PlaySound("win game");

                                isWin = true;
                                GameOver(isWin);

                                DialogResult result = MessageBox.Show("Congratulations! You win the game!", "Congratulations");
                                if (result == DialogResult.OK)
                                {
                                    otherSoundPlayer.controls.stop();
                                }
                            }
                        }
                    }
                    else
                    {
                        player.MoveRight(distance);

                        player.DisplayPicture(this);
                    }
                }
                else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
                {
                    if (player.Picture.Location.X >= 10)
                        player.MoveLeft(distance);

                    player.DisplayPicture(this);
                }
                else if (e.KeyCode == Keys.Enter)
                {
                    if (currentWalkArea.CheckTouchPerson(player, out People touchPerson) == true)
                    {
                        enterTalkArea = true;
                        activePerson = touchPerson;
                        activePersonLastLocation = activePerson.Picture.Location;
                        EnterTalkArea();
                    }
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    if (activePerson != null)
                    {
                        ExitTalkArea();
                    }
                    else if (started != false)
                    {
                        paused = true;
                        timerTime.Stop();
                        backSoundPlayer.controls.pause();

                        FormPause form = new FormPause();
                        form.Size = this.ClientSize;
                        form.Location = this.PointToScreen(Point.Empty);
                        DialogResult result = form.ShowDialog();

                        if (result == DialogResult.Abort)
                        {
                            started = false;
                            timerPlayTime.Stop();

                            enterTalkArea = false;
                            panelTalkArea.Visible = false;
                            activePerson = null;

                            panelGame.Visible = false;
                            labelTime.Visible = false;
                            panelHome.Visible = true;

                            this.BackgroundImage = Properties.Resources.background;

                            if (currentWalkArea != null)
                            {
                                currentWalkArea.RemoveAllPeople();
                                currentWalkArea = null;
                            }

                            if (player != null && player.Picture != null)
                            {
                                this.Controls.Remove(player.Picture);
                                player.Picture.Dispose();
                                player = null;
                            }
                        }
                        else
                        {
                            paused = false;
                            timerTime.Start();
                            backSoundPlayer.controls.play();
                        }
                    }
                }
                else if (e.KeyCode == Keys.Y && activePerson?.NoPerson == 1)
                {
                    MerchantForm form = new MerchantForm();
                    form.Owner = this;
                    form.ShowDialog();
                }
                else if (e.KeyCode == Keys.Y && activePerson?.SolvedStatus == false && activePerson.NoPerson != 1)
                {
                    FormQuestion form = new FormQuestion();
                    form.Owner = this;
                    form.ShowDialog();
                }
            }
        }

        }

        private void GenerateWalkArea()
        {
            try
            {
                if (currentWalkArea == null)
                {
                    currentWalkArea = new WalkAreas("Basecamp", Properties.Resources.walkArea1, 1);

                    currentWalkArea.AddPerson(1, "Merchant", Properties.Resources.Merchant_Character, new Size(376, 211), new Point(600, 530), "Welcome to my humble shop. \nPress 'y' to continue.");
                }
                else if (currentWalkArea.NoArea == 2)
                {
                    timerTime.Start();
                    currentWalkArea.RemoveAllPeople();

                    currentWalkArea = new WalkAreas("The Barn", Properties.Resources.walkArea1, 2);

                    currentWalkArea.AddPerson(2, "Anna", Properties.Resources.person1, new Size(50, 80), new Point(150, 660), "I have a question for you. Are you ready? \nPress 'y' to continue.");
                    currentWalkArea.AddPerson(3, "Andy", Properties.Resources.person2, new Size(50, 80), new Point(420, 660), "Can you answer my question? Let's Go! \nPress 'y' to continue.");
                    currentWalkArea.AddPerson(4, "Bobby", Properties.Resources.person3, new Size(50, 80), new Point(600, 670), "Just answer my question please... \nPress 'y' to continue.");
                }
                else if (currentWalkArea.NoArea == 3)
                {
                    currentWalkArea.RemoveAllPeople();

                    currentWalkArea = new WalkAreas("The Field", Properties.Resources.walkArea2, 3);

                    currentWalkArea.AddPerson(5, "Rina", Properties.Resources.person4, new Size(50, 80), new Point(100, 610), "I'm sure you can answer my question. \nPress 'y' to continue.");
                    currentWalkArea.AddPerson(6, "Tommy", Properties.Resources.person5, new Size(50, 80), new Point(450, 660), "You look so smart. Can you answer this? \nPress 'y' to continue.");
                }
                else if (currentWalkArea.NoArea == 4)
                {
                    currentWalkArea.RemoveAllPeople();

                    currentWalkArea = new WalkAreas("The Farm", Properties.Resources.walkArea3, 4);

                    currentWalkArea.AddPerson(7, "Marie", Properties.Resources.person6, new Size(50, 80), new Point(120, 660), "Answer my question carefully.. \nPress 'y' to continue.");
                    currentWalkArea.AddPerson(8, "Luke", Properties.Resources.person7, new Size(50, 80), new Point(470, 660), "I have a question for you. \nPress 'y' to continue.");
                }
                else if (currentWalkArea.NoArea == 5)
                {
                    currentWalkArea.RemoveAllPeople();

                    currentWalkArea = new WalkAreas("The Boss", Properties.Resources.dark_fantasy_background, 5);

                    currentWalkArea.AddPerson(9, "THE BOSS", Properties.Resources.Boss, new Size(1000, 1000), new Point(277, 41), "WHO DO YOU DARE TO COME HERE \nPress 'y' to continue.");
                }

                currentWalkArea.DisplayPicture(this);
                currentWalkArea.DisplayPeople(this);
                labelArea.Text = currentWalkArea.DisplayData();

                if (player != null)
                {
                    player.Picture.Location = new Point(0, player.Picture.Location.Y);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GenerateTalkArea()
        {
            try
            {
                string namaTempat = "";
                Image gambarLatar = null;

                if (activePerson.NoPerson == 1)
                {
                    namaTempat = "Shop";
                    gambarLatar = Resources.talkArea1;
                }
                else if (activePerson.NoPerson == 2)
                {
                    namaTempat = "Anna's House";
                    gambarLatar = Resources.talkArea1;
                }
                else if (activePerson.NoPerson == 3)
                {
                    namaTempat = "Andy's Room";
                    gambarLatar = Resources.talkArea2;
                }
                else if (activePerson.NoPerson == 4)
                {
                    namaTempat = "Bobby's Office";
                    gambarLatar = Resources.talkArea3;
                }
                else if (activePerson.NoPerson == 5)
                {
                    namaTempat = "Rina's Room";
                    gambarLatar = Resources.talkArea4;
                }
                else if (activePerson.NoPerson == 6)
                {
                    namaTempat = "Tommy's Place";
                    gambarLatar = Resources.talkArea5;
                }
                else if (activePerson.NoPerson == 7)
                {
                    namaTempat = "Marie's Place";
                    gambarLatar = Resources.talkArea6;
                }
                else if (activePerson.NoPerson == 8)
                {
                    namaTempat = "Luke's House";
                    gambarLatar = Resources.talkArea7;
                }

                currentTalkArea = new TalkAreas(namaTempat, gambarLatar, activePerson);

                
                if (activePerson.PersonQuestion == null)
                {
                    Random rnd = new Random();
                    int index = rnd.Next(soalTersedia.Count);
                    Questions soalTerpilih = soalTersedia[index];

                    activePerson.PersonQuestion = soalTerpilih;
                    soalTersedia.RemoveAt(index);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void EnterTalkArea()
        {
            GenerateTalkArea();

            player.Picture.Visible = false;

            panelTalkArea.BackgroundImage = currentTalkArea.Background;
            panelTalkArea.Visible = true;
            panelTalkArea.BringToFront();

            if (currentWalkArea.NoArea == 1)
                activePerson.Picture.Size = new Size(376, 211);
            else
                activePerson.Picture.Size = new Size(300, 400);

            activePerson.Picture.Location = new Point((panelTalkArea.Width - activePerson.Picture.Width) / 2, (panelTalkArea.Height - activePerson.Picture.Height) / 2 + 120);
            activePerson.DisplayPicture(panelTalkArea);

            if (activePerson.SolvedStatus == true)
            {
                activePerson.Dialog = "Congratulations! \nYou have answered my question.";
            }
            activePerson.DisplayDialog(panelTalkArea);

            PlaySound("talk area");
        }

        public void ExitTalkArea()
        {
            activePerson.RemoveDialog();

            player.Picture.Visible = true;
            enterTalkArea = false;

            panelTalkArea.Visible = false;

            if (currentWalkArea.NoArea == 1)
            {
                activePerson.Picture.Size = new Size(376, 211);
            }
            else
            {
                activePerson.Picture.Size = new Size(50, 80);
            }
            activePerson.Picture.Location = activePersonLastLocation;
            activePerson.DisplayPicture(this);
            activePerson = null;

            PlaySound("walk area");
        }

        private void PlaySound(string type)
        {
            otherSoundPlayer = new WindowsMediaPlayer();

            if (type == "walk area")
            {
                backSoundPlayer.URL = Application.StartupPath + "\\sound\\BacksoundWalkArea.mp3";
                backSoundPlayer.settings.setMode("loop", true);
            }
            else if (type == "talk area")
            {
                backSoundPlayer.URL = Application.StartupPath + "\\sound\\BacksoundTalkArea.mp3";
                backSoundPlayer.settings.setMode("loop", true);
            }
            else if (type == "lose game")
            {
                otherSoundPlayer.URL = Application.StartupPath + "\\sound\\LoseGame.mp3";
            }
            else if (type == "win game")
            {
                otherSoundPlayer.URL = Application.StartupPath + "\\sound\\WinGame.mp3";
            }
            otherSoundPlayer.controls.play();
        }

        public void SaveLeaderboard(string fileName)
        {
            FileStream file = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(file, listLeaderboard);
            file.Close();
        }

        public void LoadLeaderboard(string fileName)
        {
            if (File.Exists(fileName))
            {
                FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryFormatter formatter = new BinaryFormatter();
                listLeaderboard = (List<Record>)formatter.Deserialize(file);
                file.Close();
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            FormLogin form = new FormLogin();
            form.Owner = this;
            form.StartPosition = FormStartPosition.CenterParent;
            DialogResult result = form.ShowDialog();

            if (result != DialogResult.Abort)
            {
                StartGame();
            }
        }

        private void buttonLeaderboard_Click(object sender, EventArgs e)
        {
            LoadLeaderboard(fileDefLeaderboard);

            FormLeaderboard form = new FormLeaderboard();
            form.Owner = this;
            form.ShowDialog();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timerPlayTime_Tick(object sender, EventArgs e)
        {
            playTime.AddWithSecond(1);

            labelPlayer.Text = player.DisplayData();
        }

        private void buttonInformation_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Press arrow key to move player. \n\nPress Enter to talk with the person. " + "\n\nPress Y key to answer the question. \n\nPress Esc to exit the talk area.", "How to Play");
        }
    }
}
