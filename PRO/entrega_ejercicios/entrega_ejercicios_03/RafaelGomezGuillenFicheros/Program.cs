namespace RafaelGomezGuillenFicheros
{
    class Program
    {
        private static void Main (string[] args)
        {
            if (Ficheros.ExisteFichero())
            {
                Ficheros.LeerFichero();
                if (Ficheros.DatosFichero())
                {
                    Ficheros.CrearFichero(Ficheros.FICHERO_SALIDA);
                    Ficheros.ImprimirDatos();
                }
                else
                {
                    Ficheros.CrearFichero(Ficheros.FICHERO_ERRORES);
                    Console.WriteLine("\nHay errores en el archivo de entrada.");
                }
            }
        }
    }
}
