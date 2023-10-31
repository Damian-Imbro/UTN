using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_2._0
{
    internal class Virus : Medicamento
    {
        public override void EliminarMedicamento()
        {
            nombre = "YYY";
            Console.WriteLine("Virus eliminado");
        }
    }
}
