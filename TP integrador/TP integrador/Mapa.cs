using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_integrador
{
    internal class Mapa
    {
        public Localizacion[,] mapa;
        public Cuartel cuartelGeneral;
        
        public Mapa(int filas, int columnas)
        {
            CompletarMapa(filas, columnas);
        }
        private void CompletarMapa(int filas, int columnas)
        {
            mapa = new Localizacion[filas, columnas];
            

            RandomCrearCuartel(filas, columnas);
            for (int fila = 0; fila < filas; fila++)
            {
                for (int columna = 0; columna < columnas; columna++)
                {
                    RandomCrearLocacion(fila, columna);
                    
                }
                
            }
        }

        private void RandomCrearLocacion(int fila, int columna)
        {
            Random random = new Random();
            Localizacion nuevaLocalizacion;
            if (mapa[fila, columna] == null)
            {
                do
                {
                    nuevaLocalizacion = new Localizacion();
                    nuevaLocalizacion.localizacion = (Localizaciones)random.Next(Enum.GetValues(typeof(Localizaciones)).Length);
                } while (nuevaLocalizacion.localizacion == Localizaciones.Cuartel);
                mapa[fila, columna] = nuevaLocalizacion;
            }
        }

        private void RandomCrearCuartel(int filas, int columnas)
        {
            Random random = new Random();
            Localizacion localizacionCuartel = new Localizacion(Localizaciones.Cuartel);
            int cuartelFila = 0;
            int cuartelColumna = 0;
            do
            {
                cuartelFila = random.Next(filas);
                cuartelColumna = random.Next(columnas);

            } while (mapa[cuartelFila, cuartelColumna] != null);
            mapa[cuartelFila, cuartelColumna] = localizacionCuartel;
            cuartelGeneral = new Cuartel(cuartelFila, cuartelColumna);


        }

        
    }
}

