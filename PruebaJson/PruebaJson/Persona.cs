using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaJson
{
    internal class Persona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set;}
        public Direccion Direccion { get; set; }
        public static List<Auto> Autos { get; set; }

        public Persona(string nombre, string apellido, Direccion direccion)
        {
            Nombre = nombre;
            Apellido = apellido;
            this.Direccion = direccion;
            
        }
    }

}
