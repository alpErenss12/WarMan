namespace WarMan
{
    public partial class Game : Form
    {
        private TimeSpan gecenSure { get; set; }
        public System.Windows.Forms.Timer zamanlayici { get; set; }
        public int seviye { get; set; } = 1;
        public int skor { get; set; } 
        public int cansayisi { get; set; } = 3;
        private int startLocationX = 1, startLocationY = 2;
        private Duraklat duraklat;
        private bool isMoveEnabled = true;
        private int ManDefaultLocationX = 11;
        private int ManDefaultLocationY = 116;
        string isim = ((StartScreen)Application.OpenForms["StartScreen"]).oyuncuisim;
        int totalTimeInSeconds;

        public Game()
        {
            InitializeComponent();
            InitializeTimer();
            DoubleBuffered = true;
            InitializeSeviye();
        }

        private void InitializeTimer()
        {
            KeyPreview = true;
            zamanlayici = new System.Windows.Forms.Timer();
            zamanlayici.Interval = 1000; // Millisaniye cinsinden zamanlayıcı aralığı
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
            lblsure.Text = "Geçen Süre : " + gecenSure.ToString(@"mm\:ss");
        }

        private void Game_Load(object sender, EventArgs e)
        {
            string isim = ((StartScreen)Application.OpenForms["StartScreen"]).oyuncuisim;
            label1.Text = "Hoş geldiniz " + isim;
            lblCanSayisi.Text = "Kalan Can : " + cansayisi;
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Game_KeyDown);
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
                if (duraklat == null || duraklat.IsDisposed)
                {
                    duraklat = new Duraklat(this);
                    duraklat.Show();
                    this.Enabled = false;
                    zamanlayici.Stop();
                }
            }
            if (isMoveEnabled)
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
                {
                    MoveNesne(0, -105);
                    CheckCell(0, -1);
                }

                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
                {
                    MoveNesne(0, 105);
                    CheckCell(0, 1);
                }
                if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
                {
                    MoveNesne(-109, 0);
                    CheckCell(-1, 0);
                }

                if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
                {
                    MoveNesne(109, 0);
                    CheckCell(1, 0);
                }
            }
        }

        private void MoveNesne(int deltaX, int deltaY)
        {
            int newX = man.Location.X + deltaX;
            int newY = man.Location.Y + deltaY;

            if (newX > 1320)
            {
                newX = newX - deltaX;
            }
            if (newX < 0)
            {
                newX = newX - deltaX;
            }
            if (newY > 326)
            {
                newY = newY - deltaY;
            }
            if (newY < 0)
            {
                newY = newY - deltaY;
            }

            if (newX > 10 && newX < 1320 && newY < 327 && newY > 10)
            {
                man.Location = new Point(newX , newY);
                isMoveEnabled = false;
                Task.Delay(100).ContinueWith(_ => isMoveEnabled = true);
            }
        }

        private void CheckCell(int row, int col)
        {
            int[,] Hucre = new int[2, 2];

            // Var olan elemanları kopyalamaya gerek yok.

            if (startLocationX >= 0 && startLocationX <= 13)
            {
                startLocationX = startLocationX + row;
            }
            if (startLocationY >= 0 && startLocationY <= 4)
            {
                startLocationY = startLocationY + col;
            }

            // startLocationX ve startLocationY sınırlarını kontrol et
            if (startLocationX <= 0)
            {
                startLocationX = 1;
            }
            if (startLocationY <= 0)
            {
                startLocationY = 1;
            }
            if (startLocationX > 13)
            {
                startLocationX = 13;
            }
            if (startLocationY > 4)
            {
                startLocationY = 4;
            }

            Hucre[1, 0] = startLocationX;
            Hucre[1, 1] = startLocationY;
            row = Hucre[1, 0];
            col = Hucre[1, 1];

            // Recursive çağrıyı kontrol et
            if (row != startLocationX || col != startLocationY)
            {
                CheckCell(row, col);
            }

            label2.Text = $"Man entered cell ({row}, {col}).";
            Bitis(row, col);
        }

        private void Bitis(int row, int col)
        {
            SeviyeBilgiForm seviyeBilgiForm = new SeviyeBilgiForm(gecenSure, col, row, this);
            if (seviye < 3)
            {
                if (row == 13)
                {
                    seviye++;
                    InitializeSeviye();
                    zamanlayici.Stop();
                    seviyeBilgiForm.Show();
                }
            }
            else if (seviye == 3)
            {
                if (row == 13)
                {
                    seviyeBilgiForm.Show();
                    zamanlayici.Stop();
                    SaveScoreToTxt();
                }
            }
            BilgiGonder();
        }

        private void InitializeSeviye()
        {
            lblseviye.Text = "Seviye " + seviye;

            // Her seviye başlangıç koordinatlarını ayarla
            switch (seviye)
            {
                case 1:
                    seviye1();
                    break;
                case 2:
                    seviye2();
                    break;
                case 3:
                    seviye3();
                    break;
            }
        }

        private void BilgiGonder()
        {
            totalTimeInSeconds = Convert.ToInt32(gecenSure.TotalSeconds); // Burada gerçek geçen süreyi kullanın

            skor = cansayisi * 500 + (1000 - totalTimeInSeconds);
        }

        private void SaveScoreToTxt()
        {
            string scoreInfo = $"Oyuncu = {isim},Puan = {skor}, Kalan Can = {cansayisi}, Geçen Süre = {totalTimeInSeconds} sn";
            string dosyaYolu = Path.Combine(Application.StartupPath, "scores.txt");

            List<string> skorlar = new List<string>();
            if (File.Exists(dosyaYolu))
            {
                skorlar = File.ReadAllLines(dosyaYolu).ToList();
            }

            // Yeni skor bilgisini ekle
            skorlar.Add(scoreInfo);

            // Skorları büyükten küçüğe sırala
            skorlar = skorlar.OrderByDescending(s => int.Parse(s.Split(',')[1].Split('=')[1])).ToList();

            // Skorları dosyaya yaz
            File.WriteAllLines(dosyaYolu, skorlar);

            MessageBox.Show("Skor başarıyla eklendi ve sıralandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void seviye1()
        {
            startLocationX = 1;
            startLocationY = 2;
            man.Location = new Point(ManDefaultLocationX, ManDefaultLocationY);
        }

        private void seviye2()
        {
            startLocationX = 1;
            startLocationY = 2;
            man.Location = new Point(ManDefaultLocationX, ManDefaultLocationY);
        }

        private void seviye3()
        {
            startLocationX = 1;
            startLocationY = 2;
            man.Location = new Point(ManDefaultLocationX, ManDefaultLocationY);
        }

    }
}
