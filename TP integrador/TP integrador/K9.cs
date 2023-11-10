using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_integrador
{
    public class K9:Operador
    {
        
        public K9 (double cargaMaxima = 40, double velocidadOptima = 20)
        : base(new Bateria(6500), cargaMaxima, velocidadOptima)
        {
            
        }

        public override void VolverCuartelCargarBateria()
        {
            bateria.mAh = 6500;
            int[] coordenadasCuartel;
            coordenadasEnElMapa[0] = Cuartel.filaMapa;
            coordenadasEnElMapa[1] = Cuartel.columnaMapa;
            estado = EstadoOperador.GuardadoEnCuartel;
            Console.WriteLine($"El operador {id} se encuentra en las coordenadas {coordenadasEnElMapa[0]} - {coordenadasEnElMapa[1]} y su carga de bateria actual es {bateria}");
        }
    }
}
