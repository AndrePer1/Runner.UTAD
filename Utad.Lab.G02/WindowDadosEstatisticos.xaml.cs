using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Lógica interna para WindowDadosEstatisticos.xaml
    /// </summary>
    public partial class WindowDadosEstatisticos : Window
    {
        private App _app;
        private List<Atividade> atividades;
        public class Item
        {
            public float TotalKilometros { get; set; }
            public TimeSpan totalTempo { get; set; }
            public float QuilometroMaisRapido { get;set; } 
            public TimeSpan AtividadeMaisDemorada { get; set; }
            public string DezQuilometrosMaisRapidos { get; set; }
            public float AtividadeMaisLonga { get;set; }
        }
        public WindowDadosEstatisticos()
        {
            InitializeComponent();
            _app = App.Current as App;
            atividades = new List<Atividade>();
        }
        public List<Atividade> ObterAtividades()
        {
            return atividades;
        }
        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private List<float> DezKmRapidos(List<Atividade> atividades)
        {
            List<float> top10 = new List<float>();
            List<Atividade> ordenada = atividades.OrderBy(atividades => atividades.Ritmo).ToList();

            for(int i= 0;i<Math.Min(ordenada.Count,10);i++)
            {
                top10.Add(ordenada[i].Distancia);
            }
            return top10;
        }
        private float CalcularTotalKilometros(List<Atividade> atividades)
        {
            float totalKilometros = 0;
            foreach (var atividade in atividades)
            {
                totalKilometros += atividade.Distancia;
            }
            return totalKilometros;
        }
        private TimeSpan CalcularTempototal(List<Atividade> atividades)
        {
            TimeSpan TotalTempo = TimeSpan.Zero;
            foreach (var atividade in atividades)
            {
                TimeSpan duracao = atividade.Termino.Subtract(atividade.Inicio);
                TotalTempo += duracao;
            }
            return TotalTempo;
        }

        private float VerificarAtividadeMaisLonga(List<Atividade> atividades)
        {
            Atividade AtividadeMaisLonga = null;
            float Maiordistancia = 0;
            foreach(var atividade in atividades)
            {
                if(atividade.Distancia > Maiordistancia)
                {
                    Maiordistancia = atividade.Distancia;
                }
            }
            return Maiordistancia;
        }
        private TimeSpan VerAtividadeMaisDemorada(List<Atividade> atividades)
        {
            TimeSpan AtividadeMaisDemorada = TimeSpan.Zero;
            foreach(var atividade in atividades)
            {
                TimeSpan duracao = atividade.Termino.Subtract(atividade.Inicio);
                if (duracao > AtividadeMaisDemorada)
                {
                    AtividadeMaisDemorada = duracao;
                }
            }
            return AtividadeMaisDemorada;
        }
        private float VerificarQuilometroMaisRapido(List<Atividade> atividades)
        {
            float quilometroMaisRapido = float.MaxValue;
            foreach(var atividade in atividades)
            {
                if(atividade.Ritmo<quilometroMaisRapido)
                {
                    quilometroMaisRapido = atividade.Ritmo;
                }
            }
            return quilometroMaisRapido;
        }

        private DateTime VerDia(List<Atividade> atividades)
        {
            DateTime dia = DateTime.MinValue;
            foreach(var atividade in atividades)
            {
                dia = atividade.Termino; 
            }
            return dia;
        }
        public void AtualizarAtividades(List<Atividade> atividades)
        {
            this.atividades = atividades;
        }

        private void btnEscolher_Click(object sender, RoutedEventArgs e)
        {
            List<Atividade> atividades = _app.Gestor.ListAtividade;
            AtualizarAtividades(atividades);

            float totalkilometros = CalcularTotalKilometros(atividades);
            TimeSpan TotalTempo = CalcularTempototal(atividades);
            float AtividadeLonga = VerificarAtividadeMaisLonga(atividades);
            float QuilometroMaisLongo = VerificarAtividadeMaisLonga(atividades);
            DateTime DiaAtividade = VerDia(atividades);
            TimeSpan AtividadeMaisDemorada = VerAtividadeMaisDemorada(atividades);
            List<float> DezKmMaisRapidos = DezKmRapidos(atividades);

            string elemento = string.Join(";", DezKmMaisRapidos);

            DateTime primeirodia = Calendario.SelectedDates.First();
            DateTime ultimodia = Calendario.SelectedDates.Last();

            if (primeirodia <= DiaAtividade && ultimodia >= DiaAtividade)
            {
                Item dado = new Item
                {
                    TotalKilometros = totalkilometros,
                    totalTempo = TotalTempo,
                    AtividadeMaisLonga = AtividadeLonga,
                    QuilometroMaisRapido = QuilometroMaisLongo,
                    AtividadeMaisDemorada = AtividadeMaisDemorada,
                    DezQuilometrosMaisRapidos = elemento
                };
                lvDados.Items.Clear();
                lvDados.Items.Add(dado);
            }
            else
            {
                _app.M_Dados.erro("Não tem atividades realizadas nessa data");
            }
        }
    }
}
