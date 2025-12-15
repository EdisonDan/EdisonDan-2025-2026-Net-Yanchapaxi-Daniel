using System;

// Clase que representa un círculo con encapsulación de datos
public class Circulo
{
    private double radio;

    public double Radio
    {
        get { return radio; }
        set
        {
            if (value > 0)
                radio = value;
            else
                throw new ArgumentException("El radio debe ser mayor que cero");
        }
    }

    public Circulo(double radioInicial)
    {
        Radio = radioInicial;
    }

    public double CalcularArea()
    {
        return Math.PI * radio * radio;
    }

    public double CalcularPerimetro()
    {
        return 2 * Math.PI * radio;
    }

    public override string ToString()
    {
        return $"Círculo - Radio: {radio:F2}, Área: {CalcularArea():F2}, Perímetro: {CalcularPerimetro():F2}";
    }

}

// Clase que representa un rectángulo con encapsulación de datos
public class Rectangulo
{
    // Campos privados para almacenar las dimensiones del rectángulo
    private double baseRectangulo;
    private double altura;

    // Propiedad pública para acceder y modificar la base con validación
    // Asegura que la base siempre sea un valor positivo
    public double Base
    {
        get { return baseRectangulo; }
        set 
        { 
            if (value > 0)
                baseRectangulo = value;
            else
                throw new ArgumentException("La base debe ser mayor que cero");
        }
    }

    // Propiedad pública para acceder y modificar la altura con validación
    // Asegura que la altura siempre sea un valor positivo
    public double Altura
    {
        get { return altura; }
        set 
        { 
            if (value > 0)
                altura = value;
            else
                throw new ArgumentException("La altura debe ser mayor que cero");
        }
    }

    // Constructor que inicializa el rectángulo con base y altura específicas
    // Parámetros: 
    //   baseInicial - valor inicial para la base del rectángulo
    //   alturaInicial - valor inicial para la altura del rectángulo
    public Rectangulo(double baseInicial, double alturaInicial)
    {
        Base = baseInicial;     // Usa la propiedad para validar
        Altura = alturaInicial; // Usa la propiedad para validar
    }

    // CalcularArea es un método que devuelve un valor double
    // Calcula el área del rectángulo usando la fórmula: base * altura
    // Retorna: el área del rectángulo
    public double CalcularArea()
    {
        return baseRectangulo * altura;
    }

    // CalcularPerimetro es un método que devuelve un valor double
    // Calcula el perímetro usando la fórmula: 2 * (base + altura)
    // Retorna: el perímetro del rectángulo
    public double CalcularPerimetro()
    {
        return 2 * (baseRectangulo + altura);
    }

    // Método que verifica si el rectángulo es un cuadrado
    // Retorna: true si la base y altura son iguales, false en caso contrario
    public bool EsCuadrado()
    {
        return Math.Abs(baseRectangulo - altura) < 0.0001; // Compara con tolerancia
    }

    // Método ToString sobrescrito para mostrar información del rectángulo
    // Retorna: una cadena con los datos del rectángulo formateados
    public override string ToString()
    {
        string tipo = EsCuadrado() ? "Cuadrado" : "Rectángulo";
        return $"{tipo} - Base: {baseRectangulo:F2}, Altura: {altura:F2}, Área: {CalcularArea():F2}, Perímetro: {CalcularPerimetro():F2}";
    }
}

// Clase principal para demostrar el uso de las figuras geométricas
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== DEMOSTRACIÓN DE FIGURAS GEOMÉTRICAS ===\n");

        // Crear un círculo con radio de 5 unidades
        Circulo miCirculo = new Circulo(5.0);
        Console.WriteLine(miCirculo.ToString());
        Console.WriteLine();

        // Crear un rectángulo con base 8 y altura 4
        Rectangulo miRectangulo = new Rectangulo(8.0, 4.0);
        Console.WriteLine(miRectangulo.ToString());
        Console.WriteLine();

        // Crear un cuadrado (rectángulo con lados iguales)
        Rectangulo miCuadrado = new Rectangulo(6.0, 6.0);
        Console.WriteLine(miCuadrado.ToString());
        Console.WriteLine();

        // Modificar propiedades usando los setters
        Console.WriteLine("--- Modificando valores ---");
        miCirculo.Radio = 7.5;
        Console.WriteLine($"Círculo con nuevo radio: {miCirculo}");
        
        miRectangulo.Base = 10.0;
        miRectangulo.Altura = 5.0;
        Console.WriteLine($"Rectángulo modificado: {miRectangulo}");

        Console.ReadKey();
    }
}
