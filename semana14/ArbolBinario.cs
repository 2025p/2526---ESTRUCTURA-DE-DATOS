using System;

namespace EstructuraDatos
{
    // Clase Nodo: La unidad básica del árbol
    public class Nodo
    {
        public int Valor;
        public Nodo Izquierdo, Derecho;

        public Nodo(int item)
        {
            Valor = item;
            Izquierdo = Derecho = null;
        }
    }

    // Clase BST: Contiene toda la lógica de gestión
    public class ArbolBinarioBusqueda
    {
        public Nodo Raiz;

        public ArbolBinarioBusqueda() => Raiz = null;

        // Operaciones de insercion, busqueda y eliminacion.

        public void Insertar(int valor) => Raiz = InsertarRecursivo(Raiz, valor);
        private Nodo InsertarRecursivo(Nodo raiz, int valor)
        {
            if (raiz == null) return new Nodo(valor);
            if (valor < raiz.Valor) raiz.Izquierdo = InsertarRecursivo(raiz.Izquierdo, valor);
            else if (valor > raiz.Valor) raiz.Derecho = InsertarRecursivo(raiz.Derecho, valor);
            return raiz;
        }

        public bool Buscar(int valor) => BuscarRecursivo(Raiz, valor);
        private bool BuscarRecursivo(Nodo raiz, int valor)
        {
            if (raiz == null) return false;
            if (raiz.Valor == valor) return true;
            return valor < raiz.Valor ? BuscarRecursivo(raiz.Izquierdo, valor) : BuscarRecursivo(raiz.Derecho, valor);
        }

        public void Eliminar(int valor) => Raiz = EliminarRecursivo(Raiz, valor);
        private Nodo EliminarRecursivo(Nodo raiz, int valor)
        {
            if (raiz == null) return raiz;
            if (valor < raiz.Valor) raiz.Izquierdo = EliminarRecursivo(raiz.Izquierdo, valor);
            else if (valor > raiz.Valor) raiz.Derecho = EliminarRecursivo(raiz.Derecho, valor);
            else {
                if (raiz.Izquierdo == null) return raiz.Derecho;
                else if (raiz.Derecho == null) return raiz.Izquierdo;
                raiz.Valor = MinimoValor(raiz.Derecho);
                raiz.Derecho = EliminarRecursivo(raiz.Derecho, raiz.Valor);
            }
            return raiz;
        }

        // Estructura de recorrido
        public void Inorden(Nodo raiz) { if (raiz != null) { Inorden(raiz.Izquierdo); Console.Write(raiz.Valor + " "); Inorden(raiz.Derecho); } }
        public void Preorden(Nodo raiz) { if (raiz != null) { Console.Write(raiz.Valor + " "); Preorden(raiz.Izquierdo); Preorden(raiz.Derecho); } }
        public void Postorden(Nodo raiz) { if (raiz != null) { Postorden(raiz.Izquierdo); Postorden(raiz.Derecho); Console.Write(raiz.Valor + " "); } }

        // Logica adicional
        public int MinimoValor(Nodo raiz) { int min = raiz.Valor; while (raiz.Izquierdo != null) { min = raiz.Izquierdo.Valor; raiz = raiz.Izquierdo; } return min; }
        public int MaximoValor(Nodo raiz) { int max = raiz.Valor; while (raiz.Derecho != null) { max = raiz.Derecho.Valor; raiz = raiz.Derecho; } return max; }
        public int ObtenerAltura(Nodo raiz) => raiz == null ? 0 : Math.Max(ObtenerAltura(raiz.Izquierdo), ObtenerAltura(raiz.Derecho)) + 1;
        public void Limpiar() => Raiz = null;
    }
}
