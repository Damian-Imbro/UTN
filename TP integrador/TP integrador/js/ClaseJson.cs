using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TP_integrador.js
{
    internal class ClaseJson
    {
        public static string path = Directory.GetCurrentDirectory();
        public static string carpeta = "\\Data";
        static JsonSerializerOptions opcionesJson = new JsonSerializerOptions();
        public ClaseJson()
        {
            path = Directory.GetCurrentDirectory();
            path += carpeta;
            Directory.CreateDirectory(path);
        }
        
        
        public static void GuardarMapaEnJSON(Plano mapa)
        {
            string formatoFecha = "yyyy-MM-dd HH-mm-ss";
            string nombreArchivo = "Plano - " + DateTime.Now.ToString(formatoFecha)+".json";

            string json = JsonConvert.SerializeObject(mapa, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            });

            File.WriteAllText(path+carpeta+"\\"+nombreArchivo, json);
        }

        public static Plano RecuperarMapaDesdeJSON(int numeroArchivo)
        {
            string nombreArchivo;
            List<string> listaDeArchivos = new List<string> (ListaArchivosGuardados());
            nombreArchivo = listaDeArchivos[numeroArchivo-1];
            nombreArchivo = Path.GetFileName(nombreArchivo);
            string json = File.ReadAllText(path + carpeta + "\\" + nombreArchivo);

            Plano mapa = JsonConvert.DeserializeObject<Plano>(json, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            });

            return mapa;
        }

        public static void MostrarListaDeArchivosGuardados()
        {
            List<string> archivos = new List <string> (Directory.GetFiles(path+ carpeta));
            int contador = 1;
            foreach (string archivo in archivos)
            {
                string nombreArchivo = Path.GetFileName(archivo);
                Console.WriteLine($"[{contador}] {nombreArchivo}");
                contador++;
            }
        }
        public static List<string> ListaArchivosGuardados()
        {
            List<string> archivos = new List<string>(Directory.GetFiles(path + carpeta));
            return archivos;
        }

    }
}
