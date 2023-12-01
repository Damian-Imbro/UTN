using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_integrador.js;
using TP_integrador;

namespace TP_integrador.Menu.Mapa
{
    internal class ComandoNuevaSimulacion : IMenuCommand
    {
        public void Execute(Plano mapa)
        {
            mapa = Plano.GetInstance();
            ClaseJson.GuardarMapaEnJSON(mapa);
            Console.WriteLine("Plano generado correctamente");
            mapa.MotrarMapaEnConsola();
        }

        public void ReportPurpose()
        {
            Console.WriteLine("Nueva simulación");
        }
    }
}
