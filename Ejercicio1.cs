using System;

class Ahorcado
{
    static void Main()
    {
        string palabra = "ciclo"; // palabra fija
        char[] estado = { '_', '_', '_', '_', '_' }; // guiones iniciales

        int intentos = 0; // contador de errores

        while (intentos < 6)
        {
            Console.Clear();

            // mostrar palabra
            Console.Write("Palabra: ");
            for (int i = 0; i < estado.Length; i++)
                Console.Write(estado[i] + " ");

            // pedir letra
            Console.Write("\nLetra: ");
            char letra = Console.ReadLine()[0];

            bool acierto = false;

            // buscar letra
            for (int i = 0; i < palabra.Length; i++)
            {
                if (palabra[i] == letra)
                {
                    estado[i] = letra;
                    acierto = true;
                }
            }

            // sumar error si falla
            if (!acierto)
                intentos++;

            // verificar victoria
            bool gano = true;
            for (int i = 0; i < estado.Length; i++)
            {
                if (estado[i] == '_')
                {
                    gano = false;
                    break;
                }
            }

            if (gano)
            {
                Console.WriteLine("\nGanaste");
                break;
            }
        }

        Console.WriteLine("\nFin del juego");
    }
}