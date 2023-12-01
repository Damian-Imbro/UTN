using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_integrador.Operadores;

namespace TP_integrador.Daños
{
    internal class PuertoBateriaDesconectado : Daño
    {
        public PuertoBateriaDesconectado(string descripcion) : base(descripcion, TipoDaño.PuertoBateriaDesconectado)
        {
        }
        public override void AplicarDesperfecto(Operador operador)
        {
            DesconectarPuertoDeBateria(operador.Batery);
        }

        private void DesconectarPuertoDeBateria(Bateria batery)
        {
            batery.DesconectarPuerto();
        }
    }
}
