namespace Programa07
{
    class Program
    {
        public static List<Pedido> listaPedidos = new List<Pedido>();
        public static List<Pedido> listaPedidosServidos = new List<Pedido>();
        public static Cafeteria cafeteria = new Cafeteria();

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
                    case 1: Cafeteria.VerCarta(); break;
                    case 2: Cafeteria.VerPedidos(); break;
                    case 3: Cafeteria.HacerPedido(); break;
                    case 4: Cafeteria.ServirPedido(); break;
                    case 5: Cafeteria.HacerCaja(); break;
                    case 0: noError = false; break;
                }
            } while (noError);
            Menu.Adios();
        }
    }
}