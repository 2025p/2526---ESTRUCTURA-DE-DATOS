using System;
using System.Collections.Generic;

namespace TorneoFutbol
{
    // Usamos un record para representar al Jugador de forma sencilla
    public record Jugador(string Nombre, int Dorsal);

    public class Equipo
    {
        public string Nombre { get; set; }
        // HashSet (Teoría de Conjuntos) para evitar dorsales duplicados
        public HashSet<Jugador> Jugadores { get; set; } = new HashSet<Jugador>();

        public Equipo(string nombre) => Nombre = nombre;
    }

    class Program
    {
        static void Main()
        {
            // Diccionario (Mapa) para guardar: Nombre del Equipo -> Objeto Equipo
            Dictionary<string, Equipo> torneo = new Dictionary<string, Equipo>();

            Console.WriteLine("=== REGISTRO INTERACTIVO DE TORNEO ===\n");

            // Bucle para 2 equipos
            for (int i = 1; i <= 2; i++)
            {
                Console.Write($"Ingrese el nombre del EQUIPO {i}: ");
                string nombreEquipo = Console.ReadLine() ?? $"Equipo {i}";
                Equipo nuevoEquipo = new Equipo(nombreEquipo);

                Console.WriteLine($"--- Registrando jugadores para {nombreEquipo} (Máximo 8) ---");
                
                while (nuevoEquipo.Jugadores.Count < 8)
                {
                    Console.Write($"\nJugador #{nuevoEquipo.Jugadores.Count + 1} - Nombre (o 'fin' para cerrar equipo): ");
                    string nombreJugador = Console.ReadLine() ?? "";
                    
                    if (nombreJugador.ToLower() == "fin") break;

                    Console.Write($"Jugador #{nuevoEquipo.Jugadores.Count + 1} - Dorsal: ");
                    if (int.TryParse(Console.ReadLine(), out int dorsal))
                    {
                        Jugador j = new Jugador(nombreJugador, dorsal);
                        
                        // .Add devuelve 'false' si el elemento ya existe en el conjunto
                        if (!nuevoEquipo.Jugadores.Add(j))
                        {
                            Console.WriteLine("¡ERROR! Ese dorsal ya existe en este equipo. Intente otro.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Dorsal no válido. Ingrese un número.");
                    }
                }

                // Guardamos el equipo completo en el Mapa (Diccionario)
                torneo.Add(nombreEquipo, nuevoEquipo);
                Console.WriteLine($"\n>> {nombreEquipo} registrado con {nuevoEquipo.Jugadores.Count} jugadores.\n");
            }

            // SALIDA FINAL EN COLUMNAS
            Console.Clear();
            Console.WriteLine("==========================================");
            Console.WriteLine("      RESUMEN FINAL DEL TORNEO");
            Console.WriteLine("==========================================");

            foreach (var entrada in torneo)
            {
                Console.WriteLine($"\nEQUIPO: {entrada.Key.ToUpper()}");
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("{0,-20} {1,10}", "NOMBRE", "DORSAL");
                Console.WriteLine("------------------------------------------");

                foreach (var jugador in entrada.Value.Jugadores)
                {
                    // Formato de columnas: {0,-20} alinea a la izquierda, {1,10} a la derecha
                    Console.WriteLine("{0,-20} {1,10}", jugador.Nombre, jugador.Dorsal);
                }
            }
            Console.WriteLine("==========================================");
        }
    }
}
