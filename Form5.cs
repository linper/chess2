using System;
using System.Windows.Forms;

namespace chess
{
    public partial class Form5 : Form
    {
        Form1 f;
        public String Desination { get; set; }
        public Form5(Form1 f1, string d, string c)
        {
            InitializeComponent();
            f = f1;
            Desination = d;
            label1.Text = c;
        }

        private void RY_Click(object sender, EventArgs e)
        {
            f.Enabled = true;
            this.Hide();
            switch (Desination)
            {
                case "resign":
                    f.ToEndGame(false, "Oponent resigned");
                    break;
                case "reset":
                    Application.Restart();
                    break;
                case "aDraw":
                    f.ToEndGame(true, "Agreed");
                    break;
                case "oDraw":
                    f.Draw = true;
                    break;
                default:
                    Console.WriteLine("Something went wrong!");
                    break;
            }
            
        }

        private void RN_Click(object sender, EventArgs e)
        {
            f.Enabled = true;
            this.Hide();
        }

        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {
            f.Enabled = true;
        }
    }
}
