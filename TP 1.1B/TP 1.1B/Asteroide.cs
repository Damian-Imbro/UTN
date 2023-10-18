using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_1._1B
{
    internal class Asteroide
    {
        public TipoAsteroides tamañoAsteroide;
        public string[] metales;
        int[] metalesEnElAsteriode;

        public void InicializarAsteriode(string[] metales)
        {
            this.metales = metales;
            tamañoAsteroide = DeterminarTamañoAsteriode();
            //metalesEnElAsteriode = DeterminarMetalesEnElAsteriode(tamañoAsteroide);
        }

        public int[] DeterminarMetalesEnElAsteriode(TipoAsteroides tamañoAsteriode)
        {
            int CantidadDeMetales = metales.Length;
            int mineralesMaximos = (int)tamañoAsteroide;
            int[] metalesEnElAsteriode = new int[CantidadDeMetales];
            Random random = new Random();

            for (int i = 0; i < CantidadDeMetales; i++)
            {
                if (i != CantidadDeMetales-1)
                {
                    int mineral = random.Next(0, mineralesMaximos);
                    mineralesMaximos -= mineral;
                    metalesEnElAsteriode[i] = mineral;
                }
                else { 
                    metalesEnElAsteriode[i] = mineralesMaximos;
                }
            }
         return metalesEnElAsteriode;
        }

        private TipoAsteroides DeterminarTamañoAsteriode()
        {
            Random random = new Random();
            int cantidadTamañoAsteriodes = random.Next(Enum.GetValues(typeof(TipoAsteroides)).Length);
            TipoAsteroides tamañoAsteriode = (TipoAsteroides)Enum.GetValues(typeof(TipoAsteroides)).GetValue(cantidadTamañoAsteriodes);
            return tamañoAsteriode;
        }

        public void DetalleMinadoPorAsteriode(int[,] asteroidesMinadosEnElUniverso)
        {
            Console.WriteLine("Se ha conseguido el siguiente detalle de metales:");
            for (int i = 0; i < asteroidesMinadosEnElUniverso.GetLength(0); i++)
            {
                Console.WriteLine($"En el asteroide número {i + 1}");
                for (int j = 0; j < asteroidesMinadosEnElUniverso.GetLength(1); j++)
                {
                    Console.WriteLine($"De {metales[j]} se recolectaron {asteroidesMinadosEnElUniverso[i,j]} kilos");
                }
           }
            Console.WriteLine("-------------------------------");
        }

    }
}
