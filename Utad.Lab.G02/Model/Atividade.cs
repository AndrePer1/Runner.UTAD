using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Utad.Lab.G02.Model
{
    public class Atividade
    {
        private TipoAtividade tipoAtividade;
        private string descricao;
        private DateTime inicio;
        private DateTime termino;
        private float distancia;
        private Calçado? calçado;
        private float ritmo;

        public Atividade() 
        {
            TipoAtividade b = new TipoAtividade();
            Calçado a = new Calçado();
            tipoAtividade = b;
            descricao = string.Empty;
            inicio = new DateTime();
            termino = new DateTime();
            distancia = 0;
            calçado = a;
            ritmo = 0;
        }

        public Atividade(TipoAtividade tipoAtividade, string descricao, DateTime inicio, DateTime termino,float distancia,Calçado calçado,float ritmo)
        {
            TipoAtividade=tipoAtividade;
            Descricao=descricao;
            Inicio=inicio;
            Termino=termino;
            Distancia = distancia;
            Ritmo = ritmo;
        }

        public TipoAtividade TipoAtividade
        {
            get => tipoAtividade;
            set => tipoAtividade = value;
        }

        public string Descricao
        {
            get => descricao;
            set => descricao = value;
        }

        public DateTime Inicio
        { get => inicio; set => inicio = value;}

        public DateTime Termino
        {
            get => termino;
            set => termino = value;
        }

        public float Distancia
        {
            get => distancia;
            set => distancia = value;
        }

        public Calçado Calçado
        {
            get => calçado;
            set => calçado = value;
        }

        public float Ritmo
        {
            get => ritmo;
            set => ritmo = value;
        }
    }
}
