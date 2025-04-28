using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace almacenvirtual
{
    public class Producto
    {
        public int Referencia { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; } 

        public Producto(int Referencia, string Nombre, int Cantidad, double Precio)
        {
            Referencia = referencia;
            Nombre = nombre;
            Cantidad = cantidad;
            Precio = precio;

        }

    }

    public class Inventario
    {
        public List<Producto> productos { get; set; }

        public Inventario()
        {
            productos = new List<Producto>();
        }
    }

    class Program
    {
        static void Main(strings[] args)
        {
               while(opcion != 5)
               {

            Console.WriteLine("n\---Menu---");

            Console.WriteLine("1. Agregar un producto");

            Console.WriteLine("2. Buscar producto por nombre");

            Console.WriteLine("3. Mostrar todo los productos");

            Console.WriteLine("4. Producto mas caro");

            Console.WriteLine("5. Salir");
            
            int opcion = Convert.ToInt32(Console.ReadLine());

            if(opcion == 1)
            {
                Console.WriteLine("Ingresa la referencia de tu codigo");
                int referenciaprod = int.Parse(Console.ReadLine());

                Console.WriteLine("Ingresa el nombre del producto");
                string nombreprod = Console.ReadLine();

                Console.WriteLine("Ingresa la cantidad");
                int cantidadprod = int.Parse(Console.ReadLine());

                Console.WriteLine("Ingresa su precio");
                double precioprod = double.Parse(Console.ReadLine());

                Producto usuarioproduct = new Producto(referenciaprod, nombreprod, cantidadprod, precioprod);

                Inventario inventario = new Inventario();

            }
            else if (opcion == 2)
            {
                
            }

         
            

            }
            
        }
    }
    
}