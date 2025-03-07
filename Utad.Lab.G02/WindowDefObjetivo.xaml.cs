using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
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
    /// Lógica interna para WindowDefObjetivo.xaml
    /// </summary>
    public partial class WindowDefObjetivo : Window
    {
        public App app;
        public Objetivo lista { get; private set; }
        public WindowDefObjetivo()
        {
            app = App.Current as App;
            InitializeComponent();
            lista = new Objetivo();

            objet.Items.Add(new Tipo(1, "Caminhada"));
            objet.Items.Add(new Tipo(2, "Corrida"));
            objet.Items.Add(new Tipo(3, "Peso"));

        }
        public void lancarERRO()
        {

            if (nome_de_objet == null || objet.SelectedItem as Tipo == null || metaValor.Text == null)
            {
                throw new erroOBJ("falta preencher argumentos");
            }


        }
        public void lancarERRO1()

        {
            float aux;
            if (float.TryParse(metaValor.Text,out aux)==false)
            {
                throw new erroOBJ("O valor de 'meta' tem de ser numero !");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void TextBox_metaValor(object sender, TextChangedEventArgs e)
        {

        }
        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {

            // listaobj.items.add(janela.Lista);




        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lancarERRO1();
                lancarERRO();
                if (datalim.SelectedDate == null)
                {
                   
                    app.modelo.lista.Add(new Objetivo(nome_de_objet.Text, objet.SelectedItem as Tipo, Convert.ToInt64(metaValor.Text)));
                    DialogResult = true;
                    app.modelo.chamarobjetivoadicionado(new Objetivo(nome_de_objet.Text, objet.SelectedItem as Tipo, Convert.ToInt64(metaValor.Text)));
                }
                else if (datalim.SelectedDate != null)
                {

                    app.modelo.lista.Add(new Objetivo(nome_de_objet.Text, objet.SelectedItem as Tipo, Convert.ToInt64(metaValor.Text), Convert.ToDateTime(datalim.Text)));
                    DialogResult = true;
                    app.modelo.chamarobjetivoadicionado(new Objetivo(nome_de_objet.Text, objet.SelectedItem as Tipo, Convert.ToInt64(metaValor.Text), Convert.ToDateTime(datalim.Text)));
                }
            }
            catch (erroOBJ ex)
            {
                MessageBox.Show(ex.Message ,"ERRO", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
            //app.modelo.lista.Add(new Objetivo(nome_de_objet.Text, objet.SelectedItem as Tipo, Convert.ToInt64(metaValor.Text), Convert.ToDateTime(datalim.Text)));
            //DialogResult = true;
            //app.modelo.chamarobjetivoadicionado(new Objetivo(nome_de_objet.Text, objet.SelectedItem as Tipo, Convert.ToInt64(metaValor.Text), Convert.ToDateTime(datalim.Text)));
            /*lista.Meta = float.Parse(metaValor.Text);
            lista.DataLimite = Convert.ToDateTime(datalim.Text);
            lista.TipoObjetivo = objet.SelectedItem as Tipo;
            this.DialogResult = true;*/


        }


    }
}