using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_integrador.Operadores
{
    internal class UAV : Operador
    {
        public double CargaMaxima { get; set; } = 5;
        public double VelocidadOptima { get; set; } = 250;


        public UAV()
        {

        }

        
    }
}
