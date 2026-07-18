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
    public partial class FormPause : Form
    {
        public FormPause()
        {
            InitializeComponent();
        }

        private void FormPause_Load(object sender, EventArgs e)
        {

        }

        private void FormPause_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void buttonInformation_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Press arrow key to move player. \n\nPress Enter to talk with the person. " + "\n\nPress Y key to answer the question. \n\nPress Esc to exit the talk area.", "How to Play");
        }
    }
}
