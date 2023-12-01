using TP_integrador.Operadores;

namespace TP_integrador.Menu.Cuartel
{
    internal class AgregarOperador : IMenuCommand
    {
        public void Execute(Plano mapa)
        {
            Localizaciones.Cuartel cuartel = (Localizaciones.Cuartel) mapa.CuartelGeneral();
            cuartel.AgregarOperador();       
        }

        public void ReportPurpose()
        {
            Console.WriteLine("Agregar un operador");
        }
    }
}
