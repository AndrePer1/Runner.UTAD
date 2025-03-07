using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Xml.Linq;

namespace Utad.Lab.G02.Model
{
    public class Perfil
    {
        private string nome;
        private string sexo;
        private DateTime dtNasc;
        private BitmapImage? fotografia;
        public string? FotografiaPath { get; set; }

        public Perfil()
        {
            nome = "";
            sexo = "";
            DateTime dtNasc = new DateTime();
            BitmapImage fotografia = new BitmapImage();
            FotografiaPath = "";
        }

        public Perfil(string nome, string sexo, string id, DateTime dtNasc, BitmapImage fotografia)
        {
            Nome = nome;
            Sexo = sexo;
            DtNasc = dtNasc;
            Fotografia = fotografia;
        }

        public string Nome
        {
            get => nome ; set => nome = value;
        }

        public string Sexo
        {
            get => sexo; set => sexo = value;
        }

        public DateTime DtNasc
        {
            get => dtNasc; set => dtNasc = value;
        }

        public BitmapImage Fotografia
        {
            get => fotografia; set => fotografia = value;
        }

        public XElement ToXML()
        {
            XElement no = new XElement("perfil");
            // atributos "simples" podem ser definidos como atributos do elemento
            no.Add(new XAttribute("nome", Nome));
            no.Add(new XAttribute("dataNascimento", DtNasc.Date.ToShortDateString()));
            no.Add(new XAttribute("fotografiaPath", FotografiaPath));
            no.Add(new XAttribute("sexo", Sexo)); 

            return no;
        }
    }
}
