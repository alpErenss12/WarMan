using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;

namespace WarMan
{
    public partial class Game : Form
    {
        private TimeSpan gecenSure { get; set; }
        public System.Windows.Forms.Timer zamanlayici { get; set; }
        public System.Windows.Forms.Timer dusmanTimer { get; set; }
        public System.Windows.Forms.Timer bombaTimer { get; set; }
        public int seviye { get; set; } = 1;
        public int skor { get; set; } 
        public int cansayisi { get; set; } = 3;
        private int startLocationX = 1, startLocationY = 2, ManDefaultLocationX = 11, ManDefaultLocationY = 116, totalTimeInSeconds, bombasayisi = 0;
        private Duraklat duraklat;
        private bool isMoveEnabled = true, isTuzakOlustu;
        string secilenHucreIsim, isim;
        List<string> Hucreler = new List<string>
            {
                "p11", "p12", "p13", "p14", "p15", "p16", "p17", "p18", "p19", "p110", "p111", "p112", 
                "p21", "p22", "p23", "p24", "p25", "p26", "p27", "p28", "p29", "p210", "p211", "p212", 
                "p31", "p32", "p33", "p34", "p35", "p36", "p37", "p38", "p39", "p310", "p311", "p312", 
                "p41", "p42", "p43", "p44", "p45", "p46", "p47", "p48", "p49", "p410", "p411", "p412"
            };
        List<string> tuzakHucreIsimleri = new List<string>();
        List<string> bombaHucreIsimler = new List<string>();
        List<Tuple<int, int>> tuzakKonum = new List<Tuple<int, int>>();
        PictureBox tuzakHucre = new PictureBox();
        private List<PictureBox> dusmanPictureBoxList = new List<PictureBox>();
        List<Tuple<int, int>> bombakonum = new List<Tuple<int, int>>();
        PictureBox bombaPictureBox = new PictureBox();

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
            if (seviye == 3)
            {
                dusmanYerDegistir();
                bombaTimer.Stop();
                bombaPictureBox.Image = null;
            }
            if (seviye == 2)
            {
                if (bombasayisi == 10 && bombaTimer.Enabled)
                {
                    bombaTimer.Stop();
                }
            }
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
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Game_KeyDown);
            man.BringToFront();
            lblUyari.BringToFront();
        }

        public void IsimAl(string oyuncuIsim)
        {
            isim = oyuncuIsim;
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
                    if (seviye == 2)
                    {
                        bombaTimer.Stop();
                    }
                    if (seviye == 3)
                    {
                        dusmanTimer.Stop();
                    }
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
            if (seviye == 1)
            {
                seviye1();
            }
            else if (seviye == 2)
            {
                seviye2();
            }
            else if (seviye == 3)
            {
                seviye3();
            }
            if (cansayisi == 0)
            {
                SeviyeBilgiForm seviyeBilgiForm = new SeviyeBilgiForm(gecenSure, col, row, this);
                seviyeBilgiForm.Show();
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
                    cansayisi++;
                    InitializeSeviye();
                    zamanlayici.Stop();
                    seviyeBilgiForm.Show();
                    alanSifirla();
                    isTuzakOlustu = false;
                }
            }
            else if (seviye == 3)
            {
                if (row == 13)
                {
                    seviyeBilgiForm.Show();
                    zamanlayici.Stop();
                    dusmanTimer.Stop();
                    SaveScoreToTxt();
                }
            }
            BilgiGonder();
        }

        private void InitializeSeviye()
        {
            lblseviye.Text = "Seviye " + seviye;
            lblCanSayisi.Text = "Kalan Can : " + cansayisi;

            // Her seviye başlangıç koordinatlarını ayarla
            switch (seviye)
            {
                case 1:
                    seviye1();
                    break;
                case 2:
                    seviye2();
                    InitializeBombaTimer();
                    break;
                case 3:
                    seviye3();
                    InitializeDusmanTimer();
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

            using (StreamWriter writer = new StreamWriter("scores.txt", true))
            {
                writer.WriteLine(scoreInfo);
            }
        }

        private async void seviye1()
        {
            foreach (var point in tuzakKonum)
            {
                if (man.Location.X == point.Item1 && man.Location.Y == point.Item2)
                {
                    lblUyari.Visible = true;
                    Task.Delay(2000).ContinueWith(t => { lblUyari.Visible = false; }, TaskScheduler.FromCurrentSynchronizationContext());
                    cansayisi--;
                    lblCanSayisi.Text = "Kalan Can : " + cansayisi;

                    string hucreisim = "p" + startLocationY + startLocationX;

                    if (!tuzakHucreIsimleri.Contains(hucreisim))
                    {
                        tuzakHucreIsimleri.Add(hucreisim);
                    }

                    // PictureBox'ı seç
                    PictureBox hedefPictureBox = Controls.Find(hucreisim, true).FirstOrDefault() as PictureBox;

                    if (hedefPictureBox != null)
                    {
                        if (hedefPictureBox.ImageLocation == null)
                        {
                            tuzakResimSecici(hedefPictureBox);
                        }
                    }
                }
            }
            if (!isTuzakOlustu)
            {
                isTuzakOlustu = true;
                Random random = new Random();
                for (int i = 0; i < 10; i++)
                {
                    int randomNumber = random.Next(Hucreler.Count);
                    secilenHucreIsim = Hucreler[randomNumber];
                    tuzakHucre = Controls.Find(secilenHucreIsim, true)[0] as PictureBox;
                    Hucreler.RemoveAt(randomNumber);
                    Tuple<int, int> tuzakNoktasi = Tuple.Create(tuzakHucre.Location.X, tuzakHucre.Location.Y);
                    tuzakKonum.Add(tuzakNoktasi);
                }
            }
        }

        private async void seviye2()
        {
            string secilenHucre;
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                int randomIndex = random.Next(Hucreler.Count);
                secilenHucre = Hucreler[randomIndex];
                bombaHucreIsimler.Add(secilenHucre);
            }
            if (ManDenkBombaKonumu(bombakonum, man.Location))
            {
                // Man bombaya denk geldiği için cansayısı 1 azalacak
                cansayisi--;
                lblCanSayisi.Text = "Kalan Can : " + cansayisi;
            }
        }

        private async void seviye3()
        {
            foreach (PictureBox pictureBox in dusmanPictureBoxList)
            {
                if (man.Location == pictureBox.Location)
                {
                    // Man nesnesi ve PictureBox'un konumu eşleşirse
                    cansayisi--;
                    lblCanSayisi.Text = "Kalan Can : " + cansayisi;
                    // Uyarı verildikten sonra gerekli işlemleri yapabilirsiniz.
                }
            }
        }

        private void InitializeDusmanTimer()
        {
            dusmanTimer = new System.Windows.Forms.Timer();
            dusmanTimer.Interval = 2000; // 2 saniye
            dusmanTimer.Tick += dusmanTimer_Tick;
            dusmanTimer.Start();
        }

        private void dusmanTimer_Tick(object sender, EventArgs e)
        {
            // Timer her tetiklendiğinde bu metod çalışacak
            EkleDusmanPictureBox();
        }

        private void EkleDusmanPictureBox()
        {
            string imagePath = @"C:\Users\bartu\source\repos\WarMan\WarMan\Contents\soldier.png";
            PictureBox dusmanPictureBox = new PictureBox();
            dusmanPictureBox.Image = Image.FromFile(imagePath); // Düşmanın resmini ekleyin
            dusmanPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            dusmanPictureBox.Size = new Size(100, 100);
            dusmanPictureBox.BackColor = Color.LightSlateGray;

            // Rastgele bir konum belirleyin (siz bu kısmı isteğinize göre düzenleyebilirsiniz)
            Random random = new Random();
            int x = 13;
            int y = random.Next(1, 5);
            string kontrol = "p" + y + x;
            PictureBox kontrolPictureBox = gaeZone.Controls.Find(kontrol, true).FirstOrDefault() as PictureBox;
            Point point = new Point(kontrolPictureBox.Location.X, kontrolPictureBox.Location.Y);
            dusmanPictureBox.Location = point;

            // Oluşturulan PictureBox'ı forma ekleyin
            gaeZone.Controls.Add(dusmanPictureBox);
            dusmanPictureBox.BringToFront();

            // PictureBox'ı listeye ekleyin
            dusmanPictureBoxList.Add(dusmanPictureBox);
        }

        private void dusmanYerDegistir()
        {
            foreach (PictureBox pictureBox in dusmanPictureBoxList)
            {
                // Her PictureBox'ın konumunu rastgele olarak güncelle
                int x = pictureBox.Location.X;
                int y = pictureBox.Location.Y;
                pictureBox.Location = new Point(x - 109, y);
            }
        }

        private void alanSifirla()
        {
            startLocationX = 1;
            startLocationY = 2;
            man.Location = new Point(ManDefaultLocationX, ManDefaultLocationY);
            if (seviye == 2)
            {
                foreach (var item in tuzakHucreIsimleri)
                {
                    PictureBox hedefPictureBox = gaeZone.Controls.Find(item, true).FirstOrDefault() as PictureBox;

                    if (hedefPictureBox != null)
                    {
                        hedefPictureBox.ImageLocation = null;
                    }
                }
            }
            if (seviye == 3)
            {
                foreach (var item in bombaHucreIsimler)
                {
                    PictureBox hedefPictureBox = gaeZone.Controls.Find(item, true).FirstOrDefault() as PictureBox;

                    if (hedefPictureBox != null)
                    {
                        hedefPictureBox.Image = null;
                    }
                }
            }
        }

        private void tuzakResimSecici(PictureBox pictureBox)
        {
            string klasorYolu = @"C:\Users\bartu\source\repos\WarMan\WarMan\Contents\Traps\";

            // Klasördeki tüm dosyaları al
            string[] dosyaListesi = Directory.GetFiles(klasorYolu, "*.png"); // veya diğer uzantıları kullanabilirsiniz

            // Rastgele 4 dosya seç
            Random random = new Random();
            var rastgeleDosyalar = dosyaListesi.OrderBy(x => random.Next()).Take(4).ToArray();
            // Örneğin, PictureBox nesnelerine atayarak göstermek
            for (int i = 0; i < Math.Min(4, rastgeleDosyalar.Length); i++)
            {
                pictureBox.ImageLocation = rastgeleDosyalar[i];
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private bool ManDenkBombaKonumu(List<Tuple<int, int>> bombakonum, Point manKonumu)
        {
            foreach (var bombaNoktasi in bombakonum)
            {
                if (manKonumu.X == bombaNoktasi.Item1 && manKonumu.Y == bombaNoktasi.Item2)
                {
                    lblUyari.Visible = true;
                    Task.Delay(2000).ContinueWith(t => { lblUyari.Visible = false; }, TaskScheduler.FromCurrentSynchronizationContext());
                    return true; // Man bombaya denk geldi
                }
            }
            return false; // Man bombaya denk gelmedi
        }

        private void InitializeBombaTimer()
        {
            bombaTimer = new System.Windows.Forms.Timer();
            bombaTimer.Interval = 3000; // 3 saniye
            bombaTimer.Tick += bombaTimer_Tick;
            bombaTimer.Start();
        }

        private void bombaTimer_Tick(object sender, EventArgs e)
        {
            bombasayisi++;
            bombaPictureBox = Controls.Find(bombaHucreIsimler[bombasayisi], true).FirstOrDefault() as PictureBox;
            Tuple<int, int> bombaNoktasi = Tuple.Create(bombaPictureBox.Location.X, bombaPictureBox.Location.Y);
            bombakonum.Add(bombaNoktasi);

            // Burada nuclear_bomb.png dosyanızın yolunu belirtmelisiniz
            string imagePath = @"C:\Users\bartu\source\repos\WarMan\WarMan\Contents\Traps\nuclear-bomb.png";

            // pictureBox.ImageLocation kullanarak
            bombaPictureBox.Image = Image.FromFile(imagePath);
            bombaPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        }
    }
}