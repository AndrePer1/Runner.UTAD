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
    /// Lógica interna para WindowPerfil.xaml
    /// </summary>
    public partial class WindowPerfil : Window
    {
        private App _app;
        public WindowPerfil()
        {
            InitializeComponent();

            _app = App.Current as App;

            _app.modelo.PerfilAlterado += Modelo_PerfilAlterado;
            _app.modelo.AlteracaoFisicaAdicionada += Modelo_AlteracaoFisicaAdicionada;
        }

        private void Modelo_AlteracaoFisicaAdicionada()
        {
            //tbAlturaCM = _app.modelo.EditarAltura
        }

        private void Modelo_PerfilAlterado()
        {
            tbNome.Text = _app.modelo.MyPerfil.Nome;
            tbNascimento.Text = _app.modelo.MyPerfil.DtNasc.Date.ToShortDateString();
            imgPerfil.Source = _app.modelo.MyPerfil.Fotografia;
            tbSexo.Text = _app.modelo.MyPerfil.Sexo;
            //tbPeso.Text = _app.modelo.AlteracaoFisica.
        }

        //WindowCriarPerfil criar = new WindowCriarPerfil();
        //    if (criar.ShowDialog() == true)
        //    {
        //        tbNome.Text = criar.tbNome.Text;
        //        tbSexo.Text = criar.cbSexo.Text;
        //        tbNascimento.Text = criar.dpNascimento.Text;
        //        imgPerfil.Source = criar.imgPerfil.Source;
        //        tbPeso.Text = criar.tbPeso.Text;
        //        tbAlturaCM.Text = criar.tbAltura.Text;
        //    }

        private void Window_Loaded (object sender, RoutedEventArgs e)
        {
            _app.modelo.LoadFromXML("dados.xml");
        }

        private void Window_Closing (object sender, System.ComponentModel.CancelEventArgs e)
        {
            _app.modelo.SaveToXML("dados.xml");
        }

        private void btEditarPerfil_Click(object sender, RoutedEventArgs e)
        {
            WindowEditarPerfil janela = new WindowEditarPerfil();

            janela.ShowDialog();

            if(janela.DialogResult == true)
            {
                tbNome.Text = janela.tbNome.Text;
                tbSexo.Text = janela.cbSexo.Text;
                tbNascimento.Text = janela.dpNascimento.SelectedDate.Value.ToShortDateString();
                imgPerfil.Source = janela.imgPerfil.Source;
            }
        }

        private void btVoltar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnPeso_Click(object sender, RoutedEventArgs e)
        {
            WindowPeso janelaPeso = new WindowPeso();
            AlteracoesFisicas alteracao = new AlteracoesFisicas();

            if (janelaPeso.ShowDialog() == true)
            {
                tbPeso.Text = janelaPeso.tbPeso.Text;

                tbPesoDia.Text = janelaPeso.dpPeso.SelectedDate.Value.ToShortDateString();
            }
        }

        private void btnAlterarAltura_Click(object sender, RoutedEventArgs e)
        {
            WindowAltura janelaAltura = new WindowAltura();
            AlteracoesFisicas alteracao = new AlteracoesFisicas();

            if (janelaAltura.ShowDialog() == true)
            {
                tbAlturaCM.Text = janelaAltura.tbValor.Text;
                tbAlturaDia.Text = janelaAltura.dpAltura.SelectedDate.Value.ToShortDateString();
            }
        }
    }
}
