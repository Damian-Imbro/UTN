namespace TP_integrador.Menu.Cuartel
{
    internal class CambiarEstadoAStandby : IMenuCommand
    {
        public void Execute(Plano mapa)
        {
            Localizaciones.Cuartel cuartel = (Localizaciones.Cuartel)mapa.CuartelGeneral();
            Operadores.Operador operador=cuartel.SeleccionarUnOperador();
            operador.Estado = Operadores.EstadoOperador.Standby;
        }

        public void ReportPurpose()
        {
            Console.WriteLine("Seleccionar un operador en específico y cambiar Estado a STANDBY");
        }
    }
}