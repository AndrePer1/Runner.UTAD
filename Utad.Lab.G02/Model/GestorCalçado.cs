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
    public class GestorCalçado
    {
        private List<Calçado> listCalcado;

        public List<Calçado> ListCalcado
        {
            get => listCalcado;
            set => listCalcado = value;
        }

        public GestorCalçado()
        {
            listCalcado = new List<Calçado>();

        }

        public void AdicionarCalcado(int id, string marca, string modelo, string cor, float limitKilo, DateTime dataCompra, bool inativo)
        {
            Calçado calc = new Calçado();
            calc.Id = id;
            calc.Marca = marca;
            calc.Modelo = modelo;
            calc.Cor = cor;
            calc.LimitKilo = limitKilo;
            calc.DataCompra = dataCompra;
            calc.Inativo = inativo;

            listCalcado.Add(calc);
        }

        public void RemoverAtividade(int id, string marca, string modelo, string cor, float limitKilo, DateTime dataCompra, bool inativo)
        {
            Calçado calc = new Calçado();
            calc.Id = id;
            calc.Marca = marca;
            calc.Modelo = modelo;
            calc.Cor = cor;
            calc.LimitKilo = limitKilo;
            calc.DataCompra = dataCompra;
            calc.Inativo = inativo;

            listCalcado.Remove(calc);
        }
    }
}
