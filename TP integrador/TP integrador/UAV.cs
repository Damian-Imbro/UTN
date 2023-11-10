using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_integrador
{
    internal class UAV : Operador
    {
        
        public UAV(double cargaMaxima = 5, double velocidadOptima = 250)
        : base(new Bateria(4000), cargaMaxima, velocidadOptima)
        {
            
        }

        public override void VolverCuartelCargarBateria()
        {
            bateria.mAh = 4000;
            int[] coordenadasCuartel;
            coordenadasEnElMapa[0] = Cuartel.filaMapa;
            coordenadasEnElMapa[1] = Cuartel.columnaMapa;
            estado = EstadoOperador.GuardadoEnCuartel;
            Console.WriteLine($"El operador {id} se encuentra en las coordenadas {coordenadasEnElMapa[0]} - {coordenadasEnElMapa[1]} y su carga de bateria actual es {bateria}");
        }
    }
}
