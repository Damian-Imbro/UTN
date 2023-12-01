namespace TP_integrador.Menu.Cuartel
{
    internal class GuardarEstadoActual : IMenuCommand
    {
        public void Execute(Plano mapa)
        {
            js.ClaseJson.GuardarMapaEnJSON(mapa);
            int opcion = MenuCuartel.OpcionesMenuCuartel();
            MenuCuartel.EjecutarComandoCuartel(opcion);
        }

        public void ReportPurpose()
        {
            Console.WriteLine("Guardar Estado actual");
        }
    }
}