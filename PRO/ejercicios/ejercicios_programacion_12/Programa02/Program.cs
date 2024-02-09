namespace Programa02
{
    class Program
    {
        private static void Main (string[] args)
        {
            int opcion;
            bool noError = true;

            do
            {
                Menu.VerMenu();
                opcion = Menu.LeerOpcion();
                Console.Write("\n");
                switch (opcion)
                {
                    case 1: Console.Clear(); Funciones.RellenarMaquina(); break;
                    case 2: Console.Clear(); Funciones.MostrarLinea(); break;
                    case 3: Console.Clear(); Funciones.ExtraerMaquina(); break;
                    case 4: Console.Clear(); noError = false; break;
                }
            } while (noError);
            Menu.Adios();
        }
    }
}