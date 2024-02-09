namespace Programa06
{
    class Menu
    {
        public static void VerMenu ()
        {
            Console.Clear();
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("-         Maquina expendedora           -");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("- Pulsar las siguientes opciones        -");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("- 1. Ver contenido maquina.             -");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("- 2. Añadir producto.                   -");
            Console.WriteLine("- 3. Quitar producto.                   -");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("- 4. Añadir stock.                      -");
            Console.WriteLine("- 5. Rellenar maquina.                  -");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("- 6. Comprar producto.                  -");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("- 7. Gestionar número de líneas.        -");
            Console.WriteLine("- 8. Gestionar capacidad de stock.      -");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("- 9. Salir.                             -");
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
                    case '6': valor = 6; break;
                    case '7': valor = 7; break;
                    case '8': valor = 8; break;
                    case '9': valor = 9; break;
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
