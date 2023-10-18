using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_2._0
{
    internal class Dueño
    {
        public string dni;
        public bool vip;

        public Dueño()
        {
            this.dni = GenerarRandomDNI();
            this.vip = GenerarRandomVIP();
        }

        static string GenerarRandomDNI()
        {
            Random random = new Random();
            return random.Next(100000000, 999999999).ToString();
        }
        static bool GenerarRandomVIP()
        {
            Random random = new Random();
            return random.Next(0, 1) == 1;
        }
    }

}
