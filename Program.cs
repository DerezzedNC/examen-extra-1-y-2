using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace InventarioApp
{
    
    public class Producto
    {
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }

        public Producto(string nombre, double precio, int cantidad)
        {
            Nombre = nombre;
            Precio = precio;
            Cantidad = cantidad;
        }

        
        public double TotalVentas()
        {
            return Precio * Cantidad;
        }
    }

  
    public class Inventario
    {
        public List<Producto> Productos { get; set; }

        public Inventario()
        {
            Productos = new List<Producto>();
        }

        public void CargarDesdeArchivo(string ruta)
        {
            try
            {
                string[] lineas = File.ReadAllLines(ruta);

                foreach (var linea in lineas)
                {
                    string[] partes = linea.Split(',');

                    if (partes.Length == 3)
                    {
                        string nombre = partes[0].Trim();
                        double precio = double.Parse(partes[1].Trim());
                        int cantidad = int.Parse(partes[2].Trim());

                        Productos.Add(new Producto(nombre, precio, cantidad));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al leer el archivo: " + ex.Message);
            }
        }

        public double CalcularTotalVentas()
        {
            return Productos.Sum(p => p.TotalVentas());
        }

        public Producto ObtenerProductoMasCaro()
        {
            return Productos.OrderByDescending(p => p.Precio).FirstOrDefault();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Ingrese el nombre del producto vendido:");
            string nombreUsuario = Console.ReadLine();

            Console.WriteLine("Ingrese la cantidad vendida:");
            int cantidadUsuario = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el precio unitario:");
            double precioUsuario = double.Parse(Console.ReadLine());

            Producto productoUsuario = new Producto(nombreUsuario, precioUsuario, cantidadUsuario);

           
            Inventario inventario = new Inventario();
            inventario.CargarDesdeArchivo("productos.json");

            Console.WriteLine("\n--- Reporte de Ventas ---");

           
            double totalVentas = inventario.CalcularTotalVentas() + productoUsuario.TotalVentas();
            Console.WriteLine($"Total de ventas realizadas: ${totalVentas}");

            Producto masCaro = inventario.ObtenerProductoMasCaro();

            if (masCaro != null)
            {
                Console.WriteLine($"Producto más caro: {masCaro.Nombre} (${masCaro.Precio})");
            }
            else
            {
                Console.WriteLine("No se encontraron productos en el inventario.");
            }
        }
    }
}
