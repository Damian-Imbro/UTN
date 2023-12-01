namespace TP_integrador.Localizaciones
{
    [Serializable]
    public class Localizacion //se quitó lo abtracto por problemas con Json
    {
        public string nombre;
        public string descripcion;
        public Localizacion(string nombre, string descripcion)// Cambiar que cada clase que herede cargue los datos de nombre y descripcion
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
        }
    }
}

