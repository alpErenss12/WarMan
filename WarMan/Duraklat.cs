namespace WarMan
{
    public partial class Duraklat : Form
    {
        private Game game;
        public Duraklat(Game game)
        {
            InitializeComponent();

            KeyPreview = true;
            this.game = game;
        }

        private void Duraklat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.P || e.KeyCode == Keys.Escape)
            {
                btnDevamet.PerformClick();
            }
        }

        private void btnDevamet_Click(object sender, EventArgs e)
        {
            game.Enabled = true;
            System.Windows.Forms.Timer timer1 = ((Game)Application.OpenForms["Game"]).zamanlayici;
            System.Windows.Forms.Timer bombaTimer = ((Game)Application.OpenForms["Game"]).bombaTimer;
            System.Windows.Forms.Timer dusmanTimer = ((Game)Application.OpenForms["Game"]).dusmanTimer;
            int seviye = ((Game)Application.OpenForms["Game"]).seviye;
            if (seviye == 2)
            {
                bombaTimer.Start();
            }
            if (seviye == 3)
            {
                dusmanTimer.Start();
            }
            timer1.Start();
            Close();
        }

        private void btnOyundancik_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {

        }

        private void btnAnamenu_Click(object sender, EventArgs e)
        {
            Close();
            game.Close();
            StartScreen ss = new StartScreen();
            ss.Show();
        }

        private void btnshowcontrols_Click(object sender, EventArgs e)
        {
            info info = new info();
            info.Show();
        }
    }
}
