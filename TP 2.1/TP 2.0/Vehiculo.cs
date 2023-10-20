using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace TP_2._0
{
    internal class Vehiculo
    {
        public string matricula;
        public string modelo;
        public Dueño dueño;
        public string Tamaño;

        public Vehiculo()
        {
            matricula = GenerarRandomMatricula();
            modelo = GenerarRandomModelo();
            dueño = new Dueño();
            Tamaño= GenerarRandomTamaño();
            
        }

        private string GenerarRandomTamaño()
        {
            double largo = GenerarRandomLargo();
            double ancho = GenerarRandomAncho();
            string tamaño="";
            if (largo < 4 && ancho < 1.5)
            {
                tamaño = Enum.GetName(typeof(TamañoParking),0);
            } else if(largo <=5 && ancho <= 2)
            {
                tamaño = Enum.GetName(typeof(TamañoParking), 1);
            }
            else
            {
                tamaño = Enum.GetName(typeof(TamañoParking), 2);
            }


            return tamaño;

        }

        static string GenerarRandomMatricula()
        {
            Random rand = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 7)
              .Select(s => s[rand.Next(s.Length)]).ToArray());
        }

        static string GenerarRandomModelo()
        {
            string[] modelos = { "Sedan", "SUV", "Camioneta", "Furgoneta" };
            Random rand = new Random();
            return modelos[rand.Next(modelos.Length)];
        }

        

        static double GenerarRandomLargo()
        {
            Random random = new Random();
            return random.NextDouble() * (5 - 2) + 2;
        }

        static double GenerarRandomAncho()
        {
            Random random = new Random();
            return random.NextDouble() * (2 - 1.5) + 1.5;
        }
            
    }
}
