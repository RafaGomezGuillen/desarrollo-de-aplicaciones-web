using System;
using System.Runtime.Intrinsics.X86;

namespace Programa07 {
  class Program {
    public static void Main(string[] args) {
      Console.WriteLine("\tUna tienda quiere controlar las compras de sus clientes. " +
                        "\nPor cada 3 productos que se compren, quiere regalar el de precio inferior. " +
                        "\nLa aplicación debe preguntar el número de productos a comprar. " +
                        "\nPara cada producto, preguntar su nombre y su precio. " +
                        "\nPor cada 3 productos, se regala un producto, comenzando por los que tengan menor precio del todos los productos. " +
                        "\nMostrar al final cada uno de los productos, el precio que tenía y el precio que se aplica. " +
                        "\nTambién dar el precio final a pagar por todos los productos.\r\n\n");

      // Número de productos que quiero comprar
      int numeroProductos = 0;
      Console.Write("\nIntroduce el número de productos que desea comprar: ");
      while(!int.TryParse(Console.ReadLine(), out numeroProductos) || numeroProductos <= 0) {
        Console.Write("\nError. Introduce un número mayor que 0: ");
      }

      // Guardo el precio en un vector
      decimal[] vectorPrecios = new decimal[numeroProductos];
      for(int i = 0; i < numeroProductos; i++) {
        Console.Write("\nIntroduce el precio de los prodcutos (" + i + ") : ");
        while(!decimal.TryParse(Console.ReadLine(), out vectorPrecios[i]) || vectorPrecios[i] <= 0) {
          Console.Write("\nERROR. Introduce el precio de los productos (" + i + ") :");
        }
      }

      // Guardo el nombre en un vector
      string[] vectorNombres = new string[numeroProductos];
      for (int i = 0; i < numeroProductos; i++) {
        Console.Write("\nIntroduce el nombre de los prodcutos (" + i + ") : ");
        vectorNombres[i] = Console.ReadLine();
      }

      // Regalar producto
      int regalarProducto = numeroProductos / 3;

      // Ordeno de menor a mayor los productos
      for (int i = 0; i < numeroProductos; i++) {
        for (int j = i; j < numeroProductos; j++) {
          if (vectorPrecios[i] > vectorPrecios[j]) {
            decimal aux = vectorPrecios[i];
            vectorPrecios[i] = vectorPrecios[j];
            vectorPrecios[j] = aux;

            string aux2 = vectorNombres[i];
            vectorNombres[i] = vectorNombres[j];
            vectorNombres[j] = aux2;
          }
        }
      }

      // Los imprimo por pantalla y hago suma de los precios
      decimal suma = 0;
      for (int i = 0; i < numeroProductos;i++) {
        if (i < regalarProducto) {
          vectorPrecios[i] = 0;
        }
        suma += vectorPrecios[i];
        Console.Write("\n" + vectorNombres[i] + " cuesta " + vectorPrecios[i]);
      }
      Console.WriteLine("\n\nLa suma de los precios = " + suma);
    }
  }
}