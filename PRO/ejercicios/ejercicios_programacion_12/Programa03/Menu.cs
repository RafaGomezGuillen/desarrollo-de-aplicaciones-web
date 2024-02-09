namespace Programa03
{
    class Menu
    {
        public static void VerMenu ()
        {
            Console.Clear();
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("-         Lista Maquina                 -");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("- Pulsar las siguientes opciones        -");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("- 1. Rellenar máquina.                  -");
            Console.WriteLine("- 2. Cobrar línea.                      -");
            Console.WriteLine("- 3. Extraer producto.                  -");
            Console.WriteLine("- 4. Terminar compra.                   -");
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
