using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_integrador.Operadores;

namespace TP_integrador.Daños
{
    internal class PinturaRayada : Daño
    {
        public PinturaRayada(string descripcion) : base(descripcion, TipoDaño.PinturaRayada)
        {
        }
        public override void AplicarDesperfecto(Operador operador)
        {
            Console.WriteLine("El operador tiene la pintura rayada");
        }
    }
}
