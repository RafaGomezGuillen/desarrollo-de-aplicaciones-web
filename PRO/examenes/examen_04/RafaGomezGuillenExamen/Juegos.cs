namespace RafaGomezGuillenExamen
{
    class Juegos
    {
        private string Nombre { get; set; }

        private decimal Precio { get; set; }

        public Juegos ()
        {
            Nombre = "Nombre por defecto";
            Precio = 5;
        }

        public Juegos (string nombre, decimal precio)
        {
            SetNombre(nombre);
            SetPrecio(precio);
        }

        public void SetNombre (string nombre)
        {
            if (string.IsNullOrEmpty(nombre.Trim()))
            {
                Nombre = "Nombre por defecto";
            }
            else
            {
                Nombre = nombre;
            }
        }

        public void SetPrecio (decimal precio)
        {
            if (precio < 0)
            {
                Precio = 5;
            }
            else
            {
                Precio = precio;
            }
        }

        public string GetNombre () { return Nombre; }

        public decimal GetPrecio () { return Precio; }

        public static int PedirJuego()
        {
            int index;
            Console.Write($"\n\nIntroduce un número entre 1 y {Program.tienda.GetCatalogo().Count}: ");
            while (!int.TryParse(Console.ReadLine(), out index) || index <= 0 || index > Program.tienda.GetCatalogo().Count)
            {
                Console.Write($"\nERROR. Introduce un número entre 1 y {Program.tienda.GetCatalogo().Count}: ");
            }

            return index - 1;
        }

        public static int PediHistorial ()
        {
            int index;
            Console.Write($"\n\nIntroduce un número entre 1 y {Program.tienda.GetHistorial().Count}: ");
            while (!int.TryParse(Console.ReadLine(), out index) || index <= 0 || index > Program.tienda.GetHistorial().Count)
            {
                Console.Write($"\nERROR. Introduce un número entre 1 y {Program.tienda.GetHistorial().Count}: ");
            }

            return index - 1;
        }

        public override string ToString ()
        {
            return $"Nombre: {Nombre} - Precio {Precio}:";
        }
    }
}
