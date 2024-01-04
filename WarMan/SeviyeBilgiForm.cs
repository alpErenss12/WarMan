namespace WarMan
{
    public partial class SeviyeBilgiForm : Form
    {
        // oyun formundan gerekli bilgiler çekildi ve tanımlamalar yapıldı
        private int seviye = ((Game)Application.OpenForms["Game"]).seviye;
        private int skor = ((Game)Application.OpenForms["Game"]).skor;
        private int kalancan = ((Game)Application.OpenForms["Game"]).cansayisi;
        private TimeSpan gecenSureForm2;
        private int col1, row1;
        private Game game;

        public SeviyeBilgiForm(TimeSpan gecenSure, int col, int row, Game game)
        {
            InitializeComponent();
            gecenSureForm2 = gecenSure; // oyun formundan geçen süre çekildi
            GuncelleSureLabel(); // süreyi gösteren etiket dolduruldu
            col1 = col;
            row1 = row;
            this.game = game;
        }

        private void GuncelleSureLabel()
        {
            lblGuncelSure.Text = $"Geçen Süre: {gecenSureForm2}"; // süre gösterildi
        }

        private void btnDevam_Click(object sender, EventArgs e)
        {
            if (kalancan != 0)
            {
                if (seviye < 3)
                {
                    if (row1 == 13)
                    {
                        System.Windows.Forms.Timer timer1 = ((Game)Application.OpenForms["Game"]).zamanlayici;
                        timer1.Start();
                        if (seviye == 1)
                        {
                            ((Game)Application.OpenForms["Game"]).bombaTimer.Start(); // kalan can sayısı 0 değilse ve geçilen seviye 2 ise bomba zamanlayaıcısı başlatılsın
                        }
                        if (seviye == 2)
                        {
                            ((Game)Application.OpenForms["Game"]).dusmanTimer.Start(); // kalan can sayısı 0 değilse ve geçilen seviye 3 ise düşman zamanlayıcısı başlatılsın
                        }
                    }
                }
                else if (seviye == 3)
                {
                    if (row1 == 13)
                    {
                        game.Close(); // gelinen satır 13 ve seviye 3 ise oyun formu kapatılsın
                    }
                }
            }
            else if (kalancan == 0)
            {
                game.Close(); // kalan can 0 ise oyun formu kapatılsın
            }
            this.Close();
        }

        private void SeviyeBilgiForm_Load(object sender, EventArgs e)
        {
            if (kalancan != 0)
            {
                if (seviye < 3)
                {
                    if (row1 == 13)
                    {   // seviye 3'ten küçükse geçilen seviyeyi ve diğer bilgileri göstersin
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
                    {   // seviye 3 ise oyunu bitirdiniz mesajı versin
                        lblbitis.Text = "Tebrikler oyunu bitirdiniz.";
                        lblseviye.Visible = false;
                        lblskor.Text = "Skor : " + skor;
                        lblKalanCan.Text = "Kalan Can : " + kalancan;
                    }
                }
            }
            else if (kalancan == 0)
            {   // can sayısı 0 ise oyunu kaybettiniz mesajı versin
                lblseviye.Text = "Can hakkınızın hepsini bitirdiniz.";
                lblbitis.Text = "Oyun bitti. Kaybettiniz.";
                lblskor.Visible = false;
                lblGuncelSure.Visible = false;
                lblKalanCan.Text = "Kalan Can : " + kalancan;
            }
            
        }
    }
}
