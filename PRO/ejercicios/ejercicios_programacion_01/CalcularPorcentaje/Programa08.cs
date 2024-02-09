using System;

namespace CalcularPorcentaje {
  class Programa08 {
    public static void Main(String[] args) {
      Console.WriteLine("Recogida por teclado una cantidad y un porcentaje, calcular el porcentaje " +
                        "correspondiente de la cantidad dada.");

      Console.Write("Introduce una cantidad numerica: ");
      double numero_cantidad = Convert.ToDouble(Console.ReadLine());
      Console.Write("Introduce un porcentaje: ");
      double numero_porcentaje = Convert.ToDouble(Console.ReadLine());

      double numero_cantidad_dada = (numero_porcentaje / 100) * numero_cantidad;

      Console.WriteLine("El " + numero_porcentaje + "% de " + numero_cantidad + " = " + numero_cantidad_dada);
      Console.ReadKey();
    }
  }
}
