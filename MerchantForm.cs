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
    public partial class MerchantForm : Form
    {
        public MerchantForm()
        {
            InitializeComponent();
        }
        Finder_Quest_Game frmGame;

        string namaItemDipilih = "";
        int hargaItemDipilih = 0;

        private void PilihItem(string nama, int harga)
        {
            namaItemDipilih = nama;
            hargaItemDipilih = harga;

            labelBuyMessage.Text = nama + " - Harga: " + harga.ToString();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            PilihItem("Potion Time", 1500);
        }

        private void buttonWeapon3_Click(object sender, EventArgs e)
        {
            PilihItem("Weapon OverPower", 5000);
        }

        private void buttonWeapon2_Click(object sender, EventArgs e)
        {
            PilihItem("Weapon Basic", 3000);
        }

        private void buttonWeapon1_Click(object sender, EventArgs e)
        {
            PilihItem("Weapon Noob", 1500);
        }

        private void buttonPotionHealth_Click(object sender, EventArgs e)
        {
            PilihItem("Potion Health", 1500);
        }

        private void buttonAnswerKey_Click(object sender, EventArgs e)
        {
            PilihItem("Answer Key", 1500);
        }

        private void buttonBuy_Click(object sender, EventArgs e)
        {
            if (namaItemDipilih == "")
            {
                MessageBox.Show("Pilih item terlebih dahulu!");
                return;
            }

            if (frmGame.player.Score >= hargaItemDipilih)
            {
                frmGame.player.Score -= hargaItemDipilih;
                labelScorePlayer.Text = "Score: " + frmGame.player.Score.ToString();

                if (namaItemDipilih == "Weapon OverPower")
                {
                    frmGame.player.JumlahBeliWeapon3++;
                }
                else if (namaItemDipilih == "Weapon Basic")
                {
                    frmGame.player.JumlahBeliWeapon2++;
                }
                else if (namaItemDipilih == "Weapon Noob")
                {
                    frmGame.player.JumlahBeliWeapon1++;
                }
                else if (namaItemDipilih == "Potion Health")
                {
                    frmGame.player.JumlahBeliHealth++;
                }
                else if (namaItemDipilih == "Potion Time")
                {
                    frmGame.player.JumlahBeliTime++;
                }
                else if (namaItemDipilih == "Answer Key")
                {
                    frmGame.player.JumlahBeliAnswerKey++;
                }

                    MessageBox.Show($"Berhasil membeli {namaItemDipilih}!");

                namaItemDipilih = "";
                hargaItemDipilih = 0;
                labelBuyMessage.Text = "";

                UpdateTampilanMerchant(); 
            }
            else
            {
                MessageBox.Show("Score tidak cukup untuk membeli item ini!");
            }
        }

        private void UpdateTampilanMerchant()
        {
            buttonWeapon1.Visible = frmGame.player.JumlahBeliWeapon1 < 1;
            buttonWeapon2.Visible = frmGame.player.JumlahBeliWeapon2 < 1;
            buttonWeapon3.Visible = frmGame.player.JumlahBeliWeapon3 < 1;

            buttonPotionHealth.Visible = frmGame.player.JumlahBeliHealth < 3;

            buttonPotionTime.Visible = frmGame.player.JumlahBeliTime < 1;

            buttonAnswerKey.Visible = true;
        }

        private void MerchantForm_Load(object sender, EventArgs e)
        {
            frmGame = (Finder_Quest_Game)this.Owner;

            labelScorePlayer.Text = "Your Score : " + frmGame.player.Score.ToString();
            UpdateTampilanMerchant();
        }
    }
}
