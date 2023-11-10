using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_integrador
{
    public class M8:Operador
    {
        

        public M8 (double cargaMaxima = 250, double velocidadOptima = 5)
        : base(new Bateria(12250), cargaMaxima, velocidadOptima )
        {
           
        }

        public override void VolverCuartelCargarBateria()
        {
            bateria.mAh = 12250;
            int[] coordenadasCuartel;
            coordenadasEnElMapa[0] = Cuartel.filaMapa;
            coordenadasEnElMapa[1] = Cuartel.columnaMapa;
            estado = EstadoOperador.GuardadoEnCuartel;
            Console.WriteLine($"El operador {id} se encuentra en las coordenadas {coordenadasEnElMapa[0]} - {coordenadasEnElMapa[1]} y su carga de bateria actual es {bateria}");
        }
    }
}
