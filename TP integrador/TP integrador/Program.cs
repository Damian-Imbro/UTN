using System.Reflection.PortableExecutable;

namespace TP_integrador
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int filasMapa = 10;
            int columnasMapa = 10;
            Mapa mapa = new Mapa(filasMapa, columnasMapa);
            for (int fila = 0; fila < filasMapa; fila++)
            {
                for (int columna = 0; columna < columnasMapa; columna++)
                {
                    string localizacion=Convert.ToString(mapa.mapa[fila, columna].localizacion);
                    Console.Write("["+localizacion.Substring(0,4)+"]");
                }
                Console.WriteLine();
            }
        }
    }
}