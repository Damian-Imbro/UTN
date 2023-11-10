using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_integrador
{
    public abstract class Operador
    {
        public string id;
        public Bateria bateria;
        public EstadoOperador estado;
        public double cargaMaxima;
        public double cargaActual;
        public double velocidadOptima;
        public int[] coordenadasEnElMapa;
        

        public Operador(Bateria bateria, double cargaMaxima, double velocidadOptima)
        {
            this.id = RandomId();
            this.bateria = bateria;
            estado = EstadoOperador.GuardadoEnCuartel;
            this.cargaMaxima = cargaMaxima;
            this.velocidadOptima = velocidadOptima;
            coordenadasEnElMapa[0] = Cuartel.filaMapa;
            coordenadasEnElMapa[1] = Cuartel.columnaMapa;
            cargaActual = 0;
        }
        

        public string RandomId()
        {
            Type tipoOperador = this.GetType();
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
            string id = tipoNombre+"-" + new string(nombre);
            return id;

        }


        public void Moverse(int[] nuevasCoordenadas)
        {
            Random random = new Random();
            int distanciaEnKilometros = CalcularDistancia(nuevasCoordenadas);
            double velocidadActual = velocidadOptima * (1 - (cargaActual / cargaMaxima) / 2);
            double tiempoDeMovimientoHoras = distanciaEnKilometros / velocidadActual;
            double consumoDeBateria = (tiempoDeMovimientoHoras) * 1000;
            int consumoDeBateriaActual = (int)(tiempoDeMovimientoHoras * 1000);
            if (consumoDeBateriaActual > bateria.mAh)
            {
                Console.WriteLine($"Advertencia: No hay suficiente batería para moverse hasta las coordenadas {nuevasCoordenadas[0]} - {nuevasCoordenadas[1]}" );
                return;
            }
            //if (ComprobarBateriaParaAvanzarOVolverAlCuertel(nuevasCoordenadas)) {return;}
            estado = EstadoOperador.EnMovimiento;
            coordenadasEnElMapa[0] = nuevasCoordenadas[0];
            coordenadasEnElMapa[1] = nuevasCoordenadas[1];
            bateria.mAh -= consumoDeBateriaActual;
            Console.WriteLine($"Se ha movido a las coordenadas {nuevasCoordenadas[0]} - {nuevasCoordenadas[1]} en {distanciaEnKilometros} km. Batería restante {bateria.mAh}");
            estado = EstadoOperador.EsperandoOrdenes;
        }

        public int CalcularDistancia(int[] nuevasCoordenadas)
        {
            int distancia = 0;
            //Calcula la distancia hasta unas coordenadas en específico
            return distancia;
        }

        public void TransferirCargaFisica (Operador operadorDestino, int kilos)
        {   //Falta realizar la comprobación de la carga máxima del operador destino
            //y si el operador de origen tiene ca cantidad de carga que se quiere pasar como minimo
            if (coordenadasEnElMapa==operadorDestino.coordenadasEnElMapa)
            {
                estado = EstadoOperador.TranfiriendoCarga;
                operadorDestino.estado = EstadoOperador.TranfiriendoCarga;
                cargaActual -= kilos;
                operadorDestino.cargaActual += kilos;
                Console.WriteLine("Carga actual del operador " + id + " " + cargaActual);
                Console.WriteLine("Carga actual del operador " + operadorDestino.id + " " + operadorDestino.cargaActual);
                estado = EstadoOperador.EsperandoOrdenes;
                operadorDestino.estado = EstadoOperador.EsperandoOrdenes;
            }
            else
            {
                Console.WriteLine($"Los operadores {id} y {operadorDestino.id} no se encuentran en la misma localización para poder tranferir la carga");
            };
            
        }
        public void VolverCuartelTranferirCarga()
        {
            //falta controlar si tiene suficiente energía para volver
            coordenadasEnElMapa[0] = Cuartel.filaMapa;
            coordenadasEnElMapa[1] = Cuartel.columnaMapa;
            cargaActual = 0;
            Console.WriteLine($"El operador {id} se encuentra en las coordenadas {coordenadasEnElMapa[0]} - {coordenadasEnElMapa[1]} y su carga actual es {cargaActual}");
            estado = EstadoOperador.GuardadoEnCuartel;
        }

        public void ImprimerReporteGeneral()
        {
            Console.WriteLine($"ID: {id}\n Bateria: {bateria.mAh}\n Estado: {estado}\n Carga actual: {cargaActual}\n Localización: {coordenadasEnElMapa[0]} - {coordenadasEnElMapa[1]}");
        }

        public abstract void VolverCuartelCargarBateria();
        //Habría que ver la manera de que controle la bateria restante para volver al cuartel

        public bool ComprobarBateriaParaAvanzarOVolverAlCuertel(int[] nuevasCoordenadas)
        {
            int[] coordenadasCuartel = { Cuartel.filaMapa, Cuartel.columnaMapa };
            int distanciaAlCuertel = CalcularDistancia(coordenadasCuartel);
            double velocidadActual = velocidadOptima * (1 - (cargaActual / cargaMaxima) / 2);
            double consumoDeBateria = (distanciaAlCuertel / velocidadActual) * 1000;
            double tiempoDeMovimientoHoras = distanciaAlCuertel / velocidadActual;
            int consumoDeBateriaActual = (int)(tiempoDeMovimientoHoras * 1000);
            if (consumoDeBateriaActual > bateria.mAh) { Console.WriteLine("No se recomienda avanzar, regresar a la base a recargar bateria");}
            return consumoDeBateriaActual > bateria.mAh;
        }

    }

    
}
