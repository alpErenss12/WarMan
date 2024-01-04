namespace WarMan
{
    public partial class StartScreen : Form
    {
        private bool textBoxFocused = false;
        public string oyuncuisim;
        public string oyuncuskor { get; set; }

        public StartScreen()
        {
            InitializeComponent();
            ActiveControl = null;
            DoubleBuffered = true;
            oyuncuisim = string.Empty;
        }

        private void StartScreen_Load(object sender, EventArgs e)
        {
            ActiveControl = null;
        }

        private void txtGamerName_Enter(object sender, EventArgs e)
        {
            textBoxFocused = true;
        }

        private void txtGamerName_Leave(object sender, EventArgs e)
        {
            textBoxFocused = false; // textbox dýþýna çýkýldýðýnda yazmayý býraksýn
        }

        private void txtGamerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnPlay.PerformClick(); // textbox odaklýyken enter tuþuna basýldýðýnda play tuþu çalýþsýn
            }
        }

        private void PBinfo_MouseClick(object sender, MouseEventArgs e)
        {
            info infoForm = new info();
            infoForm.Show(); // insý ikonuna basýldýðýnda bilgi ekraný gösterilsin
        }

        private void PBBestScores_Click(object sender, EventArgs e)
        {
            scores scoresForm = new scores();
            scoresForm.Show(); // skor ikonuna basýldýðýnda skor ekraný gösterilsin
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (txtGamerName.Text == string.Empty)
            {
                lblwarning.Visible = true;
                Task.Delay(4000).ContinueWith(t => { lblwarning.Visible = false; }, TaskScheduler.FromCurrentSynchronizationContext());
                // eðer isim yazýlmadan baþlamaya çalýþýlýrsa uyarý versin
            }
            else
            {
                oyuncuisim = txtGamerName.Text; // oyuncu ismi textbox ile girilen yazýya atandý
                Game game = new Game();
                game.Show(); // oyun ekraný açýldý
                info info = new info();
                info.Show(); // bilgi ekraný açýldý
                this.Hide(); // giriþ formu gizlendi
            }
        }

        private void StartScreen_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBoxFocused == false)
            {
                if (e.KeyCode == Keys.S)
                {
                    scores scoresForm = new scores();
                    scoresForm.Show(); // textbox aktif deðilken s tuþuna basýldýðýnda skorlar gösterilsin
                }
            }
            if (textBoxFocused == true)
            {
                if (e.KeyCode == Keys.Escape)
                {
                    ActiveControl = null; // textbox aktifken esc tuþuna basýldýðýnda aktiflik kapansýn
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                btnPlay.PerformClick(); // enter tuþuna basýldýðýnda play tuþuna basýlsýn
            }
        }

        private void StartScreen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBoxFocused == false)
            {
                if (e.KeyChar == 'Ý' || e.KeyChar == 'i' || e.KeyChar == 'I')
                {
                    info infoForm = new info();
                    infoForm.Show(); // textbox aktif deðilken i tuþuna basýldýðýnda skorlar gösterilsin
                }
            }
        }

        private void StartScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); // form kapatýldýðýnda uygulama sonlansýn
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit(); // çýkýþ tuþuna basýldýðýnda uygulama sonlansýn
        }
    }
}