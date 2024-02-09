namespace Programa03
{
    class Program
    {
        private static void Main (string[] args)
        {
            int opcion;
            bool noError = true;
            decimal suma = 0;
            do
            {
                Menu.VerMenu();
                opcion = Menu.LeerOpcion();
                Console.Write("\n");
                switch (opcion)
                {
                    case 1: Console.Clear(); Funciones.RellenarMaquina(); break;
                    case 2: Console.Clear(); Funciones.CobrarProductos(); break;
                    case 3: Console.Clear(); Funciones.ExtraerMaquina(); break;
                    case 4: Console.Clear(); Funciones.SumarProductos(); noError = false; break;
                }
            } while (noError);
            Menu.Adios();
        }
    }
}