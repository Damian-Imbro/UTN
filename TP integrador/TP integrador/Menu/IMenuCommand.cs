using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_integrador.Menu
{
    internal interface IMenuCommand
    {
        void Execute(Plano mapa);
        void ReportPurpose();
    }
}
