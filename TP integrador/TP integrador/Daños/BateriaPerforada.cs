using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_integrador.Operadores;

namespace TP_integrador.Daños
{
    internal class BateriaPerforada : Daño
    {
        public BateriaPerforada(string descripcion) : base(descripcion, TipoDaño.BateriaPerforada)
        {
        }
        public override void AplicarDesperfecto(Operador operador)
        {
            PerforarBateria(operador.Batery);
        }
        private void PerforarBateria(Bateria bateria)
        {
            bateria.PerforarBateria();
        }

    }
}
