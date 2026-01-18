using System;
using System.Collections.Generic;

public class Nodo
{
    public int Dato { get; set; }
    public Nodo Siguiente { get; set; }

    public Nodo(int dato)
    {
        Dato = dato;
        Siguiente = null;
    }
}

public class ListaEnlazada
{
    private Nodo cabeza;

    public ListaEnlazada()
    {
        cabeza = null;
    }

    // Agregar elemento al final
    public void Agregar(int dato)
    {
        Nodo nuevoNodo = new Nodo(dato);
        
        if (cabeza == null)
        {
            cabeza = nuevoNodo;
            return;
        }
        
        Nodo actual = cabeza;
        while (actual.Siguiente != null)
        {
            actual = actual.Siguiente;
        }
        actual.Siguiente = nuevoNodo;
    }

    // EJERCICIO 2: Invertir la lista
    public void InvertirLista()
    {
        if (cabeza == null || cabeza.Siguiente == null)
            return;

        Nodo anterior = null;
        Nodo actual = cabeza;
        Nodo siguiente = null;

        while (actual != null)
        {
            siguiente = actual.Siguiente;
            actual.Siguiente = anterior;
            anterior = actual;
            actual = siguiente;
        }
        
        cabeza = anterior;
        Console.WriteLine("Lista invertida correctamente");
    }

    // EJERCICIO 3: Buscar elemento
    public void BuscarElemento(int valor)
    {
        int ocurrencias = 0;
        Nodo actual = cabeza;

        while (actual != null)
        {
            if (actual.Dato == valor)
                ocurrencias++;
            actual = actual.Siguiente;
        }

        if (ocurrencias == 0)
        {
            Console.WriteLine($"El dato {valor} no fue encontrado");
        }
        else
        {
            Console.WriteLine($"El dato {valor} se encuentra " +
                            $"{ocurrencias} vez/veces en la lista");
        }
    }

    // Mostrar lista
    public void MostrarLista()
    {
        if (cabeza == null)
        {
            Console.WriteLine("Lista vacía");
            return;
        }

        Nodo actual = cabeza;
        while (actual != null)
        {
            Console.Write(actual.Dato);
            if (actual.Siguiente != null)
                Console.Write(" -> ");
            actual = actual.Siguiente;
        }
        Console.WriteLine();
    }
}

// Programa principal
class Program
{
    static void Main()
    {
        ListaEnlazada lista = new ListaEnlazada();

        // Agregar elementos
        lista.Agregar(5);
        lista.Agregar(10);
        lista.Agregar(3);
        lista.Agregar(8);
        lista.Agregar(10);

        Console.WriteLine("Lista original:");
        lista.MostrarLista();

        // Ejercicio 3: Buscar elemento
        lista.BuscarElemento(10);
        lista.BuscarElemento(99);

        // Ejercicio 2: Invertir lista
        lista.InvertirLista();
        Console.WriteLine("\nLista invertida:");
        lista.MostrarLista();
    }
}
