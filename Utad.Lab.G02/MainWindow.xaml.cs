using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using Utad.Lab.G02.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Utad.Lab.G02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private App _app;
        public MainWindow()
        {
            _app = App.Current as App;


            InitializeComponent();
            _app.Gestor.atividade_adicionada += Gestor_atividade_adicionada;
            _app.Gestor.Suc += Gestor_Suc;
            _app.Gestor.Dados += Gestor_Dados;
            _app.M_Dados.calcado_adicionado += M_Dados_calcado_adicionado;
            _app.M_Dados.calcado_editado += M_Dados_calcado_editado;
            _app.modelo.objetivo_adicionado += adicionar_objetivo_a_lista;
            _app.modelo.objetivo_eliminar += Modelo_objetivo_eliminar;
            _app.modelo.edit += Modelo_objetivo_editar;

            _app.modelo.PerfilAlterado += Modelo_PerfilAlterado;


        }

        private void Gestor_Suc(string mensagem)
        {
            MessageBox.Show(mensagem, "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
        }



        private void Modelo_PerfilAlterado()
        {
            btnNome.Content = _app.modelo.MyPerfil.Nome;
            imgPerfil.Source = _app.modelo.MyPerfil.Fotografia;
        }

        private void Modelo_objetivo_editar(Objetivo objetivo)
        {
            string texto = string.Concat(objetivo.TipoObjetivo, " - ", objetivo.Nome);
            if (objetivo != null)
            {
                listaobj.Items.Remove(listaobj.SelectedItem);
                listaobj.Items.Add(texto);
                _app.modelo.lista.Add(objetivo);

            }
        }
        private void Modelo_objetivo_eliminar(int posicao)
        {
            if (posicao >= 0)
            {
                listaobj.Items.RemoveAt(posicao);
                _app.modelo.lista.RemoveAt(posicao);
            }

        }

        private void mnSair_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void M_Dados_calcado_editado(Calçado cal)
        {
            if (cal != null)
            {
                lbCalcado.Items.Add(cal);
                _app.M_Dados.GestCalcado.ListCalcado.Add(cal);
            }
        }

        private void M_Dados_calcado_adicionado(Calçado cal)
        {
            if (cal != null)
            {
                lbCalcado.Items.Add(cal);
                _app.M_Dados.GestCalcado.ListCalcado.Add(cal);
            }
        }

        private void Gestor_Dados(string mensagem)
        {
            MessageBox.Show(mensagem, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Gestor_atividade_adicionada(Atividade at)
        {
            if (at != null)
            {
                lbAct.Items.Add(at);
                _app.Gestor.ListAtividade.Add(at);

            }

        }


        private void mnAddCalcado_Click(object sender, RoutedEventArgs e)
        {
            WindowAdicionar janela = new WindowAdicionar();
            janela.ShowDialog();
        }

        private void mnEditCalcado_Click(object sender, RoutedEventArgs e)
        {
            WindowEditarCalcado janela = new WindowEditarCalcado();

        }

        private void mnDefinirObjetivo_Click(object sender, RoutedEventArgs e)
        {
            WindowDefObjetivo janela = new WindowDefObjetivo();
            janela.ShowDialog();
        }
        private void adicionar_objetivo_a_lista(Objetivo objetivo)
        {
            if (objetivo != null)
            {
                string name = string.Concat(objetivo.TipoObjetivo, " - ", objetivo.Nome);
                listaobj.Items.Add(name);
            }
        }
        private void mnDados_Click(object sender, RoutedEventArgs e)
        {
            WindowDadosEstatisticos janela = new WindowDadosEstatisticos();
            janela.ShowDialog();
            janela.ObterAtividades();
        }

        private void mnVerPerfil_Click(object sender, RoutedEventArgs e)
        {
            WindowPerfil janela = new WindowPerfil();

            janela.ShowDialog();
        }

        private void mnEditarPerfil_Click(object sender, RoutedEventArgs e)
        {
            WindowEditarPerfil janela = new WindowEditarPerfil();

            janela.ShowDialog();

            if (janela.DialogResult == true)
            {
                btnNome.Content = janela.tbNome.Text;
                imgPerfil.Source = janela.imgPerfil.Source;
            }
        }

        private void mnCriarPerfil_Click(object sender, RoutedEventArgs e)
        {
            WindowCriarPerfil janela = new WindowCriarPerfil();

            janela.ShowDialog();

            if (janela.DialogResult == true)
            {
                btnNome.Content = janela.tbNome.Text;
                imgPerfil.Source = janela.imgPerfil.Source;
            }
        }

        private void listaobj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void mnAddAtividade_Click(object sender, RoutedEventArgs e)
        {
            WindowAddAtividade janela = new WindowAddAtividade();

            janela.ShowDialog();
        }

        private void mtEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowAddAtividade jan = new WindowAddAtividade();
            jan.Title = "Editar Atividade";
            if (lbAct.SelectedIndex != -1)
            {
                int pos = lbAct.SelectedIndex;
                Atividade atividade = _app.Gestor.ListAtividade[pos];

                jan.cbTipo.Text = atividade.TipoAtividade.ToString();
                jan.dtInicio.Text = atividade.Inicio.ToString();
                jan.tbHorasInicio.Text = atividade.Inicio.Hour.ToString();
                jan.tbMinutosInicio.Text = atividade.Inicio.Minute.ToString();
                jan.dtFim.Text = atividade.Termino.ToString();
                jan.tbHorasFim.Text = atividade.Termino.Hour.ToString();
                jan.tbMinutosFim.Text = atividade.Termino.Minute.ToString();
                jan.tbPerc.Text = atividade.Distancia.ToString();
                jan.tbRitmo.Text = atividade.Ritmo.ToString();
                jan.tbDescri.Text = atividade.Descricao.ToString();
                if (atividade.Calçado == null)
                {
                    jan.cbNo.IsChecked = true;
                    //jan.cbYes.IsChecked = true;
                    //jan.cbCalc.Text = atividade.Calçado.ToString();
                }
                else
                {
                    jan.cbYes.IsChecked = true;
                    jan.cbCalc.Text = atividade.Calçado.ToString();
                    atividade.Calçado = jan.cbCalc.SelectedItem as Calçado;
                    float n;
                    n = _app.M_Dados.GestCalcado.ListCalcado[jan.cbCalc.SelectedIndex].KiloDispo + atividade.Distancia;
                    n = n - jan.act.Distancia;
                    _app.M_Dados.GestCalcado.ListCalcado[jan.cbCalc.SelectedIndex].KiloDispo = n;
                }




                if (jan.ShowDialog() == true)
                {
                    lbAct.Items.Remove(atividade);
                    _app.Gestor.ListAtividade.Remove(atividade);
                }
            }
        }

        private void mtRemove_Click(object sender, RoutedEventArgs e)
        {
            if (lbAct.SelectedIndex != -1)
            {
                Atividade AtividadeSelecionada = lbAct.SelectedItem as Atividade;

                MessageBoxResult opcao = MessageBox.Show("Tem a certeza que pretende eliminar atividade?",
                "Elminar Atividade",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);
                if (opcao == MessageBoxResult.Yes)
                {
                    _app.Gestor.ListAtividade.Remove(AtividadeSelecionada);
                    lbAct.Items.Remove(AtividadeSelecionada);
                    Gestor_Suc("Atividade removida com sucesso!");
                }
            }
        }

        private void mtView_Click(object sender, RoutedEventArgs e)
        {
            WindowAddAtividade jan = new WindowAddAtividade();
            jan.Title = "Visualizar Atividade";
            if (lbAct.SelectedIndex != -1)
            {
                int pos = lbAct.SelectedIndex;
                Atividade atividade = _app.Gestor.ListAtividade[pos];

                jan.cbYes.IsEnabled = false;
                jan.cbTipo.Text = atividade.TipoAtividade.ToString();
                jan.dtInicio.Text = atividade.Inicio.ToString();
                jan.tbHorasInicio.Text = atividade.Inicio.Hour.ToString();
                jan.tbMinutosInicio.Text = atividade.Inicio.Minute.ToString();
                jan.dtFim.Text = atividade.Termino.ToString();
                jan.tbHorasFim.Text = atividade.Termino.Hour.ToString();
                jan.tbMinutosFim.Text = atividade.Termino.Minute.ToString();
                jan.tbPerc.Text = atividade.Distancia.ToString();
                jan.tbRitmo.Text = atividade.Ritmo.ToString();
                jan.tbDescri.Text = atividade.Descricao.ToString();
                if (atividade.Calçado == null)
                {
                    jan.cbNo.IsChecked = true;
                    //jan.cbYes.IsChecked = true;
                    //jan.cbCalc.Text = atividade.Calçado.ToString();
                }
                else
                {
                    jan.cbYes.IsChecked = true;
                    jan.cbCalc.Text = atividade.Calçado.ToString();
                }

                //Como apenas queremos visualizar, nao é possivel interagir com os parâmetros
                jan.cbYes.IsEnabled = false;
                jan.cbCalc.IsEnabled = false;
                jan.cbNo.IsEnabled = false;
                jan.tbDescri.IsEnabled = false;
                jan.dtFim.IsEnabled = false;
                jan.tbHorasFim.IsEnabled = false;
                jan.tbMinutosFim.IsEnabled = false;
                jan.tbPerc.IsEnabled = false;
                jan.dtInicio.IsEnabled = false;
                jan.tbHorasInicio.IsEnabled = false;
                jan.tbMinutosInicio.IsEnabled = false;
                jan.cbTipo.IsEnabled = false;
                jan.tbRitmo.IsEnabled = false;

                jan.btnCancel.Content = "Voltar";
                jan.btnConcluido.Width = 0;
                jan.btnConcluido.Height = 0;
                jan.ShowDialog();
            }
        }

        private void EditarCalcado_Click(object sender, RoutedEventArgs e)
        {
            WindowEditarCalcado janela = new WindowEditarCalcado();
            if (lbCalcado.SelectedIndex != -1)
            {
                int posicaoCalcadoSelecionada = lbCalcado.SelectedIndex;
                Calçado CalcadoSelecionado = _app.M_Dados.GestCalcado.ListCalcado[posicaoCalcadoSelecionada];

                janela.tbmarca.Text = CalcadoSelecionado.Marca.ToString();
                janela.tbmodelo.Text = CalcadoSelecionado.Modelo.ToString();
                janela.tbcor.Text = CalcadoSelecionado.Cor.ToString();
                janela.tblimkilo.Text = CalcadoSelecionado.LimitKilo.ToString();
                janela.dpData.Text = CalcadoSelecionado.DataCompra.ToString();
                janela.tbkilodisp.Text = CalcadoSelecionado.KiloDispo.ToString();

                if (float.Parse(janela.tbkilodisp.Text) <= 0)
                {
                    janela.cbsim.IsChecked = true;
                }
                else
                {
                    janela.cbnao.IsChecked = true;
                }

                if (janela.ShowDialog() == true)
                {
                    lbCalcado.Items.Remove(CalcadoSelecionado);
                    _app.M_Dados.GestCalcado.ListCalcado.Remove(CalcadoSelecionado);
                }

            }
        }

        private void VerCalcado_Click(object sender, RoutedEventArgs e)
        {
            WindowVisualizarCalcado janela = new WindowVisualizarCalcado();
            
            if (lbCalcado.SelectedIndex != -1)
            {
                int posicaoCalcadoSelecionada = lbCalcado.SelectedIndex;
                Calçado CalcadoSelecionado = _app.M_Dados.GestCalcado.ListCalcado[posicaoCalcadoSelecionada];

                janela.tbmarca.Text = CalcadoSelecionado.Marca.ToString();
                janela.tbmodelo.Text = CalcadoSelecionado.Modelo.ToString();
                janela.tbcor.Text = CalcadoSelecionado.Cor.ToString();
                janela.tblimkilo.Text = CalcadoSelecionado.LimitKilo.ToString();
                janela.dpData.Text = CalcadoSelecionado.DataCompra.ToString();
                janela.tbkilodisp.Text = CalcadoSelecionado.KiloDispo.ToString();

                if (float.Parse(janela.tbkilodisp.Text) <= 0)
                {
                    janela.cbsim.IsChecked = true;
                }
                else
                {
                    janela.cbnao.IsChecked = true;
                }

            }
            janela.ShowDialog();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Calçado a = new Calçado(1, "Nike", "Air Force", "Preto", 100000, 5, new DateTime(2023, 3, 27, 10, 0, 0), true);
            Calçado b = new Calçado(2, "Puma", "SpeedCat", "Vermelho", 200000, 200000, new DateTime(2023, 5, 1, 12, 0, 0), true);
            Calçado c = new Calçado(3, "Adidas", "Stan Smith", "Branco", 300000, 300000, new DateTime(2023, 4, 20, 9, 0, 0), true);

            _app.M_Dados.AddCalcado(a);
            _app.M_Dados.AddCalcado(b);
            _app.M_Dados.AddCalcado(c);

            _app.modelo.LoadFromXML("dados.xml");

            Calçado cal1 = new Calçado(4, "Nike", "Fly move", "Azul", 20300, 20300, new DateTime(2023, 1, 29, 18, 0, 0), true);
            _app.M_Dados.AddCalcado(cal1);

            Atividade d = new Atividade(new TipoAtividade(2, "Caminhada"), "Pelo Corgo", new DateTime(2023, 2, 20, 17, 30, 0), new DateTime(2023, 2, 20, 19, 30, 0), 10, new Calçado(), 12);
            Atividade g = new Atividade(new TipoAtividade(1, "Corrida"), "Rapidinha de alta intensidade", new DateTime(2023, 5, 31, 10, 30, 0), new DateTime(2023, 5, 31, 11, 30, 0), 2, new Calçado(), 30);
            Atividade f = new Atividade(new TipoAtividade(2, "Corrida"), "De manhazinha", new DateTime(2023, 6, 2, 9, 0, 0), new DateTime(2023, 6, 2, 11, 0, 0), 20, new Calçado(), 6);
            _app.Gestor.AtividadeAddLoaded(d);
            _app.Gestor.AtividadeAddLoaded(g);
            _app.Gestor.AtividadeAddLoaded(f);




            Objetivo ob1 = new Objetivo("1", new Tipo(1, "Caminhada"), 11);
            Objetivo ob2 = new Objetivo("2", new Tipo(3, "Peso"), 20);
            Objetivo ob3 = new Objetivo("3", new Tipo(2, "Corrida"), 5);
            Objetivo ob4 = new Objetivo("4", new Tipo(2, "Corrida"), 10, new DateTime(2023, 3, 15, 0, 0, 0));

            _app.modelo.carregarObjetivo(ob1);
            _app.modelo.lista.Add(ob2);
            _app.modelo.lista.Add(ob3);
            _app.modelo.lista.Add(ob4);
            _app.modelo.chamarobjetivoadicionado(ob1);
            _app.modelo.chamarobjetivoadicionado(ob2);
            _app.modelo.chamarobjetivoadicionado(ob3);
            _app.modelo.chamarobjetivoadicionado(ob4);

        }

        private void btnNome_Click(object sender, RoutedEventArgs e)
        {
            WindowPerfil janela = new WindowPerfil();

            janela.ShowDialog();
        }

        private void mnEditarObj_Click(object sender, RoutedEventArgs e)
        {
            WindowVerObjetivos janela = new WindowVerObjetivos(_app.modelo.lista[listaobj.SelectedIndex]);
            janela.Title = "editar atividade";
            janela.ShowDialog();


        }
        private void removerObj_Click(object sender, RoutedEventArgs e)
        {
            Modelo_objetivo_eliminar(listaobj.SelectedIndex);
            //listaobj.Items.Remove(listaobj.SelectedItem);
            //app.modelo.lista.RemoveAt(Convert.ToInt32(listaobj.SelectedItem));
        }
        private void ver_Obj_Click(object sender, RoutedEventArgs e)
        {
            vizualizarOBJ janela = new vizualizarOBJ(_app.modelo.lista[listaobj.SelectedIndex]);
            janela.ShowDialog();
        }

    }

}