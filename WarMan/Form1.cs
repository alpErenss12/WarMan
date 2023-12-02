using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;

namespace WarMan
{
    public partial class StartScreen : Form
    {
        private bool textBoxFocused = false;
        public string oyuncuisim { get; set; }
        public string oyuncuskor { get; set; }

        public StartScreen()
        {
            InitializeComponent();
            ActiveControl = null;
            DoubleBuffered = true;
        }

        private void StartScreen_Load(object sender, EventArgs e)
        {
            ActiveControl = null;
        }

        private void pnlLogin_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
        }

        private void txtGamerName_Enter(object sender, EventArgs e)
        {
            textBoxFocused = true;
        }

        private void txtGamerName_Leave(object sender, EventArgs e)
        {
            textBoxFocused = false;
        }

        private void txtGamerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnPlay.PerformClick();
            }
        }

        private void PBinfo_MouseClick(object sender, MouseEventArgs e)
        {
            info infoForm = new info();
            infoForm.Show();
        }

        private void PBBestScores_Click(object sender, EventArgs e)
        {
            scores scoresForm = new scores();
            scoresForm.Show();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (txtGamerName.Text == string.Empty)
            {
                lblwarning.Visible = true;
                Task.Delay(4000).ContinueWith(t => { lblwarning.Visible = false; }, TaskScheduler.FromCurrentSynchronizationContext());
            }
            else
            {
                oyuncuisim = txtGamerName.Text;
                Game game = new Game();
                game.Show();
                info info = new info();
                info.Show();
                this.Hide();
            }
        }

        private void StartScreen_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBoxFocused == false)
            {
                if (e.KeyCode == Keys.S)
                {
                    scores scoresForm = new scores();
                    scoresForm.Show();
                }
            }
            if (textBoxFocused == true)
            {
                if (e.KeyCode == Keys.Escape)
                {
                    this.ActiveControl = null;
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                btnPlay.PerformClick();
            }
        }

        private void StartScreen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBoxFocused == false)
            {
                if (e.KeyChar == 'Ý' || e.KeyChar == 'i' || e.KeyChar == 'I')
                {
                    info infoForm = new info();
                    infoForm.Show();
                }
            }
        }

        private void StartScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}