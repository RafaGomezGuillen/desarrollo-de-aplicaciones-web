namespace Programa06
{
    class Producto
    {
        public static List<Producto> listaProductos = new()
        {
            new Producto ("Coca Cola", 1, 5),
            new Producto ("Galletas", 1.5m, 3),
            new Producto ("Platano Canario", 2m, 2),
            new Producto ("Agua", 1, 6),
            new Producto ("Vino", 7.5m, 8)
        };
        private string NombreProducto { get; set; }
        private decimal Precio { get; set; }
        private int Stock { get; set; }
        public Producto ()
        {
            NombreProducto = "Producto por defecto";
            Precio = 5;
            Stock = Maquina.stock;
        }
        public Producto (string producto, decimal precio, int stock)
        {
            SetProducto(producto);
            SetPrecio(precio);
            SetStock(stock);
        }
        public void SetProducto (string producto)
        {
            if (string.IsNullOrEmpty(producto.Trim()))
            {
                NombreProducto = "Producto por defecto";
            }
            else
            {
                NombreProducto = producto;
            }
        }
        public void SetPrecio (decimal precio)
        {
            if (precio < 0)
            {
                Precio = 1;
            }
            else
            {
                Precio = precio;
            }
        }
        public void SetStock (int stock)
        {
            if (stock < 0)
            {
                Stock = Maquina.stock;
            }
            else
            {
                Stock = stock;
            }
        }
        public string GetProducto () { return NombreProducto; }
        public decimal GetPrecio () { return Precio; }
        public int GetStock () { return Stock; }
        public override string ToString ()
        {
            return $"|{NombreProducto}||{Precio} euros||Stock[{Stock}]|";
        }

        public static void VerProductos ()
        {
            int i = 1;
            listaProductos.ForEach(p =>
            {
                Console.WriteLine($"[{i++}]{p}");
            });
            Menu.Adios();
        }
        public static void AñadirProducto ()
        {
            if (Maquina.linea > listaProductos.Count)
            {
                Producto producto = new Producto();
                producto.SetProducto(Funciones.PedirProducto());
                producto.SetPrecio(Funciones.PedirPrecio());
                producto.SetStock(Funciones.PedirStock());
                listaProductos.Add(producto);
            }
            else
            {
                Console.WriteLine("Has llegado al máximo de productos posibles.");
            }
            Menu.Adios();
        }
        public static void QuitarProducto ()
        {
            listaProductos.RemoveAt(Funciones.ElegirProducto("eliminar"));
            Menu.Adios();
        }
        public static void AñadirStock ()
        {
            listaProductos[Funciones.ElegirProducto("añadir stock")].SetStock(Funciones.PedirStock());
            Menu.Adios();
        }
        public static void RellenarMaquina ()
        {
            listaProductos.ForEach(p =>
            {
                p.SetStock(10);
            });
            Console.WriteLine("Maquina rellenada.");
            Menu.Adios();
        }
        public static void ComprarProducto ()
        {
            decimal dinero = 0;
            Console.Write("\nIntroduce dinero: ");
            while (!decimal.TryParse(Console.ReadLine(), out dinero) || dinero <= 0)
            {
                Console.Write("\nIntroduce un dinero mayor que 0: ");
            }

            int indexProducto = Funciones.ElegirProducto("comprar");
            decimal dineroProducto = listaProductos[indexProducto].GetPrecio();

            if (dinero >= dineroProducto)
            {
                Console.WriteLine($"Ha comprado un {listaProductos[indexProducto].GetProducto()}");
                Console.WriteLine($"Su vuelto es: {dinero - dineroProducto}.");
                listaProductos[indexProducto].SetStock(listaProductos[indexProducto].GetStock() - 1);
            }
            else
            {
                Console.WriteLine("No tiene el suficiente dinero.");
            }
            Menu.Adios();
        }
    }
}
