using System.Windows.Forms;
using System.Drawing;

namespace Five
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LogicGame logic = new LogicGame(panel1, 4);
            Size = new Size(panel1.Width + 40, panel1.Height + 65);
        }
    }
}
