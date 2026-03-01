using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

class Traductor
{
    static void Main()
    {
        // Diccionario Español -> Inglés
        Dictionary<string, string> diccionario = new Dictionary<string, string>()
        {
            {"dia", "day"}, {"mundo", "world"}, {"punto", "point"},  {"trabajo", "work"},
            {"vida", "life"},{"cosa", "thing"}, {"caso", "case"}, {"lugar", "place"},
            {"mano", "hand"},{"tema", "point"}, {"semana", "week"},  {"mujer", "woman"},
            {"ojo", "eye"},  {"niña", "child"}, {"niño", "child"},  {"parte", "part"},
            {"hombre", "man"},
           
        };

        int opcion;

        do
        {
            Console.WriteLine("Ingrese una frase:");
            string? entrada = Console.ReadLine();
            string frase = entrada?.ToLower() ?? "";

            string[] palabras = frase.Split(' ');
            bool encontrada = false;

            // Reemplazar palabra si existe en diccionario
            for (int i = 0; i < palabras.Length; i++)
            {
                if (diccionario.ContainsKey(palabras[i]))
                {
                    palabras[i] = diccionario[palabras[i]];
                    encontrada = true;
                }
            }

            if (encontrada)
            {
                Console.WriteLine("\nFrase traducida:");
                Console.WriteLine(string.Join(" ", palabras));
            }
            else
            {
                Console.WriteLine("\nNo se encontró ninguna palabra en el diccionario.");
            }

            Console.WriteLine("\nOpciones:");
            Console.WriteLine("Presione 1 para intentar nuevamente.");
            Console.WriteLine("Presione 2 agregar nueva palabra.");
            Console.WriteLine("Presione 0 para salir.");

            while (!int.TryParse(Console.ReadLine(), out opcion) ||
                   (opcion != 0 && opcion != 1 && opcion != 2))
            {
                Console.WriteLine("Opción inválida. Intente nuevamente.");
            }

            if (opcion == 2)
            {
                Console.WriteLine("Ingrese palabra en español:");
                string? esp = Console.ReadLine();
                string palabraEsp = esp?.ToLower() ?? "";

                Console.WriteLine("Ingrese traducción en inglés:");
                string? ing = Console.ReadLine();
                string palabraIng = ing?.ToLower() ?? "";

                if (!diccionario.ContainsKey(palabraEsp))
                {
                    diccionario.Add(palabraEsp, palabraIng);
                    Console.WriteLine("Palabra agregada correctamente al diccionario");
                }
                else
                {
                    Console.WriteLine("La palabra ya existe.");
                }

                opcion = 1;
            }

            Console.WriteLine();

        } while (opcion == 1);

        Console.WriteLine("Programa finalizado.");
    }
}
