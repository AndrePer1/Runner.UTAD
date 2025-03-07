using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
    /// Lógica interna para WindowAltura.xaml
    /// </summary>
    public partial class WindowAltura : Window
    {
        public AlteracoesFisicas Altura;

        private App app;
        public WindowAltura()
        {
            InitializeComponent();

            Altura = new AlteracoesFisicas();
            app = App.Current as App;

            //app.modelo.PerfilAlterado += Modelo_PerfilAlterado;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            app.modelo.LoadFromXML("Dados/dados.xml");
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            app.modelo.SaveToXML("Dados/dados.xml");
        }

        private void btGuardarAlteracoes_Click(object sender, RoutedEventArgs e)
        {
            AlteracoesFisicas alteracao = new AlteracoesFisicas();

            alteracao.Data = dpAltura.SelectedDate ?? DateTime.Now;
            alteracao.Valor = float.Parse(tbValor.Text);

            app.modelo.AdicionaAlteracaoFisica(alteracao);

            MessageBox.Show("Alterações efetuadas com sucesso.", "Alterações", MessageBoxButton.OK, MessageBoxImage.Information);
            this.DialogResult = true;
        }

        private void btCancelarAlteracoes_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
