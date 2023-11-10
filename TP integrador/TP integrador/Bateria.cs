namespace TP_integrador
{
    public class Bateria
    {
        public int mAh;
        public int cargaActual;

        public Bateria(int mAh)
        {
            this.mAh = mAh;
            cargaActual = mAh;
        }
    }
}
