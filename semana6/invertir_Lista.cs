//Creamos una lista enlazada y el objetivo es invertir el orden de sus elementos

using System;
using System.Collections.Generic;

   class Program
    {
        static void Main()
        {
            // Creamos la lista con una sola coma entre números
            List<int> numeros = new List<int> { 19, 28, 37, 46, 55, 64, 73, 82, 91 };

            // Invertimos la lista
            numeros.Reverse();

            Console.WriteLine("Se invirtio la lista enlazada:");
            foreach (int n in numeros)
            {
                Console.Write(n + " ");
            }
        }
    }


