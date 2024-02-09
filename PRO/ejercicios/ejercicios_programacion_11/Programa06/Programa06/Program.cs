namespace Programa06
{
    class Program
    {
        private static void Main (string[] args)
        {
            int opcionPais = 0, opcionAño = 0;
            if (Ficheros.ExisteFichero())
            {
                Ficheros.LeerFichero();
                opcionPais = Ficheros.ObtenerPais();
                Console.Clear();
                opcionAño = Ficheros.ObtenerAño();
                Console.Clear ();
                Ficheros.MostrarDatos(opcionPais, opcionAño);
            }
        }
    }
}
