namespace Ejercicio02
{
    internal class Funciones
    {
        public static int LeerNumeroLineas ()
        {
            int num = 0;

            Console.Write("Introduce el numero de lineas: ");
            while (!int.TryParse(Console.ReadLine(), out num) || num <= 0)
            {
                Console.Write("\nERROR :-( Introduce un numero positivo: ");
            }
            return num;
        }
    }
}
