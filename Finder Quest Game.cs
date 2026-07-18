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
        Time time;

        int numOfWalkArea = 3;
        WalkAreas currentWalkArea = null;
        TalkAreas currentTalkArea = null;

        public Players player;

        public People activePerson;
        Point activePersonLastLocation;

        bool enterTalkArea = false;

        WindowsMediaPlayer backSoundPlayer = new WindowsMediaPlayer();
        WindowsMediaPlayer otherSoundPlayer;

        bool isWin, paused = false;

        public List<Record> listLeaderboard = new List<Record>();
        string fileDefLeaderboard = "Leaderboard.dat";

        public List<Questions> DaftarSoal = new List<Questions>();
        private List<Questions> soalTersedia = new List<Questions>();

        public Finder_Quest_Game()
        {
            InitializeComponent();
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Press arrow key to move player. \n\nPress Enter to talk with the person. " +"\n\nPress Y key to answer the question. \n\nPress Esc to exit the talk area.", "How to Play");
        }

        private void Finder_Quest_Game_Load(object sender, EventArgs e)
        {
            panelHome.Visible = true;
            menuStrip1.Visible = false;
            panelGame.Visible = false;
            labelTime.Visible = false;

            playPauseToolStripMenuItem.Enabled = false;
            timerTime.Interval = 1000;

            this.KeyPreview = true;
            this.DoubleBuffered = true;

            panelTalkArea.Visible = false;

            //Supaya Button Start tidak terlalu terhover dan berwarna putih
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
            DaftarSoal.Add(new Questions("What is the chemical compound name for sulfuric acid?", "H2SO4", 150));
            DaftarSoal.Add(new Questions("I have this pattern: \n 1  1  2  3  5  8 ... \nWhat is the next number?", "13", 150));

            DaftarSoal.Add(new Questions("Check this C# codes: \n int result = 10/100; \nMessageBox.Show(result); \nWhat is the output?", "0", 200));
            DaftarSoal.Add(new Questions("A product costs $100, discounted 10%, plus $5 shipping. \nHow much do you pay?", "95", 200));
            DaftarSoal.Add(new Questions("What is the 1st principle (sila ke-1) of Pancasila?", "Ketuhanan Yang Maha Esa", 200));
            DaftarSoal.Add(new Questions("Berapa nilai dari integral dari 2x dx?", "x^2 + C", 200));
            DaftarSoal.Add(new Questions("Berapa hasil dari 2 pangkat 10?", "1024", 200));
            DaftarSoal.Add(new Questions("Berapa turunan kedua dari fungsi x^3?", "6x", 200));
            DaftarSoal.Add(new Questions("Berapa nilai dari 5 faktorial (5!)?", "120", 200));

            soalTersedia = new List<Questions>(DaftarSoal);
        }

        private void TimerTime_Tick(object sender, EventArgs e)
        {
            time.AddWithSecond(-1);

            labelTime.Text = time.DisplayData();
            labelPlayer.Text = player.DisplayData();

            if(time.Hour == 0 && time.Minute == 0 && time.Second == 0)
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
            panelGame.Visible = true;
            panelGame.Focus();
            labelTime.Visible = true;
            menuStrip1.Visible = true;
            playPauseToolStripMenuItem.Enabled = true;
            panelHome.Visible = false;

            playPauseToolStripMenuItem.Text = "Pause Game";

            time = new Time(0, 10, 0);
            timerTime.Start();

            if (currentWalkArea != null)
                currentWalkArea.RemoveAllPeople();

            currentWalkArea = null;
            GenerateWalkArea();

            player = new Players("John", Properties.Resources.player_right, new Size(50, 80), new Point(10, 660), time);

            labelPlayer.Text = player.DisplayData();
            player.DisplayPicture(this);

            PlaySound("walk area");

            paused = false;

            playPauseToolStripMenuItem.Text = "Pause Game";
        }

        private void GameOver(bool isWin)
        {
            timerTime.Stop();

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
            menuStrip1.Visible = false;
            panelHome.Visible = true;

            playPauseToolStripMenuItem.Text = "Play/Pause";
            playPauseToolStripMenuItem.Enabled = false;

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
                        if (currentWalkArea.CheckFinishAllQuestions())
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
                    else if (paused == false)
                    {
                        paused = true;
                        timerTime.Stop();
                        backSoundPlayer.controls.pause();

                        FormPause form = new FormPause();
                        form.Size = this.ClientSize;
                        form.Location = this.PointToScreen(Point.Empty);
                        form.ShowDialog();

                        paused = false;
                        timerTime.Start();
                        backSoundPlayer.controls.play();
                    }
                }
                else if (e.KeyCode == Keys.Y && activePerson?.SolvedStatus == false)
                {
                    FormQuestion form = new FormQuestion();
                    form.Owner = this;
                    form.ShowDialog();
                }
            }
        }

        private void StartNewGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void GenerateWalkArea()
        {
            try
            {
                if (currentWalkArea == null)
                {
                    currentWalkArea = new WalkAreas("The Barn", Properties.Resources.walkArea1, 1);

                    currentWalkArea.AddPerson(1, "Anna", Properties.Resources.person1, new Size(50, 80), new Point(150, 660), "I have a question for you. Are you ready? \nPress 'y' to continue.");
                    currentWalkArea.AddPerson(2, "Andy", Properties.Resources.person2, new Size(50, 80), new Point(420, 660), "Can you answer my question? Let's Go! \nPress 'y' to continue.");
                    currentWalkArea.AddPerson(3, "Bobby", Properties.Resources.person3, new Size(50, 80), new Point(600, 670), "Just answer my question please... \nPress 'y' to continue.");
                }
                else if (currentWalkArea.NoArea == 2)
                {
                    currentWalkArea.RemoveAllPeople();

                    currentWalkArea = new WalkAreas("The Field", Properties.Resources.walkArea2, 2);

                    currentWalkArea.AddPerson(4, "Rina", Properties.Resources.person4, new Size(50, 80), new Point(100, 610), "I'm sure you can answer my question. \nPress 'y' to continue.");
                    currentWalkArea.AddPerson(5, "Tommy", Properties.Resources.person5, new Size(50, 80), new Point(450, 660), "You look so smart. Can you answer this? \nPress 'y' to continue.");
                }
                else if (currentWalkArea.NoArea == 3)
                {
                    currentWalkArea.RemoveAllPeople();

                    currentWalkArea = new WalkAreas("The Farm", Properties.Resources.walkArea3, 3);

                    currentWalkArea.AddPerson(6, "Marie", Properties.Resources.person6, new Size(50, 80), new Point(120, 660), "Answer my question carefully.. \nPress 'y' to continue.");
                    currentWalkArea.AddPerson(7, "Luke", Properties.Resources.person7, new Size(50, 80), new Point(470, 660), "I have a question for you. \nPress 'y' to continue.");
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
                    namaTempat = "Anna's House";
                    gambarLatar = Resources.talkArea1;
                }
                else if (activePerson.NoPerson == 2)
                {
                    namaTempat = "Andy's Room";
                    gambarLatar = Resources.talkArea2;
                }
                else if (activePerson.NoPerson == 3)
                {
                    namaTempat = "Bobby's Office";
                    gambarLatar = Resources.talkArea3;
                }
                else if (activePerson.NoPerson == 4)
                {
                    namaTempat = "Rina's Room";
                    gambarLatar = Resources.talkArea4;
                }
                else if (activePerson.NoPerson == 5)
                {
                    namaTempat = "Tommy's Place";
                    gambarLatar = Resources.talkArea5;
                }
                else if (activePerson.NoPerson == 6)
                {
                    namaTempat = "Marie's Place";
                    gambarLatar = Resources.talkArea6;
                }
                else if (activePerson.NoPerson == 7)
                {
                    namaTempat = "Luke's House";
                    gambarLatar = Resources.talkArea7;
                }

                currentTalkArea = new TalkAreas(namaTempat, gambarLatar, activePerson);

                // Kasih soal random cuma kalau NPC ini belum punya soal
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

            activePerson.Picture.Size = new Size(200, 300);
            activePerson.Picture.Location = new Point(300, 100);
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
            player.Picture.Visible = true;
            enterTalkArea = false;

            panelTalkArea.Visible = false;
            activePerson.Picture.Size = new Size(50, 80);
            activePerson.Picture.Location = activePersonLastLocation;
            activePerson.DisplayPicture(this);

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

        private void buttonStart_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void buttonLeaderboard_Click(object sender, EventArgs e)
        {
            FormLeaderboard form = new FormLeaderboard();
            form.Owner = this;
            form.ShowDialog();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonInformation_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Press arrow key to move player. \n\nPress Enter to talk with the person. " + "\n\nPress Y key to answer the question. \n\nPress Esc to exit the talk area.", "How to Play");
        }

        private void playPauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (playPauseToolStripMenuItem.Text == "|| Pause Game")
            {
                paused = true;
                timerTime.Stop();
                playPauseToolStripMenuItem.Text = "> Play Game";
                backSoundPlayer.controls.pause();
            }
            else
            {
                paused = false;
                timerTime.Start();
                playPauseToolStripMenuItem.Text = "|| Pause Game";
                backSoundPlayer.controls.play();
            }
        }
    }
}
