using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
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
using Utad.Lab.G02.Model;

namespace Utad.Lab.G02
{
    /// <summary>
    /// Lógica interna para WindowPeso.xaml
    /// </summary>
    public partial class WindowPeso : Window
    {
        public AlteracoesFisicas Peso;

        public WindowPeso()
        {
            InitializeComponent();

            Peso = new AlteracoesFisicas();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            Peso.Valor = float.Parse(tbPeso.Text);
            Peso.Data = dpPeso.SelectedDate ?? DateTime.Now;

            MessageBox.Show("Alterações efetuadas com sucesso.", "Alterações", MessageBoxButton.OK, MessageBoxImage.Information);

            this.DialogResult = true;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
