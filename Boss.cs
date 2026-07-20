using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinderQuest
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    namespace FinderQuest
    {
        public class Boss
        {
            private PictureBox picture;
            public int HP { get; set; } = 100;
            public int MaxHP { get; set; } = 100;
            public bool IsDead => HP <= 0;

            public Boss(Image image, Size size, Point location)
            {
                this.Picture = new PictureBox();
                this.Picture.Image = image;
                this.Picture.Size = size;
                this.Picture.Location = location;
            }

            public PictureBox Picture { get => picture; set => picture = value; }

            public void DisplayPicture(Control container)
            {
                this.Picture.Parent = container;
                this.Picture.SizeMode = PictureBoxSizeMode.StretchImage;
                this.Picture.BackColor = Color.Transparent;
                this.Picture.BringToFront();
            }

            // Damage yang diterima boss = skor jawaban user (1-10)
            public void TakeDamage(int damage)
            {
                if (IsDead) return;

                HP -= damage;
                if (HP < 0) HP = 0;
            }
        }
    }
}