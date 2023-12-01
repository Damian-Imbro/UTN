namespace PruebaJson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Direccion direccion1=new Direccion("Av Callao", 1234, Provincia.CABA);
            List<Auto> autos =new List<Auto>();
            Auto auto1 = new Auto("Ford", "Focus");
            Auto auto2 = new Auto("Fiat", "Cronos");
            autos.Add(auto1);
            autos.Add(auto2);
            Persona persona1 = new Persona("Jorge", "Perez",direccion1);
            ClaseJson jsonHelper = new ClaseJson();
            jsonHelper.GuardarArchivoJson(persona1);
        }
    }
}