using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaJson
{
    internal class Direccion
    {
        public string Calle {  get; set; }
        public int Numero {  get; set; }
        public Provincia Ciudad {  get; set; }

        public Direccion(string calle, int numero, Provincia ciudad)
        {
            Calle = calle;
            Numero = numero;
            Ciudad = ciudad;
        }
    }
}
