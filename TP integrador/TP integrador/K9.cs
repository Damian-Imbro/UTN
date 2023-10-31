using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_integrador
{
    internal class K9:Operador
    {
        public K9 (int bateria = 6500, EstadoOperador estado = EstadoOperador.GuardadoEnCuartel, double cargaMaxima = 40, double velocidadOptima = 20, string localizacionActual = "Cuartel")
        : base(bateria, estado, cargaMaxima, velocidadOptima, localizacionActual)
        {
        }

        public override void VolverCuartelCargarBateria()
        {
            bateria = 6500;
            localizacionActual = "Cuartel";
            estado = EstadoOperador.GuardadoEnCuartel;
            Console.WriteLine($"El operador {id} se encuentra en {localizacionActual} y su carga de bateria actual es {bateria}");
        }
    }
}
