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
        public List<Vacuna> listaVacunas;
        public List<Virus> listaVirus;

        public Sucursal()
        {
            codigo = GenerarCodigoAleatorio();
            listaVacunas = new List<Vacuna>();
            listaVirus = new List<Virus>();
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
            for (int i = 0;i < listaVacunas.Count; i++)
            {
                listaVacunas[i].MostrarInfo();
            }
            for (int i = 0; i < listaVirus.Count; i++)
            {
                listaVirus[i].MostrarInfo();
            }
        }

        internal void ListarMedicamentosActivos()
        {
            for (int i = 0; i < listaVacunas.Count; i++)
            {
                if(listaVacunas[i].nombre!="XXX") listaVacunas[i].MostrarInfo();
            }
            for (int i = 0; i < listaVirus.Count; i++)
            {
                if (listaVirus[i].nombre != "YYY")  listaVirus[i].MostrarInfo();
            }
        }
    }
}
