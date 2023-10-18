// Damian Imbrogiano. Del 3 al 11 voy a estar de vacaciones. Si lo ve en clase en esos días no voy a estar. Saludos

string respuesta = "";
int[,] totalMinado;
int[] totalMinadoEnTodosLosSistemas=new int[Enum.GetValues(typeof(TipoMetales)).Length];
Console.WriteLine("Bienvenido al programa de minería espacial");

do
{
    Console.WriteLine("Presiona '1' para entrar en un nuevo sistema o '2' para mostrar el total minado y salir del programa.");
    respuesta = Console.ReadLine();


    if (respuesta == "2")
    {
        for(int i = 0; i < totalMinadoEnTodosLosSistemas.Length; i++)
        {
            Console.WriteLine($"Total de {Enum.GetName(typeof(TipoMetales), i)} minado fue de {totalMinadoEnTodosLosSistemas[i]} kilos");
        }
    }

    if (respuesta == "1")
    {
        
        totalMinado = ProcesarSistema();
        for(int i = 0; i < totalMinado.GetLength(0); i++)
        {
            for(int j = 0; j < totalMinado.GetLength(1); j++)
            {
                totalMinadoEnTodosLosSistemas[j] += totalMinado[i, j];
            }
        }

    }

} while (respuesta != "2") ;

int[,] ProcesarSistema()
{
    Random random = new Random();
    int numAsteroides = random.Next(1, 10);
    int cantidadDeMetales = Enum.GetValues(typeof(TipoMetales)).Length;
    int cantidadTiposDeAsteroides = Enum.GetValues(typeof(TipoAsteroides)).Length;
    int[,] metalesEnLosAsteroides = new int[numAsteroides, cantidadDeMetales];
    int[] porcentajeDeMetales = new int[cantidadDeMetales];
    Console.WriteLine($"EN EL SISTEMA [{GenerarCodigoSistema()}] SE MINARON [{numAsteroides}] ASTEROIDES");
    for (int i = 0; i < numAsteroides; i++)
    {
        int index = random.Next(Enum.GetValues(typeof(TipoAsteroides)).Length);
        TipoAsteroides pesoAsteroide = (TipoAsteroides)Enum.GetValues(typeof(TipoAsteroides)).GetValue(index);
        porcentajeDeMetales = ArmarPorcentajeDeMetales(porcentajeDeMetales.Length);
        Console.WriteLine($"ASTEROIDE NÚMERO {i + 1}");
        for (int j = 0;j< (cantidadDeMetales); j++)
        {
            metalesEnLosAsteroides[i, j] = ((int)pesoAsteroide * porcentajeDeMetales[j])/100;
            
            Console.WriteLine($"De {Enum.GetName(typeof(TipoMetales), j)} se recolectaron {metalesEnLosAsteroides[i, j]} kilos");
        }
        Console.WriteLine("-------------------------------");
    }
    Console.WriteLine("===============================");
    return metalesEnLosAsteroides;
}

int[] ArmarPorcentajeDeMetales(int cantidadDeMetales)
{
    int[] porcentajeDeMetales = new int[cantidadDeMetales];
    Random random = new Random();
    int porcentajeAcumulado=0;
    for (int i = 0;i< cantidadDeMetales; i++)
    {
        if (i != cantidadDeMetales - 1)
        {
            porcentajeDeMetales[i] = random.Next(0, (100 - porcentajeAcumulado));
            porcentajeAcumulado += porcentajeDeMetales[i];
        }
        else
        {
            porcentajeDeMetales[i] = 100 - porcentajeAcumulado;
        }
        
    }
    return porcentajeDeMetales;
}

string GenerarCodigoSistema()
{
    Random random = new Random();
    const string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    char[] nuevoSistema = new char[6];

    for (int i = 0; i < nuevoSistema.Length; i++)
    {
        nuevoSistema[i] = caracteres[random.Next(caracteres.Length)];
    }

    return new string(nuevoSistema);
}

enum TipoAsteroides
{
    Pequeño=1000,
    Mediano=2000,
    Grande=5000,
    Cataclísmico=10000
}

enum TipoMetales
{
    Hierro,
    Oro,
    Platino,
    MetalesMisceláneos
}
