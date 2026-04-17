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

static void MostrarReporte(string[] nombres, double[] notas, int n)
    {
        Console.WriteLine();
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine("       REPORTE DE NOTAS ESTUDIANTILES");
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine("  Num  Nombre               Nota   Letra  Estado");
        Console.WriteLine("  " + new string('-', 50));

        for (int i = 0; i < n; i++)
        {
            char letra = ConvertirALetra(notas[i]);
            string estado = DeterminarEstado(notas[i]);

            string nombreFormateado = nombres[i];

            if (nombreFormateado.Length > 18)
                nombreFormateado = nombreFormateado.Substring(0, 18);

            Console.WriteLine("  " + (i + 1) + "    " +
                          nombreFormateado.PadRight(20) +
                          notas[i].ToString("F2").PadRight(7) +
                          letra.ToString().PadRight(7) +
                          estado);
        }

        Console.WriteLine("  " + new string('-', 50));
    }

    static void MostrarResumen(double[] notas, int n)
    {
        double promedio = CalcularPromedio(notas, n);
        double maximo = CalcularMaximo(notas, n);
        double minimo = CalcularMinimo(notas, n);

        int aprobados = 0;
        int reprobados = 0;

        for (int i = 0; i < n; i++)
        {
            if (notas[i] >= 6.0)
                aprobados++;
            else
                reprobados++;
        }

        Console.WriteLine();
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine("              RESUMEN DEL GRUPO");
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine("  Total de estudiantes : " + n);
        Console.WriteLine("  Aprobados            : " + aprobados);
        Console.WriteLine("  Reprobados           : " + reprobados);
        Console.WriteLine("  Promedio general     : " + promedio.ToString("F2"));
        Console.WriteLine("  Nota maxima          : " + maximo.ToString("F2"));
        Console.WriteLine("  Nota minima          : " + minimo.ToString("F2"));
        Console.WriteLine("----------------------------------------------");
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
            string entrada = Console.ReadLine() ?? "";

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
                nombre = (Console.ReadLine() ?? "").Trim();

                if (nombre == "")
                    Console.WriteLine("  El nombre no puede estar vacio.");
            }

            nombres[i] = nombre;

            double nota = 0;
            bool notaValida = false;

            while (!notaValida)
            {
                Console.Write("  Nota (0.0 - 10.0): ");
                string entradaNota = (Console.ReadLine() ?? "").Replace(',', '.');

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