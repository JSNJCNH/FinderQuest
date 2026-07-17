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

        public Finder_Quest_Game()
        {
            InitializeComponent();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
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
                if (e.KeyCode == Keys.Right)
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
                else if (e.KeyCode == Keys.Left)
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
                    ExitTalkArea();
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
                if (activePerson.NoPerson == 1)
                {
                    currentTalkArea = new TalkAreas("Anna's House", Resources.talkArea1, activePerson);
                    activePerson.AddQuestion("Solve this math equation: \n x + y = 10 \n If x = 3, then y = ?", "7", 100);
                }
                else if (activePerson.NoPerson == 2)
                {
                    currentTalkArea = new TalkAreas("Andy's Room", Resources.talkArea2, activePerson);
                    activePerson.AddQuestion("What is the capital city of Indonesia ? ", "Jakarta", 50);
                }
                else if (activePerson.NoPerson == 3)
                {
                    currentTalkArea = new TalkAreas("Bobby's Office", Resources.talkArea3, activePerson);
                    activePerson.AddQuestion("I have this pattern: \n 1   1   2   3   5   8 ... \nWhat is the next number?", "13", 200);
                }
                else if (activePerson.NoPerson == 4)
                {
                    currentTalkArea = new TalkAreas("Rina's Room", Resources.talkArea4, activePerson);
                    activePerson.AddQuestion("What is the chemical compound name for sulfuric acid?", "H2SO4", 250);
                }
                else if (activePerson.NoPerson == 5)
                {
                    currentTalkArea = new TalkAreas("Tommy's Place", Resources.talkArea5, activePerson);
                    activePerson.AddQuestion("Check this C# codes: \n int result = 10/100; \nMessageBox.Show(result); \nWhat is the output of these codes?", "0", 170);
                }
                else if (activePerson.NoPerson == 6)
                {
                    currentTalkArea = new TalkAreas("Marie's Place", Resources.talkArea6, activePerson);
                    activePerson.AddQuestion("A product has a selling price of $100 and is discounted 10% off the list price. It also has a shipping fee of $5. \nIf you want to purchase this product, how much will you have to pay?", "95", 300);
                }
                else if (activePerson.NoPerson == 7)
                {
                    currentTalkArea = new TalkAreas("Luke's House", Resources.talkArea7, activePerson);
                    activePerson.AddQuestion("What is the 1st principle(sila ke - 1) of Pancasila ? ", "Ketuhanan Yang Maha Esa", 150);
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
