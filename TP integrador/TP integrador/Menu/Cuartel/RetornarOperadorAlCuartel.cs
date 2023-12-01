namespace TP_integrador.Menu.Cuartel
{
    internal class RetornarOperadorAlCuartel : IMenuCommand
    {
        public void Execute(Plano mapa)
        {
            Localizaciones.Cuartel cuartel = (Localizaciones.Cuartel)mapa.CuartelGeneral();
            Operadores.Operador operador = cuartel.SeleccionarUnOperador();
            operador.VolverCuartel();
        }

        public void ReportPurpose()
        {
            Console.WriteLine("Seleccionar un operador en específico e indicar retorno a cuartel");
        }
    }
}