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
        private Time playTime;
            

        #region constructor
        public Players(string name, Image image, Size size, Point location, Time playTime)
        {
            this.Name = name;
            this.Picture = new PictureBox();
            this.Picture.Image = image;
            this.Picture.Size = size;
            this.Picture.Location = location;
            this.Score = 0;
            this.PlayTime = playTime;
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

        public Time PlayTime { get => playTime; set => playTime = value; }
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