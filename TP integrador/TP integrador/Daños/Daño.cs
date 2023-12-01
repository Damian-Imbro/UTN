using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_integrador.Operadores;

namespace TP_integrador.Daños
{
    public abstract class Daño
    {
        public string Descripcion { get; private set; }
        public TipoDaño TipoDaño { get; private set; }

        public Daño(string descripcion, TipoDaño tipoDesperfecto)
        {
            Descripcion = descripcion;
            TipoDaño = tipoDesperfecto;
        }

        public abstract void AplicarDesperfecto(Operador operador);

    }
}
