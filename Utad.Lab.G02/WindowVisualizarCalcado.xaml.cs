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

namespace Utad.Lab.G02
{
    /// <summary>
    /// Lógica interna para WindowVisualizarCalcado.xaml
    /// </summary>
    public partial class WindowVisualizarCalcado : Window
    {
        public WindowVisualizarCalcado()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
