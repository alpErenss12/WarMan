using System;
using System.Windows.Forms;

namespace WarMan
{
    public partial class info : Form
    {
        public info()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Game game = Application.OpenForms["Game"] as Game;
            Duraklat duraklat = Application.OpenForms["Duraklat"] as Duraklat;
            if (game != null && game.Visible)
            {
                if(duraklat == null)
                {
                    game.zamanlayici.Start();
                }
            }

            Close();
        }

        private void info_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape || e.KeyChar == 'İ' || e.KeyChar == 'i' || e.KeyChar == 'I')
            {
                BtnClose.PerformClick();
            }
        }
    }
}
