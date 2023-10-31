using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_2._0
{
    internal class Sucursal
    {
        public string codigo;
        public List<Medicamento> listaMedicamentos;
       
        public Sucursal()
        {
            codigo = GenerarCodigoAleatorio();
            listaMedicamentos = new List<Medicamento>();
        }

        private string GenerarCodigoAleatorio()
        {
            Random random = new Random();
            const string caracteresPermitidos = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            const int longitudNombre = 3;
            char[] nombreAleatorio = new char[longitudNombre];
            for (int i = 0; i < longitudNombre; i++)
            {
                nombreAleatorio[i] = caracteresPermitidos[random.Next(caracteresPermitidos.Length)];
            }
            return new string (nombreAleatorio);
        }
        public void ListarTodosMedicamentos()
        {
            foreach (Medicamento m in listaMedicamentos)
            {
                m.MostrarInfo();
            }
        }

        internal void ListarMedicamentosActivos()
        {
            foreach (Medicamento m in listaMedicamentos)
            {
                if (m.nombre != "XXX" && m.nombre != "YYY") m.MostrarInfo();
            }
        }
    }
}
