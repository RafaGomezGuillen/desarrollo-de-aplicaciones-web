namespace Programa01
{
    class Program
    {
        private static void Main (string[] args)
        {
            int opcion;
            bool noError = true;

            do
            {
                Menu.VerMenu();
                opcion = Menu.LeerOpcion();
                Console.Write("\n");
                switch (opcion)
                {
                    case 1: Console.Clear(); Funciones.AñadirClientes(); break;
                    case 2: Console.Clear(); Funciones.MostrarClientes(); break;
                    case 3: Console.Clear(); Funciones.BuscarClientes(); break;
                    case 4: Console.Clear(); Funciones.BorrarClientes(); break;
                    case 5: Console.Clear(); noError = false; break;
                }
            } while (noError);
            Menu.Adios();
        }
    }
}