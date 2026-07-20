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
    public partial class FormLeaderboard : Form
    {
        Finder_Quest_Game formGame;

        public FormLeaderboard()
        {
            InitializeComponent();
        }

        private void FormLeaderboard_Load(object sender, EventArgs e)
        {
            formGame = (Finder_Quest_Game) this.Owner;

            listBoxLeaderboard.Items.Clear();
            listBoxLeaderboard.Items.Add("Name\t\t\tPlay Time");

            foreach(Record record in formGame.listLeaderboard)
            {
                listBoxLeaderboard.Items.Add(record.DisplayData());
            }
        }
    }
}
