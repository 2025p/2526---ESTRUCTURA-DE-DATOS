// Programa para gestionar registros de estudiantes usando una lista enlazada

using System;
using System.Collections.Generic;

namespace RegistroRedesIII
{
    // Informacion que representa al Estudiante (Nodo)
    public class Estudiante
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public double NotaDefinitiva { get; set; }
        public Estudiante Siguiente { get; set; } 

        public Estudiante(string cedula, string nombre, string apellido, string correo, double nota)
        {
            Cedula = cedula;
            Nombre = nombre;
            Apellido = apellido;
            Correo = correo;
            NotaDefinitiva = nota;
            Siguiente = null;
        }
    }

    // Clase de Lista Enlazada
    public class ListaEstudiantes
    {
        private Estudiante cabeza;

        public void Agregar(Estudiante nuevo)
        {
            // Regla: Aprobados (>= 7) al inicio, Reprobados (< 7) al final
            if (nuevo.NotaDefinitiva >= 7)
            {
                nuevo.Siguiente = cabeza;
                cabeza = nuevo;
                Console.WriteLine("Estudiante aprobado insertado al inicio.");
            }
            else
            {
                if (cabeza == null)
                {
                    cabeza = nuevo;
                }
                else
                {
                    Estudiante actual = cabeza;
                    while (actual.Siguiente != null)
                    {
                        actual = actual.Siguiente;
                    }
                    actual.Siguiente = nuevo;
                }
                Console.WriteLine("Estudiante reprobado insertado al final.");
            }
        }

        public Estudiante Buscar(string cedula)
        {
            Estudiante actual = cabeza;
            while (actual != null)
            {
                if (actual.Cedula == cedula) return actual;
                actual = actual.Siguiente;
            }
            return null;
        }

        public bool Eliminar(string cedula)
        {
            if (cabeza == null) return false;

            if (cabeza.Cedula == cedula)
            {
                cabeza = cabeza.Siguiente;
                return true;
            }

            Estudiante actual = cabeza;
            while (actual.Siguiente != null && actual.Siguiente.Cedula != cedula)
            {
                actual = actual.Siguiente;
            }

            if (actual.Siguiente != null)
            {
                actual.Siguiente = actual.Siguiente.Siguiente;
                return true;
            }
            return false;
        }

        public void ContarTotales()
        {
            int aprobados = 0;
            int reprobados = 0;
            Estudiante actual = cabeza;
            while (actual != null)
            {
                if (actual.NotaDefinitiva >= 7) aprobados++;
                else reprobados++;
                actual = actual.Siguiente;
            }
            Console.WriteLine($"\nTotal Aprobados: {aprobados}");
            Console.WriteLine($"Total Reprobados: {reprobados}");
        }
    }

    //  Programa Principal
    class Program
    {
        static void Main(string[] args)
        {
            ListaEstudiantes lista = new ListaEstudiantes();
            int opcion;

            do
            {
                Console.WriteLine("\n--- REGISTROS DE ESTUDIANTES ---");
                Console.WriteLine("1. Agregar Estudiante");
                Console.WriteLine("2. Buscar por Cédula");
                Console.WriteLine("3. Eliminar Estudiante");
                Console.WriteLine("4. Ver Totales (Aprobados/Reprobados)");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.Write("Cédula: "); string c = Console.ReadLine();
                        Console.Write("Nombre: "); string n = Console.ReadLine();
                        Console.Write("Apellido: "); string a = Console.ReadLine();
                        Console.Write("Correo: "); string co = Console.ReadLine();
                        Console.Write("Nota (1-10): "); double nt = double.Parse(Console.ReadLine());
                        lista.Agregar(new Estudiante(c, n, a, co, nt));
                        break;
                    case 2:
                        Console.Write("Cédula a buscar: ");
                        var est = lista.Buscar(Console.ReadLine());
                        if (est != null) Console.WriteLine($"Encontrado: {est.Nombre} {est.Apellido} - Nota: {est.NotaDefinitiva}");
                        else Console.WriteLine("No encontrado.");
                        break;
                    case 3:
                        Console.Write("Cédula a eliminar: ");
                        if (lista.Eliminar(Console.ReadLine())) Console.WriteLine("Eliminado con éxito.");
                        else Console.WriteLine("No se encontró el estudiante.");
                        break;
                    case 4:
                        lista.ContarTotales();
                        break;
                }
            } while (opcion != 5);
        }
    }
}
