namespace Programa07
{
    class Funciones
    {
        public static int IndexProducto ()
        {
            int index;
            Console.Write($"\n\nIntroduce un número entre 1 y {Program.cafeteria.GetCartaProductos().Count}: ");

            while (!int.TryParse(Console.ReadLine(), out index) || index <= 0 || index > Program.cafeteria.GetCartaProductos().Count)
            {
                Console.Write($"\nERROR. Introduce un número entre 1 y {Program.cafeteria.GetCartaProductos().Count}: ");
            }

            return index - 1;
        }
    }
}
