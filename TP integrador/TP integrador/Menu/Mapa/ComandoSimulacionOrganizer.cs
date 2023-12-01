using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TP_integrador.Menu.Mapa
{
    internal class ComandoSimulacionOrganizer
    {
        private static ComandoSimulacionOrganizer instance;
        private ComandoSimulacionOrganizer()
        {
            commands = new List<IMenuCommand>();
            commands.Add(new ComandoNuevaSimulacion());
            commands.Add(new ComandoRecuperarSumulacion());
        }
        public static ComandoSimulacionOrganizer GetInstance()
        {
            if (instance == null) instance = new ComandoSimulacionOrganizer();
            return instance;
        }
        List<IMenuCommand> commands;

        public void ReportarComandosSimulacion()
        {
            int contador = 1;
            foreach (IMenuCommand comando in commands)
            {
                Console.Write("[" + contador + "] ");
                comando.ReportPurpose();
                contador++;
            }

        }
        public void ExecuteCommand(int numeroComando)
        {
            commands[numeroComando].Execute(Plano.GetInstance()); ;
        }
    }
}
