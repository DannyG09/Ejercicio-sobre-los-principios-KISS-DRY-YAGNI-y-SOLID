using System;

namespace DRY_Principle
{
    class Program
    {
        static void Main()
        {
            Console.Write("Seleccione el tipo de empleado (1: Tiempo completo, 2: Medio tiempo): ");
            int tipo = int.Parse(Console.ReadLine() ?? "1");

            decimal salarioBase = tipo == 1 ? ObtenerSalarioBase() : ObtenerSalarioPorHora();
            decimal salarioNeto = CalcularSalarioNeto(salarioBase);

            Console.WriteLine($"Salario neto después de impuestos y bono: {salarioNeto}");
        }

        static decimal ObtenerSalarioBase()
        {
            Console.Write("Ingrese el salario base: ");
            return decimal.TryParse(Console.ReadLine(), out var salario) ? salario : 0;
        }

        static decimal ObtenerSalarioPorHora()
        {
            Console.Write("Ingrese el sueldo por hora: ");
            decimal sueldoPorHora = decimal.TryParse(Console.ReadLine(), out var sueldo) ? sueldo : 0;

            Console.Write("Ingrese las horas trabajadas: ");
            int horas = int.TryParse(Console.ReadLine(), out var h) ? h : 0;

            return sueldoPorHora * horas;
        }

        static decimal CalcularSalarioNeto(decimal salario)
        {
            const decimal impuesto = 0.18m;
            const decimal bono = 0.05m;
            return salario * (1 - impuesto + bono);
        }
    }
}
