using System;
using System.Linq;

namespace KISS_Principle
{
    class Program
    {
        static void Main()
        {
            Console.Write("Ingrese los precios de los platos (separados por comas): ");
            string input = Console.ReadLine() ?? ""; // Evita posibles null
            var precios = input.Split(',')
                               .Select(p => decimal.TryParse(p.Trim(), out var precio) ? precio : 0)
                               .ToList();

            Console.Write("¿Desea agregar una propina personalizada? (s/n): ");
            string respuesta = Console.ReadLine()?.Trim().ToLower() ?? "n";
            decimal propina = respuesta == "s" ? ObtenerPropina() : 0.10m;

            decimal total = precios.Sum() * (1 + propina);
            Console.WriteLine($"Total a pagar (con propina del {propina * 100}%): {total}");
        }

        static decimal ObtenerPropina()
        {
            Console.Write("Ingrese el porcentaje de propina (ej. 0.15 para 15%): ");
            string input = Console.ReadLine() ?? "0.10"; // Valor predeterminado
            return decimal.TryParse(input.Trim(), out var propina) ? propina : 0.10m;
        }
    }
}
