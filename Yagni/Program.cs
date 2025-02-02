using System;
using System.Collections.Generic;
using System.Linq;

namespace YAGNI_Principle
{
    class Program
    {
        static List<(int, string, decimal)> productos = new();
        static int idCounter = 1;

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("1. Agregar producto");
                Console.WriteLine("2. Eliminar producto");
                Console.Write("Seleccione una opción: ");
                int opcion;
                while (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.Write("Entrada no válida. Ingrese una opción válida: ");
                }

                if (opcion == 1) AgregarProducto();
                else if (opcion == 2) EliminarProducto();
            }
        }

        static void AgregarProducto()
        {
            Console.Write("Ingrese el nombre del producto: ");
            string nombre = Console.ReadLine() ?? "Producto desconocido";  // Asignamos un valor por defecto si es nulo

            Console.Write("Ingrese el precio: ");
            decimal precio;
            while (!decimal.TryParse(Console.ReadLine(), out precio))
            {
                Console.Write("Por favor ingrese un precio válido: ");
            }

            // Agregar el producto a la lista
            productos.Add((idCounter, nombre, precio));

            // Mostrar mensaje con el ID asignado
            Console.WriteLine($"Producto '{nombre}' agregado con éxito. ID asignado: {idCounter}");

            // Incrementar el contador para el siguiente producto
            idCounter++;
        }

        static void EliminarProducto()
        {
            Console.Write("Ingrese el ID del producto a eliminar: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.Write("Por favor ingrese un ID válido: ");
            }

            var producto = productos.FirstOrDefault(p => p.Item1 == id);
            if (producto.Equals(default((int, string, decimal))))
            {
                Console.WriteLine("Producto no encontrado.");
            }
            else
            {
                productos.RemoveAll(p => p.Item1 == id);
                Console.WriteLine("Producto eliminado.");
            }
        }
    }
}
