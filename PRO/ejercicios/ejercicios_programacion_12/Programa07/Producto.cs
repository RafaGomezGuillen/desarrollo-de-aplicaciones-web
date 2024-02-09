namespace Programa07
{
    class Producto
    {
        private string NombreProducto { get; set; }

        private decimal Precio { get; set; }

        public Producto ()
        {
            NombreProducto = "Producto por defecto";
            Precio = 4;
        }

        public Producto (string producto, decimal precio)
        {
            SetProducto(producto);
            SetPrecio(precio);
        }

        public void SetProducto (string producto)
        {
            if (string.IsNullOrEmpty(producto.Trim()))
            {
                NombreProducto = "Producto por defecto";
            }
            else
            {
                NombreProducto = producto;
            }
        }

        public void SetPrecio (decimal precio)
        {
            if (precio < 0)
            {
                Precio = 4;
            }
            else
            {
                Precio = precio;
            }
        }

        public string GetProducto () { return NombreProducto; }

        public decimal GetPrecio () { return Precio; }

        public override string ToString ()
        {
            return $"Producto: {NombreProducto} de {Precio} euros.";
        }
    }
}
