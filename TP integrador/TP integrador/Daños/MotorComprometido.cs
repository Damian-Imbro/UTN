using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_integrador.Operadores;

namespace TP_integrador.Daños
{
    internal class MotorComprometido : Daño
    {
        public MotorComprometido(string descripcion) : base(descripcion, TipoDaño.MotorComprometido)
        {
        }
        public override void AplicarDesperfecto(Operador operador)
        {
            ReducirVelocidadDeMotor(operador);
        }

        private void ReducirVelocidadDeMotor(Operador operador)
        {
            operador.VelocidadOptima = operador.VelocidadOptima / 2;
        }
    }
}
