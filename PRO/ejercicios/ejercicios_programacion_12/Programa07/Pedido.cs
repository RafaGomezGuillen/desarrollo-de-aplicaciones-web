namespace Programa07
{
    class Pedido
    {
        private string Nombre { get; set; }

        private List<Producto> ListaProductos { get; set; }

        private DateTime Fecha { get; set; }

        public Pedido ()
        {
            Nombre = "Alumno por defecto";
            ListaProductos = new List<Producto>();
            Fecha = DateTime.Now;
        }

        public Pedido (string nombre, List<Producto> listaProductos, DateTime fecha)
        {
            SetNombre(nombre);
            SetListaProducto(listaProductos);
            SetFecha(fecha);
        }

        public void SetNombre (string nombre)
        {
            if (string.IsNullOrEmpty(nombre.Trim()))
            {
                Nombre = "Alumno por defecto";
            }
            else
            {
                Nombre = nombre;
            }
        }

        public void SetListaProducto (List<Producto> listaProductos) { ListaProductos = listaProductos; }

        public void SetFecha (DateTime fecha)
        {
            if (string.IsNullOrEmpty(fecha.ToString().Trim()))
            {
                Fecha = DateTime.Now;
            }
            else
            {
                Fecha = fecha;
            }
        }

        public string GetNombre () { return Nombre; }

        public List<Producto> GetListaProductos () { return ListaProductos; }

        public DateTime GetFecha () { return Fecha; }

        public static string PedirNombre ()
        {
            Console.Write("Introduce tu nombre: ");
            string nombre = Console.ReadLine().Trim();

            while (nombre.Length == 0)
            {
                Console.Write("ERROR. Introduce un nombre no vacío: ");
                nombre = Console.ReadLine();
            }

            return nombre;
        }

        public override string ToString ()
        {
            string productos = ListaProductos.Aggregate("", (str, prod) => $"{str}\n{prod}");
            return $"--------------\nAlumno: {Nombre}.{productos}\nFecha: {Fecha}.\n--------------";
        }

    }
}
