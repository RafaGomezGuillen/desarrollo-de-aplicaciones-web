namespace Programa08
{
    class Funciones
    {
        // Rojo -> Triangulo, Azul -> Circulo, Amarillo -> Rectangulo
        public static string ElegirFigura ()
        {
            string[] colores = { "rojo", "amarillo", "azul" };

            Console.Write("\nrojo -> Triángulo" +
                          "\nazul -> Círculo" +
                          "\namarillo -> Rectángulo" +
                          "\nElige entre estas opciones: ");
            string eleccion = Console.ReadLine().ToLower().Trim();

            while (!colores.Contains(eleccion))
            {
                Console.Write("ERROR. Elige bien: ");
                eleccion = Console.ReadLine().ToLower().Trim();
            }

            return eleccion;
        }

        public static decimal PedirNumeroDecimal ()
        {
            decimal numero;
            while (!decimal.TryParse(Console.ReadLine(), out numero) || numero <= 0)
            {
                Console.Write("\nERROR. Introduce un número mayor que 0: ");
            }
            return numero;
        }

        public static int PedirNumeroEntero ()
        {
            int numero;
            while (!int.TryParse(Console.ReadLine(), out numero) || numero <= 0)
            {
                Console.Write("\nERROR. Introduce un número mayor que 0: ");
            }
            return numero;
        }


    }
}
