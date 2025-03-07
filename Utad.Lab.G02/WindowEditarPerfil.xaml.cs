using Microsoft.Win32;
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
    /// Lógica interna para WindowEditarPerfil.xaml
    /// </summary>
    public partial class WindowEditarPerfil : Window
    {
        private App _app;

        public Perfil InfoNovo { get; private set; }
        public WindowEditarPerfil()
        {
            InitializeComponent();

            _app = App.Current as App;
            _app.modelo.PerfilFotoCarregada += Modelo_PerfilFotoCarregada;
            _app.modelo.PerfilFotoGuardada += Modelo_PerfilFotoGuardada;

            _app.modelo.PerfilAlterado += Modelo_PerfilAlterado;

            InfoNovo = new Perfil();
        }

        private void Modelo_PerfilAlterado()
        {
            tbNome.Text = _app.modelo.MyPerfil.Nome;
            imgPerfil.Source = _app.modelo.MyPerfil.Fotografia;
            dpNascimento.SelectedDate = _app.modelo.MyPerfil.DtNasc;
            cbSexo.Text = _app.modelo.MyPerfil.Sexo;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _app.modelo.LoadFromXML("dados.xml");
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _app.modelo.SaveToXML("dados.xml");

            MainWindow mainft = new MainWindow();

            mainft.btnNome.Content = tbNome.Text;
            mainft.imgPerfil.Source = imgPerfil.Source as BitmapImage;
        }

        private void Modelo_PerfilFotoGuardada(string str)
        {
            MessageBox.Show("Fotografia atualizada com sucesso !", "Fotografia", MessageBoxButton.OK, MessageBoxImage.Information);
            imgPerfil.Source = new BitmapImage(new Uri(str, UriKind.RelativeOrAbsolute));
            imgPerfil.Source.Freeze();
        }

        private void Modelo_PerfilFotoCarregada()
        {
            imgPerfil.Source = _app.modelo.MyPerfilFoto.Fotografia;
        }

        private void btGuardarAlteracoes_Click(object sender, RoutedEventArgs e)
        {
            //InfoNovo.Fotografia = imgPerfil.Source as BitmapImage;
            //InfoNovo.Nome = tbNome.Text;
            //InfoNovo.Sexo = cbSexo.Text;
            //InfoNovo.DtNasc = dpNascimento.SelectedDate.Value;
            //InfoNovo.FotografiaPath = "Imagens/" + System.IO.Path.GetFileName((imgPerfil.Source as BitmapImage).UriSource.ToString());
            //_app.modelo.SaveToXML("dados.xml");
            //MessageBox.Show("Perfil editado com sucesso!", "Editar Perfil", MessageBoxButton.OK, MessageBoxImage.Information);

            //this.DialogResult = true;

            Perfil perfil = new Perfil();

            
            perfil.Fotografia = imgPerfil.Source as BitmapImage;
            perfil.Nome = tbNome.Text;
            perfil.DtNasc = dpNascimento.SelectedDate ?? DateTime.Now;
            perfil.Sexo = cbSexo.Text;
            perfil.FotografiaPath = "Imagens/" + System.IO.Path.GetFileName((imgPerfil.Source as BitmapImage).UriSource.ToString());

            _app.modelo.EditarPerfil(perfil);
            
            MessageBox.Show("Perfil alterado com sucesso!", "Perfil", MessageBoxButton.OK, MessageBoxImage.Information);
            this.DialogResult = true;


            Close();
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnEditFoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Imagens JPG|*.jpg|Imagens PNG|*.png|Todos os ficheiros|*.*";

            if (dlg.ShowDialog() == true)
            {
                _app.modelo.GuardarFoto(dlg.FileName);
            }
        }
    }
}
