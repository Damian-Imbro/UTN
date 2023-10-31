using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_2._0
{
    internal abstract class Medicamento
    {
        public string nombre;
        public string identificadorUnico;
        public DesignacionMedicamento designacion;

        public Medicamento()
        {
            nombre = RandomNombre();
            identificadorUnico = RandomUID();
            designacion = RandomDesidnacion();
        }

        private DesignacionMedicamento RandomDesidnacion()
        {
            Random random = new Random();
            Array valoresEnum = Enum.GetValues(typeof(DesignacionMedicamento));
            DesignacionMedicamento randomDM = (DesignacionMedicamento)valoresEnum.GetValue(random.Next(valoresEnum.Length));
            return randomDM;
        }

        private string RandomUID()
        {
            Guid randomId = Guid.NewGuid();
            return randomId.ToString();
        }

        private string RandomNombre()
        {
            Random random = new Random();
            const string caracteresPermitidos = "abcdefghijklmnopqrstuvwxyz0123456789";
            const int longitudNombre = 4;
            char[] nombreAleatorio = new char[longitudNombre];
            for (int i = 0; i < longitudNombre; i++)
            {
                nombreAleatorio[i] = caracteresPermitidos[random.Next(caracteresPermitidos.Length)];
            }
            return new string(nombreAleatorio);
        }
        public void MostrarInfo()
        {
            Console.WriteLine($"Nombre: {nombre}");
            Console.WriteLine($"UID: {identificadorUnico}");
            Console.WriteLine($"Designación: {designacion}");
            Console.WriteLine("---------------------------------------------");
        }
        public abstract void EliminarMedicamento();
    }
}
