namespace chess
{
    partial class Form5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            this.label1 = new System.Windows.Forms.Label();
            this.RY = new System.Windows.Forms.Button();
            this.RN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(9, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "i";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // RY
            // 
            this.RY.Location = new System.Drawing.Point(23, 66);
            this.RY.Name = "RY";
            this.RY.Size = new System.Drawing.Size(76, 21);
            this.RY.TabIndex = 1;
            this.RY.Text = "Yes";
            this.RY.UseVisualStyleBackColor = true;
            this.RY.Click += new System.EventHandler(this.RY_Click);
            // 
            // RN
            // 
            this.RN.Location = new System.Drawing.Point(105, 66);
            this.RN.Name = "RN";
            this.RN.Size = new System.Drawing.Size(76, 21);
            this.RN.TabIndex = 2;
            this.RN.Text = "No";
            this.RN.UseVisualStyleBackColor = true;
            this.RN.Click += new System.EventHandler(this.RN_Click);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(203, 107);
            this.Controls.Add(this.RN);
            this.Controls.Add(this.RY);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(219, 146);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(219, 146);
            this.Name = "Form5";
            this.Text = "Really?";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form5_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button RY;
        private System.Windows.Forms.Button RN;
    }
}