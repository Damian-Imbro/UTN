using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_integrador
{
    internal abstract class Operador
    {
        public string id;
        public int bateria;
        public EstadoOperador estado;
        public double cargaMaxima;
        public double cargaActual;
        public double velocidadOptima;
        public string localizacionActual;
        private int field;

        public Operador(int bateria, EstadoOperador estado, double cargaMaxima, double velocidadOptima, string localizacionActual)
        {
            this.id = RandomId();
            this.bateria = bateria;
            this.estado = estado;
            this.cargaMaxima = cargaMaxima;
            this.velocidadOptima = velocidadOptima;
            this.localizacionActual = localizacionActual;
            cargaActual = 0;
        }
        

        private string RandomId()
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


        public void Moverse(string nuevaLocalizacion)
        {
            Random random = new Random();
            int distanciaEnKilometros = random.Next(1, 200);
            double velocidadActual = velocidadOptima * (1 - (cargaActual / cargaMaxima) / 2);
            double tiempoDeMovimientoHoras = distanciaEnKilometros / velocidadActual;
            double consumoDeBateria = (tiempoDeMovimientoHoras) * 1000;
            int consumoDeBateriaActual = (int)(tiempoDeMovimientoHoras * 1000);
            if (consumoDeBateriaActual > bateria)
            {
                Console.WriteLine($"Advertencia: No hay suficiente batería para moverse a {nuevaLocalizacion}");
                return;
            }
            if (ComprobarBateriaParaAvanzarOVolverAlCuertel(nuevaLocalizacion)) {return;}
            estado = EstadoOperador.EnMovimiento;
            localizacionActual = nuevaLocalizacion;
            bateria -= consumoDeBateriaActual;
            Console.WriteLine($"Se ha movido a {nuevaLocalizacion} en {distanciaEnKilometros} km. Batería restante {bateria}");
            estado = EstadoOperador.EsperandoOrdenes;
        }




        public void TransferirCargaFisica (Operador operadorDestino, int kilos)
        {   //Falta realizar la comprobación de la carga máxima del operador destino
            //y si el operador de origen tiene ca cantidad de carga que se quiere pasar como minimo
            if (localizacionActual.Equals(operadorDestino.localizacionActual))
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
            localizacionActual = "Cuartel";
            cargaActual = 0;
            Console.WriteLine($"El operador {id} se encuentra en {localizacionActual} y su carga actual es {cargaActual}");
            estado = EstadoOperador.GuardadoEnCuartel;
        }

        public void ImprimerReporteGeneral()
        {
            Console.WriteLine($"ID: {id}\n Bateria: {bateria}\n Estado: {estado}\n Carga actual: {cargaActual}\n Localización: {localizacionActual}");
        }

        public abstract void VolverCuartelCargarBateria();
        //Habría que ver la manera de que controle la bateria restante para volver al cuartel

        public bool ComprobarBateriaParaAvanzarOVolverAlCuertel(String destino)
        {
            int distanciaAlCuertel = 50; //por el momento es un número fijo hasta que se pueda calcular la distante entre la localización dde destino y el cuartel
            double velocidadActual = velocidadOptima * (1 - (cargaActual / cargaMaxima) / 2);
            double consumoDeBateria = (distanciaAlCuertel / velocidadActual) * 1000;
            double tiempoDeMovimientoHoras = distanciaAlCuertel / velocidadActual;
            int consumoDeBateriaActual = (int)(tiempoDeMovimientoHoras * 1000);
            if (consumoDeBateriaActual > bateria) { Console.WriteLine("No se recomienda avanzar, regresar a la base a recargar bateria");}
            return consumoDeBateriaActual > bateria;
        }

    }

    
}
