using System.Windows.Forms;

namespace WarMan
{
    public partial class scores : Form
    {
        private Game game;
        private StartScreen startScreen;
        private const string FileName = "score.txt";
        private const int MaxScoresToShow = 10;
        public scores()
        {
            InitializeComponent();
            LoadScoresToDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // form oyun bittikten sonra açılmışsa oyun formunu ve kendisini kapatsın, anasayfadayken açılmışsa sadece kendisini kapatsın
            if (this.game != null && !game.IsDisposed)
            {
                startScreen.Show();
                game.Close();
            }
            Close();
        }

        private void scores_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                button1.PerformClick(); // esc tuşuna basıldığında tamam tuşuna basılsın
            }
        }

        private void scores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S)
            {
                button1.PerformClick(); // s tuşuna basıldığında tamam tuşuna basılsın
            }
        }

        private void LoadScoresToDataGridView()
        {
            string fileName = "scores.txt";
            // skorlar text dosyasından çekilerek tabloya verilsin
            try
            {
                if (File.Exists(fileName))
                {
                    List<ScoreInfo> scores = new List<ScoreInfo>();
                    string[] lines = File.ReadAllLines(fileName);

                    foreach (string line in lines)
                    {
                        ScoreInfo score = ParseScoreInfo(line);
                        scores.Add(score);
                    }

                    // Puanlara göre büyükten küçüğe sıralama
                    var sortedScores = scores.OrderByDescending(s => s.Puan).Take(5).ToList();

                    // DataGridView'e ekleme
                    skorlarGV.DataSource = sortedScores;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
            }
        }

        private ScoreInfo ParseScoreInfo(string line)
        {
            string[] parts = line.Split(',');

            string oyuncu = parts[0].Split('=')[1].Trim();
            int puan = int.Parse(parts[1].Split('=')[1].Trim());
            int kalanCan = int.Parse(parts[2].Split('=')[1].Trim());
            int gecenSure = int.Parse(parts[3].Split('=')[1].Trim().Split(' ')[0]);
            // skor verileri ayrılsın
            return new ScoreInfo(oyuncu, puan, kalanCan, gecenSure);
        }

        public class ScoreInfo
        {
            public string Oyuncu { get; set; }
            public int Puan { get; set; }
            public int KalanCan { get; set; }
            public int GecenSure { get; set; }
            // skor verileri skora göre sıralansın
            public ScoreInfo(string oyuncu, int puan, int kalanCan, int gecenSure)
            {
                Oyuncu = oyuncu;
                Puan = puan;
                KalanCan = kalanCan;
                GecenSure = gecenSure;
            }

            public int CompareTo(ScoreInfo other)
            {
                // Puanlara göre azalan sıralama yap
                return other.Puan.CompareTo(Puan);
            }
        }
    }
}
