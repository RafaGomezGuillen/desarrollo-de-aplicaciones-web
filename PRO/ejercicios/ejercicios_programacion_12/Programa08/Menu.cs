namespace Programa08
{
    class Menu
    {
        public static void VerMenu ()
        {
            Console.Clear();
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("-         Figuras geométricas            -");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("- Pulsar las siguientes opciones        -");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("- 1. Ver figuras geométricas.           -");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("- 2. Crear figura geométrica.           -");
            Console.WriteLine("- 3. Eliminar una figura geométrica.    -");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("- 4. Área de una figura geométrica.     -");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("- 0. Salir.                             -");
            Console.WriteLine("-----------------------------------------");
        }
        public static int LeerOpcion ()
        {
            ConsoleKeyInfo tecla;
            int valor;

            do
            {
                valor = -1;
                tecla = Console.ReadKey(true);
                switch (tecla.KeyChar)
                {
                    case '1': valor = 1; break;
                    case '2': valor = 2; break;
                    case '3': valor = 3; break;
                    case '4': valor = 4; break;
                    case '0': valor = 0; break;
                }
            } while (valor == -1);
            return valor;
        }
        public static void Adios ()
        {
            Console.Write("\n\nPulsa una tecla para finalizar...");
            Console.ReadKey();
        }
    }
}
