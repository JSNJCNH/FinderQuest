namespace FinderQuest
{
    partial class FormPause
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonContinue = new System.Windows.Forms.PictureBox();
            this.buttonInfo = new System.Windows.Forms.PictureBox();
            this.buttonBackToMenu = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonContinue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonBackToMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::FinderQuest.Properties.Resources.Menu_Button;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(375, 260);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(433, 357);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // buttonContinue
            // 
            this.buttonContinue.BackgroundImage = global::FinderQuest.Properties.Resources.Continue_Button;
            this.buttonContinue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonContinue.Location = new System.Drawing.Point(375, 260);
            this.buttonContinue.Name = "buttonContinue";
            this.buttonContinue.Size = new System.Drawing.Size(433, 92);
            this.buttonContinue.TabIndex = 1;
            this.buttonContinue.TabStop = false;
            this.buttonContinue.Click += new System.EventHandler(this.buttonContinue_Click);
            // 
            // buttonInfo
            // 
            this.buttonInfo.BackgroundImage = global::FinderQuest.Properties.Resources.Info_Setting_Button;
            this.buttonInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonInfo.Location = new System.Drawing.Point(375, 393);
            this.buttonInfo.Name = "buttonInfo";
            this.buttonInfo.Size = new System.Drawing.Size(433, 92);
            this.buttonInfo.TabIndex = 2;
            this.buttonInfo.TabStop = false;
            this.buttonInfo.Click += new System.EventHandler(this.buttonInfo_Click);
            // 
            // buttonBackToMenu
            // 
            this.buttonBackToMenu.BackgroundImage = global::FinderQuest.Properties.Resources.Back_to_Menu_Button;
            this.buttonBackToMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonBackToMenu.Location = new System.Drawing.Point(375, 523);
            this.buttonBackToMenu.Name = "buttonBackToMenu";
            this.buttonBackToMenu.Size = new System.Drawing.Size(433, 94);
            this.buttonBackToMenu.TabIndex = 3;
            this.buttonBackToMenu.TabStop = false;
            this.buttonBackToMenu.Click += new System.EventHandler(this.buttonBackToMenu_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackgroundImage = global::FinderQuest.Properties.Resources.Paused_Title;
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox5.Location = new System.Drawing.Point(339, 110);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(509, 118);
            this.pictureBox5.TabIndex = 4;
            this.pictureBox5.TabStop = false;
            // 
            // FormPause
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1163, 783);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.buttonBackToMenu);
            this.Controls.Add(this.buttonInfo);
            this.Controls.Add(this.buttonContinue);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FormPause";
            this.Opacity = 0.75D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FormPause";
            this.Load += new System.EventHandler(this.FormPause_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormPause_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonContinue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonBackToMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox buttonContinue;
        private System.Windows.Forms.PictureBox buttonInfo;
        private System.Windows.Forms.PictureBox buttonBackToMenu;
        private System.Windows.Forms.PictureBox pictureBox5;
    }
}