using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Utad.Lab.G02.Model;

namespace Utad.Lab.G02.ViewModels
{
    public class Dados
    {
        public GestorCalçado GestCalcado { get; private set; } = new GestorCalçado();

        public delegate void aceitarCalcado(Calçado cal);
        public delegate void Erro(string mensagem);

        public event aceitarCalcado calcado_adicionado;
        public event aceitarCalcado calcado_editado;
        public event Erro erros;

        public void erro(string mensagem)
        {
            MessageBox.Show(mensagem, "ERRO",MessageBoxButton.OK,MessageBoxImage.Error);
        }
        public void EditCalcado(Calçado calcado)
        {
            calcado_editado(calcado);
        }
        public void AddCalcado(Calçado calcado)
        {
            calcado_adicionado(calcado);
        }
    }
}
