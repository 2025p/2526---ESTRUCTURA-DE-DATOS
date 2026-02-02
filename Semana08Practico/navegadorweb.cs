using System;
using System.Collections.Generic;


namespace NavegadorWeb
{
  public class Navegador
{
       private Stack<string> historial = new Stack<string>();

       public void VisitarPagina(string pagina)
       {
          historial.Push(pagina); 
          Console.WriteLine("Página visitada: " + pagina);
       }


  public void Retroceder()
   {
      if (historial.Count > 1)
       {
          historial.Pop();
          Console.WriteLine("Retrocedió a: " + historial.Peek());
 
       }
      else
       {
          Console.WriteLine("No hay páginas anteriores.");
       }
     }

   public void MostrarHistorial()
     {
        Console.WriteLine("\nHistorial:");
        foreach (string pagina in historial)
        {
           Console.WriteLine("- " + pagina);}
        }
      }
    }
 
