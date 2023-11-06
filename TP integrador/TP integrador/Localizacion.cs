using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_integrador
{
    internal class Localizacion
    {
        public Localizaciones localizacion;
        public Localizacion()
        {
            Random random = new Random();
            Array localizaciones = Enum.GetValues(typeof(Localizaciones));
            localizacion = (Localizaciones)localizaciones.GetValue(random.Next(localizaciones.Length));
        }
        public Localizacion(Localizaciones localizacion)
        {
            this.localizacion = localizacion;
        }
    }
}

