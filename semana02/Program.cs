// Programa para calcular el area y el perimetro de un circulo y un rectangulo.
using System;

namespace FigurasGeometricas
{
    //  Creamos la clase para el Círculo
    public class Circulo
    {
        
        private double radio;

        
        public Circulo(double radio)
        {
            this.radio = radio;
        }

        // Método para calcular el área: π * r²
        public double CalcularArea()
        {
            return Math.PI * Math.Pow(radio, 2);
        }

        // Método para calcular el perímetro: 2 * π * r
        public double CalcularPerimetro()
        {
            return 2 * Math.PI * radio;
        }
    }

    //  Clase para el Rectángulo
    public class Rectangulo
    {
        
        private double @base;
        private double altura;

        
        public Rectangulo(double @base, double altura)
        {
            this.@base = @base;
            this.altura = altura;
        }

        // Método para calcular el área: base * altura
        public double CalcularArea()
        {
            return @base * altura;
        }

        // Método para calcular el perímetro: 2 * (base + altura)
        public double CalcularPerimetro()
        {
            return 2 * (@base + altura);
        }
    }

    // Clase principal para probar el código
    class Program
    {
        static void Main()
        {
            
            Circulo miCirculo = new Circulo(5.0);
            Console.WriteLine($"Círculo -> Área: {miCirculo.CalcularArea():F2}, Perímetro: {miCirculo.CalcularPerimetro():F2}");

            
            Rectangulo miRect = new Rectangulo(10.0, 4.0);
            Console.WriteLine($"Rectángulo -> Área: {miRect.CalcularArea():F2}, Perímetro: {miRect.CalcularPerimetro():F2}");
        }
    }
}

