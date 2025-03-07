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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Utad.Lab.G02.Model;

namespace Utad.Lab.G02
{
    /// <summary>
    /// Interação lógica para vizualizarOBJ.xam
    /// </summary>
    public partial class vizualizarOBJ
    {
        public vizualizarOBJ(Objetivo objetivo)
        {
            InitializeComponent();
            //objet1.Items.Add(new Tipo(1, "Caminhada"));
            //objet1.Items.Add(new Tipo(2, "Corrida"));
            //objet1.Items.Add(new Tipo(3, "Peso"));
            
            nome_do_objet1.Text = objetivo.Nome;
            metaValor1.Text = Convert.ToString(objetivo.Meta);
            if(objetivo.DataLimite!=null) {
                datalim1.Text = Convert.ToString(objetivo.DataLimite);
            }

            tipoObj.Text = objetivo.TipoObjetivo.ToString();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void objet1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}