namespace Programa07
{
    class Cafeteria
    {
        private List<Producto> CartaProductos { get; set; }

        private List<Pedido> ListaPedidos { get; set; }

        private List<Pedido> ListaPedidosServidos { get; set; }

        private string NombreCafeteria { get; set; }

        private int MaximoPedidos { get; set; }

        public Cafeteria ()
        {
            SetCartaProductos(new()
            {
                new Producto ("Coca Cola", 1),
                new Producto ("Galletas", 1.5m),
                new Producto ("Platano Canario", 2.4m),
                new Producto ("Agua", 1),
                new Producto ("Bocadillo", 2.5m)
            });

            SetlistaPedidos(new List<Pedido>());

            SetlistaPedidosServidos(new List<Pedido>());

            SetNombreCafeteria("Cafe Gómez");

            SetMaximoPedidos(5);
        }

        public Cafeteria (List<Producto> cartaProductos, List<Pedido> listaPedidos, List<Pedido> listaPedidosServidos,
                        string nombreCafeteria, int maximoPedidos)
        {
            SetCartaProductos(cartaProductos);
            SetlistaPedidos(listaPedidos);
            SetlistaPedidosServidos(listaPedidosServidos);
            SetNombreCafeteria(nombreCafeteria);
            SetMaximoPedidos(maximoPedidos);
        }

        public void SetCartaProductos (List<Producto> cartaProductos) { CartaProductos = cartaProductos; }

        public void SetlistaPedidos (List<Pedido> listaPedidos) { ListaPedidos = listaPedidos; }

        public void SetlistaPedidosServidos (List<Pedido> listaPedidosServidos) { ListaPedidosServidos = listaPedidosServidos; }

        public void SetNombreCafeteria (string nombreCaferia)
        {
            if (string.IsNullOrEmpty(nombreCaferia.Trim()))
            {
                NombreCafeteria = "Caferia por defecto";
            }
            else
            {
                NombreCafeteria = nombreCaferia;
            }
        }

        public void SetMaximoPedidos (int maximoPedidos)
        {
            if (maximoPedidos < 0)
            {
                MaximoPedidos = 5;
            }
            else
            {
                MaximoPedidos = maximoPedidos;
            }
        }

        public List<Producto> GetCartaProductos () { return CartaProductos; }

        public List<Pedido> GetListaPedidos () { return ListaPedidos; }

        public List<Pedido> GetListaPedidosServidos () { return ListaPedidosServidos; }

        public string GetNombreCageteria () { return NombreCafeteria; }

        public int GetMaximoPedidos () { return MaximoPedidos; }

        public bool PedidoLleno ()
        {
            if (Program.cafeteria.GetListaPedidos().Count < Program.cafeteria.GetMaximoPedidos()) return false;
            return true;
        }

        public bool SepuedePedir ()
        {
            if (Program.cafeteria.GetListaPedidos().Count > 0) return true;
            return false;
        }

        public static void VerCarta ()
        {
            int i = 1;

            Program.cafeteria.GetCartaProductos().ForEach(p =>
            {
                Console.WriteLine($"[{i++}] {p}");
            });
            Menu.Adios();
        }

        public static void VerPedidos ()
        {
            Program.cafeteria.GetListaPedidos().ForEach(p =>
            {
                Console.WriteLine($"{p}");
            });
            Menu.Adios();
        }

        public static void HacerPedido ()
        {
            if (!Program.cafeteria.PedidoLleno())
            {
                string nombre = Pedido.PedirNombre(), eleccion;
                List<Producto> listaProductos = new List<Producto>();
                DateTime fecha = DateTime.Now;
                Console.Clear();

                do
                {
                    Console.Write("¿Quieres un producto? (s -> si): ");
                    eleccion = Console.ReadLine();
                    Console.Clear();

                    if (eleccion == "s")
                    {
                        VerCarta();
                        int indexProducto = Funciones.IndexProducto();
                        listaProductos.Add(Program.cafeteria.GetCartaProductos()[indexProducto]);
                        Console.Clear();
                    }
                } while (eleccion == "s");

                Program.listaPedidos.Add(new Pedido(nombre, listaProductos, fecha));
                Program.cafeteria.SetlistaPedidos(Program.listaPedidos);
            }
            else
            {
                Console.WriteLine($"{Program.cafeteria.GetMaximoPedidos()} pedidos realizados.");
            }
            Menu.Adios();
        }

        public static void ServirPedido ()
        {
            if (Program.cafeteria.SepuedePedir())
            {
                Program.listaPedidosServidos.Add(Program.cafeteria.GetListaPedidos()[0]);
                Program.cafeteria.SetlistaPedidosServidos(Program.listaPedidosServidos);
                Program.cafeteria.GetListaPedidos().RemoveAt(0);
                Console.WriteLine("Pedido servido.");
            }
            else
            {
                Console.WriteLine("Debes realizar algún pedido.");
            }
            Menu.Adios();
        }

        public static void HacerCaja ()
        {
            int i = 1;
            decimal dineroRecaudado = Program.cafeteria.GetListaPedidosServidos().Sum(p => p.GetListaProductos().Sum(p => p.GetPrecio()));

            Program.cafeteria.GetListaPedidosServidos().ForEach(p =>
            {
                Console.WriteLine($"[{i++}] {p}");
            });

            Console.WriteLine($"Dinero recaudado: {dineroRecaudado}");

            Menu.Adios();
        }

        public override string ToString ()
        {
            return $"{NombreCafeteria}";
        }
    }
}
