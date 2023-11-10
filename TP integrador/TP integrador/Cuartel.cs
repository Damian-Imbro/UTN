namespace TP_integrador
{
    public class Cuartel:Localizacion
    {
        public List<Operador> listaOperadores = new List<Operador>();
        public static int filaMapa;
        public static int columnaMapa;

        

        public Cuartel(int filaMapa, int columnaMapa):base("Cuartel", "Un punto de control donde los operadores pueden recargar batería o ser reparados. Pueden existir varios, pero nunca más de 3.")
        {
            filaMapa = Cuartel.filaMapa;
            columnaMapa = Cuartel.columnaMapa;
        }

        public void ListarTodosLosOperadores()
        {
            foreach (Operador operador in listaOperadores)
            {
                operador.ImprimerReporteGeneral();
            }
        }

        public void ListarOperadoresEnUnaLocalizacion(int[] coordenadas)
        {
            int contador = 0;
            foreach (Operador operador in listaOperadores)
            {
                if (operador.coordenadasEnElMapa==coordenadas)
                {
                    operador.ImprimerReporteGeneral();
                    contador++;
                }
            }
            if (contador == 0) { Console.WriteLine($"No hay ningún operador en las coordenadas {coordenadas[0]} - {coordenadas[1]}");}
        }

        public void VolverTodosAlCuertel()
        {
            foreach (Operador operador in listaOperadores)
            {
                int[] coordenadasCuertel = { Cuartel.filaMapa, Cuartel.columnaMapa };
                if (!(operador.coordenadasEnElMapa==coordenadasCuertel)) {operador.Moverse(coordenadasCuertel);}
            }
        }

        public void enviarOperador(Operador operador, int[] coordenadas)
        {
            operador.Moverse(coordenadas);
        }
    }
}
