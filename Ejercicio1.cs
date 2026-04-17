using System;

class Ahorcado
{
    // banco de palabras
    static string[] palabras = {
        "computadora","algoritmo","programacion","variable",
        "funcion","arreglo","ciclo","metodo","consola","compilador"
    };

    // seleccionar palabra aleatoria
    static string SeleccionarPalabra()
    {
        Random r = new Random();
        return palabras[r.Next(0, palabras.Length)];
    }

    // verificar si la letra ya fue usada
    static bool Repetida(char letra, char[] usadas, int total)
    {
        for (int i = 0; i < total; i++)
        {
            if (usadas[i] == letra)
                return true;
        }
        return false;
    }

    // mostrar palabra con guiones
    static void Mostrar(string palabra, char[] usadas, int total)
    {
        Console.Write("Palabra: ");
        for (int i = 0; i < palabra.Length; i++)
        {
            bool encontrada = false;

            for (int j = 0; j < total; j++)
            {
                if (usadas[j] == palabra[i])
                {
                    encontrada = true;
                    break;
                }
            }

            if (encontrada)
                Console.Write(palabra[i] + " ");
            else
                Console.Write("_ ");
        }
        Console.WriteLine();
    }

    // verificar si ganó
    static bool Gano(string palabra, char[] usadas, int total)
    {
        for (int i = 0; i < palabra.Length; i++)
        {
            bool encontrada = false;

            for (int j = 0; j < total; j++)
            {
                if (usadas[j] == palabra[i])
                {
                    encontrada = true;
                    break;
                }
            }

            if (!encontrada)
                return false;
        }
        return true;
    }

    // dibujar el ahorcado
    static void Dibujar(int fallos)
    {
        Console.WriteLine("  +---+");
        Console.WriteLine("  |   |");

        if (fallos >= 1) Console.WriteLine("  O   |");
        else Console.WriteLine("      |");

        if (fallos == 2) Console.WriteLine("  |   |");
        else if (fallos == 3) Console.WriteLine(" /|   |");
        else if (fallos >= 4) Console.WriteLine(" /|\\  |");
        else Console.WriteLine("      |");

        if (fallos == 5) Console.WriteLine(" /    |");
        else if (fallos >= 6) Console.WriteLine(" / \\  |");
        else Console.WriteLine("      |");

        Console.WriteLine("      |");
        Console.WriteLine("=======");
    }

    // método principal del juego
    public static void Iniciar()
    {
        string palabra = SeleccionarPalabra();

        char[] usadas = new char[26];
        int total = 0;
        int fallos = 0;

        bool gano = false;

        while (fallos < 6 && !gano)
        {
            Console.Clear();

            Dibujar(fallos);
            Console.WriteLine("Fallos: " + fallos + "/6");

            Mostrar(palabra, usadas, total);

            Console.Write("Letra: ");
            string entrada = Console.ReadLine();

            // validar entrada
            if (string.IsNullOrEmpty(entrada) || entrada.Length != 1 || !char.IsLetter(entrada[0]))
            {
                Console.WriteLine("Entrada inválida");
                Console.ReadLine();
                continue;
            }

            char letra = char.ToLower(entrada[0]);

            // evitar repetir letras
            if (Repetida(letra, usadas, total))
            {
                Console.WriteLine("Letra repetida");
                Console.ReadLine();
                continue;
            }

            usadas[total] = letra;
            total++;

            bool acierto = false;

            // verificar si la letra está en la palabra
            for (int i = 0; i < palabra.Length; i++)
            {
                if (palabra[i] == letra)
                {
                    acierto = true;
                }
            }

            if (!acierto)
                fallos++;

            // verificar victoria
            gano = Gano(palabra, usadas, total);
        }

        Console.Clear();
        Dibujar(fallos);

        if (gano)
            Console.WriteLine("\nGanaste. Palabra: " + palabra);
        else
            Console.WriteLine("\nPerdiste. Palabra: " + palabra);

        Console.ReadLine();
    }
}