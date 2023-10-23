using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TP_2._0
{
    internal class Estacionamiento
    {
        public List<Estacionamiento> estacionamientoEstatico = new List<Estacionamiento>();
        public List<Estacionamiento> estacionamientoDinamico = new List<Estacionamiento>();
        public Vehiculo vehiculo;
        public TamañoParking tamañoParking;
        public int[] estacionamientosVip = { 3, 7, 12 };
        int largoEstacionamientoEstático = 12;
        
        

        public Estacionamiento()
        {
            tamañoParking = GenerarRandomTamañoParking();
            
        }

        public void InicializarEstacionamientoEstatico()
        {
            for (int i = 0; i < largoEstacionamientoEstático; i++)
            {
                estacionamientoEstatico.Add(new Estacionamiento());
            }
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
            
            for (int i = 0; i < largoEstacionamientoEstático; i++)
             {
                controlEstacionamiento = false;
                    if (estacionamientoEstatico[i].vehiculo ==null && vehiculo.dueño.vip)
                    {
                        estacionamientoEstatico[i].vehiculo = vehiculo;
                        controlEstacionamiento = true;
                        break;
                    }
                    if (estacionamientoEstatico[i].vehiculo == null && !vehiculo.dueño.vip && !estacionamientosVip.Contains((i+1)))
                    {
                        estacionamientoEstatico[i].vehiculo = vehiculo;
                        controlEstacionamiento = true;
                        break;
                    }

             }
                
            

            if (!controlEstacionamiento)
            {
                bool vehiculoAgregado = false;
                while (!vehiculoAgregado)
                {
                    if (estacionamientoDinamico.Count == 0)
                    {
                        estacionamientoDinamico.Add(new Estacionamiento());
                        if (estacionamientoDinamico[0].tamañoParking.Equals(vehiculo.Tamaño))
                        {
                            estacionamientoDinamico[0].vehiculo = vehiculo;
                            vehiculoAgregado = true;
                        }
                    }
                    else
                    {
                        for (int j = 0; j < estacionamientoDinamico.Count; j++)
                        {
                            if (estacionamientoDinamico[j].vehiculo == null)
                            {
                                if (estacionamientoDinamico[0].tamañoParking.Equals(vehiculo.Tamaño))
                                {
                                    estacionamientoDinamico[0].vehiculo = vehiculo;
                                    vehiculoAgregado = true;
                                }
                                break;
                            }
                        }
                    }


                    if (!vehiculoAgregado)
                    {
                        estacionamientoDinamico.Add(new Estacionamiento());
                        if (estacionamientoDinamico[0].tamañoParking.Equals(vehiculo.Tamaño))
                        {
                            estacionamientoDinamico[0].vehiculo = vehiculo;
                            vehiculoAgregado = true;
                        }

                    }
                }
            }

        }
        public void RemoverVehiculoPorMatricula(string matricula)
        {
            matricula = matricula.ToUpper();
            for (int i = 0; i < estacionamientoEstatico.Count; i++)
            {
                if (estacionamientoEstatico[i].vehiculo.matricula== matricula)
                {
                    estacionamientoEstatico[i].vehiculo = null;
                    break;
                }
            }
            for (int i = 0; i < estacionamientoDinamico.Count; i++)
            {
                if (estacionamientoDinamico[i].vehiculo.matricula == matricula)
                {
                    estacionamientoDinamico[i].vehiculo = null;
                    break;
                }
            }
        }

        

        public void OptimizarEspacio()
        {
            
        }


        public void RemoverCantidadAleatoria()
        {
            
        }

        public void RemoverVehiculoPorDni(string dni)
        {
            for (int i = 0; i < estacionamientoEstatico.Count; i++)
            {
                if (estacionamientoEstatico[i].vehiculo.dueño.dni == dni)
                {
                    estacionamientoEstatico[i].vehiculo = null;
                    break;
                }
            }
            for (int i = 0; i < estacionamientoDinamico.Count; i++)
            {
                if (estacionamientoDinamico[i].vehiculo.dueño.dni == dni)
                {
                    estacionamientoDinamico[i].vehiculo = null;
                    break;
                }
            }
        }

        public void listarVehiculos()
        {
            Console.WriteLine("Lista de vehículos en el estacionamiento fijo");
            for (int i = 0;  i < estacionamientoEstatico.Count; i++)
            {
                if (estacionamientoEstatico[i].vehiculo != null) 
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
