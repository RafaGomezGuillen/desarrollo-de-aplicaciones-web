using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaExpendedora
{
    internal class Functions
    {
        public static void MostrarOpcionesMenu()
        {
            Console.WriteLine("\nElije una opción");
            Console.WriteLine("1.- Añadir Producto a la máquina");
            Console.WriteLine("2.- Eliminar Producto de la máquina");
            Console.WriteLine("3.- Comprar Producto");
            Console.WriteLine("4.- Rellenar máquina");
            Console.WriteLine("5.- Mostrar Contenido Máquina");
            Console.WriteLine("0.- Salir");
        }

        public static int SolicitarOpcion()
        {
            int opt = 0;
            Console.WriteLine("Introduce la opción elegida:");
            while(!int.TryParse(Console.ReadLine(), out opt) || opt<0 || opt>5)
                Console.WriteLine("La opción ha de ser un número entero entre 0 y 5");
            return opt;
        }
    }
}
