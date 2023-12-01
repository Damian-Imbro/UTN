namespace TP_integrador.Operadores
{
    [Serializable]
    public class Bateria
    {
        public int CargaTotalmAh { get; private set; }
        public int VelocidadDeDescarga {  get; private set; }
        public int CargaActualmAh { get; private set; }
        public bool PuertoConectado { get; private set; } = true;

        public Bateria(int mAh)
        {
            CargaTotalmAh = mAh;
            CargaActualmAh = mAh;
            VelocidadDeDescarga = 1;
        }

        public void RecargarBateria()
        {
            if (PuertoConectado)
            { 
                CargaActualmAh = CargaTotalmAh;
            }
            else
            {
                Console.WriteLine("El puerto de carga está desconectado");
            }
        }
               

        public void GastoBateria(double horas)
        {
            double consumoDeBateria = horas * 1000;
            int consumoDeBateriaActual = (int)(horas * 1000)*VelocidadDeDescarga;
            if (consumoDeBateriaActual > CargaActualmAh)
            {
                Console.WriteLine("Advertencia: No hay suficiente batería para moverse");
            }
            else
            {
                CargaActualmAh -= consumoDeBateriaActual;
            }
           
        }

        //public bool TryGastoBateria(double horas)
        //{
        //    comprueba si con la bateria actual puede recorrer una distancia determinada
        //    return true;
        //}

        public void DañoBateria()
        {
            CargaTotalmAh = (int)(CargaTotalmAh * 0.8);
        }

        public void PerforarBateria()
        {
            VelocidadDeDescarga = 5;
        }

        internal void DesconectarPuerto()
        {
            PuertoConectado = false;
        }
    }
}
