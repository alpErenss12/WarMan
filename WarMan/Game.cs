using System;

namespace WarMan
{
    public partial class Game : Form
    {
        private TimeSpan gecenSure;
        public System.Windows.Forms.Timer zamanlayici { get; set; }
        private Form duraklat;

        public Game()
        {
            InitializeComponent();
            InitializeTimer();
            DoubleBuffered = true;
        }

        private void InitializeTimer()
        {
            KeyPreview = true;
            zamanlayici = new System.Windows.Forms.Timer();
            zamanlayici.Interval = 1000; // Millisaniye cinsinden zamanlayıcı aralığı (örnekte 1 saniye)
            zamanlayici.Tick += new EventHandler(Zamanlayici_Tick);

            // Zamanı başlatın
            gecenSure = TimeSpan.Zero;
            GuncelleSureLabel();
            //zamanlayici.Start();
        }

        private void Zamanlayici_Tick(object? sender, EventArgs e)
        {
            gecenSure = gecenSure.Add(TimeSpan.FromSeconds(1));
            GuncelleSureLabel();
        }

        private void GuncelleSureLabel()
        {
            // Label kontrolüne dakika ve saniye olarak zamanı yazdır
            lblsure.Text = gecenSure.ToString(@"mm\:ss");
        }

        private void Game_Load(object sender, EventArgs e)
        {
            string isim = ((StartScreen)Application.OpenForms["StartScreen"]).oyuncuisim;
            label1.Text = "Hoş geldiniz " + isim;
            lblsure.Text = "00:00";
        }

        private void Game_FormClosed(object sender, FormClosedEventArgs e)
        {
            StartScreen form = new StartScreen();
            form.Show();
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.P || e.KeyCode == Keys.Escape)
            {
                duraklat = new Duraklat(this);
                duraklat.Show();
                this.Enabled = false;
                zamanlayici.Stop();
            }
        }
    }
}
