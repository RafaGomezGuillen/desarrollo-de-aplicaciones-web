﻿namespace RafaGomezGuillenExamen
{
    class Tienda
    {

        private string Nombre { get; set; }

        private int Telefono { get; set; }

        private List<Juego> Catalogo { get; set; }

        private List<Usuario> ListaUsuarios { get; set; }

        private List<Usuario> Historial { get; set; }

        public Tienda ()
        {
            SetNombre("Abraham");

            SetTelefono(922712389);

            SetCatalogo(new()
            {
                new Juego ("Zelda", 35.75m),
                new Juego ("Mario", 30),
                new Juego ("Sonic", 27.40m),
                new Juego ("Alex Kid", 15.20m),
                new Juego ("Wonder Boy", 21.90m)
            });

            SetlistaUsusarios(new List<Usuario>());

            SetHistorial(new List<Usuario>());
        }

        public Tienda (string nombre, int telefono, List<Juego> catalogo, List<Usuario> listaUsuarios,
                        List<Usuario> Historial)
        {
            SetNombre(nombre);
            SetTelefono(telefono);
            SetCatalogo(catalogo);
            SetlistaUsusarios(listaUsuarios);
            SetHistorial(Historial);
        }

        public void SetNombre (string nombre)
        {
            if (nombre.Trim().Length < 3)
            {
                Nombre = "Nombre por defecto";
            }
            else
            {
                Nombre = nombre;
            }
        }

        public void SetTelefono (int telefono)
        {
            if (telefono.ToString().Length != 9 || telefono.ToString().Substring(0, 3) != "922")
            {
                Telefono = 922123456;
            }
            else
            {
                Telefono = telefono;
            }
        }

        public void SetCatalogo (List<Juego> catalogo) { Catalogo = catalogo; }

        public void SetlistaUsusarios (List<Usuario> listaUsuarios) { ListaUsuarios = listaUsuarios; }

        public void SetHistorial (List<Usuario> historial) { Historial = historial; }

        public string GetNombre () { return Nombre; }

        public int GetTelefono () { return Telefono; }

        public List<Juego> GetCatalogo () { return Catalogo; }

        public List<Usuario> GetListaUsuarios () { return ListaUsuarios; }

        public List<Usuario> GetHistorial () { return Historial; }

        public static string PedirNombre ()
        {
            string nombre = Console.ReadLine();

            while (nombre.Trim().Length < 3)
            {
                Console.Write("\nERROR. Introduce un nombre mayor de 3 letras: ");
                nombre = Console.ReadLine();
            }

            return nombre;
        }

        public static int PedirTelefono ()
        {
            int telefono;
            while (!int.TryParse(Console.ReadLine(), out telefono) || telefono.ToString().Length != 9
                   || telefono.ToString().Substring(0, 3) != "922")
            {
                Console.Write("\nERROR. El numero debe ser de 9 cifras y empezar en 922: ");
            }

            return telefono;
        }

        public static void VerInfoTienda ()
        {
            Console.WriteLine($"Encargado de la tienda: {Program.tienda.GetNombre()}");
            Console.WriteLine($"Telefono de la tienda: {Program.tienda.GetTelefono()}");
            Console.WriteLine("\nJuegos disponibles: ");
            int i = 1;
            Program.tienda.GetCatalogo().ForEach(p =>
            {
                Console.WriteLine($"[{i++}]{p}");
            });
            Console.WriteLine("\nJuegos alquilados: ");
            int j = 1;
            Program.tienda.GetListaUsuarios().ForEach(p =>
            {
                Console.WriteLine($"[{j++}]{p}");
            });
            Menu.Adios();
        }

        public bool EsCodigoValido (int codigo)
        {
            bool correcto = false;
            Usuario[] comprobacion = Program.tienda.GetListaUsuarios().Where(p => p.GetCodigo() == codigo).ToArray();
            foreach (Usuario var in comprobacion)
                if (var.GetCodigo() == codigo) correcto = true;
            return correcto;
        }

        public static void AlquilarJuego ()
        {
            Console.Write("\nIntroduce tu código de usuario: ");
            int codigo = Usuario.PedirCodigo();

            if (!Program.tienda.EsCodigoValido(codigo))
            {
                VerInfoTienda();
                int indexJuego = Juego.PedirJuego();

                Program.listaUsusarios.Add(new Usuario(codigo, Program.tienda.GetCatalogo()[indexJuego]));
                Program.tienda.SetlistaUsusarios(Program.listaUsusarios);

                Program.historial.Add(new Usuario(codigo, Program.tienda.GetCatalogo()[indexJuego]));
                Program.tienda.SetHistorial(Program.historial);
                Program.tienda.GetCatalogo().RemoveAt(indexJuego);
            }
            else
            {
                Console.WriteLine("El usuario ya existe");
            }
            Menu.Adios();
        }

        public static void DevolverJuego ()
        {
            Console.Write("\nIntroduce tu código de usuario: ");
            int codigo = Usuario.PedirCodigo();

            Usuario[] comprobacion = Program.tienda.GetListaUsuarios().Where(p => p.GetCodigo() == codigo).ToArray();
            bool correcto = false;
            int i = 0, index = 0;
            foreach (Usuario var in comprobacion)
            {
                if (var.GetCodigo() == codigo) correcto = true;
                i++;
            }

            if (correcto)
            {
                Program.tienda.GetCatalogo().Add(comprobacion.ElementAt(index).GetJuego());
                Program.tienda.SetCatalogo(Program.tienda.GetCatalogo());
                Program.tienda.GetListaUsuarios().RemoveAt(index);
                Program.tienda.SetlistaUsusarios(Program.listaUsusarios);
                Console.WriteLine("Juego devuelto.");
            }
            else
            {
                Console.WriteLine("El usuario no existe");
            }
            Menu.Adios();
        }

        // Profe el dinero esta mal pero bueno...
        public static void VerHistorial ()
        {
            Program.tienda.GetHistorial().ForEach(p =>
            {
                Console.WriteLine(p.GetJuego().GetNombre());
            });

            Console.Write("Escoge un juego: ");
            string juego = Console.ReadLine();

            decimal dinero = 0;
            bool comprobacion = false;
            Program.tienda.GetHistorial().ForEach(p =>
            {
                if (p.GetJuego().GetNombre() == juego)
                {
                    dinero = Program.tienda.GetHistorial().Sum(p => p.GetJuego().GetPrecio());
                    comprobacion = true;
                    Console.WriteLine(p);
                }
            });

            if (!comprobacion)
                Console.WriteLine("Juego no encotrado.");
            else
                Console.WriteLine("Dinero recaudado: " + dinero);

            Menu.Adios();
        }
    }
}
