using System;

// Clase para representar cada nodo del árbol
class Nodo
{
    public int Valor;
    public Nodo Izquierdo;
    public Nodo Derecho;

    public Nodo(int valor)
    {
        Valor = valor;
        Izquierdo = null;
        Derecho = null;
    }
}

// Clase principal del Árbol Binario de Búsqueda
class ArbolBST
{
    private Nodo raiz;

    public ArbolBST()
    {
        raiz = null;
    }

    // ==================== INSERTAR ====================
    public void Insertar(int valor)
    {
        raiz = InsertarRecursivo(raiz, valor);
    }

    private Nodo InsertarRecursivo(Nodo nodo, int valor)
    {
        if (nodo == null)
            return new Nodo(valor);

        if (valor < nodo.Valor)
            nodo.Izquierdo = InsertarRecursivo(nodo.Izquierdo, valor);
        else if (valor > nodo.Valor)
            nodo.Derecho = InsertarRecursivo(nodo.Derecho, valor);
        else
            Console.WriteLine($"  [!] El valor {valor} ya existe en el árbol.");

        return nodo;
    }

    // ==================== BUSCAR ====================
    public bool Buscar(int valor)
    {
        return BuscarRecursivo(raiz, valor);
    }

    private bool BuscarRecursivo(Nodo nodo, int valor)
    {
        if (nodo == null)
            return false;

        if (valor == nodo.Valor)
            return true;
        else if (valor < nodo.Valor)
            return BuscarRecursivo(nodo.Izquierdo, valor);
        else
            return BuscarRecursivo(nodo.Derecho, valor);
    }

    // ==================== ELIMINAR ====================
    public void Eliminar(int valor)
    {
        if (!Buscar(valor))
        {
            Console.WriteLine($"  [!] El valor {valor} no existe en el árbol.");
            return;
        }
        raiz = EliminarRecursivo(raiz, valor);
        Console.WriteLine($"  Valor {valor} eliminado correctamente.");
    }

    private Nodo EliminarRecursivo(Nodo nodo, int valor)
    {
        if (nodo == null)
            return null;

        if (valor < nodo.Valor)
            nodo.Izquierdo = EliminarRecursivo(nodo.Izquierdo, valor);
        else if (valor > nodo.Valor)
            nodo.Derecho = EliminarRecursivo(nodo.Derecho, valor);
        else
        {
            // Caso 1: nodo sin hijos
            if (nodo.Izquierdo == null && nodo.Derecho == null)
                return null;

            // Caso 2: nodo con un solo hijo
            if (nodo.Izquierdo == null)
                return nodo.Derecho;
            if (nodo.Derecho == null)
                return nodo.Izquierdo;

            // Caso 3: nodo con dos hijos -> buscar el sucesor inorden (mínimo del subárbol derecho)
            int sucesor = ObtenerMinimo(nodo.Derecho);
            nodo.Valor = sucesor;
            nodo.Derecho = EliminarRecursivo(nodo.Derecho, sucesor);
        }

        return nodo;
    }

    // ==================== RECORRIDOS ====================
    public void Preorden()
    {
        if (raiz == null) { Console.WriteLine("  El árbol está vacío."); return; }
        Console.Write("  Preorden (Raíz - Izq - Der): ");
        PreordenRecursivo(raiz);
        Console.WriteLine();
    }

    private void PreordenRecursivo(Nodo nodo)
    {
        if (nodo == null) return;
        Console.Write(nodo.Valor + " ");
        PreordenRecursivo(nodo.Izquierdo);
        PreordenRecursivo(nodo.Derecho);
    }

    public void Inorden()
    {
        if (raiz == null) { Console.WriteLine("  El árbol está vacío."); return; }
        Console.Write("  Inorden (Izq - Raíz - Der): ");
        InordenRecursivo(raiz);
        Console.WriteLine();
    }

    private void InordenRecursivo(Nodo nodo)
    {
        if (nodo == null) return;
        InordenRecursivo(nodo.Izquierdo);
        Console.Write(nodo.Valor + " ");
        InordenRecursivo(nodo.Derecho);
    }

    public void Postorden()
    {
        if (raiz == null) { Console.WriteLine("  El árbol está vacío."); return; }
        Console.Write("  Postorden (Izq - Der - Raíz): ");
        PostordenRecursivo(raiz);
        Console.WriteLine();
    }

    private void PostordenRecursivo(Nodo nodo)
    {
        if (nodo == null) return;
        PostordenRecursivo(nodo.Izquierdo);
        PostordenRecursivo(nodo.Derecho);
        Console.Write(nodo.Valor + " ");
    }

    // ==================== MÍNIMO Y MÁXIMO ====================
    private int ObtenerMinimo(Nodo nodo)
    {
        while (nodo.Izquierdo != null)
            nodo = nodo.Izquierdo;
        return nodo.Valor;
    }

    private int ObtenerMaximo(Nodo nodo)
    {
        while (nodo.Derecho != null)
            nodo = nodo.Derecho;
        return nodo.Valor;
    }

    public void MostrarMinimo()
    {
        if (raiz == null) { Console.WriteLine("  El árbol está vacío."); return; }
        Console.WriteLine($"  Valor mínimo: {ObtenerMinimo(raiz)}");
    }

    public void MostrarMaximo()
    {
        if (raiz == null) { Console.WriteLine("  El árbol está vacío."); return; }
        Console.WriteLine($"  Valor máximo: {ObtenerMaximo(raiz)}");
    }

    // ==================== ALTURA ====================
    public void MostrarAltura()
    {
        if (raiz == null) { Console.WriteLine("  El árbol está vacío."); return; }
        int altura = CalcularAltura(raiz);
        Console.WriteLine($"  Altura del árbol: {altura}");
    }

    private int CalcularAltura(Nodo nodo)
    {
        if (nodo == null)
            return 0;

        int altIzq = CalcularAltura(nodo.Izquierdo);
        int altDer = CalcularAltura(nodo.Derecho);

        return 1 + Math.Max(altIzq, altDer);
    }

    // ==================== LIMPIAR ====================
    public void Limpiar()
    {
        raiz = null;
        Console.WriteLine("  Árbol limpiado correctamente.");
    }

    public bool EstaVacio()
    {
        return raiz == null;
    }
}

// ==================== PROGRAMA PRINCIPAL ====================
class Program
{
    static void Main(string[] args)
    {
        ArbolBST arbol = new ArbolBST();
        int opcion;

        Console.WriteLine("==============================================");
        Console.WriteLine("   ÁRBOL BINARIO DE BÚSQUEDA (BST) en C#");
        Console.WriteLine("==============================================");

        do
        {
            MostrarMenu();
            Console.Write("Selecciona una opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("  [!] Entrada inválida, ingresa un número.\n");
                continue;
            }

            Console.WriteLine();

            switch (opcion)
            {
                case 1: // Insertar
                    Console.Write("  Ingresa el valor a insertar: ");
                    if (int.TryParse(Console.ReadLine(), out int valInsertar))
                    {
                        arbol.Insertar(valInsertar);
                        Console.WriteLine($"  Valor {valInsertar} insertado.");
                    }
                    else
                        Console.WriteLine("  [!] Valor inválido.");
                    break;

                case 2: // Buscar
                    Console.Write("  Ingresa el valor a buscar: ");
                    if (int.TryParse(Console.ReadLine(), out int valBuscar))
                    {
                        bool encontrado = arbol.Buscar(valBuscar);
                        if (encontrado)
                            Console.WriteLine($"  El valor {valBuscar} SÍ existe en el árbol.");
                        else
                            Console.WriteLine($"  El valor {valBuscar} NO existe en el árbol.");
                    }
                    else
                        Console.WriteLine("  [!] Valor inválido.");
                    break;

                case 3: // Eliminar
                    Console.Write("  Ingresa el valor a eliminar: ");
                    if (int.TryParse(Console.ReadLine(), out int valEliminar))
                        arbol.Eliminar(valEliminar);
                    else
                        Console.WriteLine("  [!] Valor inválido.");
                    break;

                case 4: // Recorridos
                    arbol.Preorden();
                    arbol.Inorden();
                    arbol.Postorden();
                    break;

                case 5: // Mínimo, Máximo y Altura
                    arbol.MostrarMinimo();
                    arbol.MostrarMaximo();
                    arbol.MostrarAltura();
                    break;

                case 6: // Limpiar
                    Console.Write("  ¿Estás seguro que deseas limpiar el árbol? (s/n): ");
                    string resp = Console.ReadLine().ToLower();
                    if (resp == "s")
                        arbol.Limpiar();
                    else
                        Console.WriteLine("  Operación cancelada.");
                    break;

                case 0:
                    Console.WriteLine("  Saliendo del programa... ¡Hasta luego!");
                    break;

                default:
                    Console.WriteLine("  [!] Opción no válida, intenta de nuevo.");
                    break;
            }

            Console.WriteLine();

        } while (opcion != 0);
    }

    static void MostrarMenu()
    {
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine(" MENÚ PRINCIPAL");
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine(" 1. Insertar valor");
        Console.WriteLine(" 2. Buscar valor");
        Console.WriteLine(" 3. Eliminar valor");
        Console.WriteLine(" 4. Ver recorridos (Preorden, Inorden, Postorden)");
        Console.WriteLine(" 5. Ver mínimo, máximo y altura");
        Console.WriteLine(" 6. Limpiar árbol");
        Console.WriteLine(" 0. Salir");
        Console.WriteLine("----------------------------------------------");
    }
}