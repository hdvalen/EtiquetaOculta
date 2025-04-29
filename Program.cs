internal class Program
{
    private static void Main(string[] args)
    {
        List<Producto> productos = new List<Producto>
        {
            new Producto { Id = 1, Nombre = "Laptop HP", Categoria = "Electrónica", Precio = 3500, Stock = 10},
            new Producto { Id = 2, Nombre = "Mouse Logitech", Categoria = "Electrónica", Precio = 150, Stock = 50 },
            new Producto { Id = 3, Nombre = "Silla de Oficina", Categoria = "Muebles", Precio = 800, Stock = 5  },
            new Producto { Id = 4, Nombre = "Cafetera Oster", Categoria = "Electrodomésticos", Precio = 600, Stock = 0},
            new Producto { Id = 5, Nombre = "Escritorio Moderno", Categoria = "Muebles", Precio = 1200, Stock = 7},
            new Producto { Id = 6, Nombre = "Monitor Samsung", Categoria = "Electrónica", Precio = 2500, Stock = 8},
            new Producto { Id = 7, Nombre = "Teclado Mecánico", Categoria = "Electrónica", Precio = 400, Stock = 15},
            new Producto { Id = 8, Nombre = "Aspiradora LG", Categoria = "Electrodomésticos", Precio = 1100, Stock = 2}
        };

        var productosConEtiquetas = new List <(string Producto, List<string> Etiquetas)>
        {
            ("Laptop HP", new List<string> {"Electronica", "Computadores", "Trabajo"}),
            ("Silla de Oficina", new List<string> {"Muebles", "Confort", "Oficina"}),
            ("Cafeteria Oster", new List<string> {"Cocina", "Electrodomesticos", "Cafe"}),
            ("Mouse Logitech", new List<string> {"Electronica", "Computadores", "Trabajo"}),
            ("Escritorio Moderno", new List<string> {"Muebles", "Confort", "Oficina"}),
            ("Monitor Samsung", new List<string> {"Electronica", "Computadores", "Trabajo"}),
            ("Teclado Mecanico", new List<string> {"Electronica", "Computadores", "Trabajo"}),
            ("Aspiradora LG", new List<string> {"Sala", "Electrodomesticos", "Hogar"}),
        };

        Console.WriteLine("\nTodas las Etiquetas: ");
        var todasEtiquetas = productosConEtiquetas.SelectMany(p=> p.Etiquetas).Distinct();
        foreach(var Etiquetas in todasEtiquetas)
            Console.WriteLine(Etiquetas);

        //Lista de productos

        Console.WriteLine("\nTodos los productos: ");
        var nombresProductos = productos.Select(p=>p.Nombre);
        foreach (var nombre in nombresProductos)
            Console.WriteLine(nombre);

        //Cada producto tiene varias etiquetas
        
    }
}