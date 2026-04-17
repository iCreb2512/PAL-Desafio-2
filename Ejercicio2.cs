// Ejercicio 2: Sistema de Registro de Notas Estudiantiles
// PAL404 | Grupo 01-02L | Docente: Edwin Bonilla

using System;

class SistemaNotas
{
    // Calcula el promedio de todas las notas
    static double CalcularPromedio(double[] notas, int n)
    {
        double suma = 0;
        for (int i = 0; i < n; i++)
            suma += notas[i];
        return suma / n;
    }

    // Recorre el vector para encontrar la nota mas alta
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

    // Recorre el vector para encontrar la nota mas baja
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

    // Convierte la nota numerica en letra segun la escala definida
    static char ConvertirALetra(double nota)
    {
        char letra;

        if (nota >= 9.0)
            letra = 'A';
        else if (nota >= 8.0)
            letra = 'B';
        else if (nota >= 7.0)
            letra = 'C';
        else if (nota >= 6.0)
            letra = 'D';
        else
            letra = 'F';

        return letra;
    }

    // Retorna el estado del estudiante segun su nota
    static string DeterminarEstado(double nota)
    {
        string estado;

        if (nota >= 6.0)
            estado = "Aprobado";
        else
            estado = "Reprobado";

        return estado;
    }

    // Imprime la tabla con los datos de cada estudiante
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
            char   letra  = ConvertirALetra(notas[i]);
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

    // Imprime los totales y estadisticas del grupo
    static void MostrarResumen(double[] notas, int n)
    {
        double promedio = CalcularPromedio(notas, n);
        double maximo   = CalcularMaximo(notas, n);
        double minimo   = CalcularMinimo(notas, n);

        int aprobados  = 0;
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

    // Punto de entrada del ejercicio, llamado desde Program.cs
    public static void Iniciar()
    {
        Console.Clear();
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine("  SISTEMA DE REGISTRO DE NOTAS ESTUDIANTILES");
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine();

        // Leer la cantidad de estudiantes
        int  n      = 0;
        bool valido = false;

        while (!valido)
        {
            Console.Write("  Cantidad de estudiantes: ");
            string entrada = Console.ReadLine() ?? "";   // ?? "" evita valor nulo

            if (int.TryParse(entrada, out n) && n > 0)
                valido = true;
            else
                Console.WriteLine("  Ingresa un numero entero mayor a 0.");
        }

        // Declarar vectores paralelos para nombres y notas
        string[] nombres = new string[n];
        double[] notas   = new double[n];

        Console.WriteLine();

        // Ingresar los datos de cada estudiante
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("  Estudiante " + (i + 1));

            // Validar que el nombre no este vacio
            string nombre = "";
            while (nombre == "")
            {
                Console.Write("  Nombre: ");
                nombre = (Console.ReadLine() ?? "").Trim();  // ?? "" evita valor nulo
                if (nombre == "")
                    Console.WriteLine("  El nombre no puede estar vacio.");
            }
            nombres[i] = nombre;

            // Validar que la nota este entre 0.0 y 10.0
            double nota     = 0;
            bool notaValida = false;

            while (!notaValida)
            {
                Console.Write("  Nota (0.0 - 10.0): ");
                string entradaNota = (Console.ReadLine() ?? "").Replace(',', '.');  // ?? "" evita valor nulo

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

        // Mostrar resultados
        MostrarReporte(nombres, notas, n);
        MostrarResumen(notas, n);

        Console.Write("\n  Presiona ENTER para volver al menu principal...");
        Console.ReadLine();
    }
}