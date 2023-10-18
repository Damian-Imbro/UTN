using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_2._0
{
    internal class Estacionamiento
    {
        public Estacionamiento[] estacionamientoEstatico = new Estacionamiento[12];
        public List<Estacionamiento> estacionamientoDinamico = new List<Estacionamiento>();
        public Vehiculo vehiculo;
        public TamañoParking tamañoParking;    

        public Estacionamiento()
        {
            tamañoParking = GenerarRandomTamañoParking();
            

        }

        

        private TamañoParking GenerarRandomTamañoParking()
        {
            Random random = new Random();
            Array tamaños = Enum.GetValues(typeof(TamañoParking));
            return (TamañoParking)tamaños.GetValue(random.Next(tamaños.Length)); ;
        }

        public void AgregarVehiculo(Vehiculo vehiculo)
        {
            bool controlEstacionamiento = false;
            
            for (int i = 0; i < estacionamientoEstatico.Length; i++)
            {
                //falta el control de los VIP!!!!!
                if (estacionamientoEstatico[i] == null)
                {
                    estacionamientoEstatico[i] = new Estacionamiento();
                    estacionamientoEstatico[i].vehiculo = vehiculo;
                    controlEstacionamiento = true;
                    break;
                }
            }
            // falta controlar el tamaño de la cochera
            if (!controlEstacionamiento)
            {
                bool vehiculoAgregado = false;

                
                if (estacionamientoDinamico.Count == 0)
                {
                    estacionamientoDinamico.Add(new Estacionamiento { vehiculo = vehiculo });
                    vehiculoAgregado = true;
                }
                else
                {
                    for (int j = 0; j < estacionamientoDinamico.Count; j++)
                    {
                        if (estacionamientoDinamico[j].vehiculo == null)
                        {
                            estacionamientoDinamico[j].vehiculo = vehiculo;
                            vehiculoAgregado = true;
                            break;
                        }
                    }
                }

                
                if (!vehiculoAgregado)
                {
                    estacionamientoDinamico.Add(new Estacionamiento { vehiculo = vehiculo });
                }
            }


        }
        public void RemoverVehiculoPorMatricula(string matricula)
        {
            
        }

        public void OptimizarEspacio()
        {
            
        }

        

        

        public void RemoverCantidadAleatoria()
        {
            
        }

        public void RemoverVehiculoPorDni(string? dni)
        {
            
        }

        public void listarVehiculos()
        {
            Console.WriteLine("Lista de vehículos en el estacionamiento fijo");
            for (int i = 0;  i < estacionamientoEstatico.Length; i++)
            {
                if (estacionamientoEstatico[i] != null) 
                {
                    Console.WriteLine((i+1) + " Matricula: " + estacionamientoEstatico[i].vehiculo.matricula +
                      " DNI: " + estacionamientoEstatico[i].vehiculo.dueño.dni);
                }
               
            }
            Console.WriteLine("Lista de vehículos en el estacionamiento infinito");
            for (int j = 0; j < estacionamientoDinamico.Count; j++)
            {
                Console.WriteLine((j+1) +" Matricula: " + estacionamientoDinamico[j].vehiculo.matricula +
                    " DNI: " + estacionamientoDinamico[j].vehiculo.dueño.dni);
            }
        }
    }
}
