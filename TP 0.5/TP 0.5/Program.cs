using System.Timers;

double dineroEnCaja = 1000;
double comidaGatosStock = 50;
double comidaPerrosStock = 50;

mostrarStock(dineroEnCaja, comidaGatosStock, comidaPerrosStock);
anduriasModificarDinero(dineroEnCaja);
asteriosReducirComida(ref comidaGatosStock, ref comidaPerrosStock);
penuriasComprarComida(ref dineroEnCaja, ref comidaGatosStock, ref comidaPerrosStock);
mostrarStock(dineroEnCaja, comidaGatosStock, comidaPerrosStock);


static void mostrarStock(double dinero, double comGatos, double comPerros)
{
    Console.WriteLine($"El dinero en caja es de: ${dinero}");
    Console.WriteLine($"El stock de alimento para gatos es de {comGatos} kilos");
    Console.WriteLine($"El stock de alimento para perros es de {comPerros} kilos");
}

static double anduriasModificarDinero (double dinero)
{
    Console.WriteLine("¿Cúanto dinero quieres modificar en la caja?");
    double respuesta=Convert.ToDouble(Console.ReadLine());
    dinero+=respuesta;
    return dinero;
}
static void  asteriosReducirComida (ref double comGatos, ref double comPerros)
{
    Console.WriteLine("¿Qué alimento deseas reducir?");
    Console.WriteLine("1 - Comida para gatos");
    Console.WriteLine("2 - Comida para perros");
    String respuesta = Console.ReadLine();
    while (respuesta != "1" && respuesta != "2")
    {
        Console.WriteLine("Sólo puede seleccionar 1 o 2");
        respuesta = Console.ReadLine();
    }
    Console.WriteLine("¿Cúanto alimiento desea reducir?");
    double cantidad = Convert.ToDouble(Console.ReadLine());
    if (respuesta == "1")
    {
        comGatos -= cantidad;
    }
    else
    {
        comPerros -= cantidad;
    }
}
    static void penuriasComprarComida(ref double dinero, ref double comGatos, ref double comPerros)
    {
        Console.WriteLine("¿Qué alimento deseas Comprar?");
        Console.WriteLine("1 - Comida para gatos");
        Console.WriteLine("2 - Comida para perros");
        String respuesta = Console.ReadLine();
        while (respuesta != "1" && respuesta != "2")
        {
            Console.WriteLine("Sólo puede seleccionar 1 o 2");
            respuesta = Console.ReadLine();
        }
        Console.WriteLine("¿Cúanto alimiento desea comprar?");
        double cantidad = Convert.ToDouble(Console.ReadLine());
        while (cantidad * 50 > dinero)
        {
            Console.WriteLine("Dinero insuficiente, selecciona una cantidad menor");
            cantidad = Convert.ToDouble(Console.ReadLine());
        }
        if (respuesta == "1")
        {
            comGatos += cantidad;
        }
        else
        {
            comPerros += cantidad;
        }
        dinero -= cantidad * 50;
    }

    
    


