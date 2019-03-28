using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WebExpo.InterfaceGraphique
{
    /// <summary>
    /// Logique d'interaction pour ResultatsBarreProg.xaml
    /// </summary>
    public partial class ResultatsBarreProg : Window
    {
        private Resultats resu = null;

        public ResultatsBarreProg(Resultats r)
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            resu = r;
            this.Update();
        }

        public void Update(double val = 0)
        {
            ProgIter.Value = val;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (ProgIter.Value < 100)
            {
                resu.Abort();
                resu.Busy = false;
            }
        }
    }
}
