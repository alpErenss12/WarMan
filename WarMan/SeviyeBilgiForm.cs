﻿namespace WarMan
{
    public partial class SeviyeBilgiForm : Form
    {
        private int seviye = ((Game)Application.OpenForms["Game"]).seviye;
        private int skor = ((Game)Application.OpenForms["Game"]).skor;
        private int kalancan = ((Game)Application.OpenForms["Game"]).cansayisi;
        private TimeSpan gecenSureForm2;
        private int col1, row1;
        private Game game;

        public SeviyeBilgiForm(TimeSpan gecenSure, int col, int row, Game game)
        {
            InitializeComponent();
            gecenSureForm2 = gecenSure;
            GuncelleSureLabel();
            col1 = col;
            row1 = row;
            this.game = game;
        }

        private void GuncelleSureLabel()
        {
            lblGuncelSure.Text = $"Geçen Süre: {gecenSureForm2}";
        }

        private void btnDevam_Click(object sender, EventArgs e)
        {
            if (seviye < 3)
            {
                if (row1 == 13)
                {
                    System.Windows.Forms.Timer timer1 = ((Game)Application.OpenForms["Game"]).zamanlayici;
                    timer1.Start();
                }
            }
            else if (seviye == 3)
            {
                if (row1 == 13)
                {
                    game.Close();
                }
            }
            this.Close();
        }

        private void SeviyeBilgiForm_Load(object sender, EventArgs e)
        {
            if (seviye < 3)
            {
                if (row1 == 13)
                {
                    lblseviye.Text = "Tebrikler " + seviye + ". seviyeyi bitirdiniz. Şuanda " + (seviye + 1) + ". seviyeye geçmektesiniz." +
                    "\nDevam etmek için 'Tamam' tuşuna basınız.";
                    lblskor.Text = "Mevcut skor : " + skor;
                    lblKalanCan.Text = "Kalan Can : " + kalancan;
                    lblbitis.Visible = false;
                }
            }
            else if (seviye == 3)
            {
                if (row1 == 13)
                {
                    lblbitis.Text = "Tebrikler oyunu bitirdiniz.";
                    lblseviye.Text = " ";
                    lblskor.Text = "Skor : " + skor;
                    lblKalanCan.Text = "Kalan Can : " + kalancan;
                }
            }
        }
    }
}