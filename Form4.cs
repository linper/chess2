using System;
using System.Windows.Forms;

namespace chess
{
    public partial class Form4 : Form
    {
        public int figMum { get; set; }
        public Form4()
        {
            InitializeComponent();
            figMum = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                figMum = 1;
            else if (radioButton2.Checked)
                figMum = 2;
            else if (radioButton3.Checked)
                figMum = 3;
            else if (radioButton4.Checked)
                figMum = 4;
        }
    }
}
