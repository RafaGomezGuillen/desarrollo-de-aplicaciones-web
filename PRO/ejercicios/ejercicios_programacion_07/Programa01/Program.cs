using System;

namespace Programa01 {
  class Program {
    public static void Main(string[] args) {
      Console.WriteLine("Una tienda quiere controlar las compras de sus clientes. " +
                        "\nPor cada 3 productos que se compren, quiere regalar el de precio inferior." +
                        "\nLa aplicación debe preguntar el número de productos a comprar." +
                        "\nPara cada producto, preguntar su nombre y su precio." +
                        "\nPor cada 3 productos, se regala un producto, comenzando por los que tengan menor precio del todos los productos." +
                        "\nMostrar al final cada uno de los productos, el precio que tenía y el precio que se aplica." +
                        "\nTambién dar el precio final a pagar por todos los productos.");

      // Introduzco el número de productos. Este será el máximo.
      Console.Write("\nIntroduce el número de productos que quieres comprar: ");
      int numeroProductos = 0;

      // Compruebo que sea positivo y un número
      while(!int.TryParse(Console.ReadLine(), out numeroProductos) || (numeroProductos < 1)) {
        Console.WriteLine("Error. Introduce un número mayor que 0");
      }

      // Introduzco en un vector los precios de los productos con MAX = numeroProductos
      decimal[] precioProductos = new decimal[numeroProductos];
      for (int i = 0; i < numeroProductos; i++) {
        Console.Write("\n Introduzca los precios del producto (" + i + ") : ");
        while (!decimal.TryParse(Console.ReadLine(), out precioProductos[i])) {
          Console.Write("Error. Introduzca un número (" + i + ") : ");
        }
      }

      // Introduzco el nombre de los productos
      string[] nombreProductos = new string[numeroProductos];
      for (int i = 0; i < numeroProductos; i++) {
        Console.Write("\n Introduzca los números del vector (" + i + ") : ");
        nombreProductos[i] = Console.ReadLine();
      }

      // Ordeno los dos vectores de menor a mayor.
      decimal menorPrecio = 0;
      string menorNombre = "";
      int contador = numeroProductos / 3;
      for (int i = 0; i < numeroProductos; i++) {
        for (int j = i; j < numeroProductos; j++) {
          if ((precioProductos[i] > precioProductos[j])) {
            menorPrecio = precioProductos[i];
            precioProductos[i] = precioProductos[j];
            precioProductos[j] = menorPrecio;

            menorNombre = nombreProductos[i];
            nombreProductos[i] = nombreProductos[j];
            nombreProductos[j] = menorNombre;
          }
        }
      }

      // Los imprimo y de paso sumo el valor del precio de los productos no regalados
      decimal suma = 0;
      Console.WriteLine("------------------------");
      for (int i = 0; i < numeroProductos; i++) {
        // Hago que los productos regalados valgan 0
        if (i < contador) {
          precioProductos[i] = 0;
        }
        suma += precioProductos[i];
        Console.WriteLine("Nombre: " + nombreProductos[i] + " ,precio: " + precioProductos[i]);
      }
      Console.WriteLine("------------------------");
      Console.WriteLine("La suma es de los producto es: " + suma);
    }
  }
}