using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;

namespace WarMan
{
    public partial class Game : Form
    {
        //Oyun içerisindeki bütün değişkenler burada tanımlandı
        private TimeSpan gecenSure { get; set; }
        public System.Windows.Forms.Timer zamanlayici { get; set; }
        public System.Windows.Forms.Timer dusmanTimer { get; set; }
        public System.Windows.Forms.Timer bombaTimer { get; set; }
        public int seviye { get; set; } = 1;
        public int skor { get; set; }
        public int cansayisi { get; set; } = 300;
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
        //-------------------------------------------------------------
        public Game()
        {
            //Oyun başlangıcında yapılacaklar burada tanımlandı.
            InitializeComponent(); //Varsayılan tanımlama
            InitializeTimer(); //Oyun zamanlayıcısının tanımlanması
            DoubleBuffered = true; //Çift tamponlama 
            InitializeSeviye(); //Seviye belirlemesi
        }

        private void InitializeTimer()
        {
            KeyPreview = true;
            zamanlayici = new System.Windows.Forms.Timer(); // Zamanlayıcı tanımlandı
            zamanlayici.Interval = 1000; // Millisaniye cinsinden zamanlayıcı aralığı
            zamanlayici.Tick += new EventHandler(Zamanlayici_Tick); // Her saniye atmasında yapılacak olay

            // Zamanı başlatın
            gecenSure = TimeSpan.Zero;
            GuncelleSureLabel(); // Süreyi ekrana yazdır
        }

        private void Zamanlayici_Tick(object? sender, EventArgs e)
        {
            gecenSure = gecenSure.Add(TimeSpan.FromSeconds(1)); // Zamanlayıcı her attığında geçen süreye 1 saniye ekle
            GuncelleSureLabel(); // Labeli güncelle
            if (seviye == 3)
            {
                dusmanYerDegistir(); // Düşman yer değiştirmesini temel zamanlayıcıyla beraber çalıştır
            }
        }

        private void GuncelleSureLabel()
        {
            // Label kontrolüne dakika ve saniye olarak zamanı yazdır
            lblsure.Text = "Geçen Süre : " + gecenSure.ToString(@"mm\:ss");
        }

        private void Game_Load(object sender, EventArgs e)
        {
            string isim = ((StartScreen)Application.OpenForms["StartScreen"]).oyuncuisim; // Oyuncu ismini giriş ekranından çek
            label1.Text = "Hoş geldiniz " + isim; // Oyuncu ismini etikete yazdır
            this.KeyPreview = true; // Form için tuş kontrolünü aç
            this.KeyDown += new KeyEventHandler(Game_KeyDown); // keydown için özellik oluştur
            man.BringToFront(); // man nesnesini öne taşı
            lblUyari.BringToFront(); // uyarı etiketini öne taşı
            OrtalaPanel(); // oyunalanını tam ekran yapıldığında ortala
        }

        private void Game_FormClosed(object sender, FormClosedEventArgs e)
        {
            StartScreen form = new StartScreen();
            form.Show(); // oyun ekranı kapandığında giriş ekranı açılsın
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.P || e.KeyCode == Keys.Escape) // esc veya p tuşuna basıldığında oyun duraklatılsın
            {
                if (duraklat == null || duraklat.IsDisposed)
                {
                    duraklat = new Duraklat(this);
                    duraklat.Show(); // duraklatma menüsünü göster
                    this.Enabled = false;
                    zamanlayici.Stop(); // ana zamanlayıcıyı durdur
                    if (seviye == 2)
                    {
                        bombaTimer.Stop(); // 2. seviye aktifse domba zamanlayıcısı dursun
                    }
                    if (seviye == 3)
                    {
                        dusmanTimer.Stop(); // 3. seviye aktifse düşman zamanlayıcısı dursun
                    }
                }
            }
            if (isMoveEnabled) // yön tuşları ve wasd tuşlarına basıldığında adamı kontrol etsin
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

            // kontrol edilen adamın belirli sınırlar içerisinde hareket etmesi sağlansın
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

            if (newX > 10 && newX < 1320 && newY < 327 && newY > 10) // adam bu sınırlar içerisindeyse yeni konumu uygulansın
            {
                man.Location = new Point(newX, newY);
                isMoveEnabled = false;
                Task.Delay(100).ContinueWith(_ => isMoveEnabled = true); // yön tuşuna basıldığında iki defa algılanmaması için biraz beklesin
            }
        }

        private void CheckCell(int row, int col)
        {
            int[,] Hucre = new int[2, 2];

            // kontrol edilen nesnenin hücre konumu basitleştirilerek anlaşılır hale getirilsin

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

            // her hareket edildiğinde seviyelere özel olaylar gerçekleşsin
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

            // can sayısı 0 olduğunda oyun bitirilsin
            if (cansayisi == 0)
            {
                SeviyeBilgiForm seviyeBilgiForm = new SeviyeBilgiForm(gecenSure, col, row, this);
                seviyeBilgiForm.Show();
            }

            //basitleştirilmiş gösterim için ve konum kontrolü için gerekli atamalar burada yapıldı
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

            // seviye 3'ten küçük ise ve basitleştirilmiş sütun 13 ise sonraki seviyeye geçilsin
            if (seviye < 3)
            {
                if (row == 13)
                {
                    seviye++; // seviye 1 artırıldı
                    cansayisi++; // +1 can eklendi
                    InitializeSeviye(); // seviye tekrar tanımlandı
                    zamanlayici.Stop(); // seviye bilgi ekranı gösterildiği için zamanlayıcı durduruldu
                    seviyeBilgiForm.Show(); // seviye bilgi ekranı açıldı
                    alanSifirla(); // oyun alanı sıfırlandı
                    isTuzakOlustu = false;
                    if (seviye == 2)
                    {
                        if (bombasayisi == 10 && bombaTimer.Enabled)
                        {
                            bombaTimer.Stop(); // seviye 2 ise ve bomba sayısı 10 olduysa ve bomba zamanlayıcısı aktif ise durdurulsun
                        }
                    }
                    if (seviye == 3)
                    {
                        bombaTimer.Stop(); // seviye 3 ise bomba zamanlayıcı durdurulsun
                        bombaPictureBox.Image = null; // zamanlayıcıdan kaynaklı son anda eklenen bomba görseli kaldırılsın
                    }
                }
            }
            //seviye 3 ve sütun 13 ise oyun bitsin
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
            BilgiGonder(); // bilgiler seviye bilgi ekranına gönderilsin
        }

        private void InitializeSeviye()
        {
            lblseviye.Text = "Seviye " + seviye;
            lblCanSayisi.Text = "Kalan Can : " + cansayisi;

            // oyun açılışında seviyelerin ataması yapılsın

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
            totalTimeInSeconds = Convert.ToInt32(gecenSure.TotalSeconds); // geçen süre saniyeye çevrildi

            skor = cansayisi * 500 + (1000 - totalTimeInSeconds); // skor hesaplandı
        }

        private void SaveScoreToTxt()
        {
            string scoreInfo = $"Oyuncu = {isim},Puan = {skor}, Kalan Can = {cansayisi}, Geçen Süre = {totalTimeInSeconds} sn";
            // oyun bittiğinde skor scores.txt dosyasına kaydedildi
            using (StreamWriter writer = new StreamWriter("scores.txt", true))
            {
                writer.WriteLine(scoreInfo);
            }
        }

        private async void seviye1()
        {
            foreach (var point in tuzakKonum)
            {
                // kontrol edilen adam bir tuzağa denk geldiğinde uyarılır
                if (man.Location.X == point.Item1 && man.Location.Y == point.Item2)
                {
                    lblUyari.Visible = true; // uyarı etiketi gösterilir
                    Task.Delay(2000).ContinueWith(t => { lblUyari.Visible = false; }, TaskScheduler.FromCurrentSynchronizationContext()); // uyarı etiketi gizlenir
                    cansayisi--; // can sayısı azaltılır
                    lblCanSayisi.Text = "Kalan Can : " + cansayisi; // can sayısını gösteren etiket güncellenir
                    
                    string hucreisim = "p" + startLocationY + startLocationX; // çarpılan hücre ismi atanır

                    if (!tuzakHucreIsimleri.Contains(hucreisim))
                    {
                        tuzakHucreIsimleri.Add(hucreisim); //tuzak olan hücre listeye eklenir
                    }

                    // PictureBox seçilir
                    PictureBox hedefPictureBox = Controls.Find(hucreisim, true).FirstOrDefault() as PictureBox;

                    if (hedefPictureBox != null)
                    {
                        if (hedefPictureBox.ImageLocation == null)
                        {
                            tuzakResimSecici(hedefPictureBox); // çarpılan hücre için tuzak yerleştirme fonksiyonu çağrılır
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
                    int randomNumber = random.Next(Hucreler.Count); // rastgele yerlerde tuzaklar oluşturulur
                    secilenHucreIsim = Hucreler[randomNumber]; // isimler içerisinden hücreler seçilir
                    tuzakHucre = Controls.Find(secilenHucreIsim, true)[0] as PictureBox; // oyun alanında seçilen isimlerdeki pictureBox'lar bulunur
                    Hucreler.RemoveAt(randomNumber); // bu hücreler bir daha seçilmemesi için listeden çıkarılır
                    Tuple<int, int> tuzakNoktasi = Tuple.Create(tuzakHucre.Location.X, tuzakHucre.Location.Y); // seçilen hücrelerin konumları bulunur
                    tuzakKonum.Add(tuzakNoktasi); // bulunan konumlar listeye eklenir
                }
            }
        }

        private async void seviye2()
        {
            string secilenHucre;
            Random random = new Random();

            // bombaların düşeceği hücreler seçilir
            for (int i = 0; i < 10; i++)
            {
                int randomIndex = random.Next(Hucreler.Count);
                secilenHucre = Hucreler[randomIndex];
                bombaHucreIsimler.Add(secilenHucre);
            }
            if (ManDenkBombaKonumu(bombakonum, man.Location)) // bomba konumu ve man konumu kontrol edilir
            {
                // bombaya denk gelindiğinde can 1 azaltılır
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
                    // Man nesnesi ve düşman eşleşmesi kontrolü
                    cansayisi--; // can sayısı 1 azaltıldı
                    lblCanSayisi.Text = "Kalan Can : " + cansayisi; // can sayısı ekrana yazdırıldı
                }
            }
        }

        private void InitializeDusmanTimer()
        {
            // düşman oluşturma zamanlayıcısı tanımlandı
            dusmanTimer = new System.Windows.Forms.Timer(); 
            dusmanTimer.Interval = 2000; // 2 saniye
            dusmanTimer.Tick += dusmanTimer_Tick;
        }

        private void dusmanTimer_Tick(object sender, EventArgs e)
        {
            // zamanlayıcı her tetiklendiğinde bu metod çalışacak
            EkleDusmanPictureBox();
        }

        private void EkleDusmanPictureBox()
        {
            string uygulamaDizini = AppDomain.CurrentDomain.BaseDirectory; // taşınabilir olması için konum bu şekilde gösterildi
            string imagePath = Path.Combine(uygulamaDizini, "Contents", "soldier.png");

            PictureBox dusmanPictureBox = new PictureBox();
            dusmanPictureBox.Image = Image.FromFile(imagePath); // pictureBox nesnelerine resim eklendi
            dusmanPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            dusmanPictureBox.Size = new Size(100, 100);
            dusmanPictureBox.BackColor = Color.LightSlateGray;

            // Rastgele bir konum belirleyin (siz bu kısmı isteğinize göre düzenleyebilirsiniz)
            Random random = new Random();
            int x = 13;
            int y = random.Next(1, 5); // 1 - 4 aralığında rastgele bir değer seçilerek rastgele bir satırda düşman oluşturuldu
            string kontrol = "p" + y + x;
            PictureBox kontrolPictureBox = gaeZone.Controls.Find(kontrol, true).FirstOrDefault() as PictureBox; // düşman nesnesinin yerleştirilmesi için konum kontrolü yapıldı
            Point point = new Point(kontrolPictureBox.Location.X, kontrolPictureBox.Location.Y); // düşman nesnesinin konumu belirlendi
            dusmanPictureBox.Location = point; // düşman nesnesinin konum ataması yapıldı

            // Oluşturulan PictureBox'ı forma ekleyin
            gaeZone.Controls.Add(dusmanPictureBox); // düsşman nesnesi oyun alanına eklendi
            dusmanPictureBox.BringToFront(); // düşman nesnesi en üste alındı

            // PictureBox'ı listeye ekleyin
            dusmanPictureBoxList.Add(dusmanPictureBox); // konum kontrolü için düşman nesnesi listeye eklendi
        }

        private void dusmanYerDegistir()
        {
            foreach (PictureBox pictureBox in dusmanPictureBoxList)
            {
                // her düşman nesnesinin konumunu başlangıca doğru ilerleyecek olarak güncelle
                int x = pictureBox.Location.X;
                int y = pictureBox.Location.Y;
                pictureBox.Location = new Point(x - 109, y);
            }
        }

        private void alanSifirla()
        {
            startLocationX = 1; // başlangıç pozisyonu sıfırlandı
            startLocationY = 2;
            man.Location = new Point(ManDefaultLocationX, ManDefaultLocationY); // man nesnesi başlangıç konumuna getirildi
            if (seviye == 2)
            {
                foreach (var item in tuzakHucreIsimleri)
                {
                    PictureBox hedefPictureBox = gaeZone.Controls.Find(item, true).FirstOrDefault() as PictureBox;

                    if (hedefPictureBox != null)
                    {
                        hedefPictureBox.ImageLocation = null; // seviye 2 aktif ise tuzakları kaldır
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
                        hedefPictureBox.Image = null; // seviye 3 aktif ise bombaları kaldır
                    }
                }
            }
        }

        private void tuzakResimSecici(PictureBox pictureBox)
        {
            string uygulamaDizini = AppDomain.CurrentDomain.BaseDirectory;
            string klasorYolu = Path.Combine(uygulamaDizini, "Contents", "Traps"); // dosya yolu tanımlandı

            // Klasördeki tüm dosyaları al
            string[] dosyaListesi = Directory.GetFiles(klasorYolu, "*.png"); // dosya uzantısı belirlendi

            // Rastgele 4 dosya seçilsin
            Random random = new Random();
            var rastgeleDosyalar = dosyaListesi.OrderBy(x => random.Next()).Take(4).ToArray(); // rastgele 4 tane görsel seçildi

            for (int i = 0; i < Math.Min(4, rastgeleDosyalar.Length); i++)
            {
                // seçilen görseller tuzak resimleri olarak atandı
                pictureBox.ImageLocation = rastgeleDosyalar[i];
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private bool ManDenkBombaKonumu(List<Tuple<int, int>> bombakonum, Point manKonumu)
        {
            // bombaya denk gelme kontrolü
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
            // 3 saniyede 1 bomba oluşturulmasını sağlayan zamanlayıcı
            bombaTimer = new System.Windows.Forms.Timer();
            bombaTimer.Interval = 3000; // 3 saniye
            bombaTimer.Tick += bombaTimer_Tick;
        }

        private void bombaTimer_Tick(object sender, EventArgs e)
        {
            bombasayisi++; // bomba sayısı 1 artırıldı
            bombaPictureBox = Controls.Find(bombaHucreIsimler[bombasayisi], true).FirstOrDefault() as PictureBox; // bomba hücresi oyun alanından bulundu
            Tuple<int, int> bombaNoktasi = Tuple.Create(bombaPictureBox.Location.X, bombaPictureBox.Location.Y); // hücrenin konumu bomba konumu olarak atandı
            bombakonum.Add(bombaNoktasi); // bomba konumu listeye eklendi

            string uygulamaDizini = AppDomain.CurrentDomain.BaseDirectory; // görsel yolu belirlendi
            string imagePath = Path.Combine(uygulamaDizini, "Contents", "Traps", "nuclear-bomb.png");

            // hücrelere bomba görselleri yerleştirildi
            bombaPictureBox.Image = Image.FromFile(imagePath);
            bombaPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void Game_Resize(object sender, EventArgs e)
        {
            OrtalaPanel(); // oyun alanını ortalamak için ufak bi şey
        }

        private void OrtalaPanel()
        {
            // Paneli formun ortasına yerleştir
            int panelX = (this.ClientSize.Width - gaeZone.Width) / 2;
            int panelY = (this.ClientSize.Height - gaeZone.Height) / 2;

            gaeZone.Location = new Point(panelX, panelY);
        }
    }
}