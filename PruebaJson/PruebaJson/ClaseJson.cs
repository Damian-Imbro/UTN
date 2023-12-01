using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;



namespace PruebaJson
{
    internal class ClaseJson
    {
        public void GuardarArchivoJson(Persona persona)
        { 
        string json = JsonSerializer.Serialize<Persona>(persona);
        Console.WriteLine(json);
        }

    }
}
