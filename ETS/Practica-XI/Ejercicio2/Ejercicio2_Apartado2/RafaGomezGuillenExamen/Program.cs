namespace RafaGomezGuillenExamen
{
    internal class Program
    {
        public static Tienda tienda = new Tienda();
        public static List<Usuario> listaUsusarios = new List<Usuario>();
        public static List<Juego> catalogo = new()
        {
            new Juego ("Zelda", 35.75m),
            new Juego ("Mario", 30),
            new Juego ("Sonic", 27.40m),
            new Juego ("Alex Kid", 15.20m),
            new Juego ("Wonder Boy", 21.90m)
        };
        public static List<Usuario> historial = new List<Usuario>();

        static void Main (string[] args)
        {
            int opcion;
            bool noError = true;

            Console.Write("Introduce el encargado de la tienda: ");
            string nombre = Tienda.PedirNombre();

            Console.Write("\nIntroduce el teléfono de la tienda: ");
            int telefono = Tienda.PedirTelefono();

            tienda.SetNombre(nombre);
            tienda.SetTelefono(telefono);

            do
            {
                Menu.VerMenu();
                opcion = Menu.LeerOpcion();
                Console.Write("\n");
                Console.Clear();
                switch (opcion)
                {
                    case 1: Tienda.AlquilarJuego(); break;
                    case 2: Tienda.DevolverJuego(); break;
                    case 3: Tienda.VerInfoTienda(); break;
                    case 4: Tienda.VerHistorial(); break;
                    case 0: noError = false; break;
                }
            } while (noError);
            Menu.Adios();
        }
    }
}