using WarMan.Interface;
using WarMan.Enum;
using System.Windows.Forms;

namespace WarMan.Concrete
{
    internal class Oyun : IOyun
    {
        public void hareket(Yon yon)
        {
            MessageBox.Show(yon.ToString());
        }
    }
}
