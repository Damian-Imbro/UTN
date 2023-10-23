//Damian Imbrogiano
using System.ComponentModel.Design;

namespace TP_2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Estacionamiento estacionamiento = new Estacionamiento();
            Menu();
      
        void Menu()
        {
            estacionamiento.InicializarEstacionamientoEstatico();
            string opcion = "1";
                while (opcion == "1" || opcion == "2" || opcion == "3" || opcion == "4" || opcion == "5" || opcion == "6")
                {
                    Console.WriteLine("Bienvenido a los estacionamientos de los Laboratorios Apertura");
                    Console.WriteLine("Menu");
                    Console.WriteLine("1. Listar todos los vehículos");
                    Console.WriteLine("2. Agregar un nuevo vehículo");
                    Console.WriteLine("3. Remover vehículo por matrícula");
                    Console.WriteLine("4. Remover vehículo por DNI del propietario");
                    Console.WriteLine("5. Remover una cantidad aleatoria de vehículos");
                    Console.WriteLine("6. Optimizar espacio");
                    opcion = Console.ReadLine();
                    if (opcion == "1") { estacionamiento.listarVehiculos(); };
                    if (opcion == "2") { estacionamiento.AgregarVehiculo(new Vehiculo()); };
                    if (opcion == "3")
                    {
                        string matricula;
                        Console.WriteLine("Ingrese la matrícula");
                        matricula = Console.ReadLine();
                        estacionamiento.RemoverVehiculoPorMatricula(matricula);
                    }
                    if (opcion == "4")
                    {
                        string dni;
                        Console.WriteLine("Ingrese el DNI del propietario");
                        dni = Console.ReadLine();
                        estacionamiento.RemoverVehiculoPorDni(dni);
                    }
                    if (opcion == "5") { estacionamiento.RemoverCantidadAleatoria(); };
                    if (opcion == "6") { estacionamiento.OptimizarEspacio(); };
                }

            }
        }
    }
}