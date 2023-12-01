using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TP_integrador.Localizaciones;
using TP_integrador.Menu.Cuartel;


namespace TP_integrador.Operadores
{
    [Serializable]
    public class Operador //Se quitó el abstrac por generar error con el Json
    {
        public string Id {  get; set; }
        public Bateria Batery {  get; set; }
        public EstadoOperador Estado {  get; set; }
        public double CargaMaxima {  get; protected set; }
        public double CargaActual {  get; set; }
        public double VelocidadOptima { get; set; }
        public Tuple<int, int> CoordenadasEnElMapa {  get; set; }
        


        public Operador()
        {
            Id = RandomId();
            this.Batery = Batery;
            Estado = EstadoOperador.GuardadoEnCuartel;
            CoordenadasEnElMapa = Tuple.Create(Cuartel.filaMapa, Cuartel.columnaMapa);
            CargaActual = 0;
        }


        public string RandomId()
        {
            Type tipoOperador = GetType();
            string tipoNombre = tipoOperador.Name;
            int longitudNombre = 10;
            string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            char[] nombre = new char[longitudNombre];
            for (int i = 0; i < longitudNombre; i++)
            {
                int indice = random.Next(caracteres.Length);
                nombre[i] = caracteres[indice];
            }
            string id = tipoNombre + "-" + new string(nombre);
            return id;

        }


        public void Moverse()
        {
            Tuple<int, int> nuevasCoordenadas=ingresarCordenadas();
            int distanciaEnKilometros = CalcularDistancia(nuevasCoordenadas);
            double tiempoDeMovimientoHoras = CalcualarTiempoMovimientoHoras(distanciaEnKilometros);
            Batery.GastoBateria(tiempoDeMovimientoHoras);
        }

        private double CalcualarTiempoMovimientoHoras(int distanciaEnKilometros)
        {
            double velocidadActual = VelocidadOptima * (1 - CargaActual / CargaMaxima / 2);
            double tiempoDeMovimientoHoras = distanciaEnKilometros / velocidadActual;
            return tiempoDeMovimientoHoras;
        }

        private Tuple<int, int> ingresarCordenadas()
        {
            Tuple<int, int> coord;
            Console.WriteLine("Ingrese las coordenadas");
            Console.WriteLine("Ingrese la fila");
            int fila = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese la columna");
            int columna = Convert.ToInt32(Console.ReadLine());
            coord =Tuple.Create(columna, fila);
            return coord;


        }

        public int CalcularDistancia(Tuple<int, int> nuevasCoordenadas)
        {
            int distancia = 0;
            //Calcula la distancia hasta unas coordenadas en específico
            return distancia;
        }

        public void TransferirCargaFisica(Operador operadorDestino, int carga)
        {   try
            {
                ContieneCarga(carga);
                EstanEnLaMismaUbicacion(operadorDestino);
                ComprobarPesoMaximo(carga);
                operadorDestino.AgregarCarga(carga);

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

        }

        private void AgregarCarga(int carga)
        {
            CargaActual += carga;
        }

        
        private bool ComprobarPesoMaximo(int carga)
        {
            return (CargaActual+carga > CargaMaxima)? true: throw new Exception("Supera el peso maximo soportado");
}

        private bool EstanEnLaMismaUbicacion(Operador operadorDestino)
        {
            return this.CoordenadasEnElMapa==operadorDestino.CoordenadasEnElMapa ? true : throw new Exception("Ambos operadores no se encuentran en la misma ubicación");
        }

        private bool ContieneCarga(int carga)
        {
            return (CargaActual>carga) ? true : throw new Exception("No posee la carga que desea transferir");
        }

        public void VolverCuartelTranferirCarga()
        {
            VolverCuartel();
            CargaActual = 0;
            
        }

        public void ImprimerReporteGeneral()
        {
            Console.WriteLine($"ID: {Id}\n Bateria: {Batery.CargaActualmAh}\n Estado: {Estado}\n Carga actual: {CargaActual}\n Localización: {CoordenadasEnElMapa.Item1} - {CoordenadasEnElMapa.Item2}");
        }

        public void VolverCuartelCargarBateria()
        {
            Batery.RecargarBateria();
            VolverCuartel();
        }



        internal void VolverCuartel()
        {
            //calcular distancia
            //calcular bateria
            //if true
            CoordenadasEnElMapa = Tuple.Create(Cuartel.filaMapa, Cuartel.columnaMapa);
            Estado = EstadoOperador.GuardadoEnCuartel;
        }
    }


}
