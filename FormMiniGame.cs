using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FinderQuest.Projectile;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FinderQuest
{
    public partial class FormMiniGame : Form
    {
        FormQuestion formQuestion;

        PunishmentTime maxTime;
        bool berhasilPunishment;

        // Durasi minigame dalam detik, default 10 detik sesuai fase dodge boss
        private int punishmentDurationSeconds;

        // Dilaporkan ke form pemanggil (FormQuestion) apakah player selamat
        public bool PlayerSurvived { get; private set; } = true;

        public FormMiniGame() : this(10) // default 10 detik kalau dipanggil tanpa parameter
        {
        }

        public FormMiniGame(int durationSeconds)
        {
            InitializeComponent();
            punishmentDurationSeconds = durationSeconds;
        }

        private void FormMiniGame_Load(object sender, EventArgs e)
        {
            formQuestion = (FormQuestion) this.Owner;

            player = new MiniGamePlayer(Properties.Resources.Player_Orb_Asset, new Size(20, 20), new Point(240, 323), formQuestion.frmGame.player.Hp);
            player.DisplayPicture(this);

            labelTimePunishment.Visible = true;

            timerMiniGame.Interval = 16;
            timerMiniGame.Start();

            timerPunshment.Interval = 1000;
            timerPunshment.Start();

            SpawnWallWithGapKanan();
            SpawnWallWithGapKiri();
            UpdateHealthDisplay();

            maxTime = new PunishmentTime(0, 0, punishmentDurationSeconds);
            labelTimePunishment.Text = maxTime.DisplayData();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (berhasilPunishment == false && player != null && player.IsDead == false)
            {
                e.Cancel = true; // batalkan proses close, kecuali player mati (harus tetap bisa ditutup)
            }
            else
            {
                e.Cancel = false;
            }
        }


        public MiniGamePlayer player;
        public Projectile projectile;
        public List<Projectile> projectileList = new List<Projectile>();
        private Random rng = new Random();

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //Kecepatan gerak player

            if (e.KeyCode == Keys.Right)
            {
                player.GoRight = true;
            }

            else if (e.KeyCode == Keys.Left)
            {
                player.GoLeft = true;
            }

            else if (e.KeyCode == Keys.Up)
            {
                player.GoUp = true;
            }

            else if (e.KeyCode == Keys.Down)
            {
                player.GoDown = true;
            }
            player.DisplayPicture(this);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //Kecepatan gerak player

            if (e.KeyCode == Keys.Right)
            {
                player.GoRight = false;
            }

            else if (e.KeyCode == Keys.Left)
            {
                player.GoLeft = false;
            }

            else if (e.KeyCode == Keys.Up)
            {
                player.GoUp = false;
            }

            else if (e.KeyCode == Keys.Down)
            {
                player.GoDown = false;
            }
        }


        private void MainGameTimer(object sender, EventArgs e)
        //Pake Timer supaya smooth & pake apa yang udah di ajarin ga pake perhitungan frame
        {
            int distance = 4;
            int margin = 10;
            // 1. Calculate boundary permissions

            int batasAtas = panelBulletBoard.Location.Y + margin;
            int batasBawah = panelBulletBoard.Height + panelBulletBoard.Location.Y - margin - player.Picture.Height;
            int batasKanan = panelBulletBoard.Width + panelBulletBoard.Location.X - margin - player.Picture.Width;
            int batasKiri = panelBulletBoard.Location.X + margin;

            bool canMoveRight = player.Picture.Location.X <= (batasKanan);
            bool canMoveLeft = player.Picture.Location.X >= (batasKiri);
            bool canMoveUp = player.Picture.Location.Y >= (batasAtas);
            bool canMoveDown = player.Picture.Location.Y <= (batasBawah);

            // 2. Combine input intent with boundary permission
            bool moveRight = player.GoRight && canMoveRight;
            bool moveLeft = player.GoLeft && canMoveLeft;
            bool moveUp = player.GoUp && canMoveUp;
            bool moveDown = player.GoDown && canMoveDown;

            // 3. Execute the movement
            if (moveRight && moveUp) player.MoveRightUpWays(distance);
            else if (moveRight && moveDown) player.MoveRightDownWays(distance);
            else if (moveLeft && moveUp) player.MoveLeftUpWays(distance);
            else if (moveLeft && moveDown) player.MoveLeftDownWays(distance);
            else if (moveRight) player.MoveRight(distance);
            else if (moveLeft) player.MoveLeft(distance);
            else if (moveUp) player.MoveUp(distance);
            else if (moveDown) player.MoveDown(distance);

            #region testing
            //int projectileMovement = 1;
            //projectile.ProjectileMovement(player.Picture.Location.X, player.Picture.Location.Y, projectileMovement, batasAtas, batasBawah, batasKanan, batasKiri, (int)panelBulletBoard.Location.X, (int)panelBulletBoard.Location.Y);
            #endregion

            // === Gerakan & collision semua projectile (kanan & kiri jadi satu loop) ===
            int speedBullet = 2;

            foreach (var p in projectileList.ToList())
            {
                p.Move(speedBullet);

                if (p.IsOutOfBounds(batasKiri, batasKanan))
                {
                    p.Destroy(this);
                    projectileList.Remove(p);
                    continue;
                }

                if (p.GetBounds().IntersectsWith(player.GetBounds()))
                {
                    player.TakeDamage(p.Damage);
                    UpdateHealthDisplay();
                }
            }

            // Kalau semua bullet udah lewat, spawn wall baru (celah beda posisi)
            if (projectileList.Count == 0)
            {
                SpawnWallWithGapKanan();
                SpawnWallWithGapKiri();
            }

            player.UpdateInvincibility(); // handle flicker & cooldown invincibility

            if (player.IsDead)
            {
                PlayerSurvived = false;
                timerPunshment.Stop();
                StopGame();
                MessageBox.Show("Game Over!");
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void UpdateHealthDisplay()
        {
            // Tambahkan Label bernama "labelHP" di Form1 lewat Designer
            labelHP.Text = $"HP: {player.Hp} / 100";
        
        }

        private void SpawnWallWithGapKanan()
        {
            int jumlahSlot = 4;      // total posisi dalam 1 kolom
            int jarakSlot = 30;      // jarak antar bullet (spasi vertikal)
            int margin = 10;

            int gapIndex = rng.Next(0, jumlahSlot); // posisi lubang, random tiap dipanggil

            int startX = panelBulletBoard.Location.X + panelBulletBoard.Width - margin - 20; // spawn dari sisi kanan
            int startY = panelBulletBoard.Location.Y + margin;

            for (int i = 0; i < jumlahSlot; i++)
            {
                if (i == gapIndex) continue; // <-- ini lubangnya, sengaja dilewati (tidak spawn)

                Point spawnPoint = new Point(startX, startY + (i * jarakSlot));
                // Spawn dari kanan -> geraknya ke kiri
                Projectile p = new Projectile(Properties.Resources.Bullet_Projectiles, spawnPoint, ProjectileDirection.Left);
                p.DisplayProjectiles(this);
                projectileList.Add(p);
            }
        }

        private void SpawnWallWithGapKiri()
        {
            int jumlahSlot = 4;
            int jarakSlot = 30;
            int margin = 10;
            int gapIndex = rng.Next(0, jumlahSlot);

            int startX = panelBulletBoard.Location.X + margin; // nempel sisi kiri
            int startY = panelBulletBoard.Location.Y + margin; // mulai dari atas

            for (int i = 0; i < jumlahSlot; i++)
            {
                if (i == gapIndex) continue;

                Point spawnPoint = new Point(startX, startY + (i * jarakSlot));
                // Spawn dari kiri -> geraknya ke kanan
                Projectile p = new Projectile(Properties.Resources.Bullet_Projectiles, spawnPoint, ProjectileDirection.Right);
                p.DisplayProjectiles(this);
                projectileList.Add(p);
            }
        }

        private void StopGame()
        {
            // 1. Stop timer, biar MainGameTimer nggak dipanggil lagi
            timerMiniGame.Stop();

            // 2. Matikan semua input arah, biar player nggak "nyangkut" gerak
            if (player != null)
            {
                player.GoRight = false;
                player.GoLeft = false;
                player.GoUp = false;
                player.GoDown = false;
            }

            // 3. Hapus semua projectile yang masih ada di board
            foreach (var p in projectileList.ToList())
            {
                p.Destroy(this);
            }
            projectileList.Clear();

            // 4. Matikan KeyPreview biar form ini nggak lagi "nyuri" input keyboard
            this.KeyPreview = false;
        }

        private void timerPunshment_Tick(object sender, EventArgs e)
        {
            maxTime.AddWithSecond(-1);
            labelTimePunishment.Text = maxTime.DisplayData();

            if (maxTime.Hour == 0 && maxTime.Minute == 0 && maxTime.Second == 0)
            {
                timerPunshment.Stop();
                berhasilPunishment = true;
                PlayerSurvived = true;

                StopGame();               // <-- diperbaiki: stop dulu semuanya
                this.DialogResult = DialogResult.OK;
                this.Close();              // <-- baru close terakhir

                MessageBox.Show("Your consequences Finish!");
            }
        }
    }
}