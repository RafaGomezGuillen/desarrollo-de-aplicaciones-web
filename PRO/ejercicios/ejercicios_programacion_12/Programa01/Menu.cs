namespace Programa01
{
    class Menu
    {
        public static void VerMenu ()
        {
            Console.Clear();
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("-         Lista Clientes                -");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("- Pulsar las siguientes opciones        -");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("- 1. Añadir cliente.                    -");
            Console.WriteLine("- 2. Mostrar clientes.                  -");
            Console.WriteLine("- 3. Buscar cliente.                    -");
            Console.WriteLine("- 4. Borrar cliente.                    -");
            Console.WriteLine("- 5. Salir.                             -");
            Console.WriteLine("-----------------------------------------");
        }
        public static int LeerOpcion ()
        {
            ConsoleKeyInfo tecla;
            int valor;

            do
            {
                valor = 0;
                tecla = Console.ReadKey(true);
                switch (tecla.KeyChar)
                {
                    case '1': valor = 1; break;
                    case '2': valor = 2; break;
                    case '3': valor = 3; break;
                    case '4': valor = 4; break;
                    case '5': valor = 5; break;
                }
            } while (valor == 0);
            return valor;
        }
        public static void Adios ()
        {
            Console.Write("\n\nPulsa una tecla para finalizar...");
            Console.ReadKey();
        }
    }
}
