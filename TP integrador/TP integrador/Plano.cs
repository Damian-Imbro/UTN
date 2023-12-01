using System.Reflection;
using TP_integrador.Localizaciones;

namespace TP_integrador
{
    [Serializable]
    public class Plano
    {
        public Localizacion[,] Mapa {  get; set; }
        //public Cuartel CuartelGeneral {  get; set; }
        public List<Type> TiposDeLocalizacion {  get; set; }
        int filasMapa = 10;// Por tema de control es de 10x10 pero puede ser de n dimensiones 
        int columnasMapa = 10;
        private static Plano instance;



        private Plano()
        {
            ObtenerClasesDerivadas();
            CompletarMapa(filasMapa, columnasMapa);
            
        }

        public static Plano GetInstance()
        {
            if (instance == null)
            {
                instance = new Plano();
            }
            return instance;
        }



        public void ObtenerClasesDerivadas()
        {
            TiposDeLocalizacion = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.IsSubclassOf(typeof(Localizacion)) && !t.IsAbstract)
            .ToList();
        }

        public void CompletarMapa(int filas, int columnas)
        {
            Mapa = new Localizacion[filas, columnas];
            RandomCrearCuartel(filas, columnas);
            for (int fila = 0; fila < filas; fila++)
            {
                for (int columna = 0; columna < columnas; columna++)
                {
                    if (Mapa[fila, columna] == null) { RandomCrearLocacion(fila, columna); };
                }
            }
        }

        public void RandomCrearLocacion(int fila, int columna)
        {
            Random random = new Random();
            var tiposFiltrados = TiposDeLocalizacion.Where(t => t != typeof(Cuartel)).ToList();
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
                if (cantidadSitiosReciclaje > 5) {TiposDeLocalizacion.Remove(typeof(SitioDeReciclaje)); }
                Mapa[fila, columna] = nuevaLocalizacion;
            }
        }

        public int CantidadDeLocalizacionesEnMapa(Type tipoLocalizacion)
        {
            int contador = 0;
            foreach (Localizacion localizacion in Mapa)
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
            Cuartel.filaMapa= random.Next(filas); ;
            Cuartel.columnaMapa = random.Next(columnas);
            Mapa[Cuartel.filaMapa,Cuartel.columnaMapa] = Cuartel.GetInstance();
            //do
            //{
            //    cuartelFila = random.Next(filas);
            //    cuartelColumna = random.Next(columnas);
            //} while (Mapa[cuartelFila, cuartelColumna] != null);
            //localizacionCuartel = new Cuartel(cuartelFila, cuartelColumna);
            //Mapa[cuartelFila, cuartelColumna] = localizacionCuartel;
            //if (CuartelGeneral == null)
            //{
            //    CuartelGeneral = new Cuartel(cuartelFila, cuartelColumna);
            //}

        }

        public int[] coordenadasDelCuartel()
        {
            int[] coordenadasCuartel = new int[2];
            coordenadasCuartel[0] = Cuartel.filaMapa;
            coordenadasCuartel[1] = Cuartel.columnaMapa;
            return coordenadasCuartel;

        }

        public void MotrarMapaEnConsola()
        {
            for (int fila = 0; fila < Mapa.GetLength(0); fila++)
            {
                for (int columna = 0; columna < Mapa.GetLength(1); columna++)
                {
                    string localizacion = Convert.ToString(Mapa[fila, columna].nombre);
                    Console.Write("[" + localizacion.Substring(0, 4) + "]");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        internal Localizacion CuartelGeneral()
        {
            return Mapa[Cuartel.filaMapa, Cuartel.columnaMapa];
        }
    }
}

