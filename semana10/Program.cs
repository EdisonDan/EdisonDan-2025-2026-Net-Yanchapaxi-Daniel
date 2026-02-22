using System;
using System.Collections.Generic;
using System.Linq;

namespace CampanaVacunacion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // 1. GENERACIÓN DE CONJUNTOS FICTICIOS

            // Conjunto universo: 500 ciudadanos
            HashSet<string> ciudadanos = new HashSet<string>();
            for (int i = 1; i <= 500; i++)
                ciudadanos.Add($"Ciudadano {i}");

            // Convertir a lista para facilitar la selección aleatoria
            List<string> listaCiudadanos = ciudadanos.ToList();

            Random rnd = new Random(42); // Semilla fija para reproducibilidad

            // Función auxiliar: seleccionar N ciudadanos aleatorios distintos de una lista
            HashSet<string> SeleccionarAleatorios(List<string> fuente, int cantidad)
            {
                // Mezclar la lista con Fisher-Yates y tomar los primeros 'cantidad'
                List<string> copia = new List<string>(fuente);
                for (int i = copia.Count - 1; i > 0; i--)
                {
                    int j = rnd.Next(0, i + 1);
                    string temp = copia[i];
                    copia[i] = copia[j];
                    copia[j] = temp;
                }
                return new HashSet<string>(copia.Take(cantidad));
            }

            // Conjunto A: 75 ciudadanos vacunados con Pfizer
            HashSet<string> vacunadosPfizer = SeleccionarAleatorios(listaCiudadanos, 75);

            // Para AstraZeneca, excluimos primero los ya elegidos para Pfizer
            // (permitir solapamiento parcial: algunos pueden tener ambas dosis)
            // Se permite que un ciudadano aparezca en ambos conjuntos (recibió ambas dosis).
            HashSet<string> vacunadosAstraZeneca = SeleccionarAleatorios(listaCiudadanos, 75);

            // 2. OPERACIONES DE TEORÍA DE CONJUNTOS

            // Unión: ciudadanos que recibieron AL MENOS UNA dosis
            HashSet<string> alMenosUnaDosis = new HashSet<string>(vacunadosPfizer);
            alMenosUnaDosis.UnionWith(vacunadosAstraZeneca);

            // 2.1 No vacunados: Diferencia(Universo, Unión)
            HashSet<string> noVacunados = new HashSet<string>(ciudadanos);
            noVacunados.ExceptWith(alMenosUnaDosis);

            // 2.2 Ambas dosis: Intersección(Pfizer, AstraZeneca)
            HashSet<string> ambasDosis = new HashSet<string>(vacunadosPfizer);
            ambasDosis.IntersectWith(vacunadosAstraZeneca);

            // 2.3 Solo Pfizer: Diferencia(Pfizer, AstraZeneca)
            HashSet<string> soloPfizer = new HashSet<string>(vacunadosPfizer);
            soloPfizer.ExceptWith(vacunadosAstraZeneca);

            // 2.4 Solo AstraZeneca: Diferencia(AstraZeneca, Pfizer)
            HashSet<string> soloAstraZeneca = new HashSet<string>(vacunadosAstraZeneca);
            soloAstraZeneca.ExceptWith(vacunadosPfizer);

            // 3. PRESENTACIÓN DE RESULTADOS

            Console.WriteLine("   CAMPAÑA DE VACUNACIÓN COVID-19 – MINISTERIO DE SALUD");

            Console.WriteLine($"\nTotal ciudadanos (Universo):        {ciudadanos.Count}");
            Console.WriteLine($"Vacunados con Pfizer      (|A|):    {vacunadosPfizer.Count}");
            Console.WriteLine($"Vacunados con AstraZeneca (|B|):    {vacunadosAstraZeneca.Count}");

            //  Listado 1: No vacunados 
            Console.WriteLine($"[1] CIUDADANOS NO VACUNADOS  (|U - (A ∪ B)|) = {noVacunados.Count}");
            ImprimirConjunto(noVacunados.OrderBy(c => ObtenerNumero(c)));

            // Listado 2: Ambas dosis
            Console.WriteLine($"[2] CIUDADANOS CON AMBAS DOSIS  (|A ∩ B|) = {ambasDosis.Count}");
            ImprimirConjunto(ambasDosis.OrderBy(c => ObtenerNumero(c)));

            // Listado 3: Solo Pfizer 
            Console.WriteLine($"[3] CIUDADANOS SOLO CON PFIZER  (|A - B|) = {soloPfizer.Count}");
            ImprimirConjunto(soloPfizer.OrderBy(c => ObtenerNumero(c)));

            // Listado 4: Solo AstraZeneca 
            Console.WriteLine($"[4] CIUDADANOS SOLO CON ASTRAZENECA  (|B - A|) = {soloAstraZeneca.Count}");
            ImprimirConjunto(soloAstraZeneca.OrderBy(c => ObtenerNumero(c)));

            // Verificación de consistencia 
            Console.WriteLine("VERIFICACIÓN DE CONSISTENCIA");
            int total = noVacunados.Count + ambasDosis.Count + soloPfizer.Count + soloAstraZeneca.Count;
            Console.WriteLine($"No vacunados + Ambas dosis + Solo Pfizer + Solo AstraZeneca = {total}");
            Console.WriteLine($"Debe coincidir con el universo: {ciudadanos.Count}");
            Console.WriteLine(total == ciudadanos.Count ? "✔ Verificación exitosa." : "✘ Error en la verificación.");

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }

        // Extrae el número de "Ciudadano N" para ordenar numéricamente
        static int ObtenerNumero(string ciudadano)
        {
            string[] partes = ciudadano.Split(' ');
            return int.TryParse(partes[1], out int n) ? n : 0;
        }

        // Imprime los ciudadanos de un conjunto en columnas de 5
        static void ImprimirConjunto(IEnumerable<string> conjunto)
        {
            int col = 0;
            foreach (string c in conjunto)
            {
                Console.Write($"  {c,-15}");
                if (++col % 5 == 0) Console.WriteLine();
            }
            if (col % 5 != 0) Console.WriteLine();
        }
    }
}