using TP_integrador.Operadores;

namespace TP_integrador.Menu.Cuartel
{
    internal class RemoverOperador : IMenuCommand
    {
        public void Execute(Plano mapa)
        {
            Localizaciones.Cuartel cuartel = (Localizaciones.Cuartel)mapa.CuartelGeneral();
            Operadores.Operador operador = cuartel.SeleccionarUnOperador();
            operador.Estado = Operadores.EstadoOperador.Removido;
            // se podría haber utilizado ".Remove(operador);" pero preferí hacer un borrado lógico para mantener al operador y a todo su historial
        }

        public void ReportPurpose()
        {
            Console.WriteLine("Remover un operador");
        }
    }
}