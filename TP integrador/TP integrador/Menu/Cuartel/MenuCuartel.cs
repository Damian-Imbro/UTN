using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_integrador.Menu.Mapa;

namespace TP_integrador.Menu.Cuartel
{
    internal class MenuCuartel
    {
        public static void EjecutarComandoCuartel(int opcion)
        {
            ComandoCuartelOrganizer menu = ComandoCuartelOrganizer.GetInstance();
            try
            {
                menu.ExecuteCommand(opcion - 1);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Error: Ingrese un número válido.");
                int nuevaOpcion = OpcionesMenuCuartel();
                EjecutarComandoCuartel(nuevaOpcion);
            }
        }

        public static int OpcionesMenuCuartel()
        {
            Logo.EscribirLogo();
            Console.WriteLine("Bienvenido al Cuartel \n Seleccione una opcion");
            ComandoCuartelOrganizer menu = ComandoCuartelOrganizer.GetInstance();
            menu.ReportarComandosCuartel();
            try
            {
                int opcion = Convert.ToInt32(Console.ReadLine());
                return opcion;
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Ingrese un número.");
                return OpcionesMenuCuartel();
            }
        }
    }
}
