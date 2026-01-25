// Programa para resolver el problema de las torres de hanoi usando pilas.

using System;
using System.Collections.Generic;

// Definimos la clase TorresHanoi.
class TorresHanoi
{
    static Stack<int> origen = new Stack<int>();
    static Stack<int> trayecto = new Stack<int>();
    static Stack<int> destino = new Stack<int>();
    
    // Metodo Main para iniciar el programa.
    static void Main()
    {
        int n = 3; 
        for (int i = n; i > 0; i--) origen.Push(i);

        Console.WriteLine("Estado inicial: Origen tiene discos 3, 2, 1");
        ResolverHanoi(n, origen, trayecto, destino, "Origen", "Trayecto", "Destino");
    }
    // Metodo recursivo para resolver los movimientos de los discos.
    static void ResolverHanoi(int n, Stack<int> de, Stack<int> a, Stack<int> tra, 
                               string nombreDe, string nombreA, string nombreTra)
    {
        if (n > 0)
        {
            // Mover discos de Origen a Trayecto
            ResolverHanoi(n - 1, de, tra, a, nombreDe, nombreTra, nombreA);

            // Mover el disco restante a Destino
            int disco = de.Pop();
            a.Push(disco);
            Console.WriteLine($"Mover disco {disco} de {nombreDe} a {nombreA}");

            // Mover discos de Trayecto a Destino
            ResolverHanoi(n - 1, tra, a, de, nombreTra, nombreA, nombreDe);
        }
    }
}
