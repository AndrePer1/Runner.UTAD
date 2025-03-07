using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Utad.Lab.G02.Model
{
    public class Objetivo
    {
        public string Nome { get; set; }
        private Tipo tipoObjetivo;
        private float meta;
        private DateTime? dataLimite;
        private DateTime dataAlcance;

        public Objetivo()
        {
            Tipo a = new Tipo();
            tipoObjetivo = a;
            meta = 0;
            dataLimite = new DateTime();
            dataAlcance = new DateTime();
        }
        public Objetivo(String nome, Tipo tipoObjetivo, float meta)
        {
            Nome = nome;
            TipoObjetivo = tipoObjetivo;
            Meta = meta;
            //comentario
        }
        public Objetivo(String nome ,Tipo tipoObjetivo, float meta, DateTime dataLimite)
        {
            Nome = nome;
            TipoObjetivo = tipoObjetivo;
            Meta = meta;
            DataLimite = dataLimite;
        }

        public Tipo TipoObjetivo { get => tipoObjetivo;set => tipoObjetivo = value; } 
        public float Meta { get => meta; set => meta = value; }
        public DateTime ?DataLimite { get => dataLimite; set => dataLimite = value; }
        public DateTime DataAlcance { get => dataAlcance; set => dataAlcance = value; }

    }
}
