using System;

namespace GestionEstudiantes
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("  SISTEMA DE GESTIÓN DE ESTUDIANTES");
            Console.WriteLine("═══════════════════════════════════════\n");

            // Solicitar datos del estudiante
            Console.Write("Ingrese el ID del estudiante: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Ingrese los nombres: ");
            string nombres = Console.ReadLine();

            Console.Write("Ingrese los apellidos: ");
            string apellidos = Console.ReadLine();

            Console.Write("Ingrese la dirección: ");
            string direccion = Console.ReadLine();

            // Crear array para almacenar 3 números de teléfono
            string[] telefonos = new string[3];

            Console.WriteLine("\nIngrese los números de teléfono:");
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"Teléfono {i + 1}: ");
                telefonos[i] = Console.ReadLine();
            }

            // Crear objeto estudiante con los datos ingresados
            Estudiante estudiante = new Estudiante(id, nombres,
                                                   apellidos, direccion,
                                                   telefonos);

            // Mostrar la información del estudiante
            estudiante.MostrarInformacion();

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            if (!Console.IsInputRedirected) Console.ReadKey();
        }
    }
}


namespace GestionEstudiantes
{
    // Clase que representa a un estudiante
    public class Estudiante
    {
        // Propiedades de la clase
        public int ID { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        
        // Array para almacenar los números de teléfono
        public string[] Telefonos { get; set; }

        // Constructor de la clase
        public Estudiante(int id, string nombres, string apellidos, 
                         string direccion, string[] telefonos)
        {
            ID = id;
            Nombres = nombres;
            Apellidos = apellidos;
            Direccion = direccion;
            Telefonos = telefonos;
        }

        // Método para mostrar la información del estudiante
        public void MostrarInformacion()
        {
            Console.WriteLine("\n╔═══════════════════════════════════════╗");
            Console.WriteLine("║     INFORMACIÓN DEL ESTUDIANTE        ║");
            Console.WriteLine("╚═══════════════════════════════════════╝\n");
            
            Console.WriteLine($"ID:        {ID}");
            Console.WriteLine($"Nombres:   {Nombres}");
            Console.WriteLine($"Apellidos: {Apellidos}");
            Console.WriteLine($"Dirección: {Direccion}");
            
            Console.WriteLine("\nTeléfonos:");
            for (int i = 0; i < Telefonos.Length; i++)
            {
                Console.WriteLine($"  [{i + 1}] {Telefonos[i]}");
            }
            Console.WriteLine();
        }
    }
}
