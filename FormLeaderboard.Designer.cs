namespace FinderQuest
{
    partial class FormLeaderboard
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
            this.listBoxLeaderboard = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBoxLeaderboard
            // 
            this.listBoxLeaderboard.FormattingEnabled = true;
            this.listBoxLeaderboard.Location = new System.Drawing.Point(12, 12);
            this.listBoxLeaderboard.Name = "listBoxLeaderboard";
            this.listBoxLeaderboard.Size = new System.Drawing.Size(556, 420);
            this.listBoxLeaderboard.TabIndex = 0;
            // 
            // FormLeaderboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 450);
            this.Controls.Add(this.listBoxLeaderboard);
            this.Name = "FormLeaderboard";
            this.Text = "FormLeaderboard";
            this.Load += new System.EventHandler(this.FormLeaderboard_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxLeaderboard;
    }
}