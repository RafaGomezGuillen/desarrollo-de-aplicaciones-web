namespace Programa01
{
    class Funciones
    {
        static List<Cliente> listaCliente = new List<Cliente>();
        static int i = 1;
        public static void AñadirClientes ()
        {
            Cliente cliente = new Cliente();

            Console.Write("\nIntroduce el nombre del cliente: ");
            cliente.SetNombre(Console.ReadLine());
            Console.Write("\nIntroduce el apellido del cliente: ");
            cliente.SetApellidos(Console.ReadLine());
            cliente.SetId(i++);
            listaCliente.Add(cliente);
            Menu.Adios();
        }
        public static void MostrarClientes ()
        {
            listaCliente.ForEach(cliente =>
            {
                Console.WriteLine($"--------------\n{cliente}\n--------------");
            });
            Menu.Adios();
        }
        public static void BuscarClientes ()
        {
            Console.Write("Introduce el nombre de la persona que desea buscar: ");
            string nombre = Console.ReadLine();
            bool existe = false;

            foreach (Cliente cliente in listaCliente)
            {
                if (nombre == cliente.GetNombre()) existe = true;
            }

            if (existe)
                Console.WriteLine(nombre + " existe.");
            else
                Console.WriteLine(nombre + " no existe.");

            Menu.Adios();
        }
        private static int PedirCliente ()
        {
            int numero;
            int size = listaCliente.Count;
            MostrarClientes();
            Console.Write($"\nIntroduce uno de los clientes (1 al {size}): ");
            while (!int.TryParse(Console.ReadLine(), out numero) || numero <= 0 || numero > size)
            {
                Console.Write($"\nERROR. Introduce un número del 1 al {size}: ");
            }
            return numero - 1;
        }
        public static void BorrarClientes ()
        {
            int id = PedirCliente();
            listaCliente.RemoveAt(id);
            Menu.Adios();
        }
    }
}
