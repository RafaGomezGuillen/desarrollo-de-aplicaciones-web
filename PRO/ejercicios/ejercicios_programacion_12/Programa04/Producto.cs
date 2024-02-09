namespace Programa04
{
    class Producto
    {
        private string nombre;
        private decimal precio;

        private string Nombre { get; set; }
        private decimal Precio { get; set; }
        public void SetNombre (string nombre)
        {
            while (nombre.Trim().Length == 0 || nombre == null)
            {
                Console.Write("\nEl nombre del cliente no puede ser nulo: ");
                nombre = Console.ReadLine();
            }
            Nombre = nombre;
        }
        public void SetPrecio(decimal precio)
        {
            while (precio < 0)
            {
                Console.Write("\nEl precio del producto no puede ser negativo: ");
                precio = Convert.ToDecimal(Console.ReadLine());
            }
            Precio = precio;
        }
        public string GetNombre() { return Nombre; }
        public decimal GetPrecio() { return Precio; }
        public override string ToString () => $"Producto: {Nombre} [{Precio}] euros.";
    }
}
