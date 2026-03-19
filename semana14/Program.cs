class Program
{
    static void Main()
    {
        var bst = new EstructuraDatos.ArbolBinarioBusqueda();
        int opcion, valor;

        do {
            Console.WriteLine("\n   MENÚ DEL ÁRBOL BINARIO DE BÚSQUEDA    ");
            Console.WriteLine("1. Insertar");
            Console.WriteLine("2. Buscar");
            Console.WriteLine("3. Eliminar");
            Console.WriteLine("4. Recorridos");
            Console.WriteLine("5. Estadísticas");
            Console.WriteLine("6. Limpiar");
            Console.WriteLine("7. Salir");
            Console.Write("Seleccione: ");
            
            if (!int.TryParse(Console.ReadLine(), out opcion)) continue;

            switch (opcion) {
                case 1:
                    Console.Write("Valor a insertar: ");
                    bst.Insertar(int.Parse(Console.ReadLine()));
                    break;
                case 2:
                    Console.Write("Valor a buscar: ");
                    Console.WriteLine(bst.Buscar(int.Parse(Console.ReadLine())) ? "¡Encontrado!" : "No existe.");
                    break;
                case 3:
                    Console.Write("Valor a eliminar: ");
                    bst.Eliminar(int.Parse(Console.ReadLine()));
                    break;
                case 4:
                    Console.Write("\nPreorden: "); bst.Preorden(bst.Raiz);
                    Console.Write("\nInorden: "); bst.Inorden(bst.Raiz);
                    Console.Write("\nPostorden: "); bst.Postorden(bst.Raiz);
                    Console.WriteLine();
                    break;
                case 5:
                    if (bst.Raiz == null) Console.WriteLine("Árbol vacío.");
                    else {
                        Console.WriteLine($"Mínimo: {bst.MinimoValor(bst.Raiz)}");
                        Console.WriteLine($"Máximo: {bst.MaximoValor(bst.Raiz)}");
                        Console.WriteLine($"Altura: {bst.ObtenerAltura(bst.Raiz)}");
                    }
                    break;
                case 6:
                    bst.Limpiar();
                    Console.WriteLine("Árbol borrado.");
                    break;
            }
        } while (opcion != 7);
    }
}
