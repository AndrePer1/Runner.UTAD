using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Utad.Lab.G02.Model
{
    public class Calçado
    {
        private int id;
        private string marca;
        private string modelo;
        private string cor;
        private float limitKilo;
        private float kiloDispo;
        private DateTime dataCompra;
        private bool inativo; 

        public Calçado()
        {
            id = 00000;
            marca = "";
            modelo = "";
            cor = "";
            limitKilo = 0;
            kiloDispo = 0;
            dataCompra = new DateTime();
            inativo = true;
        }

        public Calçado(int id, string marca, string modelo, string cor, float limitKilo, float kiloDispo, DateTime dataCompra, bool inativo)
        {
            Id = id;
            Marca = marca;
            Modelo = modelo;
            Cor = cor;
            LimitKilo = limitKilo;
            KiloDispo = kiloDispo;
            DataCompra = dataCompra;
            Inativo = inativo;
        }

        public int Id { get => id; set => id = value; }

        public string Marca { get => marca; set => marca = value; }

        public string Modelo { get => modelo; set => modelo = value; }

        public string Cor { get => cor; set => cor = value; }

        public DateTime DataCompra { get => dataCompra; set => dataCompra = value; }

        public float LimitKilo { get => limitKilo; set => limitKilo = value; }

        public float KiloDispo { get => kiloDispo; set => kiloDispo = value; }
       
        public bool Inativo { get => inativo; set => inativo = value; }


        public override string ToString()
        {
            return Marca + ","  +  Modelo + " - " + Cor;
        }
    }
}
