namespace FinderQuest
{
    partial class FormQuestion
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
            this.labelQuestion = new System.Windows.Forms.Label();
            this.labelAnswer = new System.Windows.Forms.Label();
            this.textBoxAnswer = new System.Windows.Forms.TextBox();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelQuestion
            // 
            this.labelQuestion.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.labelQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelQuestion.Location = new System.Drawing.Point(12, 9);
            this.labelQuestion.Name = "labelQuestion";
            this.labelQuestion.Size = new System.Drawing.Size(682, 205);
            this.labelQuestion.TabIndex = 0;
            this.labelQuestion.Text = "Question";
            this.labelQuestion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelAnswer
            // 
            this.labelAnswer.AutoSize = true;
            this.labelAnswer.BackColor = System.Drawing.Color.Transparent;
            this.labelAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAnswer.Location = new System.Drawing.Point(196, 227);
            this.labelAnswer.Name = "labelAnswer";
            this.labelAnswer.Size = new System.Drawing.Size(103, 25);
            this.labelAnswer.TabIndex = 1;
            this.labelAnswer.Text = "Answer :";
            // 
            // textBoxAnswer
            // 
            this.textBoxAnswer.Location = new System.Drawing.Point(305, 232);
            this.textBoxAnswer.Name = "textBoxAnswer";
            this.textBoxAnswer.Size = new System.Drawing.Size(216, 20);
            this.textBoxAnswer.TabIndex = 2;
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.BackColor = System.Drawing.Color.ForestGreen;
            this.buttonSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSubmit.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.buttonSubmit.Location = new System.Drawing.Point(305, 270);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(100, 38);
            this.buttonSubmit.TabIndex = 3;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = false;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // FormQuestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FinderQuest.Properties.Resources.backgroundQuestion;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(706, 393);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.textBoxAnswer);
            this.Controls.Add(this.labelAnswer);
            this.Controls.Add(this.labelQuestion);
            this.DoubleBuffered = true;
            this.Name = "FormQuestion";
            this.Text = "FormQuestion";
            this.Load += new System.EventHandler(this.FormQuestion_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormQuestion_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelQuestion;
        private System.Windows.Forms.Label labelAnswer;
        private System.Windows.Forms.TextBox textBoxAnswer;
        private System.Windows.Forms.Button buttonSubmit;
    }
}