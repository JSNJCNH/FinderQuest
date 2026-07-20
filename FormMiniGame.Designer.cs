namespace FinderQuest
{
    partial class FormMiniGame
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
            this.labelHP = new System.Windows.Forms.Label();
            this.timerMiniGame = new System.Windows.Forms.Timer(this.components);
            this.panelBulletBoard = new System.Windows.Forms.Panel();
            this.labelTimePunishment = new System.Windows.Forms.Label();
            this.timerPunshment = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // labelHP
            // 
            this.labelHP.AutoSize = true;
            this.labelHP.BackColor = System.Drawing.Color.Crimson;
            this.labelHP.Location = new System.Drawing.Point(202, 233);
            this.labelHP.Name = "labelHP";
            this.labelHP.Size = new System.Drawing.Size(97, 16);
            this.labelHP.TabIndex = 0;
            this.labelHP.Text = "labelHealthBar";
            // 
            // timerMiniGame
            // 
            this.timerMiniGame.Enabled = true;
            this.timerMiniGame.Interval = 1;
            this.timerMiniGame.Tick += new System.EventHandler(this.MainGameTimer);
            // 
            // panelBulletBoard
            // 
            this.panelBulletBoard.BackColor = System.Drawing.Color.Ivory;
            this.panelBulletBoard.Location = new System.Drawing.Point(205, 270);
            this.panelBulletBoard.Name = "panelBulletBoard";
            this.panelBulletBoard.Size = new System.Drawing.Size(275, 164);
            this.panelBulletBoard.TabIndex = 1;
            // 
            // labelTimePunishment
            // 
            this.labelTimePunishment.AutoSize = true;
            this.labelTimePunishment.BackColor = System.Drawing.Color.Transparent;
            this.labelTimePunishment.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimePunishment.ForeColor = System.Drawing.Color.Red;
            this.labelTimePunishment.Location = new System.Drawing.Point(505, 9);
            this.labelTimePunishment.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTimePunishment.Name = "labelTimePunishment";
            this.labelTimePunishment.Size = new System.Drawing.Size(182, 46);
            this.labelTimePunishment.TabIndex = 2;
            this.labelTimePunishment.Text = "00:00:00";
            this.labelTimePunishment.Visible = false;
            // 
            // timerPunshment
            // 
            this.timerPunshment.Tick += new System.EventHandler(this.timerPunshment_Tick);
            // 
            // FormMiniGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.BackgroundImage = global::FinderQuest.Properties.Resources.futuristic_sci_fi_techno_lights_perfect_futuristic_backgrounds;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(700, 446);
            this.Controls.Add(this.labelTimePunishment);
            this.Controls.Add(this.panelBulletBoard);
            this.Controls.Add(this.labelHP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMiniGame";
            this.Text = "FormMiniGame";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.FormMiniGame_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelHP;
        private System.Windows.Forms.Panel panelBulletBoard;
        private System.Windows.Forms.Timer timerMiniGame;
        private System.Windows.Forms.Label labelTimePunishment;
        private System.Windows.Forms.Timer timerPunshment;
    }
}