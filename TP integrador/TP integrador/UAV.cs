using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_integrador
{
    internal class UAV : Operador
    {
        public UAV(EstadoOperador estado = EstadoOperador.GuardadoEnCuartel, double cargaMaxima = 5, double velocidadOptima = 250, string localizacionActual = "Cuartel")
        : base(new Bateria(4000), estado, cargaMaxima, velocidadOptima, localizacionActual)
        {
            
        }

        public override void VolverCuartelCargarBateria()
        {
            bateria.mAh = 4000;
            localizacionActual = "Cuartel";
            estado = EstadoOperador.GuardadoEnCuartel;
            Console.WriteLine($"El operador {id} se encuentra en {localizacionActual} y su carga de bateria actual es {bateria}");

        }
    }
}
