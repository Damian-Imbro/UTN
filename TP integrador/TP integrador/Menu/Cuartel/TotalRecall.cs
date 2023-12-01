using TP_integrador.Operadores;

namespace TP_integrador.Menu.Cuartel
{
    internal class TotalRecall : IMenuCommand
    {
        public void Execute(Plano mapa)
        {
            Localizaciones.Cuartel cuartel = (Localizaciones.Cuartel)mapa.CuartelGeneral();
            List<Operador> operadores = new List<Operador>();
            operadores = cuartel.ListaOperadores;
            foreach (Operador operador in operadores)
            {
                operador.VolverCuartel();
            }
        }

        public void ReportPurpose()
        {
            Console.WriteLine("Hacer un total recall general a todos los operadores");
        }
    }
}