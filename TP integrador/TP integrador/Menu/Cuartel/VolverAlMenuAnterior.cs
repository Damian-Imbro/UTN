using TP_integrador.Menu.Mapa;

namespace TP_integrador.Menu.Cuartel
{
    internal class VolverAlMenuAnterior : IMenuCommand
    {
        public void Execute(Plano mapa)
        {
            MainMenu.ListarMenu();
        }

        public void ReportPurpose()
        {
            Console.WriteLine("Volver al menú anterior");
        }
    }
}