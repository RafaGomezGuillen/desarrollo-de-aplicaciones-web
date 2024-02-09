namespace RafaGomezExamen
{
    
    class Program
    {
        private static void Main (string[] args)
        {
            if (Ficheros.ExisteFichero())
            {
                Ficheros.LeerFichero();
                if (Ficheros.ComprobarDatos())
                {
                    Ficheros.CrearFichero(Ficheros.FICHERO_SALIDA);
                    Ficheros.ImprimirDatos();
                    decimal num = Ficheros.PedirNumero();
                    Ficheros.ImprimirConsola(num);
                }
            }
        }
    }
}