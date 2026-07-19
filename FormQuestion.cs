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

namespace FinderQuest
{
    public partial class FormQuestion : Form
    {
        Finder_Quest_Game frmGame;

        public FormQuestion()
        {
            InitializeComponent();
        }

        private void FormQuestion_Load(object sender, EventArgs e)
        {
            frmGame = (Finder_Quest_Game)this.Owner;
            labelQuestion.Text = frmGame.activePerson.PersonQuestion.Question;

            this.KeyPreview = true;
            UpdateJumlahItem();
        }

        private void UpdateJumlahItem()
        {
            labelNumberPotionHealth.Text = frmGame.player.JumlahBeliHealth.ToString();
            labelNumberAnswerKey.Text = frmGame.player.JumlahBeliAnswerKey.ToString();
            labelNumberPotionTime.Text = frmGame.player.JumlahBeliTime.ToString();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (frmGame.activePerson.CheckAnswer(textBoxAnswer.Text, out int score) == true)
            {
                MessageBox.Show("Your answer is correct! You get " + score.ToString() + " points.");
                frmGame.player.AddScore(score);
            }
            else
            {
                MessageBox.Show("Sorry.. your answer is incorrect!");
            }
            frmGame.ExitTalkArea();
            this.Close();
        }

        private void FormQuestion_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                buttonSubmit_Click((object) sender, e);
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
