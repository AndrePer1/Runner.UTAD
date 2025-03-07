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
    /// Lógica interna para WindowAddAtividade.xaml
    /// </summary>
    public partial class WindowAddAtividade : Window
    {
        public Atividade act { get; private set; }
        public int duracaoMin = 0;
        


        public App _app;

        public WindowAddAtividade()
        {
            InitializeComponent();
            act = new Atividade();
            _app = App.Current as App;

            cbTipo.Items.Add(new TipoAtividade(1, "Corrida"));
            cbTipo.Items.Add(new TipoAtividade(2, "Caminhada"));

            cbCalc.ItemsSource = _app.M_Dados.GestCalcado.ListCalcado;
            
        }

       

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        
        private void btnConcluido_Click(object sender, RoutedEventArgs e)
        {
            int ax;
            float aux;
            if (string.IsNullOrEmpty(tbDescri.Text) || string.IsNullOrEmpty(tbPerc.Text) || string.IsNullOrEmpty(cbTipo.Text) || string.IsNullOrEmpty(dtInicio.Text) ||
                (string.IsNullOrEmpty(tbHorasFim.Text) && string.IsNullOrEmpty(tbMinutosFim.Text) && string.IsNullOrEmpty(dtFim.Text)) ||
                (string.IsNullOrEmpty(tbHorasInicio.Text) && string.IsNullOrEmpty(tbMinutosInicio.Text) && string.IsNullOrEmpty(dtInicio.Text)))
            {
                _app.M_Dados.erro("Insira todos os dados da atividade!");

            }
            else if (float.TryParse(tbPerc.Text, out aux) == false)
            {
                _app.M_Dados.erro("Kilometros percorridos tem de ser um número!");
            }
            else if (int.TryParse(tbHorasInicio.Text, out ax) == false || int.TryParse(tbMinutosInicio.Text, out ax) == false ||
                int.TryParse(tbHorasFim.Text, out ax) == false || int.TryParse(tbMinutosFim.Text, out ax) == false)
            {
                _app.M_Dados.erro("Insira as horas da atividade corretamente!");
            }
            else if (float.Parse(tbRitmo.Text) < 0)
            {
                _app.M_Dados.erro("Duraçao ou kilómetros percorridos da atividade não são validos, adicione a atividade novamente!");
            }
            else if (cbNo.IsChecked == true && cbYes.IsChecked == true)
            {
                _app.M_Dados.erro("Selecione apenas uma opção no parâmetro calçado.");
            }
            else if(cbYes.IsChecked == true && string.IsNullOrEmpty(cbCalc.Text))
            {
                _app.M_Dados.erro("Selecione o calçado.");
            }
            else
            {
                act.Descricao = tbDescri.Text;
                act.Inicio = new DateTime(dtInicio.SelectedDate.Value.Year, dtInicio.SelectedDate.Value.Month, dtInicio.SelectedDate.Value.Day, Convert.ToInt32(tbHorasInicio.Text), Convert.ToInt32(tbMinutosInicio.Text), 0);
                act.Termino = new DateTime(dtFim.SelectedDate.Value.Year, dtFim.SelectedDate.Value.Month, dtFim.SelectedDate.Value.Day, Convert.ToInt32(tbHorasFim.Text), Convert.ToInt32(tbMinutosFim.Text), 0);
                act.TipoAtividade = cbTipo.SelectedItem as TipoAtividade;
                act.Distancia = float.Parse(tbPerc.Text);
                TimeSpan intervaloTempo = act.Termino - act.Inicio;

                if (intervaloTempo.Hours > 0 || intervaloTempo.Days > 0)
                    duracaoMin = intervaloTempo.Days * 1440 + intervaloTempo.Hours * 60 + intervaloTempo.Minutes;
                else
                    duracaoMin = intervaloTempo.Minutes;

                act.Ritmo = duracaoMin / float.Parse(tbPerc.Text);
                //if (act.Ritmo < 0 )
                //{
                //    _app.M_Dados.erro("Duraçao ou kilómetros percorridos da atividade não são validos, adicione a atividade novamente!");
                //    return;
                //}
                

                if (cbYes.IsChecked == true)
                {
                    if (cbCalc.SelectedItem != null)
                    {

                        float n;
                        act.Calçado = cbCalc.SelectedItem as Calçado;
                       
                        if (act.Distancia > act.Calçado.KiloDispo)
                        {
                            _app.M_Dados.erro("Calçado selecionado já se encontra demasiado gasto para a atividade que pretende registar!");
                            return;

                        }

                        n = _app.M_Dados.GestCalcado.ListCalcado[cbCalc.SelectedIndex].KiloDispo - act.Distancia;
                        _app.M_Dados.GestCalcado.ListCalcado[cbCalc.SelectedIndex].KiloDispo = n;                                                  
                    }
                }
                else
                    act.Calçado = null;

      
                DialogResult = true;
                _app.Gestor.AtividadeAdd(act);


            }
        }

        private void tbRitmo_TextChanged(object sender, TextChangedEventArgs e)
        {
            DateTime Inicio = new DateTime(dtInicio.SelectedDate.Value.Year, dtInicio.SelectedDate.Value.Month, dtInicio.SelectedDate.Value.Day, Convert.ToInt32(tbHorasInicio.Text), Convert.ToInt32(tbMinutosInicio.Text), 0);
            DateTime Fim = new DateTime(dtFim.SelectedDate.Value.Year, dtFim.SelectedDate.Value.Month, dtFim.SelectedDate.Value.Day, Convert.ToInt32(tbHorasFim.Text), Convert.ToInt32(tbMinutosFim.Text), 0);
            TimeSpan intervaloTempo = new TimeSpan();
            intervaloTempo = Fim - Inicio;
            if (intervaloTempo.Hours > 0 || intervaloTempo.Days > 0)
                duracaoMin = intervaloTempo.Days * 1440 + intervaloTempo.Hours * 60 + intervaloTempo.Minutes;
            else
                duracaoMin = intervaloTempo.Minutes;
            
            if (float.TryParse(tbPerc.Text, out float n))
            {
                float rit = duracaoMin / float.Parse(tbPerc.Text);
                tbRitmo.Text = rit.ToString();
            }
            else
            {
                tbRitmo.Text = "";
            }
            
        }

    }
}
