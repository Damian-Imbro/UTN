using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_1._1B
{
    internal class Universo
    {
        string nombre;
        int[,] asteriodes;

        public void InicializarUniverso()
        {
            nombre = CrearNombreUniverso();
           

        }

        public int[,] CrearAsteroidesEnElUniverso(Asteroide asteroide)
        {
            Random random = new Random();
            int cantidadDeAsteroides = random.Next(1, 11);
            
            int[] metalesEnElAsteroide;
            int[,] asteroides = new int[cantidadDeAsteroides, asteroide.metales.Length];
            for (int i = 0; i < cantidadDeAsteroides; i++)
            {
                asteroide.InicializarAsteriode(asteroide.metales);
                metalesEnElAsteroide = asteroide.DeterminarMetalesEnElAsteriode(asteroide.tamañoAsteroide);
                for (int j = 0; j < asteroide.metales.Length; j++)
                {
                    asteroides[i, j] = metalesEnElAsteroide[j];
                }
            }
            return asteroides;
        }


        private string CrearNombreUniverso()
        {
            Random random = new Random();
            const string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            char[] nuevoSistema = new char[6];

            for (int i = 0; i < nuevoSistema.Length; i++)
            {
                nuevoSistema[i] = caracteres[random.Next(caracteres.Length)];
            }

            return new string(nuevoSistema);
        }

        internal int[] acumularMinado(int[,] asteroidesEnElUniverso, int[] totalMinadoEnTodosLosSistemas)
        {
            int[] acumulado = new int[totalMinadoEnTodosLosSistemas.Length];
            for (int i = 0; i < asteroidesEnElUniverso.GetLength(0); i++)
            {
                for (int j = 0; j < totalMinadoEnTodosLosSistemas.Length; j++)
                {
                    acumulado[j] = totalMinadoEnTodosLosSistemas[j] + asteroidesEnElUniverso[i, j];
                }
                
            }
            return acumulado;
        }

        internal void TotalMinado(int[] totalMinadoEnTodosLosSistemas, string[] metales)
        {
            for(int i = 0;totalMinadoEnTodosLosSistemas.Length>i; i++)
            { 
                Console.WriteLine ($"Total minado de {metales[i]}: {totalMinadoEnTodosLosSistemas[i]} kilos ");
            }
        }
    }
}
