namespace RafaGomezGuillenExamen
{
    class Usuarios
    {
        private int Codigo { get; set; }

        private Juegos Juego { get; set; }

        public Usuarios()
        {
            Codigo = 100;
            Juego = new Juegos();
        }

        public Usuarios(int codigo, Juegos juego)
        {
            Codigo = codigo;
            Juego = juego;
        }

        public void Setcodigo(int codigo)
        {
            if (codigo < 100 && codigo > 1000)
            {
                Codigo = 100;
            }
            else
            {
                Codigo = codigo;
            }
        }

        public void Setjuego(Juegos juego)
        {
            Juego = juego;
        }

        public int GetCodigo() { return Codigo; }

        public Juegos GetJuego() { return Juego; }

        public static int PedirCodigo ()
        {
            int codigo;
            while (!int.TryParse(Console.ReadLine(), out codigo) || codigo.ToString().Length != 3)
            {
                Console.Write("\nERROR. El numero debe ser 3 cifras y mayor que 100: ");
            }

            return codigo;
        }

        public override string ToString ()
        {
            return $"{Juego} -- Usuario que lo tiene: {Codigo}";
        }
    }
}
