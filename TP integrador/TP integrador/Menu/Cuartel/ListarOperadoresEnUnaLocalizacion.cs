namespace TP_integrador.Menu.Cuartel
{
    internal class ListarOperadoresEnUnaLocalizacion : IMenuCommand
    {
        public void Execute(Plano mapa)
        {
            Localizaciones.Cuartel cuartel = (Localizaciones.Cuartel)mapa.CuartelGeneral();
            cuartel.ListarOperadoresEnUnaLocalizacion();
        }

        public void ReportPurpose()
        {
            Console.WriteLine("Listar el Estado de todos los operadores que estén en cierta localización");
        }
    }
}