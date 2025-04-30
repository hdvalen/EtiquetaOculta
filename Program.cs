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
         Console.WriteLine("\n Productos con sus respectivas etiquetas: ");
         var etiquetasPorProducto = from p in productos
                                   join e in productosConEtiquetas  //'join' (unión) entre la lista de productos y la lista de productosConEtiquetas
                                   on p.Nombre equals e.Producto
                                   select new { p.Nombre, Etiquetas = string.Join(", ", e.Etiquetas) }; //Unir las etiquetas separadas por comas

        foreach (var item in etiquetasPorProducto)
            Console.WriteLine($"{item.Nombre} - Etiquetas: {item.Etiquetas}");
        

        //El programa aplanara todas las etiquetas usando SelectMany
        Console.WriteLine("\nTodas las etiquetas únicas:");
         var todasLasEtiquetas = productosConEtiquetas
            .SelectMany(p => p.Etiquetas) // devuelve todas las etiquetas en una sola lista
            .Distinct();                  // elimina las etiquetas duplicadas
        foreach (var etiqueta in todasLasEtiquetas)
        {
            Console.WriteLine(etiqueta);
        }

        //El sistema elige aleatoriamente una etiqueta oculta

        var listaEtiquetas = todasLasEtiquetas.ToList();
        Random random = new Random();
        string etiquetaOculta = listaEtiquetas[random.Next(listaEtiquetas.Count)];

        //El usuario tiene que adivinar la etiqueta

        Console.WriteLine("\n Adivina la etiqueta secreta");
        string intentoUsuario;
        do
        {
            Console.Write("Tu intento: ");
            intentoUsuario = Console.ReadLine();

        if (intentoUsuario.Equals(etiquetaOculta, StringComparison.OrdinalIgnoreCase))  // .Equals() compara los textos y StringComparison.OrdinalIgnoreCase para mayúsculas o minúsculas
        {
        Console.WriteLine("🎉 Adivinaste la etiqueta secreta.");
        }
         else
        {   
        Console.WriteLine($"❌ Incorrecto. Pista: comienza con '{etiquetaOculta[0]}' y tiene {etiquetaOculta.Length} letras.");
        }

        } while (!intentoUsuario.Equals(etiquetaOculta, StringComparison.OrdinalIgnoreCase));
    }
}