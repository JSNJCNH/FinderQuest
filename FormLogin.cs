using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeApplication;

namespace FinderQuest
{
    public partial class FormLogin : Form
    {
        Finder_Quest_Game formGame;
        Players selectedPlayer;

        int collapsedHeight = 115;
        int expandedHeight = 160;

        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            formGame = (Finder_Quest_Game) this.Owner;

            this.Height = collapsedHeight;

            foreach(Players players in formGame.listPlayers)
            {
                comboBoxPlayers.Items.Add(players);
            }

            comboBoxPlayers.DisplayMember = "Name";
            comboBoxPlayers.Items.Add("Add new player");

            comboBoxPlayers.SelectedIndex = -1;
        }

        private void comboBoxPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPlayers.SelectedItem.ToString() == "Add new player")
            {
                selectedPlayer = null;

                labelInsertName.Visible = true;
                textBoxInsertName.Visible = true;

                this.Height = expandedHeight;
            }
            else
            {
                labelInsertName.Visible = false;
                textBoxInsertName.Visible = false;

                this.Height = collapsedHeight;

                selectedPlayer = (Players) comboBoxPlayers.SelectedItem;
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            formGame.playTime = new Time(0, 0, 0);
            formGame.maxTime = new Time(0, 10, 0);

            if (comboBoxPlayers.SelectedItem.ToString() == "Add new player")
            {
                formGame.listPlayers.Add(new Players(textBoxInsertName.Text, Properties.Resources.player_right, new Size(50, 80), new Point(10, 660), formGame.playTime, formGame.maxTime));
                formGame.player = new Players(textBoxInsertName.Text, Properties.Resources.player_right, new Size(50, 80), new Point(10, 660), formGame.playTime, formGame.maxTime);
            }
            else 
            {
                formGame.player = new Players(selectedPlayer.Name, Properties.Resources.player_right, new Size(50, 80), new Point(10, 660), formGame.playTime, formGame.maxTime);
            }
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
            this.Close();
        }
    }
}
