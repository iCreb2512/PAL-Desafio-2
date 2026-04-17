using System;

class Ahorcado
{
    // arreglo de palabras
    static string[] palabras = {
        "computadora","algoritmo","variable","funcion","ciclo"
    };

    // elegir palabra aleatoria
    static string SeleccionarPalabra()
    {
        Random r = new Random();
        return palabras[r.Next(0, palabras.Length)];
    }

    // mostrar estado de la palabra
    static void Mostrar(string palabra, char[] estado)
    {
        for (int i = 0; i < palabra.Length; i++)
        {
            if (estado[i] == '_')
                Console.Write("_ ");
            else
                Console.Write(estado[i] + " ");
        }
        Console.WriteLine();
    }

    static void Main()
    {
        string palabra = SeleccionarPalabra();

        // inicializar guiones
        char[] estado = new char[palabra.Length];
        for (int i = 0; i < estado.Length; i++)
            estado[i] = '_';

        int intentos = 0;

        while (intentos < 6)
        {
            Console.Clear();
            Mostrar(palabra, estado);

            // leer letra
            Console.Write("Letra: ");
            string entrada = Console.ReadLine().ToLower();

            // validar entrada
            if (entrada.Length != 1)
                continue;

            char letra = entrada[0];
            bool acierto = false;

            // buscar coincidencias
            for (int i = 0; i < palabra.Length; i++)
            {
                if (palabra[i] == letra)
                {
                    estado[i] = letra;
                    acierto = true;
                }
            }

            if (!acierto)
                intentos++;

            // revisar si ya completó
            bool completo = true;
            for (int i = 0; i < estado.Length; i++)
            {
                if (estado[i] == '_')
                    completo = false;
            }

            if (completo)
            {
                Console.WriteLine("Ganaste");
                break;
            }
        }

        Console.WriteLine("La palabra era: " + palabra);
    }
}