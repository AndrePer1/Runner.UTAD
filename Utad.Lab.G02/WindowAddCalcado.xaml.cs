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
using Utad.Lab.G02.Model;

namespace Utad.Lab.G02
{
    /// <summary>
    /// Lógica interna para WindowAdicionar.xaml
    /// </summary>
    public partial class WindowAdicionar : Window
    {
        private App _app;
        public Calçado CalcadoNovo;
        public WindowAdicionar()
        {
            InitializeComponent();

            _app = App.Current as App;
            CalcadoNovo = new Calçado();
            
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            float a;
            if (string.IsNullOrEmpty(tbModelo.Text) || string.IsNullOrEmpty(tbCor.Text) || string.IsNullOrEmpty(tbMarca.Text) || string.IsNullOrEmpty(dpCompra.Text) || string.IsNullOrEmpty(tbLimQ.Text))
            {
                _app.M_Dados.erro("Faltam dados para o registo do calçado");
                
            }
            else if (float.TryParse(tbLimQ.Text, out a) == false)
            {
                _app.M_Dados.erro("O limite de Kilometros tem que ser um numero");

            }
            else
            {
                CalcadoNovo.Marca = tbMarca.Text;
                CalcadoNovo.Modelo = tbModelo.Text;
                CalcadoNovo.Cor = tbCor.Text;
                CalcadoNovo.LimitKilo = float.Parse(tbLimQ.Text);
                CalcadoNovo.KiloDispo = float.Parse(tbLimQ.Text);
                CalcadoNovo.DataCompra = Convert.ToDateTime(dpCompra.Text);
                CalcadoNovo.KiloDispo = CalcadoNovo.LimitKilo;
                _app.M_Dados.AddCalcado(CalcadoNovo);
                this.DialogResult = true;
            }

            
        }
    }
}
