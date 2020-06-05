using System;
using System.Windows.Forms;

namespace chess
{
    public partial class Form2 : Form
    {
        Form1 f1;
        public Form2()
        {
            InitializeComponent();           
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            f1 = new Form1(Pl1Text.Text, Pl2Text.Text, Convert.ToDouble(timeBox.Text));
            this.Hide();
            f1.Show();
        }
    }
}
