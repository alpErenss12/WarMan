﻿namespace WarMan
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
                btnDevamet.PerformClick(); // p veya esc tuşuna basıldığında oyunda devam etsin
            }
        }

        private void btnDevamet_Click(object sender, EventArgs e)
        {
            game.Enabled = true;
            // zamanlayıcılar ve seviye bilgisi oyun formundan çekildi
            System.Windows.Forms.Timer timer1 = ((Game)Application.OpenForms["Game"]).zamanlayici;
            System.Windows.Forms.Timer bombaTimer = ((Game)Application.OpenForms["Game"]).bombaTimer;
            System.Windows.Forms.Timer dusmanTimer = ((Game)Application.OpenForms["Game"]).dusmanTimer;
            int seviye = ((Game)Application.OpenForms["Game"]).seviye;
            if (seviye == 2)
            {
                bombaTimer.Start(); // seviye 2 ise bomba zamanlayıcısı çalışsın
            }
            if (seviye == 3)
            {
                dusmanTimer.Start(); // seviye 3 ise düşman zamanlayıcısı çalışsın
            }
            timer1.Start(); // genel zamanlayıcı çalışsın
            Close(); // duraklat formu kapatılsın
        }

        private void btnOyundancik_Click(object sender, EventArgs e)
        {
            Application.Exit(); // oyundan çık tuşuna basıldığında uygulama sonlansın
        }

        private void btnAnamenu_Click(object sender, EventArgs e)
        {
            Close();
            game.Close(); // ana menü tuşuna basıldığında duraklatma formu ve oyun formu kapatılsın ve giriş ekranı açılsın
            StartScreen ss = new StartScreen();
            ss.Show();
        }

        private void btnshowcontrols_Click(object sender, EventArgs e)
        {
            info info = new info();
            info.Show(); // kontrolleri göster tuşuna basıldığında bilgi formu açılsın
        }
    }
}
