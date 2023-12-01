using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_integrador.Menu.Cuartel;
using TP_integrador.Menu.Mapa;

namespace TP_integrador.Menu
{
    internal class MainMenu
    {
        public static void ListarMenu()
        {
            int opcion = SimulacionesMapa.MenuSimulaciones();
            SimulacionesMapa.EjecutarSimulacion(opcion);
            opcion = MenuCuartel.OpcionesMenuCuartel();
            MenuCuartel.EjecutarComandoCuartel(opcion);
        }
    }
}
