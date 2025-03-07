using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    /// Lógica interna para WindowCriarPerfil.xaml
    /// </summary>
    public partial class WindowCriarPerfil : Window
    {
        private App _app;

        public Perfil InfoNovo { get; private set; }
        public AlteracoesFisicas Altura;
        public AlteracoesFisicas Peso;

        public WindowCriarPerfil()
        {
            InitializeComponent();

            InfoNovo = new Perfil();
            Altura = new AlteracoesFisicas();
            Peso = new AlteracoesFisicas();

            _app = App.Current as App;
            _app.modelo.PerfilFotoCarregada += Modelo_PerfilFotoCarregada;
            _app.modelo.PerfilFotoGuardada += Modelo_PerfilFotoGuardada;
            _app.modelo.TextoInvalido += Modelo_TextoInvalido;
        }

        private void Modelo_TextoInvalido(string str)
        {
            MessageBox.Show(str, "Valor Inválido", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Modelo_PerfilFotoGuardada(string str)
        {
            imgPerfil.Source = new BitmapImage(new Uri(str, UriKind.RelativeOrAbsolute));
            imgPerfil.Source.Freeze();
        }

        private void Modelo_PerfilFotoCarregada()
        {
            imgPerfil.Source = _app.modelo.MyPerfilFoto.Fotografia;
        }

        private void tbNome_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tbNome = sender as TextBox;
            tbNome.Text = string.Empty;
        }

        private void tbNome_LostFocus(object sender, RoutedEventArgs e)
        {
            if(sender is TextBox)
            {
                if(((TextBox)sender).Text.Trim().Equals(""))
                {
                    ((TextBox)sender).Text = "Nome";
                }
            }
        }

        private void tbPeso_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tbPeso = sender as TextBox;
            tbPeso.Text = string.Empty;
        }

        private void tbPeso_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox)
            {
                if (((TextBox)sender).Text.Trim().Equals(""))
                {
                    ((TextBox)sender).Text = "Peso";
                }
            }
        }

        private void tbAltura_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tbAltura = sender as TextBox;
            tbAltura.Text = string.Empty;
        }

        private void tbAltura_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox)
            {
                if (((TextBox)sender).Text.Trim().Equals(""))
                {
                    ((TextBox)sender).Text = "Altura";
                }
            }
        }

        private void btnFoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Imagens JPG|*.jpg|Imagens PNG|*.png|Todos os ficheiros|*.*";

            if (dlg.ShowDialog() == true)
            {
                _app.modelo.GuardarFoto(dlg.FileName);
            } 
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            Perfil perfil = new Perfil();
            
            //alteracao.Valor = float.Parse(tbAltura.Text);
            //alteracao.Data = DateTime.Now;
            //_app.modelo.AdicionaAlteracaoFisica(alteracao);

            //peso.Valor = float.Parse(tbPeso.Text);
            //peso.Data = DateTime.Now;

            perfil.Fotografia = imgPerfil.Source as BitmapImage;
            perfil.Nome = tbNome.Text;
            perfil.DtNasc = dpNascimento.SelectedDate ?? DateTime.Now;
            perfil.Sexo = cbSexo.Text;
            perfil.FotografiaPath = "Imagens/" + System.IO.Path.GetFileName((imgPerfil.Source as BitmapImage).UriSource.ToString());

            _app.modelo.EditarPerfil(perfil);
            //_app.modelo.AdicionaAlteracaoFisica(alteracao);
            //_app.modelo.AdicionaAlteracaoFisica(peso);

            AlteracoesFisicas altura = new AlteracoesFisicas();
            
            //alteracao.TtipoRegistoFisico =  as TipoRegistoFisico;
            //altura.Data = DateTime.Now; // se a data escolhida for nula, assume a data atual.
            //altura.Valor = float.Parse(tbAltura.Text);

            //_app.modelo.EditarAltura(altura);

            MessageBox.Show("Perfil criado com sucesso!", "Perfil", MessageBoxButton.OK, MessageBoxImage.Information);
            this.DialogResult = true;
            Close();
    }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _app.modelo.SaveToXML("dados.xml");
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
