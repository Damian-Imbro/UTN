using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_integrador.Menu.Cuartel
{
    internal class ComandoCuartelOrganizer
    {
        private static ComandoCuartelOrganizer instance;

        private ComandoCuartelOrganizer()
        {
            commands = new List<IMenuCommand>();
            commands.Add(new ListarTodosLosOperadores());
            commands.Add(new ListarOperadoresEnUnaLocalizacion());
            commands.Add(new TotalRecall());
            commands.Add(new EnviarOperadorAUnaLocalizacion());
            commands.Add(new RetornarOperadorAlCuartel());
            commands.Add(new CambiarEstadoAStandby());
            commands.Add(new AgregarOperador());
            commands.Add(new RemoverOperador());
            commands.Add(new GuardarEstadoActual());
            commands.Add(new VolverAlMenuAnterior());

        }
        public static ComandoCuartelOrganizer GetInstance()
        {
            if (instance == null) instance = new ComandoCuartelOrganizer();
            return instance;
        }
        List<IMenuCommand> commands;
        public void ReportarComandosCuartel()
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
