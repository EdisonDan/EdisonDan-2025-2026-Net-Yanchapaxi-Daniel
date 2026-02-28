using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Se inicializa el diccionario con las palabras base (Español -> Inglés)
        Dictionary<string, string> diccionario = new Dictionary<string, string>()
        {
            {"tiempo", "time"},
            {"persona", "person"},
            {"año", "year"},
            {"día", "day"},
            {"dia", "day"}, // Por si el usuario lo escribe sin tilde
            {"cosa", "thing"},
            {"hombre", "man"},
            {"mundo", "world"},
            {"vida", "life"},
            {"mano", "hand"},
            {"parte", "part"},
            {"ojo", "eye"},
            {"mujer", "woman"},
            {"lugar", "place"},
            {"trabajo", "work"},
            {"empresa", "company"}
        };

        int opcion = -1;

        while (opcion != 0)
        {
            Console.WriteLine("\nMENÚ\n");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Agregar palabras al diccionario");
            Console.WriteLine("0. Salir\n");
            Console.Write("Seleccione una opción: ");
            
            // TryParse para evitar que el programa se caiga si ingresan una letra
            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Por favor, ingrese un número válido.");
                continue;
            }

            if (opcion == 1)
            {
                Console.Write("\nIngrese la frase a traducir: ");
                string frase = Console.ReadLine();
                
                // Separamos la frase en palabras por los espacios
                string[] palabras = frase.Split(' ');
                string fraseTraducida = "";

                foreach (string palabra in palabras)
                {
                    // Limpiamos la palabra de comas o puntos para buscarla bien en el diccionario
                    string palabraLimpia = palabra.Replace(",", "").Replace(".", "").ToLower();

                    if (diccionario.ContainsKey(palabraLimpia))
                    {
                        // Si la palabra original tenía coma o punto, se lo volvemos a poner a la traducción
                        if (palabra.Contains(","))
                        {
                            fraseTraducida += diccionario[palabraLimpia] + ", ";
                        }
                        else if (palabra.Contains("."))
                        {
                            fraseTraducida += diccionario[palabraLimpia] + ". ";
                        }
                        else
                        {
                            fraseTraducida += diccionario[palabraLimpia] + " ";
                        }
                    }
                    else
                    {
                        // Si no está en el diccionario, dejamos la palabra tal cual
                        fraseTraducida += palabra + " ";
                    }
                }

                Console.WriteLine("\nTraducción: " + fraseTraducida.Trim());
            }
            else if (opcion == 2)
            {
                Console.Write("\nIngrese la palabra en español: ");
                string espanol = Console.ReadLine().ToLower();
                
                Console.Write("Ingrese la traducción en inglés: ");
                string ingles = Console.ReadLine().ToLower();

                // Verificamos que la palabra no exista antes de agregarla
                if (!diccionario.ContainsKey(espanol))
                {
                    diccionario.Add(espanol, ingles);
                    Console.WriteLine("¡Palabra agregada correctamente!");
                }
                else
                {
                    Console.WriteLine("Esa palabra ya existe en el diccionario.");
                }
            }
            else if (opcion != 0)
            {
                Console.WriteLine("\nOpción incorrecta. Intente de nuevo.");
            }
        }
        
        Console.WriteLine("Saliendo del programa...");
    }
}