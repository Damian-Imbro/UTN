using System;
using System.IO;
using Newtonsoft.Json;

namespace TP_integrador
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mapa mapa = CrearMapa();
            MotrarMapaEnConsola(mapa);
            GuardarMapa(mapa, "mapa1.json");
            Mapa mapa2 = CrearMapa();
            MotrarMapaEnConsola(mapa2);
            GuardarMapa(mapa2, "mapa2.json");

            Mapa mapa3 = RecuperarMapaDesdeJSON("mapa1.json");
            MotrarMapaEnConsola(mapa3);
        }

        private static void GuardarMapa(Mapa mapa, string nombreArchivo)
        {
            GuardarMapaEnJSON(mapa, nombreArchivo);
        }

        private static void MotrarMapaEnConsola(Mapa mapa)
        {
            for (int fila = 0; fila < mapa.mapa.GetLength(0); fila++)
            {
                for (int columna = 0; columna < mapa.mapa.GetLength(1); columna++)
                {
                    string localizacion = Convert.ToString(mapa.mapa[fila, columna].nombre);
                    Console.Write("[" + localizacion.Substring(0, 4) + "]");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static Mapa CrearMapa()
        {
            int filasMapa = 5;
            int columnasMapa = 5;
            Mapa mapa = new Mapa(filasMapa, columnasMapa);
            return mapa;
        }

        public static void GuardarMapaEnJSON(Mapa mapa, string nombreArchivo)
        {
            string json = JsonConvert.SerializeObject(mapa);
            File.WriteAllText(nombreArchivo, json);
        }

        public static Mapa RecuperarMapaDesdeJSON(string nombreArchivo)
        {
            string json = File.ReadAllText(nombreArchivo);
            return JsonConvert.DeserializeObject<Mapa>(json);
        }
    }
}
