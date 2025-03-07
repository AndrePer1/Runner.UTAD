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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Utad.Lab.G02.Model;

namespace Utad.Lab.G02
{
    /// <summary>
    /// Lógica interna para WindowEditarCalcado.xaml
    /// </summary>
    public partial class WindowEditarCalcado : Window
    {
        private App _app;
        public Calçado calcado;
        public WindowEditarCalcado()
        {
            InitializeComponent(); 
            calcado = new Calçado();
            _app = App.Current as App;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
                calcado.Marca = tbmarca.Text;
                calcado.Modelo = tbmodelo.Text;
                calcado.Cor = tbcor.Text;
                calcado.DataCompra = Convert.ToDateTime(dpData.Text);
                calcado.LimitKilo = float.Parse(tblimkilo.Text);
                calcado.KiloDispo = float.Parse(tbkilodisp.Text);
                _app.M_Dados.EditCalcado(calcado);
                this.DialogResult = true;
            
        }
    }
}
