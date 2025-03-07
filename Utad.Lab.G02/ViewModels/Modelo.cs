using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Xml.Linq;
using Utad.Lab.G02.Model;

namespace Utad.Lab.G02
{ 
    public class Modelo
    { 
        public List<Objetivo> lista { get; set; }
        public PerfilFoto MyPerfilFoto { get; private set; } = new PerfilFoto();
        public Perfil MyPerfil { get; private set; } = new Perfil();

        public AlteracoesFisicas Altura { get; private set; } = new AlteracoesFisicas();
        
        public List<TipoRegistoFisico> TiposRegistoFisico { get; private set; }
        public List<AlteracoesFisicas> AlteracaoFisica { get; private set; } = new List<AlteracoesFisicas>();

        public delegate void eleminarobj(int a);
        public delegate void eventosqueaceitemobjetivos(Objetivo objetivo);
        public event eventosqueaceitemobjetivos objetivo_adicionado;
        public event eventosqueaceitemobjetivos edit;
        public event eleminarobj objetivo_eliminar;

        private string _caminhoBase;
        private string _caminhoTotal;
        private string _caminhoFotos;

        public delegate void MetodoSemParametros();
        public delegate void MetodosComString(string str);
        public delegate void MetodoComFloat(float valor);
        public delegate void MetodoComPerfil(Perfil perfil);

        public event MetodoSemParametros? PerfilFotoCarregada;
        public event MetodosComString? PerfilFotoGuardada;
        public event MetodoSemParametros PerfilAlterado;
        public event MetodoSemParametros AlteracaoFisicaAdicionada;
        public event MetodosComString TextoInvalido;
        public event MetodoComFloat TextoValido;
        public void chamarobjetivoadicionado (Objetivo objetivo)
        { 
            objetivo_adicionado(objetivo); 
        }

       

        public void elemiminar_objetivo(int a)
        {
            objetivo_eliminar(a);
        }
        public void edit_obj(Objetivo objetivo)
        {
            edit(objetivo);
        }

        public Modelo() 
        { 
            lista = new List<Objetivo>();

            _caminhoBase = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            if(Directory.Exists(System.IO.Path.Combine(_caminhoBase, "MyApp")) == false)
            {
                Directory.CreateDirectory(System.IO.Path.Combine(_caminhoBase, "MyApp"));
            }
            _caminhoTotal = System.IO.Path.Combine(_caminhoBase, "MyApp");

            if (Directory.Exists(System.IO.Path.Combine(_caminhoTotal, "Imagens")) == false)
            {
                Directory.CreateDirectory(System.IO.Path.Combine(_caminhoTotal, "Imagens"));
            }

            _caminhoFotos = System.IO.Path.Combine(_caminhoTotal, "Imagens");

            TiposRegistoFisico = new List<TipoRegistoFisico>();
            
            //XDocument doc2 = XDocument.Load("TiposRegistosFisicos.xml");
            //foreach (XElement no in doc2.Root.Elements("tipoRegistoFisico"))
            //{
            //    TipoRegistoFisico tipo = new TipoRegistoFisico();
            //    tipo.Id = Int32.Parse(no.Attribute("id").Value);
            //    tipo.Nome = no.Attribute("nome").Value;
            //    tipo.Unidade = no.Attribute("unidade").Value;

            //    TiposRegistoFisico.Add(tipo);
            //}

        }

        public void carregarObjetivo(Objetivo objetivo)
        {
            lista.Add(objetivo);
        }

        public void _LoadSemFoto()
        {
            var uri = new Uri("pack://application:,,,/Imagens/profilee.png");
            MyPerfilFoto.Fotografia = new BitmapImage(uri);
            MyPerfilFoto.Fotografia.Freeze();

            MyPerfilFoto.Ficheiro = "[sem foto]";
        }

        public void LoadFoto(string ficheiro)
        {
            if (File.Exists(System.IO.Path.Combine(_caminhoTotal, ficheiro)) != false)
            {
                XDocument doc1 = XDocument.Load(System.IO.Path.Combine(_caminhoTotal, "dados.xml"));
                string nomeFoto = doc1.Element("perfil").Attribute("fotografia").Value;

                var uri = new Uri(System.IO.Path.Combine(_caminhoFotos, nomeFoto));
                MyPerfilFoto.Fotografia = new BitmapImage(uri);
                MyPerfilFoto.Fotografia.Freeze();

                MyPerfilFoto.Ficheiro = ficheiro;
            }
            else
            {
                _LoadSemFoto();
            }

            if (PerfilFotoCarregada != null)
            {
                PerfilFotoCarregada();
            }
        }


        public void LoadFromXML(string ficheiro)
        {

            //'C:\Users\pedro\source\repos\PL4_G02\Utad.Lab.G02\bin\Debug\net7.0-windows\dados.xml'.'

            XDocument doc2 = XDocument.Load(System.IO.Path.Combine(_caminhoTotal, ficheiro));
            
            MyPerfil = new Perfil();
            MyPerfil.Nome = doc2.Root.Element("perfil").Attribute("nome").Value;
            MyPerfil.DtNasc = DateTime.Parse(doc2.Root.Element("perfil").Attribute("dataNascimento").Value);
            MyPerfil.FotografiaPath = doc2.Root.Element("perfil").Attribute("fotografiaPath").Value;
            MyPerfil.Sexo = doc2.Root.Element("perfil").Attribute("sexo").Value;

            
            MyPerfil.Fotografia = new BitmapImage(new Uri(System.IO.Path.Combine(_caminhoTotal, MyPerfil.FotografiaPath), UriKind.RelativeOrAbsolute));
            MyPerfil.Fotografia.Freeze();

            if(PerfilAlterado != null)
            {
                PerfilAlterado();
            }


            AlteracaoFisica = new List<AlteracoesFisicas>();
            foreach (XElement no in doc2.Root.Elements("alteracoesFisicas").Elements("alteracaoFisica"))
            {
                AlteracoesFisicas alteracao = new AlteracoesFisicas();
                alteracao.Valor = float.Parse(no.Attribute("valor").Value);
                alteracao.Data = DateTime.Parse(no.Attribute("data").Value);

                TipoRegistoFisico tipo = new TipoRegistoFisico();
                tipo.Id = Int32.Parse(no.Element("tipoRegistoFisico").Attribute("id").Value);
                tipo.Nome = no.Element("tipoRegistoFisico").Attribute("nome").Value;
                tipo.Unidade = no.Element("tipoRegistoFisico").Attribute("unidade").Value;

                alteracao.TtipoRegistoFisico = tipo;
                AlteracaoFisica.Add(alteracao);
            }

            if(AlteracaoFisicaAdicionada != null)
            {
                AlteracaoFisicaAdicionada();
            }

        }

        public void GuardarFoto(string ficheiro)
        {
            string NomeFoto = System.IO.Path.GetFileName(ficheiro);
            File.Copy(ficheiro, System.IO.Path.Combine(_caminhoFotos, NomeFoto), true);

            //XDocument doc1 = new XDocument(); 
            //doc1.Add(new XElement ("perfil", new XAttribute ("fotografia", NomeFoto)));
            //doc1.Save(System.IO.Path.Combine(_caminhoTotal, "dados.xml"));

            //LoadFromXML("dados.xml");


            if (PerfilFotoGuardada != null)
            {
                PerfilFotoGuardada(System.IO.Path.Combine(_caminhoFotos, NomeFoto));
            }

            MyPerfil.FotografiaPath = ficheiro;
        }
        
        
        public void SaveToXML(string ficheiro)
        {
            string NomeFoto = System.IO.Path.GetFileName(ficheiro);
            File.Copy(ficheiro, System.IO.Path.Combine(_caminhoFotos, NomeFoto), true);

            XDocument doc2 = new XDocument(new XElement("dados"));
            doc2.Element("dados").Add(MyPerfil.ToXML());

            XElement novoNo = new XElement("alteracoesFisicas");

            foreach (AlteracoesFisicas a in AlteracaoFisica)
            {
                novoNo.Add(a.ToXML());
            }
            doc2.Element("dados").Add(novoNo);

            doc2.Save(System.IO.Path.Combine(_caminhoTotal, NomeFoto));
        }

        public void EditarPerfil(Perfil perfil)
        {
            MyPerfil = perfil;
        }

        public void EditarAltura(AlteracoesFisicas altura)
        {
            Altura = altura;
        }

        public void AdicionaAlteracaoFisica(AlteracoesFisicas alteracao)
        {
            AlteracaoFisica.Add(alteracao);

            if(AlteracaoFisicaAdicionada != null)
            {
                AlteracaoFisicaAdicionada();
            }
        }

        public void ValidarTexto(string texto)
        {
            float valor;
            
            if(texto != null)
            {
                if(float.TryParse(texto, out valor))
                {
                    TextoValido(valor);
                }
                else
                {
                    //MessageBox.Show("Este campo tem de ter um valor numérico !", "Valor errado", MessageBoxButton.OK, MessageBoxImage.Error);
                    TextoInvalido("Este campo tem de ter um valor numérico !");
                }
            }
            else
            {
                TextoInvalido("Tem de preencher todos os campos !");
            }
        }
    }
}