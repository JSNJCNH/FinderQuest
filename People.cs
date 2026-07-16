using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace FinderQuest
{
    //jeco//
    //mekel//
    public class People
    {
        private int noPerson;
        private string name;
        private PictureBox picture;
        private string dialog;
        private Questions personQuestion;
        private bool solvedStatus;

        public People(int noPerson, string name, Image image, Size size, Point location, string dialog)
        {
            this.NoPerson = noPerson;
            this.Name = name;
            this.Picture = new PictureBox();
            this.Picture.Image = image;
            this.Picture.Size = size;
            this.Picture.Location = location;
            this.Dialog = dialog;
            this.SolvedStatus = false;
        }

        public int NoPerson
        {
            get => noPerson;
            set
            {
                if (value > 0)
                {
                    noPerson = value;
                }
                else
                    throw new Exception("No person can't be negative.");
            }
        }
        public string Name
        {
            get => name;
            set
            {
                if (value != "")
                    name = value;
                else
                {
                    throw new Exception("Name can't be empty.");
                }
            }

        }
        public PictureBox Picture { get => picture; set => picture = value; }
        public string Dialog { get => dialog; set => dialog = value; }
        public Questions PersonQuestion { get => personQuestion; set => personQuestion = value; }
        public bool SolvedStatus { get => solvedStatus; private set => solvedStatus = value; }

        public string DisplayData()
        {
            string data = "Hi.. I'm " + this.Name + ".\n" + this.Dialog;
            return data;
        }

        public void DisplayDialog(Control container)
        {
            Label labelDialog = new Label();
            labelDialog.Parent = container;
            labelDialog.Size = new Size(500, 90);
            labelDialog.Text = this.DisplayData();
            labelDialog.Font = new Font("Times New Roman", 18);
            labelDialog.TextAlign = ContentAlignment.TopCenter;

            labelDialog.Location = new Point(this.Picture.Location.X - 150, 10);
            labelDialog.BackColor = Color.PaleGoldenrod;
            labelDialog.BorderStyle = BorderStyle.FixedSingle;
            labelDialog.Visible = true;
            labelDialog.BringToFront();
        }

        public void DisplayPicture(Control container)
        {
            this.Picture.Parent = container;
            this.Picture.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Picture.BackColor = Color.Transparent;
            this.Picture.BringToFront();
        }

        public void AddQuestion(string question, string answer, int score)
        {
            this.PersonQuestion = new Questions(question, answer, score);
        }

        public bool CheckAnswer(string playerAnswer, out int score)
        {
            if(playerAnswer.ToLower() == this.PersonQuestion.Answer.ToLower())
            {
                this.SolvedStatus = true;
                score = this.PersonQuestion.Score;
                return true;
            }
            else
            {
                score = 0;
                return false;
            }
        }

    }
}