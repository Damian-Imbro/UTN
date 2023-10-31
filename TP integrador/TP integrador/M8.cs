using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_integrador
{
    internal class M8:Operador
    {
        public M8 (int bateria = 12250, EstadoOperador estado = EstadoOperador.GuardadoEnCuartel, double cargaMaxima = 250, double velocidadOptima = 5, string localizacionActual = "Cuartel")
        : base(bateria, estado, cargaMaxima, velocidadOptima, localizacionActual)
        {
        }

        public override void VolverCuartelCargarBateria()
        {
            bateria = 12250;
            localizacionActual = "Cuartel";
            estado = EstadoOperador.GuardadoEnCuartel;
            Console.WriteLine($"El operador {id} se encuentra en {localizacionActual} y su carga de bateria actual es {bateria}");
        }
    }
}
