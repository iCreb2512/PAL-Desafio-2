using System;

class Program
{
    static void Main(string[] args)
    {
        int opcion = 0;

        do
        {
            Console.Clear();
            Console.WriteLine("        DESAFIO 2 - PAL404 Grupo 01-02L");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("  1. Juego del Ahorcado");
            Console.WriteLine("  2. Sistema de Registro de Notas");
            Console.WriteLine("  3. Salir");
            Console.WriteLine("----------------------------------------------");
            Console.Write("  Opcion: ");

            string entrada = Console.ReadLine();

            if (!int.TryParse(entrada, out opcion))
                opcion = 0;

            switch (opcion)
            {
                case 1:
                    Ahorcado.Iniciar();
                    break;
                case 2:
                    SistemaNotas.Iniciar();
                    break;
                case 3:
                    Console.WriteLine("\n  Hasta luego.");
                    break;
                default:
                    Console.WriteLine("  Opcion invalida.");
                    System.Threading.Thread.Sleep(700);
                    break;
            }

        } while (opcion != 3);
    }
}