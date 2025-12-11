using System;
using System.Collections.Generic;

public class Producto
{
    public string Nombre { get; set; }
    public double Precio { get; set; }

    public Producto(string nombre, double precio)
    {
        Nombre = nombre;
        Precio = precio;
    }

    public override string ToString() => $"{Nombre} - ${Precio:F2}";
}

public class CarritoCompras
{
    public static void Main()
    {
        List<Producto> carrito = new List<Producto>();
        string opcion;

        do
        {
            Console.WriteLine("\n--- Carrito de Compras ---");
            Console.WriteLine("1. Agregar producto");
            Console.WriteLine("2. Eliminar producto (por nombre)");
            Console.WriteLine("3. Mostrar carrito y total");
            Console.WriteLine("4. Salir");
            Console.Write("Elige una opción: ");
            opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Nombre del producto: ");
                    string nombre = Console.ReadLine();
                    Console.Write("Precio: $");
                    if (double.TryParse(Console.ReadLine(), out double precio) && precio > 0)
                    {
                        carrito.Add(new Producto(nombre, precio));
                        Console.WriteLine($" '{nombre}' agregado.");
                    }
                    else
                        Console.WriteLine(" Precio inválido.");
                    break;

                case "2":
                    Console.Write("Nombre del producto a eliminar: ");
                    string aEliminar = Console.ReadLine();
                    Producto encontrado = carrito.Find(p => p.Nombre.Equals(aEliminar, StringComparison.OrdinalIgnoreCase));
                    if (encontrado != null)
                    {
                        carrito.Remove(encontrado);
                        Console.WriteLine($" '{aEliminar}' eliminado.");
                    }
                    else
                        Console.WriteLine($"  Producto '{aEliminar}' no encontrado.");
                    break;

                case "3":
                    if (carrito.Count == 0)
                    {
                        Console.WriteLine("El carrito está vacío.");
                    }
                    else
                    {
                        Console.WriteLine("\n--- Productos en el carrito ---");
                        double total = 0;
                        foreach (var p in carrito)
                        {
                            Console.WriteLine(p);
                            total += p.Precio;
                        }
                        Console.WriteLine($"TOTAL: ${total:F2}");
                    }
                    break;

                case "4":
                    Console.WriteLine("Saliendo del carrito...");
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        } while (opcion != "4");
    }
}
