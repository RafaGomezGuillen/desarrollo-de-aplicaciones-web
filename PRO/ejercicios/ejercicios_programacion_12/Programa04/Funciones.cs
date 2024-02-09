namespace Programa04
{
    class Funciones
    {
        static List<Producto> listaProductos = new List<Producto>();
        static decimal precioFinal = 0;
        public static int NumeroProductos ()
        {
            int numero;
            Console.Write("\nIntroduce el número de productos a comprar: ");
            while (!int.TryParse(Console.ReadLine(), out numero) || numero <= 0)
            {
                Console.Write("\nERROR. Introduce un número entero positivo: ");
            }
            Adios();
            return numero;
        }
        public static void IntroducirDatos (int numeroProductos)
        {
            List<string> nombresProductos = new List<string>();
            for (int i = 0; i < numeroProductos; i++)
            {
                Producto datos = new Producto();
                Console.Write("\nIntroduce el nombre del producto (" + (i + 1) + "): ");
                string nombreProducto = Console.ReadLine();

                while (nombresProductos.Contains(nombreProducto) || nombreProducto.Trim().Length == 0)
                {
                    Console.Write("\nERROR. El nombre del producto ya ha sido ingresado o es vacío: ");
                    nombreProducto = Console.ReadLine();
                }

                nombresProductos.Add(nombreProducto);

                Console.Write("\nIntroduce el precio del producto (" + (i + 1) + "): ");
                datos.SetPrecio(Convert.ToDecimal(Console.ReadLine()));

                datos.SetNombre(nombreProducto);
                listaProductos.Add(datos);
            }
            Adios();
        }
        private static void MostrarDatos ()
        {
            listaProductos.ForEach(a =>
            {
                Console.WriteLine($"-------------\n{a}\n-------------");
            });
        }
        private static void OrdenarLista()
        {
            listaProductos = listaProductos.OrderBy(p => p.GetPrecio()).ToList();

            int productosRegalados = listaProductos.Count / 3;

            for (int i = 0; i < productosRegalados; i++)
            {
                listaProductos[i].SetPrecio(0);
            }

            precioFinal = listaProductos.Sum(p => p.GetPrecio());
        }

        public static void MostrarDatosFinales ()
        {
            MostrarDatos();
            Adios();
            OrdenarLista();
            MostrarDatos();
            Console.WriteLine("Precio final: " + precioFinal);
            Adios();
        }
        private static void Adios ()
        {
            Console.Write("\n\nPulse una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
