using System;
using System.Collections.Generic;
using System.Linq;

namespace EjerciciosListas
{
    // Ejercicio 3: Gestor de Calificaciones
    class GestorCalificaciones
    {
        private List<string> asignaturas;
        private Dictionary<string, double> calificaciones;

        public GestorCalificaciones()
        {
            asignaturas = new List<string> { "Matemáticas", "Física", "Química", "Historia", "Lengua" };
            calificaciones = new Dictionary<string, double>();
        }

        public void CapturarNotas()
        {
            Console.WriteLine("=== EJERCICIO 3: REGISTRO DE CALIFICACIONES ===\n");
            foreach (var asignatura in asignaturas)
            {
                Console.Write($"Introduce la nota de {asignatura}: ");
                if (double.TryParse(Console.ReadLine(), out double nota))
                {
                    calificaciones[asignatura] = nota;
                }
                else
                {
                    Console.WriteLine("Nota inválida. Se asignará 0.");
                    calificaciones[asignatura] = 0;
                }
            }
        }

        public void MostrarCalificaciones()
        {
            Console.WriteLine("\n--- Tus calificaciones ---");
            foreach (var asignatura in asignaturas)
            {
                Console.WriteLine($"En {asignatura} has sacado {calificaciones[asignatura]}");
            }
        }

        public void Ejecutar()
        {
            CapturarNotas();
            MostrarCalificaciones();
        }
    }

    // Ejercicio 4: Lotería Primitiva
    class LoteriaPrimitiva
    {
        private List<int> numerosGanadores;

        public LoteriaPrimitiva()
        {
            numerosGanadores = new List<int>();
        }

        public void CapturarNumeros()
        {
            Console.WriteLine("\n\n=== EJERCICIO 4: LOTERÍA PRIMITIVA ===\n");
            Console.WriteLine("Introduce los 6 números ganadores de la lotería:");
            
            for (int i = 1; i <= 6; i++)
            {
                Console.Write($"Número {i}: ");
                if (int.TryParse(Console.ReadLine(), out int numero))
                {
                    numerosGanadores.Add(numero);
                }
                else
                {
                    Console.WriteLine("Número inválido. Intenta de nuevo.");
                    i--;
                }
            }
        }

        public void MostrarNumerosOrdenados()
        {
            numerosGanadores.Sort();
            Console.WriteLine("\n--- Números ganadores ordenados ---");
            Console.WriteLine(string.Join(", ", numerosGanadores));
        }

        public void Ejecutar()
        {
            CapturarNumeros();
            MostrarNumerosOrdenados();
        }
    }

    // Ejercicio 5: Números en Orden Inverso
    class NumerosInversos
    {
        private List<int> numeros;

        public NumerosInversos()
        {
            numeros = new List<int>();
        }

        public void GenerarNumeros()
        {
            for (int i = 1; i <= 10; i++)
            {
                numeros.Add(i);
            }
        }

        public void MostrarInverso()
        {
            Console.WriteLine("\n\n=== EJERCICIO 5: NÚMEROS DEL 1 AL 10 EN ORDEN INVERSO ===\n");
            numeros.Reverse();
            Console.WriteLine(string.Join(", ", numeros));
        }

        public void Ejecutar()
        {
            GenerarNumeros();
            MostrarInverso();
        }
    }

    // Ejercicio 6: Asignaturas a Repetir
    class AsignaturasRepetir
    {
        private List<string> asignaturas;
        private Dictionary<string, double> calificaciones;
        private const double NOTA_APROBADO = 5.0;

        public AsignaturasRepetir()
        {
            asignaturas = new List<string> { "Matemáticas", "Física", "Química", "Historia", "Lengua" };
            calificaciones = new Dictionary<string, double>();
        }

        public void CapturarNotas()
        {
            Console.WriteLine("\n\n=== EJERCICIO 6: ASIGNATURAS A REPETIR ===\n");
            foreach (var asignatura in asignaturas)
            {
                Console.Write($"Introduce la nota de {asignatura}: ");
                if (double.TryParse(Console.ReadLine(), out double nota))
                {
                    calificaciones[asignatura] = nota;
                }
                else
                {
                    Console.WriteLine("Nota inválida. Se asignará 0.");
                    calificaciones[asignatura] = 0;
                }
            }
        }

        public void MostrarAsignaturasRepetir()
        {
            var asignaturasRepetir = asignaturas.Where(a => calificaciones[a] < NOTA_APROBADO).ToList();
            
            Console.WriteLine("\n--- Asignaturas que debes repetir ---");
            if (asignaturasRepetir.Count == 0)
            {
                Console.WriteLine("¡Felicidades! Has aprobado todas las asignaturas.");
            }
            else
            {
                foreach (var asignatura in asignaturasRepetir)
                {
                    Console.WriteLine($"- {asignatura} (Nota: {calificaciones[asignatura]})");
                }
            }
        }

        public void Ejecutar()
        {
            CapturarNotas();
            MostrarAsignaturasRepetir();
        }
    }

    // Ejercicio 7: Abecedario sin Múltiplos de 3
    class AbecedarioFiltrado
    {
        private List<char> abecedario;

        public AbecedarioFiltrado()
        {
            abecedario = new List<char>();
        }

        public void GenerarAbecedario()
        {
            for (char letra = 'a'; letra <= 'z'; letra++)
            {
                abecedario.Add(letra);
            }
        }

        public void EliminarMultiplosDeTres()
        {
            // Eliminar letras en posiciones múltiplos de 3 (posiciones 3, 6, 9, ...)
            // Las posiciones empiezan en 1
            List<char> resultado = new List<char>();
            for (int i = 0; i < abecedario.Count; i++)
            {
                if ((i + 1) % 3 != 0)
                {
                    resultado.Add(abecedario[i]);
                }
            }
            abecedario = resultado;
        }

        public void MostrarAbecedario()
        {
            Console.WriteLine("\n\n=== EJERCICIO 7: ABECEDARIO SIN MÚLTIPLOS DE 3 ===\n");
            Console.WriteLine("Abecedario sin letras en posiciones múltiplos de 3:");
            Console.WriteLine(string.Join(", ", abecedario));
        }

        public void Ejecutar()
        {
            GenerarAbecedario();
            EliminarMultiplosDeTres();
            MostrarAbecedario();
        }
    }

    // Programa Principal
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("╔════════════════════════════════════════════════╗");
            Console.WriteLine("║  EJERCICIOS DE LISTAS EN C# CON POO           ║");
            Console.WriteLine("╚════════════════════════════════════════════════╝");

            // Ejercicio 3
            var ejercicio3 = new GestorCalificaciones();
            ejercicio3.Ejecutar();

            // Ejercicio 4
            var ejercicio4 = new LoteriaPrimitiva();
            ejercicio4.Ejecutar();

            // Ejercicio 5
            var ejercicio5 = new NumerosInversos();
            ejercicio5.Ejecutar();

            // Ejercicio 6
            var ejercicio6 = new AsignaturasRepetir();
            ejercicio6.Ejecutar();

            // Ejercicio 7
            var ejercicio7 = new AbecedarioFiltrado();
            ejercicio7.Ejecutar();

            Console.WriteLine("\n\n¡Ejercicios completados!");
            Console.WriteLine("Presiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
