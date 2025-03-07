using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Utad.Lab.G02.Model
{
    public class TipoRegistoFisico : Tipo 
    {
        public string unidade;

        public TipoRegistoFisico() 
        { 
            unidade = string.Empty;
            id = 000;
            nome = "";
        }

        public TipoRegistoFisico(string unidade, int id, string nome)
        {
            Unidade = unidade;
            Id = id;
            Nome = nome;
        }

        public string Unidade
        {
            get => unidade; set => unidade = value;
        }

        public new XElement ToXML()
        {
            XElement no = new XElement("tipoRegistoFisico");
            no.Add(new XAttribute("id", Id));
            no.Add(new XAttribute("nome", Nome));
            no.Add(new XAttribute("unidade", Unidade));

            return no;
        }
    }
}
