using TP_integrador.Localizaciones;
using TP_integrador.Operadores;

namespace TP_integrador.Menu.Cuartel
{
    internal class ListarTodosLosOperadores : IMenuCommand
    {
        public void Execute(Plano mapa)
        {
            Localizaciones.Cuartel cuartel = (Localizaciones.Cuartel)mapa.CuartelGeneral();
            cuartel.ListarTodosLosOperadores();
            
            
        }

        public void ReportPurpose()
        {
            Console.WriteLine("Listar el Estado de todos los operadores");
        }
    }
}