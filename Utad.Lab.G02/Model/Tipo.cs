using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Windows.Documents;
using System.Xml.Linq;

namespace Utad.Lab.G02.Model
{
    public class Tipo
    {
        protected int id;
        protected string nome;

        public Tipo()
        {
         
            id = 0;
            nome = "";
        }

        public Tipo(int id, string nome)
        {
            List<int> list = new List<int>();
            Random numal = new Random();
            do
            {
                id = numal.Next(1, 200);

                if (!list.Contains(id))
                {
                    list.Add(id);
                    break;
                }
            } while (true);

            Nome = nome;
        }

        public int Id
        {
            get => id;
            set => id = value;
        }

        public string Nome
        {
            get => nome;
            set => nome = value;
        }

        public override string ToString() //Compor o nome na ComboBox da janela atividade
        {
            return Nome;
        }

        public XElement ToXML()
        {
            XElement no = new XElement("tipo");
            no.Add(new XAttribute("id", Id));
            no.Add(new XAttribute("nome", Nome));

            return no;
        }
    }
}
