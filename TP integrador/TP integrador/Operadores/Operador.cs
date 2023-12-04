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
            int distanciaLineal = DistanciaLineal(CoordenadasEnElMapa, nuevasCoordenadas);





            return distancia;
        }

        private int DistanciaLineal(Tuple<int, int> punto1, Tuple<int, int> punto2)
        {
            return Math.Abs(punto1.Item1 - punto2.Item1) + Math.Abs(punto1.Item2 - punto2.Item2);
        }

        
        private List<(int, int)> Vecinos((int, int) punto, int[,] matriz)
        {
            int filas = matriz.GetLength(0);
            int columnas = matriz.GetLength(1);
            int[][] movimientos = { new[] { 0, 1 }, new[] { 1, 0 }, new[] { 0, -1 }, new[] { -1, 0 } }; 
            List<(int, int)> result = new List<(int, int)>();

            foreach (var movimiento in movimientos)
            {
                int nuevoX = punto.Item1 + movimiento[0];
                int nuevoY = punto.Item2 + movimiento[1];

                if (nuevoX >= 0 && nuevoX < filas && nuevoY >= 0 && nuevoY < columnas && matriz[nuevoX, nuevoY] == 0)
                /*nuevoX >= 0: Garantiza que el nuevo valor de la coordenada X no sea menor que cero, es decir, que no se salga del límite izquierdo de la matriz.
                nuevoX < filas: Asegura que el nuevo valor de la coordenada X no sea mayor o igual al número de filas de la matriz, evitando salirse del límite derecho.
                nuevoY >= 0: Similar al punto 1, pero para la coordenada Y.
                nuevoY < columnas: Similar al punto 2, pero para la coordenada Y.
                matriz[nuevoX, nuevoY] == 0: Verifica que el valor en la nueva posición de la matriz sea igual a cero, indicando que la celda está libre y no hay un obstáculo.
                Faltaría la manera de reemplazar matriz[nuevoX, nuevoY] == 0 por una función que evalúe el tipo de terreno y el tipo de operador y saber si puede pasar por ahí
                */

                {
                    result.Add((nuevoX, nuevoY));
                }
            }

            return result;
        }
        public class PriorityQueue<T> where T : IComparable<T>
        {
            private List<T> data;

            public PriorityQueue()
            {
                this.data = new List<T>();
            }

            public void Enqueue(T item)
            {
                data.Add(item);
                int indiceHijo = data.Count - 1;
                while (indiceHijo > 0)
                {
                    int indicePadre = (indiceHijo - 1) / 2;
                    if (data[indiceHijo].CompareTo(data[indicePadre]) >= 0)
                        break;
                    T temporal = data[indiceHijo]; 
                    data[indiceHijo] = data[indicePadre]; 
                    data[indicePadre] = temporal;
                    indiceHijo = indicePadre;
                }
            }

            public T Dequeue()
            {
                int ultimoIndice = data.Count - 1;
                T primerElemento = data[0];
                data[0] = data[ultimoIndice];
                data.RemoveAt(ultimoIndice);

                --ultimoIndice;
                int indicePadre = 0;
                while (ultimoIndice > 0)
                {
                    int indiceHijoIzquierdo = indicePadre * 2 + 1;
                    if (indiceHijoIzquierdo > ultimoIndice)
                        break;
                    int indiceHijoDerecho = indiceHijoIzquierdo + 1;
                    if (indiceHijoDerecho <= ultimoIndice && data[indiceHijoDerecho].CompareTo(data[indiceHijoIzquierdo]) < 0)
                        indiceHijoIzquierdo = indiceHijoDerecho;
                    if (data[indicePadre].CompareTo(data[indiceHijoIzquierdo]) <= 0)
                        break;
                    T temporal = data[indicePadre]; data[indicePadre] = data[indiceHijoIzquierdo]; data[indiceHijoIzquierdo] = temporal;
                    indicePadre = indiceHijoIzquierdo;
                }
                return primerElemento;
            }

            
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
