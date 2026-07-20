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
            this.components = new System.ComponentModel.Container();
            this.labelQuestion = new System.Windows.Forms.Label();
            this.labelAnswer = new System.Windows.Forms.Label();
            this.textBoxAnswer = new System.Windows.Forms.TextBox();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.buttonEquipHealth = new System.Windows.Forms.Button();
            this.buttonEquipAnswerKey = new System.Windows.Forms.Button();
            this.buttonEquipPotionTime = new System.Windows.Forms.Button();
            this.labelNumberPotionHealth = new System.Windows.Forms.Label();
            this.labelNumberAnswerKey = new System.Windows.Forms.Label();
            this.labelNumberPotionTime = new System.Windows.Forms.Label();
            this.labelBossHP = new System.Windows.Forms.Label();
            this.timerBossFight = new System.Windows.Forms.Timer(this.components);
            this.labelBossTimer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelQuestion
            // 
            this.labelQuestion.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.labelQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelQuestion.Location = new System.Drawing.Point(16, 11);
            this.labelQuestion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelQuestion.Name = "labelQuestion";
            this.labelQuestion.Size = new System.Drawing.Size(909, 252);
            this.labelQuestion.TabIndex = 0;
            this.labelQuestion.Text = "Question";
            this.labelQuestion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelAnswer
            // 
            this.labelAnswer.AutoSize = true;
            this.labelAnswer.BackColor = System.Drawing.Color.Transparent;
            this.labelAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAnswer.Location = new System.Drawing.Point(261, 279);
            this.labelAnswer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAnswer.Name = "labelAnswer";
            this.labelAnswer.Size = new System.Drawing.Size(128, 31);
            this.labelAnswer.TabIndex = 1;
            this.labelAnswer.Text = "Answer :";
            // 
            // textBoxAnswer
            // 
            this.textBoxAnswer.Location = new System.Drawing.Point(407, 286);
            this.textBoxAnswer.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxAnswer.Name = "textBoxAnswer";
            this.textBoxAnswer.Size = new System.Drawing.Size(287, 22);
            this.textBoxAnswer.TabIndex = 2;
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.BackColor = System.Drawing.Color.ForestGreen;
            this.buttonSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSubmit.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.buttonSubmit.Location = new System.Drawing.Point(407, 332);
            this.buttonSubmit.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(133, 46);
            this.buttonSubmit.TabIndex = 3;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = false;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // buttonEquipHealth
            // 
            this.buttonEquipHealth.BackgroundImage = global::FinderQuest.Properties.Resources.Potion_Health;
            this.buttonEquipHealth.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonEquipHealth.Location = new System.Drawing.Point(91, 414);
            this.buttonEquipHealth.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonEquipHealth.Name = "buttonEquipHealth";
            this.buttonEquipHealth.Size = new System.Drawing.Size(66, 49);
            this.buttonEquipHealth.TabIndex = 4;
            this.buttonEquipHealth.UseVisualStyleBackColor = true;
            this.buttonEquipHealth.Click += new System.EventHandler(this.buttonEquipHealth_Click);
            // 
            // buttonEquipAnswerKey
            // 
            this.buttonEquipAnswerKey.BackgroundImage = global::FinderQuest.Properties.Resources.Paper_Aswer;
            this.buttonEquipAnswerKey.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonEquipAnswerKey.Location = new System.Drawing.Point(370, 414);
            this.buttonEquipAnswerKey.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonEquipAnswerKey.Name = "buttonEquipAnswerKey";
            this.buttonEquipAnswerKey.Size = new System.Drawing.Size(66, 49);
            this.buttonEquipAnswerKey.TabIndex = 5;
            this.buttonEquipAnswerKey.UseVisualStyleBackColor = true;
            this.buttonEquipAnswerKey.Click += new System.EventHandler(this.buttonEquipAnswerKey_Click);
            // 
            // buttonEquipPotionTime
            // 
            this.buttonEquipPotionTime.BackgroundImage = global::FinderQuest.Properties.Resources.Potion_Time;
            this.buttonEquipPotionTime.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonEquipPotionTime.Location = new System.Drawing.Point(670, 414);
            this.buttonEquipPotionTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonEquipPotionTime.Name = "buttonEquipPotionTime";
            this.buttonEquipPotionTime.Size = new System.Drawing.Size(66, 49);
            this.buttonEquipPotionTime.TabIndex = 6;
            this.buttonEquipPotionTime.UseVisualStyleBackColor = true;
            this.buttonEquipPotionTime.Click += new System.EventHandler(this.buttonEquipPotionTime_Click);
            // 
            // labelNumberPotionHealth
            // 
            this.labelNumberPotionHealth.AutoSize = true;
            this.labelNumberPotionHealth.Location = new System.Drawing.Point(162, 430);
            this.labelNumberPotionHealth.Name = "labelNumberPotionHealth";
            this.labelNumberPotionHealth.Size = new System.Drawing.Size(44, 16);
            this.labelNumberPotionHealth.TabIndex = 7;
            this.labelNumberPotionHealth.Text = "label1";
            // 
            // labelNumberAnswerKey
            // 
            this.labelNumberAnswerKey.AutoSize = true;
            this.labelNumberAnswerKey.Location = new System.Drawing.Point(441, 430);
            this.labelNumberAnswerKey.Name = "labelNumberAnswerKey";
            this.labelNumberAnswerKey.Size = new System.Drawing.Size(44, 16);
            this.labelNumberAnswerKey.TabIndex = 8;
            this.labelNumberAnswerKey.Text = "label2";
            this.labelNumberAnswerKey.Click += new System.EventHandler(this.label2_Click);
            // 
            // labelNumberPotionTime
            // 
            this.labelNumberPotionTime.AutoSize = true;
            this.labelNumberPotionTime.Location = new System.Drawing.Point(741, 430);
            this.labelNumberPotionTime.Name = "labelNumberPotionTime";
            this.labelNumberPotionTime.Size = new System.Drawing.Size(44, 16);
            this.labelNumberPotionTime.TabIndex = 9;
            this.labelNumberPotionTime.Text = "label3";
            this.labelNumberPotionTime.Click += new System.EventHandler(this.label3_Click);
            // 
            // labelBossHP
            // 
            this.labelBossHP.AutoSize = true;
            this.labelBossHP.BackColor = System.Drawing.Color.Crimson;
            this.labelBossHP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBossHP.Location = new System.Drawing.Point(19, 9);
            this.labelBossHP.Name = "labelBossHP";
            this.labelBossHP.Size = new System.Drawing.Size(124, 25);
            this.labelBossHP.TabIndex = 10;
            this.labelBossHP.Text = "labelBossHP";
            this.labelBossHP.Visible = false;
            // 
            // timerBossFight
            // 
            this.timerBossFight.Tick += new System.EventHandler(this.timerBossFight_Tick);
            // 
            // labelBossTimer
            // 
            this.labelBossTimer.AutoSize = true;
            this.labelBossTimer.BackColor = System.Drawing.Color.Transparent;
            this.labelBossTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBossTimer.ForeColor = System.Drawing.Color.Red;
            this.labelBossTimer.Location = new System.Drawing.Point(726, 21);
            this.labelBossTimer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBossTimer.Name = "labelBossTimer";
            this.labelBossTimer.Size = new System.Drawing.Size(182, 46);
            this.labelBossTimer.TabIndex = 11;
            this.labelBossTimer.Text = "00:00:00";
            this.labelBossTimer.Visible = false;
            // 
            // FormQuestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FinderQuest.Properties.Resources.backgroundQuestion;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(941, 484);
            this.Controls.Add(this.labelBossTimer);
            this.Controls.Add(this.labelBossHP);
            this.Controls.Add(this.labelNumberPotionTime);
            this.Controls.Add(this.labelNumberAnswerKey);
            this.Controls.Add(this.labelNumberPotionHealth);
            this.Controls.Add(this.buttonEquipPotionTime);
            this.Controls.Add(this.buttonEquipAnswerKey);
            this.Controls.Add(this.buttonEquipHealth);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.textBoxAnswer);
            this.Controls.Add(this.labelAnswer);
            this.Controls.Add(this.labelQuestion);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.Button buttonEquipHealth;
        private System.Windows.Forms.Button buttonEquipAnswerKey;
        private System.Windows.Forms.Button buttonEquipPotionTime;
        private System.Windows.Forms.Label labelNumberPotionHealth;
        private System.Windows.Forms.Label labelNumberAnswerKey;
        private System.Windows.Forms.Label labelNumberPotionTime;
        private System.Windows.Forms.Label labelBossHP;
        private System.Windows.Forms.Timer timerBossFight;
        private System.Windows.Forms.Label labelBossTimer;
    }
}