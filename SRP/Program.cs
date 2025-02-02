using System;

namespace SOLID_Principle
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("1. Email");
            Console.WriteLine("2. SMS");
            Console.Write("Seleccione el tipo de notificación: ");
            string input = Console.ReadLine() ?? string.Empty;
            
            int opcion;
            if (!int.TryParse(input, out opcion))
            {
                Console.WriteLine("Opción no válida.");
                return; // Salir si la opción no es válida
            }
            
            Console.Write("Ingrese el mensaje: ");
            string mensaje = Console.ReadLine() ?? string.Empty;
            
            // Validamos si el mensaje es nulo o vacío
            if (string.IsNullOrEmpty(mensaje))  
            {
                Console.WriteLine("El mensaje no puede ser nulo o vacío.");
                return; // Salir si el mensaje es nulo o vacío
            }
            
            INotificacion notificacion = opcion == 1 ? new EmailNotificacion() : new SMSNotificacion();
            notificacion.Enviar(mensaje);
            
            Logger.Registrar("Notificación enviada.");
        }
    }

    interface INotificacion
    {
        void Enviar(string mensaje);
    }

    class EmailNotificacion : INotificacion
    {
        public void Enviar(string mensaje)
        {
            Console.WriteLine($"Enviando Email: {mensaje}");
        }
    }

    class SMSNotificacion : INotificacion
    {
        public void Enviar(string mensaje)
        {
            Console.WriteLine($"Enviando SMS: {mensaje}");
        }
    }

    static class Logger
    {
        public static void Registrar(string mensaje)
        {
            Console.WriteLine($"Log: {mensaje}");
        }
    }
}