using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_integrador.js;

namespace TP_integrador.Menu.Mapa
{
    internal class ComandoRecuperarSumulacion : IMenuCommand
    {
        public void Execute(Plano mapa)
        {
            ClaseJson.MostrarListaDeArchivosGuardados();
            Console.WriteLine("Seleccione el archivo que desde cargar");
            int opcion = Convert.ToInt32(Console.ReadLine());
            mapa = ClaseJson.RecuperarMapaDesdeJSON(opcion);
            Console.WriteLine("Plano recuperado");
            mapa.MotrarMapaEnConsola();
        }

        public void ReportPurpose()
        {
            Console.WriteLine("Mostar simulaciones guardadas");
        }
    }
}
