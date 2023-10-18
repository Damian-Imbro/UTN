using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_2._0
{
    internal class Vehiculo
    {
        public string matricula;
        public string modelo;
        public Dueño dueño;
        public double largo;
        public double ancho;

        public Vehiculo()
        {
            matricula = GenerarRandomMatricula();
            modelo = GenerarRandomModelo();
            dueño = new Dueño();
            largo = GenerarRandomLargo();
            ancho = GenerarRandomAncho();
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
