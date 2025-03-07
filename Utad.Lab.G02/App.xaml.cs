using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Utad.Lab.G02.Model;
using Utad.Lab.G02.ViewModels;

namespace Utad.Lab.G02
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //Views
        public WindowAddAtividade Atividade { get; set; }
        public WindowDefObjetivo Obj { get; set; }
        public WindowAdicionar Calcado { get; set; }

        public WindowDadosEstatisticos DadosEstat { get; set; }

        //Models
        public GestorAtividade Gestor { get; set; }
        public Dados M_Dados { get; private set; }
        public Modelo modelo { get; set; }
        public App()
        {
            //Instanciar as models
            Gestor = new GestorAtividade();
            M_Dados = new Dados();
             modelo = new Modelo();
            //Instanciar as views
            Atividade = new WindowAddAtividade();
            Calcado = new WindowAdicionar();
            DadosEstat = new WindowDadosEstatisticos();

            Obj = new WindowDefObjetivo();
            modelo = new Modelo();

            modelo = new Modelo();
        }


    }

}
