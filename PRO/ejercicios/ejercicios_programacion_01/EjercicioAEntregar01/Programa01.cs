using System;

namespace EjercicioAEntregar01 {
  class Programa01 {
    public static void Main(String[] args) {
      Console.Write("Introduce el número de entradas: ");
      string cadena_01 = Console.ReadLine();

      if (int.TryParse(cadena_01, out int numero_01)) {
        if (numero_01 > 0 && numero_01 < 5) {
          const decimal precio_entrada = 34.20m;
          decimal descuento = 0m;
          if (numero_01 == 1) {
            Console.WriteLine("El precio de la entrada es: " + precio_entrada);
          }
          if (numero_01 == 2) {
            descuento = (precio_entrada - (precio_entrada * 0.05m)) * numero_01;
            Console.WriteLine("El precio de 2 entradas es: {0:f2}", descuento);
          }
          if (numero_01 == 3) {
            descuento = (precio_entrada - (precio_entrada * 0.1m)) * numero_01;
            Console.WriteLine("El precio de 3 entradas es: {0:f2}", descuento);
          }
          if (numero_01 == 4) {
            descuento = (precio_entrada - (precio_entrada * 0.2m)) * numero_01;
            Console.WriteLine("El precio de 4 entradas es: {0:f2}", descuento);
          }
        } else {
          Console.WriteLine("Error. " + numero_01 + " no está entre 1 y 4.");
        }
      } else {
        Console.WriteLine("Error. " + cadena_01 + " no es un número o no es entero.");
      }
      Console.ReadKey();
    }
  }
}
