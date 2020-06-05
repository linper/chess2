namespace chess
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.ApplyButton = new System.Windows.Forms.Button();
            this.Player1Label = new System.Windows.Forms.Label();
            this.Pl1Text = new System.Windows.Forms.TextBox();
            this.Pl2Text = new System.Windows.Forms.TextBox();
            this.Player2Label = new System.Windows.Forms.Label();
            this.timeBox = new System.Windows.Forms.TextBox();
            this.MaxTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ApplyButton
            // 
            this.ApplyButton.Location = new System.Drawing.Point(69, 117);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(75, 23);
            this.ApplyButton.TabIndex = 0;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // Player1Label
            // 
            this.Player1Label.AutoSize = true;
            this.Player1Label.Location = new System.Drawing.Point(12, 20);
            this.Player1Label.Name = "Player1Label";
            this.Player1Label.Size = new System.Drawing.Size(76, 13);
            this.Player1Label.TabIndex = 1;
            this.Player1Label.Text = "Player1 Name:";
            // 
            // Pl1Text
            // 
            this.Pl1Text.Location = new System.Drawing.Point(94, 17);
            this.Pl1Text.Name = "Pl1Text";
            this.Pl1Text.Size = new System.Drawing.Size(103, 20);
            this.Pl1Text.TabIndex = 2;
            this.Pl1Text.Text = "White";
            this.Pl1Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Pl2Text
            // 
            this.Pl2Text.Location = new System.Drawing.Point(94, 43);
            this.Pl2Text.Name = "Pl2Text";
            this.Pl2Text.Size = new System.Drawing.Size(103, 20);
            this.Pl2Text.TabIndex = 4;
            this.Pl2Text.Text = "Black";
            this.Pl2Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Player2Label
            // 
            this.Player2Label.AutoSize = true;
            this.Player2Label.Location = new System.Drawing.Point(12, 46);
            this.Player2Label.Name = "Player2Label";
            this.Player2Label.Size = new System.Drawing.Size(76, 13);
            this.Player2Label.TabIndex = 3;
            this.Player2Label.Text = "Player2 Name:";
            // 
            // timeBox
            // 
            this.timeBox.Location = new System.Drawing.Point(141, 69);
            this.timeBox.Name = "timeBox";
            this.timeBox.Size = new System.Drawing.Size(56, 20);
            this.timeBox.TabIndex = 6;
            this.timeBox.Text = "30";
            this.timeBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // MaxTime
            // 
            this.MaxTime.AutoSize = true;
            this.MaxTime.Location = new System.Drawing.Point(12, 72);
            this.MaxTime.Name = "MaxTime";
            this.MaxTime.Size = new System.Drawing.Size(123, 13);
            this.MaxTime.TabIndex = 5;
            this.MaxTime.Text = "Max time for player (min):";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(214, 161);
            this.Controls.Add(this.timeBox);
            this.Controls.Add(this.MaxTime);
            this.Controls.Add(this.Pl2Text);
            this.Controls.Add(this.Player2Label);
            this.Controls.Add(this.Pl1Text);
            this.Controls.Add(this.Player1Label);
            this.Controls.Add(this.ApplyButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(230, 200);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(230, 200);
            this.Name = "Form2";
            this.Text = "Starting";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.Label Player1Label;
        private System.Windows.Forms.TextBox Pl1Text;
        private System.Windows.Forms.TextBox Pl2Text;
        private System.Windows.Forms.Label Player2Label;
        private System.Windows.Forms.TextBox timeBox;
        private System.Windows.Forms.Label MaxTime;
    }
}