//Damian Imbrogiano
using System.Diagnostics;

Console.WriteLine("Bienvenido al traductor de español criollo a castellano profundo");
Console.WriteLine("Ingrese el texto en español que desea traducir");
string texto = Console.ReadLine();
Console.WriteLine("La traducción es");
Console.WriteLine(TraducirFrase(texto));

string TraducirFrase(string frase)
{
    string[] palabras = frase.Split(' ');
    string resultado = "";

    for (int i = 0; i < palabras.Length; i++)
    {
        palabras[i] = TraducirPalabra(palabras[i]);
        resultado += palabras[i];
        if (i < palabras.Length - 1)
        {
            resultado += " ";
        }
    }
    return resultado;
}


string TraducirPalabra(string palabra)
{
    palabra = palabra.ToLower();
    
    if (EsVocal(palabra[0]) && palabra.Length<2)
    {
        palabra = palabra[0] + palabra;
    }
    else if (EsVocal(palabra[0]) && !EsVocal(palabra[1]))
    {
        palabra = palabra[0] + palabra;
    }

    if (palabra.Length > 6)
    {
        palabra = "an" + palabra;
    }

    char ultimaLetra = palabra[palabra.Length - 1];
    if (ultimaLetra == 'n' || ultimaLetra == 's' || (EsVocal(ultimaLetra) && ultimaLetra != 'o'))
    {
        palabra += "sten";
    }
    else if (ultimaLetra == 'o')
    {
        palabra += "so";
    }
    return palabra;
}

static bool EsVocal(char letra)
{
    return "aeiou".Contains(letra);
}
