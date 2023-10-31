//Damian Imbrogiano
namespace TP_2._0
{
    internal class Program
    {
        static List<Sucursal> sucursales = new List<Sucursal>();
        static int cantidadDeSucursales = 5;

       
        static void Main(string[] args)
        {
            cargarSucursales();
            MenuGeneral();
         }

        private static void MenuGeneral()
        {
            bool salir = false;
            while (!salir)
            {
                salir = SeleccionarSucursal();
            }
        }

        private static void cargarSucursales()
        {
            for (int i = 0; i < cantidadDeSucursales; i++)
            {
                Sucursal sucursal = new Sucursal();
                sucursales.Add(sucursal);
            }
        }

        private static bool SeleccionarSucursal()
        {
            bool salir = false;
            Console.WriteLine("Lista de códigos de sucursales:");
            foreach (Sucursal sucursal in sucursales)
            {
                Console.WriteLine(sucursal.codigo);
            }
            Console.WriteLine("Ingrese el código de la sucursal o escriba 'SALIR' para salir: ");
            string codigoSucursal = Console.ReadLine();
            codigoSucursal = codigoSucursal.ToUpper();
            if (codigoSucursal == "SALIR")
            {
                salir = true;
            }
            else
            {
                Sucursal sucursalSeleccionada = sucursales.Find(s => s.codigo == codigoSucursal);
                MenuSucursal(sucursalSeleccionada);
            }
            return salir;
        }

            static void MenuSucursal(Sucursal sucursal)
        {
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("Sucursal " + sucursal.codigo);
                Console.WriteLine("Opciones:");
                Console.WriteLine("1) Catalogar nueva vacuna");
                Console.WriteLine("2) Sintetizar virus");
                Console.WriteLine("3) Destruir vacuna o virus");
                Console.WriteLine("4) Destruir por tipo");
                Console.WriteLine("5) Activar sistema de autodestrucción");
                Console.WriteLine("6) Activar sistema de autodestrucción global");
                Console.WriteLine("7) Cambiar de sucursal");
                Console.WriteLine("8) Salir");

                Console.WriteLine("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        CatalogarNuevaVacuna(sucursal);
                        break;
                    case "2":
                        SintetizarVirus(sucursal);
                        break;
                    case "3":
                        DestruirMedicamento(sucursal);
                        break;
                    case "4":
                        DestruirPorTipo(sucursal);
                        break;
                    case "5":
                        ActivarSistemaAutodestruccion(sucursal);
                        break;
                    case "6":
                        ActivarSistemaAutodestruccionGlobal();
                        break;
                    case "7":
                        MenuGeneral();
                        break;
                    case "8":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            }
        }

        static void CatalogarNuevaVacuna(Sucursal sucursal)
        {
            Vacuna vacuna = new Vacuna();
            sucursal.listaMedicamentos.Add(vacuna);
            vacuna.MostrarInfo();
        }

        static void SintetizarVirus(Sucursal sucursal)
        {
            Virus virus = new Virus();
            sucursal.listaMedicamentos.Add(virus);
            virus.MostrarInfo();
        }

        static void DestruirMedicamento(Sucursal sucursal)
        {
            Console.WriteLine("Lista de medicamentos");
            sucursal.ListarMedicamentosActivos();
            Medicamento medicamentoSeleccionado=null;
            while (medicamentoSeleccionado == null)
            {
                Console.WriteLine("Ingrese el nombre del medicamento que desea eliminar");
                string nombreMedicamento = Console.ReadLine();
                nombreMedicamento = nombreMedicamento.ToLower();
                medicamentoSeleccionado = sucursal.listaMedicamentos.Find(s => s.nombre == nombreMedicamento);
            }
            medicamentoSeleccionado.EliminarMedicamento();

        }

        static void DestruirPorTipo(Sucursal sucursal)
        {
            Console.WriteLine("Selecciones el tipo medicamento que desea eliminar");
            foreach (DesignacionMedicamento dm in Enum.GetValues(typeof(DesignacionMedicamento)))
            {
                Console.WriteLine(dm);
            }
            string respuesta=Console.ReadLine();
            Enum.TryParse<DesignacionMedicamento>(respuesta, out DesignacionMedicamento tipoAEliminar);
            foreach (Medicamento medicamento in sucursal.listaMedicamentos)
            {
                if (medicamento.designacion == tipoAEliminar) { medicamento.EliminarMedicamento(); }
            }
        }

        static void ActivarSistemaAutodestruccion(Sucursal sucursal)
        {
            foreach (Medicamento medicamento in sucursal.listaMedicamentos)
            {
               medicamento.EliminarMedicamento();
            }
        }

        static void ActivarSistemaAutodestruccionGlobal()
        {
            foreach (Sucursal sucursal in sucursales)
            {
                ActivarSistemaAutodestruccion(sucursal);
            }
        }
    }
}