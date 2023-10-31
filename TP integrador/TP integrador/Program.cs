using System.Reflection.PortableExecutable;

namespace TP_integrador
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cuartel cuartelGeneral = new Cuartel();
            Operador operador1=new UAV();
            //Console.WriteLine(operador1.id);
            //operador1.ImprimerReporteGeneral();
            //operador1.cargaActual = 2;
            operador1.Moverse("Destino 1");
            //Console.WriteLine("-------------");
            Operador operador2 = new UAV();
            //Console.WriteLine(operador2.id);
            //operador2.ImprimerReporteGeneral();
            //operador2.cargaActual = 1;
            //operador2.Moverse("Destino 1");
            //Console.WriteLine("-------------");
            Operador operador3 = new K9();
            //Console.WriteLine(operador3.id);
            //operador3.ImprimerReporteGeneral();
            //operador3.cargaActual = 30;
            //operador3.Moverse("Destino 1");
            //Console.WriteLine("-------------");
            Operador operador4 = new M8();
            //Console.WriteLine(operador4.id);
            //operador4.ImprimerReporteGeneral();
            //operador4.cargaActual = 100;
            //operador4.Moverse("Destino 1");
            //operador4.Moverse("Destino 2");
            //operador4.Moverse("Destino 3");
            //operador4.Moverse("Destino 4");
            //Console.WriteLine("-------------");
            //operador1.TransferirCargaFisica(operador3, 1);
            //Console.WriteLine("-------------");
            //operador3.TransferirCargaFisica(operador4, 10);
            //Console.WriteLine("-------------");
            //operador3.Moverse("Destino 4");
            //Console.WriteLine("-------------");
            //operador3.TransferirCargaFisica(operador4, 10);
            //Console.WriteLine("-------------");
            //operador1.VolverCuartelTranferirCarga();
            //operador1.ImprimerReporteGeneral();
            //Console.WriteLine("-------------");
            //operador2.VolverCuartelCargarBateria();
            //operador2.ImprimerReporteGeneral();
            //Console.WriteLine("-------------");
            //operador3.VolverCuartelTranferirCarga();
            //operador3.ImprimerReporteGeneral();
            //Console.WriteLine("-------------");
            //operador4.VolverCuartelCargarBateria();
            //operador4.ImprimerReporteGeneral();
            //Console.WriteLine("-------------");
            cuartelGeneral.listaOperadores.Add(operador1);
            cuartelGeneral.listaOperadores.Add(operador2);
            cuartelGeneral.listaOperadores.Add(operador3);
            cuartelGeneral.listaOperadores.Add(operador4);
            cuartelGeneral.ListarTodosLosOperadores();
            cuartelGeneral.ListarOperadoresEnUnaLocalizacion("Destino 1");
            cuartelGeneral.VolverTodosAlCuertel();
            cuartelGeneral.enviarOperador(operador1, "Destino 2");
            cuartelGeneral.enviarOperador(operador2, "Destino 2");
            cuartelGeneral.enviarOperador(operador2, "Destino 2");
            cuartelGeneral.enviarOperador(operador2, "Destino 2");
            cuartelGeneral.enviarOperador(operador2, "Destino 2");
            cuartelGeneral.enviarOperador(operador2, "Destino 2");
            cuartelGeneral.enviarOperador(operador2, "Destino 2");
            cuartelGeneral.enviarOperador(operador2, "Destino 2");
            cuartelGeneral.enviarOperador(operador2, "Destino 2");
            cuartelGeneral.enviarOperador(operador2, "Destino 2");
            cuartelGeneral.enviarOperador(operador2, "Destino 2");
            cuartelGeneral.enviarOperador(operador2, "Destino 2");
            cuartelGeneral.enviarOperador(operador2, "Destino 2");
            cuartelGeneral.enviarOperador(operador2, "Destino 2");
            cuartelGeneral.enviarOperador(operador2, "Destino 2");
            cuartelGeneral.enviarOperador(operador2, "Destino 2");
            cuartelGeneral.enviarOperador(operador2, "Destino 2");
            cuartelGeneral.enviarOperador(operador2, "Destino 2");
            cuartelGeneral.enviarOperador(operador2, "Destino 2");



        }
    }
}