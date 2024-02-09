namespace RafaGomezGuillenExamen
{
    internal class Program
    {
        public static Tiendas tienda = new Tiendas();
        public static List<Usuarios> listaUsusarios = new List<Usuarios>();
        public static List<Juegos> catalogo = new()
        {
            new Juegos ("Zelda", 35.75m),
            new Juegos ("Mario", 30),
            new Juegos ("Sonic", 27.40m),
            new Juegos ("Alex Kid", 15.20m),
            new Juegos ("Wonder Boy", 21.90m)
        };
        public static List<Usuarios> historial = new List<Usuarios>();

        static void Main (string[] args)
        {
            int opcion;
            bool noError = true;

            Console.Write("Introduce el encargado de la tienda: ");
            string nombre = Tiendas.PedirNombre();

            Console.Write("\nIntroduce el teléfono de la tienda: ");
            int telefono = Tiendas.PedirTelefono();

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
                    case 1: Tiendas.AlquilarJuego(); break;
                    case 2: Tiendas.DevolverJuego(); break;
                    case 3: Tiendas.VerInfoTienda(); break;
                    case 4: Tiendas.VerHistorial(); break;
                    case 0: noError = false; break;
                }
            } while (noError);
            Menu.Adios();
        }
    }
}