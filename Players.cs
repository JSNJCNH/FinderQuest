using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TimeApplication;

namespace FinderQuest
{
    public class Players
    {
        private string name;
        private PictureBox picture;
        private int score;
        private int hp;
        private Time playTime;
        private Time maxTime; //ini yg 10 menit


        #region constructor
        public Players(string name, Image image, Size size, Point location, Time playTime, Time maxTime)
        {
            this.Name = name;
            this.Picture = new PictureBox();
            this.Picture.Image = image;
            this.Picture.Size = size;
            this.Picture.Location = location;
            this.Score = 0;
            this.PlayTime = playTime;
            this.MaxTime = maxTime;
            this.HP = 100;
        }
        #endregion

        #region property
        public string Name
        {
            get => name;
            set
            {
                if(value == "")
                {
                    throw new Exception("Name can't be empty.");
                }
                else
                {
                    name = value;
                }
            }
        }
        public PictureBox Picture { get => picture; set => picture = value; }
        public int Score
        {
            get => score;
            set
            {
                if (value < 0)
                {
                    score = 0;
                }
                else
                {
                    score = value;
                }
            }
        }

        public int Hp {get => hp; set => hp = value; }

        public int JumlahBeliWeapon1 { get; set; } = 0;
        public int JumlahBeliWeapon2 { get; set; } = 0;
        public int JumlahBeliWeapon3 { get; set; } = 0;
        public int JumlahBeliHealth { get; set; } = 0;
        public int JumlahBeliTime { get; set; } = 0;
        public int JumlahBeliAnswerKey { get; set; } = 0;
        public int HP { get; set; } = 100;

        public Time PlayTime { get => playTime; set => playTime = value; }
        public Time MaxTime { get => maxTime; set => maxTime = value; }

        #endregion

        #region methods
        public string DisplayData()
        {
            string result = "Name : " + this.Name + "\nScore : " + this.Score + "\nPlaytime : " + this.PlayTime.DisplayData();
            return result;
        }

        public void DisplayPicture(Control container)
        {
            this.Picture.Parent = container;
            this.Picture.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Picture.BackColor = Color.Transparent;
            this.Picture.BringToFront();
        }

        public void MoveRight(int distance)
        {
            this.Picture.Location = new Point(this.Picture.Location.X + distance, this.Picture.Location.Y);
            this.Picture.Image = Properties.Resources.player_right;
        }

        public void MoveLeft(int distance)
        {
            this.Picture.Location = new Point(this.Picture.Location.X - distance, this.Picture.Location.Y);
            this.Picture.Image = Properties.Resources.player_left;
        }

        public void AddScore(int score)
        {
            this.Score += score;
        }
        #endregion
    }
}