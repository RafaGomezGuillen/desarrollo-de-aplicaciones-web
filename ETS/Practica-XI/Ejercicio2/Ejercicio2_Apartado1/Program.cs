using System.Reflection.PortableExecutable;

namespace MaquinaExpendedora
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hola Cliente! ");
            Machine machine = new Machine("Comerciales Jumbo", 5, 6);
            Console.WriteLine("Estas usando la máquina {0}", machine.GetName());
            int opt = 0;
            do
            {
                Functions.MostrarOpcionesMenu();
                opt = Functions.SolicitarOpcion();
                Console.Clear();
                switch (opt)
                {
                    case 0:
                        Console.WriteLine("Adiós amigo");
                        break;
                    case 1:
                        //Sería buena práctica hacer esto en aquellos Case que contengan mucha funcionalidad, para que quede más limpio y entendible a primera vista.
                        AgregarLinea(machine);
                        break;
                    case 2:
                        List<Line> lines = machine.GetLines();
                        int pos = 1, lineToRemove = 0;
                        Console.WriteLine("Indique el número del lineal a eliminar:");
                        lines.ForEach(line => Console.WriteLine($"Línea {pos++}: {line.GetProduct().GetName()}"));
                        while (!int.TryParse(Console.ReadLine(), out lineToRemove) || lineToRemove < 1 || lineToRemove > lines.Count)
                            Console.WriteLine("Opción incorrecta");
                        Line line = machine.RemoveLine(lineToRemove-1);
                        Console.WriteLine("Se ha eliminado la línea:");
                        Console.WriteLine(line);
                        break;
                    case 3:
                        decimal dinero = Machine.PedirDinero();
                        List<Line> lineasComprables = machine.LineasComprables(dinero);
                        Console.WriteLine("Elije un producto");
                        int cont = 1;
                        lineasComprables.ForEach(line => Console.WriteLine($"{cont++}: {line}"));
                        int linePos = 0;
                        while(!int.TryParse(Console.ReadLine(), out linePos) || linePos<1 || linePos>lineasComprables.Count)
                            Console.WriteLine("Opción incorrecta");
                        decimal cambio = machine.VenderProducto(dinero, linePos - 1);
                        Console.WriteLine($"Tu cambio es {cambio}");
                        break;
                    case 4:
                        machine.FillAllLines();
                        Console.WriteLine("Máquina rellenada con éxito.");
                        break;
                    case 5:
                        Console.WriteLine(machine.ToString()); ;
                        break;

                }
            } while (opt != 0);

        }

        public static void AgregarLinea(Machine machine)
        {
            if (!machine.IsFull())
            {
                Console.WriteLine("Vamosa añadir un producto");
                string name = Product.PedirNombre();
                decimal price = Product.PedirPrecio();
                Product productAux = new Product(name, price);
                machine.IncludeLine(productAux);
                Console.WriteLine("Producto incluido en la máquina");
            }
            else
            {
                Console.WriteLine("La máquina está llena.");
            }
        }
    }
}