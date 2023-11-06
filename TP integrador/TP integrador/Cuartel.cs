using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_integrador
{
    internal class Cuartel:Localizacion
    {
        public List<Operador> listaOperadores = new List<Operador>();
        int filaMapa;
        int columnaMapa;

        public Cuartel(int filaMapa, int columnaMapa):base("Cuartel", "Un punto de control donde los operadores pueden recargar batería o ser reparados. Pueden existir varios, pero nunca más de 3.")
        {
            this.filaMapa = filaMapa;
            this.columnaMapa = columnaMapa;
        }

        public void ListarTodosLosOperadores()
        {
            foreach (Operador operador in listaOperadores)
            {
                operador.ImprimerReporteGeneral();
            }
        }

        public void ListarOperadoresEnUnaLocalizacion(string localizacion)
        {
            int contador = 0;
            foreach (Operador operador in listaOperadores)
            {
                if (operador.localizacionActual.Equals(localizacion))
                {
                    operador.ImprimerReporteGeneral();
                    contador++;
                }
            }
            if (contador == 0) { Console.WriteLine($"No hay ningún operador en {localizacion}");}
        }

        public void VolverTodosAlCuertel()
        {
            foreach (Operador operador in listaOperadores)
            {
                if (!operador.localizacionActual.Equals("Cuartel")){operador.Moverse("Cuartel");}
            }
        }

        public void enviarOperador(Operador operador, String localizacion)
        {
            operador.Moverse(localizacion);
        }


    }
}
