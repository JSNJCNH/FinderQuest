using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
    }
}
