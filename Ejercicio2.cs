using System;

class SistemaNotas
{
    static double CalcularPromedio(double[] notas, int n)
    {
        double suma = 0;

        for (int i = 0; i < n; i++)
            suma += notas[i];

        return suma / n;
    }

    static double CalcularMaximo(double[] notas, int n)
    {
        double max = notas[0];

        for (int i = 1; i < n; i++)
        {
            if (notas[i] > max)
                max = notas[i];
        }

        return max;
    }

    static double CalcularMinimo(double[] notas, int n)
    {
        double min = notas[0];

        for (int i = 1; i < n; i++)
        {
            if (notas[i] < min)
                min = notas[i];
        }

        return min;
    }

    static char ConvertirALetra(double nota)
    {
        if (nota >= 9.0)
            return 'A';
        else if (nota >= 8.0)
            return 'B';
        else if (nota >= 7.0)
            return 'C';
        else if (nota >= 6.0)
            return 'D';
        else
            return 'F';
    }

    static string DeterminarEstado(double nota)
    {
        if (nota >= 6.0)
            return "Aprobado";
        else
            return "Reprobado";
    }

    public static void Iniciar()
    {
        Console.Clear();
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine("  SISTEMA DE REGISTRO DE NOTAS ESTUDIANTILES");
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine();

        int n = 0;
        bool valido = false;

        while (!valido)
        {
            Console.Write("  Cantidad de estudiantes: ");
            string entrada = Console.ReadLine();

            if (int.TryParse(entrada, out n) && n > 0)
                valido = true;
            else
                Console.WriteLine("  Ingresa un numero entero mayor a 0.");
        }

        string[] nombres = new string[n];
        double[] notas = new double[n];

        Console.WriteLine();

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("  Estudiante " + (i + 1));

            string nombre = "";

            while (nombre == "")
            {
                Console.Write("  Nombre: ");
                nombre = Console.ReadLine().Trim();

                if (nombre == "")
                    Console.WriteLine("  El nombre no puede estar vacio.");
            }

            nombres[i] = nombre;

            double nota = 0;
            bool notaValida = false;

            while (!notaValida)
            {
                Console.Write("  Nota (0.0 - 10.0): ");
                string entradaNota = Console.ReadLine().Replace(',', '.');

                bool esParseable = double.TryParse(
                    entradaNota,
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out nota
                );

                if (esParseable && nota >= 0.0 && nota <= 10.0)
                    notaValida = true;
                else
                    Console.WriteLine("  Nota invalida. Debe estar entre 0.0 y 10.0.");
            }

            notas[i] = nota;
            Console.WriteLine();
        }

        Console.Write("\n  Presiona ENTER para volver al menu principal...");
        Console.ReadLine();
    }
}