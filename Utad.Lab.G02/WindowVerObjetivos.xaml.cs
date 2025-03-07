using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Lógica interna para WindowVerObjetivos.xaml
    /// </summary>
    public partial class WindowVerObjetivos : Window
    {
        public App app;
        public Objetivo objetivos;
        public Objetivo a;
        public WindowVerObjetivos(Objetivo objeto)
        {
            objetivos=new Objetivo();
            app = App.Current as App;
            InitializeComponent();
            objet1.Items.Add(new Tipo(1, "Caminhada"));
            objet1.Items.Add(new Tipo(2, "Corrida"));
            objet1.Items.Add(new Tipo(3, "Peso"));
            objet1.Text = objeto.TipoObjetivo.ToString();
            metaValor1.Text =Convert.ToString( objeto.Meta);
            a = objeto;
            if (objeto.DataLimite != null)
            {
                datalim1.Text = Convert.ToString(objeto.DataLimite);
            }
            nome_do_objet1.Text=objeto.Nome;
           
        }
        public void lancarERRO()
        {

            if (nome_do_objet1 == null || objet1.SelectedItem as Tipo == null || metaValor1.Text == null)
            {
                throw new erroOBJ("falta preencher argumentos");
            }


        }
       
        public void lancarERRO1()

        {
            float aux;
            //if(metaValor1.Text == null)
            //{
            //    throw new erroOBJ("o parametro 'meta' tem de estar preenchido");
            //}
            if (float.TryParse(metaValor1.Text, out aux) == false)
            {
                throw new erroOBJ("O valor de 'meta' tem de ser numero !");
            }
        }
        private void salvar_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
                lancarERRO1();
                lancarERRO();
                objetivos.Nome = nome_do_objet1.Text;
                objetivos.Meta = Convert.ToInt64(metaValor1.Text);
                objetivos.TipoObjetivo = objet1.SelectedItem as Tipo;
                objetivos.DataLimite = Convert.ToDateTime(datalim1.Text);
                app.modelo.edit_obj(objetivos);
                this.DialogResult = true;
            }
            catch (erroOBJ ex) {

                MessageBox.Show(ex.Message, "ERRO", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
