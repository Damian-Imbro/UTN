using System.Reflection;
using TP_integrador.Menu.Cuartel;
using TP_integrador.Operadores;

namespace TP_integrador.Localizaciones
{
    [Serializable]
    public class Cuartel : Localizacion
    {
        public List<Operador> ListaOperadores {get; set;}
        public static int filaMapa;
        public static int columnaMapa;
        //public int filaMapa=
        private static Cuartel instance;
        public static Cuartel GetInstance()
        {
            if (instance == null)
            {
                instance = new Cuartel();
            }
            return instance;
        }
        private Cuartel() : base("Cuartel", "Un punto de control donde los operadores pueden recargar batería o ser reparados. Pueden existir varios, pero nunca más de 3.")
        { }
            
        //{
        //public Cuartel(int filaMapa, int columnaMapa) : base("Cuartel", "Un punto de control donde los operadores pueden recargar batería o ser reparados. Pueden existir varios, pero nunca más de 3.")
        //{
        //    filaMapa = filaMapa;
        //    columnaMapa = columnaMapa;
        //    ListaOperadores = new List<Operador>();
        //}

        public void ListarTodosLosOperadores()
        {
            foreach (Operador operador in ListaOperadores)
            {
                Console.WriteLine(operador.Id + " " + operador.Estado);
            }
            int opcionMenu = MenuCuartel.OpcionesMenuCuartel();
            MenuCuartel.EjecutarComandoCuartel(opcionMenu);
        }

        public void ListarOperadoresEnUnaLocalizacion()
        {
            Tuple<int, int> coordenadas = ingresarCordenadas();
            IEnumerable<Operador> opes = ListaOperadores.Where(op => op.CoordenadasEnElMapa == coordenadas);
            //opes.Any() ? ListarOperadores(opes) : Console.WriteLine("No hay operadores en esa ubicación");
            if (opes.Any())
            {
                ListarOperadores(opes);
            }
            else
            {
                Console.WriteLine("No hay operadores en esa ubicación");
            }
        }

        public void VolverTodosAlCuertel()
        {
            foreach (Operador operador in ListaOperadores)
            {
                Tuple<int, int> coordenadasCuertel = Tuple.Create(filaMapa, columnaMapa);
                if (!(operador.CoordenadasEnElMapa.Equals(coordenadasCuertel))) { operador.Moverse(); }
            }
        }

        public void enviarOperador()
        {
            Operador operador = SeleccionarUnOperador();
            operador.Moverse();
        } 

        public void AgregarOperador()
        {
            Type[] tipos = Assembly.GetExecutingAssembly().GetTypes();
            List<Type> clasesHeredadas = tipos.Where(t => t.IsSubclassOf(typeof(Operador))).ToList();
            int opcion = MostrarOpciones(clasesHeredadas);
            Type tipoSeleccionado = clasesHeredadas[opcion];
            Operador nuevoOperador = Activator.CreateInstance(tipoSeleccionado) as Operador;
            Console.WriteLine($"Se ha creado un nuevo operador de tipo {tipoSeleccionado.Name}.");
            ListaOperadores.Add(nuevoOperador);
            int opcionMenu = MenuCuartel.OpcionesMenuCuartel();
            MenuCuartel.EjecutarComandoCuartel(opcionMenu);
        }
        private static int MostrarOpciones(List<Type> clasesHeredadas)
        {
            int contador = 1;
            foreach (Type tipo in clasesHeredadas)
            {
                Console.WriteLine($"[{contador}] {tipo.Name}");
                contador++;
            }
            try
            {
                int opcion = Convert.ToInt32(Console.ReadLine());
                return opcion - 1;
            }
            catch (FormatException)
            {
                Console.WriteLine("Ingrese un número");
                MostrarOpciones(clasesHeredadas);
                return 0;
            }
        }
        public Operador SeleccionarUnOperador()
        {
            ListarOperadores();
            try
            {
                int opcionId = Convert.ToInt32(Console.ReadLine());
                return ListaOperadores[opcionId];
            }
            catch (FormatException ex) 
            {
                Console.WriteLine("Ingrese un número válido");
                return SeleccionarUnOperador();
            }

        }
        public void ListarOperadores()
        {
            Console.WriteLine("Selecciones un Operador");
            foreach (Operador operador in ListaOperadores)
            {
                Console.WriteLine(operador.Id + " " + operador.Estado);
            }
        }

        public void ListarOperadores(IEnumerable<Operador> operadores)
        {
            Console.WriteLine("Selecciones un Operador");
            foreach (Operador operador in operadores)
            {
                Console.WriteLine(operador.Id + " " + operador.Estado);
            }
        }
        private Tuple<int, int> ingresarCordenadas()
        {
            Tuple<int, int> coord;
            Console.WriteLine("Ingrese las coordenadas");
            Console.WriteLine("Ingrese la fila");
            int fila = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese la columna");
            int columna = Convert.ToInt32(Console.ReadLine());
            coord = Tuple.Create(columna, fila);
            return coord;


        }
    }
}
