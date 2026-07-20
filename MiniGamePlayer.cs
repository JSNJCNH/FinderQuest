using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinderQuest
{
    [Serializable]
    public class MiniGamePlayer
    {
        private PictureBox picture;
        bool goRight = false;
        bool goLeft = false;
        bool goUp = false;
        bool goDown = false;

        public MiniGamePlayer(Image image, Size size, Point playerLocation)
        {
            this.Picture = new PictureBox();
            this.Picture.Image = image;
            this.Picture.Size = size;
            this.Picture.Location = playerLocation;
        }

        //Player Health
        private bool isInvincible = false;
        private int invincibilityTimer = 0;
        private const int invincibilityDuration = 60;

        public bool IsInvincible { get => isInvincible; }
        int hp = 100;
        public bool IsDead => hp <= 0;


        public PictureBox Picture
        {
            get => picture;
            set => picture = value;
        }
        public bool GoRight { get => goRight; set => goRight = value; }
        public bool GoLeft { get => goLeft; set => goLeft = value; }
        public bool GoUp { get => goUp; set => goUp = value; }
        public bool GoDown { get => goDown; set => goDown = value; }

        #region MovementPlayer
        // 1. The Core Helper (The only place where the Point actually changes)
        private void ChangePosition(int deltaX, int deltaY)
        {
            this.Picture.Location = new Point(this.Picture.Location.X + deltaX, this.Picture.Location.Y + deltaY);
        }

        // 2. Straight Movements
        public void MoveRight(int distance) => ChangePosition(distance, 0);
        public void MoveLeft(int distance) => ChangePosition(-distance, 0);
        public void MoveUp(int distance) => ChangePosition(0, -distance);
        public void MoveDown(int distance) => ChangePosition(0, distance);

        // 3. Diagonal Movements (Using the 0.7071 normalization rule)
        public void MoveRightUpWays(int distance)
        {
            int diag = (int)Math.Round(distance * 0.7071);
            ChangePosition(diag, -diag);
        }

        public void MoveLeftUpWays(int distance)
        {
            int diag = (int)Math.Round(distance * 0.7071);
            ChangePosition(-diag, -diag);
        }

        public void MoveRightDownWays(int distance)
        {
            int diag = (int)Math.Round(distance * 0.7071);
            ChangePosition(diag, diag);
        }

        public void MoveLeftDownWays(int distance)
        {
            int diag = (int)Math.Round(distance * 0.7071);
            ChangePosition(-diag, diag);
        }
        #endregion

        //Method damage
        public void TakeDamage(int damage)
        {
            if (isInvincible || IsDead) return;

            hp -= damage;
            if (hp < 0) hp = 0;

            isInvincible = true;
            invincibilityTimer = invincibilityDuration;
        }

        //Invis ketika kena Demage
        public void UpdateInvincibility()
        {
            if (isInvincible == false) return;

            invincibilityTimer--;
            // efek kedap-kedip biar keliatan abis kena damage
            this.Picture.Visible = (invincibilityTimer / 5) % 2 == 0;

            if (invincibilityTimer <= 0)
            {
                isInvincible = false;
                this.Picture.Visible = true;
            }
        }

        public Rectangle GetBounds() => this.Picture.Bounds;

        public void DisplayPicture(Control container)
        {
            this.Picture.Parent = container;
            this.Picture.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Picture.BackColor = Color.Ivory;
            this.Picture.BringToFront();
        }
    }
}