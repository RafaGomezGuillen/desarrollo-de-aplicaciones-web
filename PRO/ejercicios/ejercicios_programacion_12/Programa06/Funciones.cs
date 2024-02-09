namespace Programa06
{
    class Funciones
    {
        public static string PedirProducto ()
        {
            string str = "";
            Console.Write("\nAñade el nombre del producto: ");
            str = Console.ReadLine();
            while (str.Trim().Length == 0)
            {
                Console.Write("\nError. Introduce una cadena no vacía: ");
                str = Console.ReadLine();
            }
            return str;
        }
        public static decimal PedirPrecio ()
        {
            decimal precio = 0;
            Console.Write("\nAñade el precio del producto: ");

            while (!decimal.TryParse(Console.ReadLine(), out precio) || precio <= 0)
            {
                Console.Write("\nIntroduce un precio mayor que 0: ");
            }

            return precio;
        }
        public static int PedirStock ()
        {
            int stock = 0;
            Console.Write("\nAñade el stock del producto: ");

            while (!int.TryParse(Console.ReadLine(), out stock) || stock < 0 || stock > Maquina.stock)
            {
                Console.Write($"\nIntroduco un stock entre 0 y {Maquina.stock}: ");
            }
            return stock;
        }
        public static int ElegirProducto (string mensaje)
        {
            int indexProducto = 0;
            int size = Producto.listaProductos.Count;
            Producto.VerProductos();
            Console.Write($"\nIntroduce el producto a {mensaje} del (1 - {size}): ");

            while (!int.TryParse(Console.ReadLine(), out indexProducto) || indexProducto <= 0 || indexProducto > size)
            {
                Console.Write($"\nERROR. Introduce el producto a {mensaje} del (1 - {size}): ");
            }
            return indexProducto - 1;
        }
    }
}
