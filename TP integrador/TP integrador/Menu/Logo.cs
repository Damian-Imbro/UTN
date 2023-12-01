using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_integrador.Menu
{
    internal class Logo
    {

        static string logo;

        public static void EscribirLogo()
        {
            logo = "\r\n   _____ _  ____     ___   _ ______ _______ \r\n  / ____| |/ /\\ \\   / / \\ | |  ____|__   __|\r\n | (___ | ' /  \\ \\_/ /|  \\| | |__     | |   \r\n  \\___ \\|  <    \\   / | . ` |  __|    | |   \r\n  ____) | . \\    | |  | |\\  | |____   | |   \r\n |_____/|_|\\_\\   |_|  |_| \\_|______|  |_|   \r\n                                            \r\n                                            \r\n";
            Console.WriteLine(logo);
        }




    }
}
