namespace Programa06
{
    internal class Program
    {
        static void Main (string[] args)
        {
            int opcion;
            bool noError = true;

            do
            {
                Menu.VerMenu();
                opcion = Menu.LeerOpcion();
                Console.Write("\n");
                Console.Clear();
                switch (opcion)
                {
                    case 1: Producto.VerProductos(); break;
                    case 2: Producto.AñadirProducto(); break;
                    case 3: Producto.QuitarProducto(); break;
                    case 4: Producto.AñadirStock(); break;
                    case 5: Producto.RellenarMaquina(); break;
                    case 6: Producto.ComprarProducto(); break;
                    case 7: Maquina.EstablecerLinea(); break;
                    case 8: Maquina.EstablecerStock(); break;
                    case 9: noError = false; break;
                }
            } while (noError);
            Menu.Adios();
        }
    }
}