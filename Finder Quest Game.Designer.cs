namespace FinderQuest
{
    partial class Finder_Quest_Game
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.playPauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerTime = new System.Windows.Forms.Timer(this.components);
            this.panelGame = new System.Windows.Forms.Panel();
            this.labelPlayer = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelArea = new System.Windows.Forms.Label();
            this.panelTalkArea = new System.Windows.Forms.Panel();
            this.buttonLeaderboard = new System.Windows.Forms.Button();
            this.buttonInformation = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.panelHome = new System.Windows.Forms.Panel();
            this.buttonExit = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panelGame.SuspendLayout();
            this.panelHome.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playPauseToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1529, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // playPauseToolStripMenuItem
            // 
            this.playPauseToolStripMenuItem.Name = "playPauseToolStripMenuItem";
            this.playPauseToolStripMenuItem.Size = new System.Drawing.Size(93, 24);
            this.playPauseToolStripMenuItem.Text = "Play/Pause";
            this.playPauseToolStripMenuItem.Click += new System.EventHandler(this.playPauseToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.HelpToolStripMenuItem_Click);
            // 
            // timerTime
            // 
            this.timerTime.Tick += new System.EventHandler(this.TimerTime_Tick);
            // 
            // panelGame
            // 
            this.panelGame.BackColor = System.Drawing.Color.Transparent;
            this.panelGame.Controls.Add(this.labelPlayer);
            this.panelGame.Controls.Add(this.labelTime);
            this.panelGame.Controls.Add(this.labelArea);
            this.panelGame.Location = new System.Drawing.Point(1, 28);
            this.panelGame.Margin = new System.Windows.Forms.Padding(4);
            this.panelGame.Name = "panelGame";
            this.panelGame.Size = new System.Drawing.Size(1528, 97);
            this.panelGame.TabIndex = 1;
            // 
            // labelPlayer
            // 
            this.labelPlayer.AutoSize = true;
            this.labelPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayer.Location = new System.Drawing.Point(1228, 12);
            this.labelPlayer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPlayer.Name = "labelPlayer";
            this.labelPlayer.Size = new System.Drawing.Size(119, 25);
            this.labelPlayer.TabIndex = 2;
            this.labelPlayer.Text = "labelPlayer";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTime.ForeColor = System.Drawing.Color.Red;
            this.labelTime.Location = new System.Drawing.Point(659, 12);
            this.labelTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(182, 46);
            this.labelTime.TabIndex = 1;
            this.labelTime.Text = "00:00:00";
            // 
            // labelArea
            // 
            this.labelArea.AutoSize = true;
            this.labelArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelArea.Location = new System.Drawing.Point(15, 12);
            this.labelArea.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelArea.Name = "labelArea";
            this.labelArea.Size = new System.Drawing.Size(104, 25);
            this.labelArea.TabIndex = 0;
            this.labelArea.Text = "labelArea";
            // 
            // panelTalkArea
            // 
            this.panelTalkArea.AutoSize = true;
            this.panelTalkArea.BackColor = System.Drawing.Color.Transparent;
            this.panelTalkArea.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelTalkArea.Location = new System.Drawing.Point(-12, 133);
            this.panelTalkArea.Margin = new System.Windows.Forms.Padding(4);
            this.panelTalkArea.Name = "panelTalkArea";
            this.panelTalkArea.Size = new System.Drawing.Size(1541, 785);
            this.panelTalkArea.TabIndex = 2;
            // 
            // buttonLeaderboard
            // 
            this.buttonLeaderboard.BackgroundImage = global::FinderQuest.Properties.Resources.Leaderboard_Button;
            this.buttonLeaderboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonLeaderboard.ForeColor = System.Drawing.Color.Transparent;
            this.buttonLeaderboard.Location = new System.Drawing.Point(34, 14);
            this.buttonLeaderboard.Name = "buttonLeaderboard";
            this.buttonLeaderboard.Size = new System.Drawing.Size(135, 59);
            this.buttonLeaderboard.TabIndex = 1;
            this.buttonLeaderboard.UseVisualStyleBackColor = true;
            this.buttonLeaderboard.Click += new System.EventHandler(this.buttonLeaderboard_Click);
            // 
            // buttonInformation
            // 
            this.buttonInformation.BackgroundImage = global::FinderQuest.Properties.Resources.Info_Button;
            this.buttonInformation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonInformation.Location = new System.Drawing.Point(590, 14);
            this.buttonInformation.Name = "buttonInformation";
            this.buttonInformation.Size = new System.Drawing.Size(135, 59);
            this.buttonInformation.TabIndex = 2;
            this.buttonInformation.UseVisualStyleBackColor = true;
            this.buttonInformation.Click += new System.EventHandler(this.buttonInformation_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.BackgroundImage = global::FinderQuest.Properties.Resources.Start_Button;
            this.buttonStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStart.ForeColor = System.Drawing.Color.IndianRed;
            this.buttonStart.Location = new System.Drawing.Point(209, 3);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(344, 81);
            this.buttonStart.TabIndex = 3;
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // panelHome
            // 
            this.panelHome.BackColor = System.Drawing.Color.Transparent;
            this.panelHome.Controls.Add(this.buttonExit);
            this.panelHome.Controls.Add(this.buttonStart);
            this.panelHome.Controls.Add(this.buttonLeaderboard);
            this.panelHome.Controls.Add(this.buttonInformation);
            this.panelHome.Location = new System.Drawing.Point(392, 517);
            this.panelHome.Name = "panelHome";
            this.panelHome.Size = new System.Drawing.Size(1125, 398);
            this.panelHome.TabIndex = 4;
            // 
            // buttonExit
            // 
            this.buttonExit.BackgroundImage = global::FinderQuest.Properties.Resources.Exit_Button;
            this.buttonExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonExit.Location = new System.Drawing.Point(963, 337);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(150, 40);
            this.buttonExit.TabIndex = 4;
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // Finder_Quest_Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FinderQuest.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1529, 916);
            this.Controls.Add(this.panelHome);
            this.Controls.Add(this.panelTalkArea);
            this.Controls.Add(this.panelGame);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Finder_Quest_Game";
            this.Text = "Finder Quest Game";
            this.Load += new System.EventHandler(this.Finder_Quest_Game_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Finder_Quest_Game_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelGame.ResumeLayout(false);
            this.panelGame.PerformLayout();
            this.panelHome.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem playPauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Timer timerTime;
        private System.Windows.Forms.Panel panelGame;
        private System.Windows.Forms.Label labelArea;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Panel panelTalkArea;
        public System.Windows.Forms.Label labelPlayer;
        private System.Windows.Forms.Button buttonInformation;
        private System.Windows.Forms.Button buttonLeaderboard;
        private System.Windows.Forms.Panel panelHome;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonExit;
    }
}