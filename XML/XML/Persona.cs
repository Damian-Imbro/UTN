using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML
{
    [Serializable]
    public class Persona
    {
        public string nombre;
        public string direccion;
        public int edad;
        public Auto auto;

        public Persona()
        {
        }

       public Persona(string nombre, string direccion, int edad, Auto auto)
         {
             this.nombre = nombre;
             this.direccion = direccion;
             this.edad = edad;
             this.auto = auto;
         }
        

    }
}
