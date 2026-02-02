

using System;


namespace NavegadorWeb
 {
    class Program
    {
       static void Main()
     {
         Navegador nav = new Navegador();
          int op;

          do
          {
             Console.WriteLine("\n1. Visitar página");
             Console.WriteLine("2. Retroceder");
             Console.WriteLine("3. Mostrar historial");
             Console.WriteLine("4. Salir");
             Console.Write("Opción: ");

            if (int.TryParse(Console.ReadLine(), out op)) continue;


            switch (op)
            {
               case 1:
                   Console.Write("URL: "); 
                   nav.VisitarPagina(Console.ReadLine()); 
                   break;

               case 2:
                   nav.Retroceder();
                   break; 
                
               case 3:
                   nav.MostrarHistorial(); 
                   break;
               case 4:
                   Console.WriteLine("Saliendo...");
                   break;
               default:
                   Console.WriteLine("Opcion no valida.");
                   break;

            }
        } while (op != 4);
      }
    }
 }
 