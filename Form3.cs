using System;
using System.Windows.Forms;

namespace chess
{
    public partial class Form3 : Form
    {
        public Form3(string winner, string condition, bool draw, string p1, string p2, int time1, int time2, int lost1, int lost2, int moves1, int moves2)
        {
            InitializeComponent();
            if (draw)
            {
                label.Text = "Draw";
                WinnerTextBox.Text = condition;
            }
            else
                WinnerTextBox.Text = winner + ", " + condition;
            pl1Label.Text = p1;
            pl2Label.Text = p2;
            Time1.Text = (time1 / 3600).ToString() + "h " + ((time1 / 60) % 60).ToString() + "min " + (time1 % 60).ToString() + "s";
            Time2.Text = (time2 / 3600).ToString() + "h " + ((time2 / 60) % 60).ToString() + "min " + (time2 % 60).ToString() + "s";
            Lost1.Text = lost1.ToString();
            Lost2.Text = lost2.ToString();
            Moves1.Text = moves1.ToString();
            Moves2.Text = moves2.ToString();
        }

        private void RetryButton_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
