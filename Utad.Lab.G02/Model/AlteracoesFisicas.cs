using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Linq;

namespace Utad.Lab.G02.Model
{
    public class AlteracoesFisicas
    {
        private float valor;
        private TipoRegistoFisico tipoRegistoFisico;
        private DateTime data;

       
        public AlteracoesFisicas(float valor, TipoRegistoFisico tipoRegistoFisico, DateTime data)
        {
            Valor = valor;
            TtipoRegistoFisico = tipoRegistoFisico;
            Data = data;
        }

        public AlteracoesFisicas() { }


        public float Valor
        {
            get => valor;
            set => valor = value;
        }

        public TipoRegistoFisico TtipoRegistoFisico
        {
            get => tipoRegistoFisico;
            set => tipoRegistoFisico = value;
        }

        public DateTime Data
        {
            get => data; 
            set => data = value;
        }

        public XElement ToXML()
        {
            XElement no = new XElement("alteracaoFisica");
            no.Add(new XAttribute("valor", Valor));
            no.Add(new XAttribute("data", Data.Date.ToShortDateString()));
            no.Add(TtipoRegistoFisico.ToXML());

            return no;
        }
    }
}
