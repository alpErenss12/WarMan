namespace WarMan
{
    public partial class scores : Form
    {
        public TableLayoutPanel scoresTable = new TableLayoutPanel();
        public scores()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}
