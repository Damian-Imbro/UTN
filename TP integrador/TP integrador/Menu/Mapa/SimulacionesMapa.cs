using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_integrador.Menu.Mapa
{
    internal class SimulacionesMapa
    {
        public static void EjecutarSimulacion(int opcion)
        {
            ComandoSimulacionOrganizer menu = ComandoSimulacionOrganizer.GetInstance();
            try
            {
                menu.ExecuteCommand(opcion - 1);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Error: Ingrese un número válido.");
                int nuevaOpcion = MenuSimulaciones();
                EjecutarSimulacion(nuevaOpcion);
            }
        }

        public static int MenuSimulaciones()
        {
            Logo.EscribirLogo();
            Console.WriteLine("MainMenu de simulaciones \n Seleccione una opcion");
            ComandoSimulacionOrganizer menu = ComandoSimulacionOrganizer.GetInstance();
            menu.ReportarComandosSimulacion();
            try
            {
                int opcion = Convert.ToInt32(Console.ReadLine());
                return opcion;
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Ingrese un número.");
                return MenuSimulaciones();
            }
        }
    }
}
