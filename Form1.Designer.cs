namespace chess
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.drawButton = new System.Windows.Forms.Button();
            this.resignButton = new System.Windows.Forms.Button();
            this.messageBox = new System.Windows.Forms.TextBox();
            this.ressetButton = new System.Windows.Forms.Button();
            this.PCButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.MoveButtton = new System.Windows.Forms.Button();
            this.MovesText = new System.Windows.Forms.TextBox();
            this.timeText = new System.Windows.Forms.TextBox();
            this.TimeL = new System.Windows.Forms.Label();
            this.MovesL = new System.Windows.Forms.Label();
            this.PlayerW = new System.Windows.Forms.Label();
            this.PlayerB = new System.Windows.Forms.Label();
            this.canvas = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Controls.Add(this.drawButton);
            this.panel1.Controls.Add(this.resignButton);
            this.panel1.Controls.Add(this.messageBox);
            this.panel1.Controls.Add(this.ressetButton);
            this.panel1.Controls.Add(this.PCButton);
            this.panel1.Controls.Add(this.startButton);
            this.panel1.Controls.Add(this.MoveButtton);
            this.panel1.Controls.Add(this.MovesText);
            this.panel1.Controls.Add(this.timeText);
            this.panel1.Controls.Add(this.TimeL);
            this.panel1.Controls.Add(this.MovesL);
            this.panel1.Controls.Add(this.PlayerW);
            this.panel1.Controls.Add(this.PlayerB);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(480, 102);
            this.panel1.TabIndex = 0;
            // 
            // drawButton
            // 
            this.drawButton.Location = new System.Drawing.Point(89, 47);
            this.drawButton.Name = "drawButton";
            this.drawButton.Size = new System.Drawing.Size(66, 23);
            this.drawButton.TabIndex = 14;
            this.drawButton.Text = "Offer draw";
            this.drawButton.UseVisualStyleBackColor = true;
            this.drawButton.Click += new System.EventHandler(this.drawButton_Click);
            // 
            // resignButton
            // 
            this.resignButton.Location = new System.Drawing.Point(362, 47);
            this.resignButton.Name = "resignButton";
            this.resignButton.Size = new System.Drawing.Size(51, 23);
            this.resignButton.TabIndex = 13;
            this.resignButton.Text = "Resign";
            this.resignButton.UseVisualStyleBackColor = true;
            this.resignButton.Click += new System.EventHandler(this.resignButton_Click);
            // 
            // messageBox
            // 
            this.messageBox.Location = new System.Drawing.Point(8, 76);
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(460, 20);
            this.messageBox.TabIndex = 10;
            // 
            // ressetButton
            // 
            this.ressetButton.Location = new System.Drawing.Point(419, 47);
            this.ressetButton.Name = "ressetButton";
            this.ressetButton.Size = new System.Drawing.Size(49, 23);
            this.ressetButton.TabIndex = 9;
            this.ressetButton.Text = "Reset";
            this.ressetButton.UseVisualStyleBackColor = true;
            this.ressetButton.Click += new System.EventHandler(this.ressetButton_Click);
            // 
            // PCButton
            // 
            this.PCButton.Location = new System.Drawing.Point(161, 47);
            this.PCButton.Name = "PCButton";
            this.PCButton.Size = new System.Drawing.Size(93, 23);
            this.PCButton.TabIndex = 8;
            this.PCButton.Text = "Pause/Continue";
            this.PCButton.UseVisualStyleBackColor = true;
            this.PCButton.Click += new System.EventHandler(this.PCButton_Click);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(8, 47);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 7;
            this.startButton.Text = "Start Game";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // MoveButtton
            // 
            this.MoveButtton.Location = new System.Drawing.Point(260, 47);
            this.MoveButtton.Name = "MoveButtton";
            this.MoveButtton.Size = new System.Drawing.Size(59, 23);
            this.MoveButtton.TabIndex = 6;
            this.MoveButtton.Text = "Move";
            this.MoveButtton.UseVisualStyleBackColor = true;
            this.MoveButtton.Click += new System.EventHandler(this.GoButtton_Click);
            // 
            // MovesText
            // 
            this.MovesText.Location = new System.Drawing.Point(295, 5);
            this.MovesText.Name = "MovesText";
            this.MovesText.Size = new System.Drawing.Size(71, 20);
            this.MovesText.TabIndex = 5;
            this.MovesText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // timeText
            // 
            this.timeText.Location = new System.Drawing.Point(156, 5);
            this.timeText.Name = "timeText";
            this.timeText.Size = new System.Drawing.Size(87, 20);
            this.timeText.TabIndex = 4;
            this.timeText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TimeL
            // 
            this.TimeL.AutoSize = true;
            this.TimeL.Location = new System.Drawing.Point(82, 9);
            this.TimeL.Name = "TimeL";
            this.TimeL.Size = new System.Drawing.Size(68, 13);
            this.TimeL.TabIndex = 3;
            this.TimeL.Text = "Time Passed";
            // 
            // MovesL
            // 
            this.MovesL.AutoSize = true;
            this.MovesL.Location = new System.Drawing.Point(250, 9);
            this.MovesL.Name = "MovesL";
            this.MovesL.Size = new System.Drawing.Size(39, 13);
            this.MovesL.TabIndex = 2;
            this.MovesL.Text = "Moves";
            // 
            // PlayerW
            // 
            this.PlayerW.AutoSize = true;
            this.PlayerW.BackColor = System.Drawing.Color.DarkGray;
            this.PlayerW.Enabled = false;
            this.PlayerW.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.PlayerW.Location = new System.Drawing.Point(416, 9);
            this.PlayerW.Name = "PlayerW";
            this.PlayerW.Size = new System.Drawing.Size(42, 13);
            this.PlayerW.TabIndex = 1;
            this.PlayerW.Text = "Player1";
            // 
            // PlayerB
            // 
            this.PlayerB.AutoSize = true;
            this.PlayerB.BackColor = System.Drawing.Color.DarkGray;
            this.PlayerB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PlayerB.Location = new System.Drawing.Point(12, 9);
            this.PlayerB.Name = "PlayerB";
            this.PlayerB.Size = new System.Drawing.Size(42, 13);
            this.PlayerB.TabIndex = 0;
            this.PlayerB.Text = "Player2";
            // 
            // canvas
            // 
            this.canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvas.Location = new System.Drawing.Point(0, 102);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(480, 480);
            this.canvas.TabIndex = 1;
            this.canvas.TabStop = false;
            this.canvas.Click += new System.EventHandler(this.canvas_Click);
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 582);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(496, 621);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(496, 621);
            this.Name = "Form1";
            this.Text = "Chess";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label PlayerB;
        private System.Windows.Forms.TextBox MovesText;
        private System.Windows.Forms.TextBox timeText;
        private System.Windows.Forms.Label TimeL;
        private System.Windows.Forms.Label MovesL;
        private System.Windows.Forms.Label PlayerW;
        private System.Windows.Forms.Button MoveButtton;
        private System.Windows.Forms.TextBox messageBox;
        private System.Windows.Forms.Button ressetButton;
        private System.Windows.Forms.Button PCButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.Button drawButton;
        private System.Windows.Forms.Button resignButton;
    }
}

