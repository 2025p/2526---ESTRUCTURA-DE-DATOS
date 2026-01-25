// Programa para verificar si una formula matematica esta balanceada en cuanto a parentisis, corchetes y llaves.

using System;
using System.Collections.Generic;

// Definimos la clase Balanceada.
class Balanceada
{
    public static bool EstaBalanceada(string expresion)
    {
        Stack<char> pila = new Stack<char>();
        foreach (char c in expresion)
        {
            if (c == '(' || c == '[' || c == '{') 
                pila.Push(c);
            else if (c == ')' || c == ']' || c == '}')
            {
                if (pila.Count == 0) return false;
                char ultimo = pila.Pop();
                if (!SonPareja(ultimo, c)) return false;
            }
        }
        return pila.Count == 0;
    }
   // Metodo para verificar si los caracteres estan Balanceados.
    private static bool SonPareja(char apertura, char cierre)
    {
        return (apertura == '(' && cierre == ')') ||
               (apertura == '[' && cierre == ']') ||
               (apertura == '{' && cierre == '}');
    }
    //creamos el metodo Main para probar la funcion.
    static void Main()
    {
        string formula = "{7 + (8 * 5) - [(9 - 7) + (4 + 3)]}";
        if (EstaBalanceada(formula))
            Console.WriteLine("Fórmula balanceada.");
        else
            Console.WriteLine("Fórmula no balanceada.");
    }
}

