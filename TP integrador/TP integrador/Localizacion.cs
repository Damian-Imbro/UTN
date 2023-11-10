
namespace TP_integrador
{
    public class Localizacion // Se quitó el Abstract para el funcionamiento del Json
    {
        public string nombre;
        public string descripcion;
        public Localizacion(string nombre, string descripcion)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
        }
    }
}

