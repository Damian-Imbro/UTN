// Damian Imbrogiano
namespace TP_1._1B
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] metales = { "Hierro", "Oro", "Platino", "MetalesMisceláneos" };
            Universo universo = new Universo ();
            Asteroide asteriode = new Asteroide ();
            int[] totalMinadoEnTodosLosSistemas = new int[metales.Length];
            String respuesta = "1";
            Console.WriteLine("Bienvenido al programa de minería espacial");
            while (respuesta != "2")
            {
                Console.WriteLine("Presiona '1' para procesar un nuevo sistema o '2' para salir.");
                respuesta = Console.ReadLine();
                if (respuesta == "1")
                {
                    universo.InicializarUniverso();
                    asteriode.InicializarAsteriode(metales);
                    int[,] asteroidesEnElUniverso=universo.CrearAsteroidesEnElUniverso(asteriode);
                    asteriode.DetalleMinadoPorAsteriode(asteroidesEnElUniverso);
                    totalMinadoEnTodosLosSistemas= universo.acumularMinado(asteroidesEnElUniverso, totalMinadoEnTodosLosSistemas);
                }
            }
            universo.TotalMinado(totalMinadoEnTodosLosSistemas, metales);
        }
    }
}