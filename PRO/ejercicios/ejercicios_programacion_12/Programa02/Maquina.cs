namespace Programa02
{
    class Maquina
    {
        public static string[] nombreProductos = { "Coca Cola", "Agua mineral", "RedBull", "Bocadillo de jamón y queso",
                                                   "Bocadillo vegetal", "Jugo de naranja", "Jugo de limón", "Galletas",
                                                   "Jamón ibérico", "Fanta", "Cubata", "Café cortado", "Café con leche",
                                                   "Platano", "Manzana", "Atún", "Cerveza", "Perrito calinete", "Limón",
                                                   "Huevos"};
        private string producto;
        private int linea;

        private string Produco { get; set; }
        private int Linea { get; set; } 
        public void SetProducto(string producto) { Produco = producto; }
        public void SetLinea(int linea)
        {
            while (linea <= 0 || linea > 10)
            {
                Console.Write("\nERROR.El número de línea debe estar entre 1 y 10: ");
                linea = Convert.ToInt32(Console.ReadLine());
            }
            Linea = linea;
        }
        public string GetProducto() { return Produco;}
        public int GetLinea() { return Linea; }
    }
}
