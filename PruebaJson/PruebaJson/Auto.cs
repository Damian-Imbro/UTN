using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaJson
{
    internal class Auto
    {
        public string Marca {  get; set; }
        public string Modelo { get; set;}

        public Auto(string marca, string modelo)
        {
            this.Marca = marca;
            this.Modelo = modelo;
        }
    }
}
