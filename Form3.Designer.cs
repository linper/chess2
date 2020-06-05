namespace chess
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.label = new System.Windows.Forms.Label();
            this.WinnerTextBox = new System.Windows.Forms.TextBox();
            this.pl1Label = new System.Windows.Forms.Label();
            this.LostFig1Label = new System.Windows.Forms.Label();
            this.Time1Label = new System.Windows.Forms.Label();
            this.Moves1Label = new System.Windows.Forms.Label();
            this.Time1 = new System.Windows.Forms.TextBox();
            this.Moves1 = new System.Windows.Forms.TextBox();
            this.Lost1 = new System.Windows.Forms.TextBox();
            this.Lost2 = new System.Windows.Forms.TextBox();
            this.Moves2 = new System.Windows.Forms.TextBox();
            this.Time2 = new System.Windows.Forms.TextBox();
            this.Moves2Label = new System.Windows.Forms.Label();
            this.Time2Label = new System.Windows.Forms.Label();
            this.LostFig2Label = new System.Windows.Forms.Label();
            this.pl2Label = new System.Windows.Forms.Label();
            this.RetryButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(27, 35);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(70, 20);
            this.label.TabIndex = 0;
            this.label.Text = "Winner:";
            // 
            // WinnerTextBox
            // 
            this.WinnerTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WinnerTextBox.Location = new System.Drawing.Point(103, 32);
            this.WinnerTextBox.Name = "WinnerTextBox";
            this.WinnerTextBox.Size = new System.Drawing.Size(315, 26);
            this.WinnerTextBox.TabIndex = 1;
            // 
            // pl1Label
            // 
            this.pl1Label.AutoSize = true;
            this.pl1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pl1Label.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.pl1Label.Location = new System.Drawing.Point(30, 81);
            this.pl1Label.Name = "pl1Label";
            this.pl1Label.Size = new System.Drawing.Size(13, 13);
            this.pl1Label.TabIndex = 2;
            this.pl1Label.Text = "x";
            // 
            // LostFig1Label
            // 
            this.LostFig1Label.AutoSize = true;
            this.LostFig1Label.Location = new System.Drawing.Point(30, 137);
            this.LostFig1Label.Name = "LostFig1Label";
            this.LostFig1Label.Size = new System.Drawing.Size(67, 13);
            this.LostFig1Label.TabIndex = 3;
            this.LostFig1Label.Text = "Lost Figures:";
            // 
            // Time1Label
            // 
            this.Time1Label.AutoSize = true;
            this.Time1Label.Location = new System.Drawing.Point(30, 108);
            this.Time1Label.Name = "Time1Label";
            this.Time1Label.Size = new System.Drawing.Size(67, 13);
            this.Time1Label.TabIndex = 4;
            this.Time1Label.Text = "Time Taken:";
            // 
            // Moves1Label
            // 
            this.Moves1Label.AutoSize = true;
            this.Moves1Label.Location = new System.Drawing.Point(30, 166);
            this.Moves1Label.Name = "Moves1Label";
            this.Moves1Label.Size = new System.Drawing.Size(72, 13);
            this.Moves1Label.TabIndex = 5;
            this.Moves1Label.Text = "Moves Made:";
            // 
            // Time1
            // 
            this.Time1.Location = new System.Drawing.Point(103, 105);
            this.Time1.Name = "Time1";
            this.Time1.Size = new System.Drawing.Size(98, 20);
            this.Time1.TabIndex = 6;
            // 
            // Moves1
            // 
            this.Moves1.Location = new System.Drawing.Point(103, 163);
            this.Moves1.Name = "Moves1";
            this.Moves1.Size = new System.Drawing.Size(98, 20);
            this.Moves1.TabIndex = 7;
            // 
            // Lost1
            // 
            this.Lost1.Location = new System.Drawing.Point(103, 134);
            this.Lost1.Name = "Lost1";
            this.Lost1.Size = new System.Drawing.Size(98, 20);
            this.Lost1.TabIndex = 8;
            // 
            // Lost2
            // 
            this.Lost2.Location = new System.Drawing.Point(320, 134);
            this.Lost2.Name = "Lost2";
            this.Lost2.Size = new System.Drawing.Size(98, 20);
            this.Lost2.TabIndex = 15;
            // 
            // Moves2
            // 
            this.Moves2.Location = new System.Drawing.Point(320, 163);
            this.Moves2.Name = "Moves2";
            this.Moves2.Size = new System.Drawing.Size(98, 20);
            this.Moves2.TabIndex = 14;
            // 
            // Time2
            // 
            this.Time2.Location = new System.Drawing.Point(320, 105);
            this.Time2.Name = "Time2";
            this.Time2.Size = new System.Drawing.Size(98, 20);
            this.Time2.TabIndex = 13;
            // 
            // Moves2Label
            // 
            this.Moves2Label.AutoSize = true;
            this.Moves2Label.Location = new System.Drawing.Point(242, 166);
            this.Moves2Label.Name = "Moves2Label";
            this.Moves2Label.Size = new System.Drawing.Size(72, 13);
            this.Moves2Label.TabIndex = 12;
            this.Moves2Label.Text = "Moves Made:";
            // 
            // Time2Label
            // 
            this.Time2Label.AutoSize = true;
            this.Time2Label.Location = new System.Drawing.Point(247, 108);
            this.Time2Label.Name = "Time2Label";
            this.Time2Label.Size = new System.Drawing.Size(67, 13);
            this.Time2Label.TabIndex = 11;
            this.Time2Label.Text = "Time Taken:";
            // 
            // LostFig2Label
            // 
            this.LostFig2Label.AutoSize = true;
            this.LostFig2Label.Location = new System.Drawing.Point(246, 137);
            this.LostFig2Label.Name = "LostFig2Label";
            this.LostFig2Label.Size = new System.Drawing.Size(67, 13);
            this.LostFig2Label.TabIndex = 10;
            this.LostFig2Label.Text = "Lost Figures:";
            // 
            // pl2Label
            // 
            this.pl2Label.AutoSize = true;
            this.pl2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pl2Label.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.pl2Label.Location = new System.Drawing.Point(405, 81);
            this.pl2Label.Name = "pl2Label";
            this.pl2Label.Size = new System.Drawing.Size(13, 13);
            this.pl2Label.TabIndex = 9;
            this.pl2Label.Text = "x";
            // 
            // RetryButton
            // 
            this.RetryButton.Location = new System.Drawing.Point(126, 215);
            this.RetryButton.Name = "RetryButton";
            this.RetryButton.Size = new System.Drawing.Size(75, 23);
            this.RetryButton.TabIndex = 16;
            this.RetryButton.Text = "Retry";
            this.RetryButton.UseVisualStyleBackColor = true;
            this.RetryButton.Click += new System.EventHandler(this.RetryButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(238, 215);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 17;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 271);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.RetryButton);
            this.Controls.Add(this.Lost2);
            this.Controls.Add(this.Moves2);
            this.Controls.Add(this.Time2);
            this.Controls.Add(this.Moves2Label);
            this.Controls.Add(this.Time2Label);
            this.Controls.Add(this.LostFig2Label);
            this.Controls.Add(this.pl2Label);
            this.Controls.Add(this.Lost1);
            this.Controls.Add(this.Moves1);
            this.Controls.Add(this.Time1);
            this.Controls.Add(this.Moves1Label);
            this.Controls.Add(this.Time1Label);
            this.Controls.Add(this.LostFig1Label);
            this.Controls.Add(this.pl1Label);
            this.Controls.Add(this.WinnerTextBox);
            this.Controls.Add(this.label);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(479, 310);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(479, 310);
            this.Name = "Form3";
            this.Text = "Results";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form3_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox WinnerTextBox;
        private System.Windows.Forms.Label pl1Label;
        private System.Windows.Forms.Label LostFig1Label;
        private System.Windows.Forms.Label Time1Label;
        private System.Windows.Forms.Label Moves1Label;
        private System.Windows.Forms.TextBox Time1;
        private System.Windows.Forms.TextBox Moves1;
        private System.Windows.Forms.TextBox Lost1;
        private System.Windows.Forms.TextBox Lost2;
        private System.Windows.Forms.TextBox Moves2;
        private System.Windows.Forms.TextBox Time2;
        private System.Windows.Forms.Label Moves2Label;
        private System.Windows.Forms.Label Time2Label;
        private System.Windows.Forms.Label LostFig2Label;
        private System.Windows.Forms.Label pl2Label;
        private System.Windows.Forms.Button RetryButton;
        private System.Windows.Forms.Button ExitButton;
    }
}