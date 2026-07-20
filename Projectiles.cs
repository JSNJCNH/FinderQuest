using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinderQuest
{
        public enum ProjectileDirection { Left, Right }

        public class Projectile
        {
            private PictureBox projectiles;
            public int Damage { get; set; } = 10;
            public ProjectileDirection Direction { get; set; } = ProjectileDirection.Left;

            public Projectile(Image ProjectilesImage, Point projectilesLocation, ProjectileDirection direction = ProjectileDirection.Left)
            {
                this.Projectiles = new PictureBox();
                this.Projectiles.Image = ProjectilesImage;
                this.Projectiles.Size = new Size(20, 20);
                this.Projectiles.Location = projectilesLocation;
                this.Direction = direction;
            }

            public PictureBox Projectiles
            {
                get => projectiles;
                set => projectiles = value;
            }

            public Rectangle GetBounds() => this.Projectiles.Bounds;

            public void DisplayProjectiles(Control container)
            {
                this.Projectiles.Parent = container;
                this.Projectiles.SizeMode = PictureBoxSizeMode.StretchImage;
                this.Projectiles.BackColor = Color.Ivory;
                this.Projectiles.BringToFront();
            }

            // Gerak sesuai arah masing-masing bullet
            public void Move(int speed)
            {
                int deltaX = (Direction == ProjectileDirection.Left) ? -speed : speed;
                this.Projectiles.Location = new Point(this.Projectiles.Location.X + deltaX, this.Projectiles.Location.Y);
            }

            // Cek keluar board sesuai arah masing-masing
            public bool IsOutOfBounds(int batasKiri, int batasKanan)
            {
                if (Direction == ProjectileDirection.Left)
                    return this.Projectiles.Location.X < batasKiri;
                else
                    return this.Projectiles.Location.X > batasKanan;
            }

            public void Destroy(Control container)
            {
                container.Controls.Remove(this.Projectiles);
                this.Projectiles.Dispose();
            }
        }
    }
