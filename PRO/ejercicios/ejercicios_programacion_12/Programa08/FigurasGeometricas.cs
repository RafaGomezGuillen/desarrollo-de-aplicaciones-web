namespace Programa08
{
    abstract class FigurasGeometricas
    {
        public static void MostrarFigurasGeometricas ()
        {
            int i = 1;
            Program.listaFigurasGeometricas.ForEach(f =>
            {
                Console.WriteLine($"\n[{i++}]{f}");
            });
            Menu.Adios();
        }

        public static void CrarFiguraGeometrica ()
        {
            string eleccion = Funciones.ElegirFigura();
            if (eleccion == "rojo")
            {
                decimal[] medidasTriangulo = Triangulo.PedirMedidas();
                Program.listaFigurasGeometricas.Add(new Triangulo(medidasTriangulo[0], medidasTriangulo[1]));
            }
            else if (eleccion == "azul")
            {
                decimal medida = Circulo.PedirMedidas();
                Program.listaFigurasGeometricas.Add(new Circulo(medida));
            }
            else
            {
                decimal[] medidasRectangulo = Rectangulo.PedirMedidas();
                Program.listaFigurasGeometricas.Add(new Rectangulo(medidasRectangulo[0], medidasRectangulo[1]));
            }

            Menu.Adios();
        }

        public static void EliminarFigurasGeometricas ()
        {
            MostrarFigurasGeometricas();

            Console.Write("\n\nIntroduce el index del número: ");
            int index = Funciones.PedirNumeroEntero() - 1;

            while (index >= Program.listaFigurasGeometricas.Count)
            {
                Console.Write("\n\nIntroduce el index del número: ");
                index = Funciones.PedirNumeroEntero() - 1;
            }

            Program.listaFigurasGeometricas.RemoveAt(index);
            Menu.Adios();
        }

        public static void Area ()
        {
            MostrarFigurasGeometricas();

            Console.Write("\n\nIntroduce el index del número: ");
            int index = Funciones.PedirNumeroEntero() - 1;

            while (index >= Program.listaFigurasGeometricas.Count)
            {
                Console.Write("\n\nIntroduce el index del número: ");
                index = Funciones.PedirNumeroEntero() - 1;
            }

            Console.WriteLine($"Área: {Program.listaFigurasGeometricas[index].CalcularArea()}");
            Menu.Adios();
        }

        public abstract decimal CalcularArea ();
    }
}
