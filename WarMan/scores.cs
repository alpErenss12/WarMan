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
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
                button1.PerformClick();
            }
        }

        private void scores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S)
            {
                button1.PerformClick();
            }
        }

        private void LoadScoresToDataGridView()
        {
            try
            {
                // Dosyadan tüm skorları oku
                List<string> lines = File.ReadAllLines(FileName).ToList();

                // Dosyadaki tüm skorları DataGridView'e ekle
                skorlarGV.Rows.Clear();
                foreach (string line in lines.Take(MaxScoresToShow))
                {
                    skorlarGV.Rows.Add(line);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
            }
        }
    }
}
