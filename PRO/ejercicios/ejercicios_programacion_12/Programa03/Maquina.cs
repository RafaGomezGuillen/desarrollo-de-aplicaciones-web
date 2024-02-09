namespace Programa03
{
    class Maquina
    {
        public static string[] nombreProductos = { "Coca Cola", "Agua mineral", "RedBull", "Bocadillo de jamón y queso",
                                                   "Bocadillo vegetal", "Jugo de naranja", "Jugo de limón", "Galletas",
                                                   "Jamón ibérico", "Fanta", "Cubata", "Café cortado", "Café con leche",
                                                   "Platano", "Manzana", "Atún", "Cerveza", "Perrito calinete", "Limón",
                                                   "Huevos"};
        
        public static decimal[] precioProductos = { 0.6m, 0.5m, 1.6m, 2.4m, 2.4m, 1.2m, 1.2m, 1.5m, 3m, 1.5m, 4m, 2m, 2m, 
                                                    1m, 1.4m, 2.6m, 1m, 1.8m, 1m, 2m};
        private string producto;
        /// <summary>
        /// Producto de la máquina
        /// </summary>
        public string Producto
        {
            get
            {
                return producto;
            }
            set { producto = value; }
        }

        private int linea;
        /// <summary>
        /// Id del cliente
        /// </summary>
        public int Linea
        {
            get
            {
                while (linea <= 0 || linea > 10)
                {
                    Console.Write("\nERROR.El número de línea debe estar entre 1 y 10: ");
                    linea = Convert.ToInt32(Console.ReadLine());
                }
                return linea;
            }
            set { linea = value; }
        }
    }
}
