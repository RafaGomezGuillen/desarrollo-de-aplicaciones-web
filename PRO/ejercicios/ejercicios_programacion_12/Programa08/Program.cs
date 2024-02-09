namespace Programa08
{
    class Program
    {
        public static List<FigurasGeometricas> listaFigurasGeometricas = new List<FigurasGeometricas>();
        static void Main (string[] args)
        {
            int opcion;
            bool noError = true;

            do
            {
                Menu.VerMenu();
                opcion = Menu.LeerOpcion();
                Console.Write("\n");
                Console.Clear();
                switch (opcion)
                {
                    case 1: FigurasGeometricas.MostrarFigurasGeometricas(); break;
                    case 2: FigurasGeometricas.CrarFiguraGeometrica(); break;
                    case 3: FigurasGeometricas.EliminarFigurasGeometricas(); break;
                    case 4: FigurasGeometricas.Area(); break;
                    case 0: noError = false; break;
                }
            } while (noError);
            Menu.Adios();
        }
    }
}