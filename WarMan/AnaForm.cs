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
            textBoxFocused = false; // textbox d���na ��k�ld���nda yazmay� b�raks�n
        }

        private void txtGamerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnPlay.PerformClick(); // textbox odakl�yken enter tu�una bas�ld���nda play tu�u �al��s�n
            }
        }

        private void PBinfo_MouseClick(object sender, MouseEventArgs e)
        {
            info infoForm = new info();
            infoForm.Show(); // ins� ikonuna bas�ld���nda bilgi ekran� g�sterilsin
        }

        private void PBBestScores_Click(object sender, EventArgs e)
        {
            scores scoresForm = new scores();
            scoresForm.Show(); // skor ikonuna bas�ld���nda skor ekran� g�sterilsin
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (txtGamerName.Text == string.Empty)
            {
                lblwarning.Visible = true;
                Task.Delay(4000).ContinueWith(t => { lblwarning.Visible = false; }, TaskScheduler.FromCurrentSynchronizationContext());
                // e�er isim yaz�lmadan ba�lamaya �al���l�rsa uyar� versin
            }
            else
            {
                oyuncuisim = txtGamerName.Text; // oyuncu ismi textbox ile girilen yaz�ya atand�
                Game game = new Game();
                game.Show(); // oyun ekran� a��ld�
                info info = new info();
                info.Show(); // bilgi ekran� a��ld�
                this.Hide(); // giri� formu gizlendi
            }
        }

        private void StartScreen_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBoxFocused == false)
            {
                if (e.KeyCode == Keys.S)
                {
                    scores scoresForm = new scores();
                    scoresForm.Show(); // textbox aktif de�ilken s tu�una bas�ld���nda skorlar g�sterilsin
                }
            }
            if (textBoxFocused == true)
            {
                if (e.KeyCode == Keys.Escape)
                {
                    ActiveControl = null; // textbox aktifken esc tu�una bas�ld���nda aktiflik kapans�n
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                btnPlay.PerformClick(); // enter tu�una bas�ld���nda play tu�una bas�ls�n
            }
        }

        private void StartScreen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBoxFocused == false)
            {
                if (e.KeyChar == '�' || e.KeyChar == 'i' || e.KeyChar == 'I')
                {
                    info infoForm = new info();
                    infoForm.Show(); // textbox aktif de�ilken i tu�una bas�ld���nda skorlar g�sterilsin
                }
            }
        }

        private void StartScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); // form kapat�ld���nda uygulama sonlans�n
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit(); // ��k�� tu�una bas�ld���nda uygulama sonlans�n
        }
    }
}