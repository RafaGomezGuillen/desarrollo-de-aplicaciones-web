namespace Programa02
{
    class Funciones
    {
        static List<Maquina> listaMaquina = new List<Maquina>();
        public static void MostrarProductos ()
        {
            Console.Clear();
            int i = 1;
            Console.WriteLine("Lista de productos.");
            foreach (string producto in Maquina.nombreProductos)
            {
                Console.WriteLine($"-[{i}]\t{producto}");
                i++;
            }
        }
        private static int PedirLinea ()
        {
            int linea;
            Console.Clear();
            Console.Write("\nIntroduc un número de línea (1 - 10): ");
            while (!int.TryParse(Console.ReadLine(), out linea) || linea < 1 || linea > 10)
            {
                Console.Write("\nERROR. Introduce un número entero (1 - 10): ");
            }
            return linea;
        }
        private static int PedirProducto ()
        {
            int numero;
            int size = Maquina.nombreProductos.Length;
            MostrarProductos();
            Console.Write($"\nIntroduce uno de los productos (1 al {size}): ");
            while (!int.TryParse(Console.ReadLine(), out numero) || numero <= 0 || numero > size)
            {
                Console.Write($"\nERROR. Introduce un número del 1 al {size}: ");
            }
            return numero - 1;
        }
        public static void RellenarMaquina ()
        {
            Maquina maquina = new Maquina();
            int linea, indexProducto;

            Console.Write("\nSelecciona una línea (1 al 10): ");
            linea = PedirLinea();
            maquina.SetLinea(linea);

            indexProducto = PedirProducto();
            maquina.SetProducto(Maquina.nombreProductos.ElementAt(indexProducto));

            listaMaquina.Add(maquina);
            Menu.Adios();
        }
        public static void ExtraerMaquina ()
        {
            int indexProducto;
            Console.Write("\nSelecciona una línea (1 al 10): ");

            indexProducto = PedirProducto();
            listaMaquina.RemoveAt(indexProducto);
            
            Menu.Adios();
        }
        public static void MostrarLinea ()
        {
            int linea = PedirLinea();
            foreach (string producto in Maquina.nombreProductos)
            {
                int contadorProducto = 0;

                foreach (Maquina maquina in listaMaquina)
                {
                    if (maquina.GetLinea() == linea && maquina.GetProducto() == producto)
                    {
                        contadorProducto++;
                        if (contadorProducto >= 10) contadorProducto = 10;
                    }
                }
                if (contadorProducto > 0)
                {
                    Console.WriteLine($"Línea: {linea}\t{producto}\t({contadorProducto}).");
                }
            }
            Menu.Adios();
        }
    }
}