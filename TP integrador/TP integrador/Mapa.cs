using System.Reflection;


namespace TP_integrador
{
    [Serializable]
    public class Mapa
    {
        public Localizacion[,] mapa;
        public Cuartel cuartelGeneral;
        public List<Type> tiposDeLocalizacion;

        public Mapa(int filas, int columnas)
        {
            ObtenerClasesDerivadas();
            CompletarMapa(filas, columnas);
        }
        public Mapa()
        {
        }

        public void ObtenerClasesDerivadas()
        {
            tiposDeLocalizacion = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.IsSubclassOf(typeof(Localizacion)) && !t.IsAbstract)
            .ToList();
        }

        public void CompletarMapa(int filas, int columnas)
        {
            mapa = new Localizacion[filas, columnas];
            RandomCrearCuartel(filas, columnas);
            for (int fila = 0; fila < filas; fila++)
            {
                for (int columna = 0; columna < columnas; columna++)
                {
                    if (mapa[fila, columna] == null) { RandomCrearLocacion(fila, columna); };
                }
            }
        }

        public void RandomCrearLocacion(int fila, int columna)
        {
            Random random = new Random();
            var tiposFiltrados = tiposDeLocalizacion.Where(t => t != typeof(Cuartel)).ToList();
            int cantidadSitiosReciclaje = CantidadDeLocalizacionesEnMapa(typeof(SitioDeReciclaje));
            if (tiposFiltrados.Count > 0)
            {
                int indiceAleatorio = random.Next(tiposFiltrados.Count);
                Type tipoSeleccionado = tiposFiltrados[indiceAleatorio];
                Localizacion nuevaLocalizacion = (Localizacion)Activator.CreateInstance(tipoSeleccionado);
                if (tipoSeleccionado == typeof(SitioDeReciclaje))
                {
                    cantidadSitiosReciclaje++;
                }
                if (cantidadSitiosReciclaje > 5) {tiposDeLocalizacion.Remove(typeof(SitioDeReciclaje)); }
                mapa[fila, columna] = nuevaLocalizacion;
            }
        }

        public int CantidadDeLocalizacionesEnMapa(Type tipoLocalizacion)
        {
            int contador = 0;
            foreach (Localizacion localizacion in mapa)
            {
                if (localizacion != null && localizacion.GetType() == tipoLocalizacion)
                {
                    contador++;
                }
            }
            return contador;
        }



        public void RandomCrearCuartel(int filas, int columnas)
        {
            Random random = new Random();
            Localizacion localizacionCuartel;
            int cuartelFila = 0;
            int cuartelColumna = 0;
            do
            {
                cuartelFila = random.Next(filas);
                cuartelColumna = random.Next(columnas);
            } while (mapa[cuartelFila, cuartelColumna] != null);
            localizacionCuartel = new Cuartel(cuartelFila, cuartelColumna);
            mapa[cuartelFila, cuartelColumna] = localizacionCuartel;
            cuartelGeneral = new Cuartel(cuartelFila, cuartelColumna);
        }

        public int[] coordenadasDelCuartel()
        {
            int[] coordenadasCuartel = new int[2];
            coordenadasCuartel[0] = Cuartel.filaMapa;
            coordenadasCuartel[1] = Cuartel.columnaMapa;
            return coordenadasCuartel;

        }


       
    }
}

