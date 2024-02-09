namespace Programa06
{
    class Maquina
    {
        public static int linea = 6;
        public static int stock = 10;

        public static int EstablecerLinea ()
        {
            Console.Write("\nIntroduce las líneas de tu maquina expendedora: ");
            while (!int.TryParse(Console.ReadLine(), out linea) || linea <= 0)
            {
                Console.Write("\nERROR.Introduce un número entero mayor que 0: ");
            }
            return linea;
        }
        public static int EstablecerStock ()
        {
            Console.Write("\nIntroduce el máximo de stock de cada producto: ");
            while (!int.TryParse(Console.ReadLine(), out stock) || stock <= 0)
            {
                Console.Write("\nERROR.Introduce un número entero mayor que 0: ");
            }
            return stock;
        }
    }
}
