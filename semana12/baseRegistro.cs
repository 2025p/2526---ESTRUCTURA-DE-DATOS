using System;
using System.Collections.Generic;

namespace TorneoFutbol
{
    // Clase básica para representar a un jugador
    public class Jugador
    {
        public string Nombre { get; set; }
        public int Dorsal { get; set; }

        public Jugador(string nombre, int dorsal)
        {
            Nombre = nombre;
            Dorsal = dorsal;
        }

        // Sobrescribimos Equals y GetHashCode para que el HashSet 
        // identifique si un jugador es "el mismo" por su dorsal.
        public override bool Equals(object obj)
        {
            return obj is Jugador j && j.Dorsal == this.Dorsal;
        }

        public override int GetHashCode() => Dorsal.GetHashCode();
    }

    public class Equipo
    {
        public string Nombre { get; set; }
        // Conjunto de jugadores (Teoría de conjuntos: No duplicados)
        public HashSet<Jugador> Jugadores { get; set; } = new HashSet<Jugador>();

        public Equipo(string nombre) => Nombre = nombre;

        public void AgregarJugador(Jugador j)
        {
            if (!Jugadores.Add(j)) 
                Console.WriteLine($"¡Error! El dorsal {j.Dorsal} ya existe en {Nombre}.");
        }
    }

    class Program
    {
        static void Main()
        {
            // El Mapa (Diccionario): Nombre del Equipo -> Objeto Equipo
            Dictionary<string, Equipo> torneo = new Dictionary<string, Equipo>();

            // 1. Registrar Equipos
            torneo.Add("Real Madrid", new Equipo("Real Madrid"));
            torneo.Add("FC Barcelona", new Equipo("FC Barcelona"));

            // 2. Registrar Jugadores en un equipo específico usando la llave
            var madrid = torneo["Real Madrid"];
            madrid.AgregarJugador(new Jugador("Vinicius", 7));
            madrid.AgregarJugador(new Jugador("Mbappé", 9));
            madrid.AgregarJugador(new Jugador("Modric", 10));
            
            // Intento de duplicado (La teoría de conjuntos lo bloquea)
            madrid.AgregarJugador(new Jugador("Infiltrado", 7)); 

            // 3. Mostrar información
            Console.WriteLine("\n--- Lista de Equipos en el Torneo ---");
            foreach (var nombre in torneo.Keys)
            {
                Console.WriteLine($"- {nombre}");
            }
        }
    }
}
