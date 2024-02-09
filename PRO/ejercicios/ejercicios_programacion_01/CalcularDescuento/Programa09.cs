using System;

namespace CalcularDescuento {
  class Programa09 {
    public static void Main(String[] args) {
      Console.WriteLine("Dado un precio inicial de una prenda, y un porcentaje de descuento, " +
                        "mostrar cuál era el precio inicial, y cuál es el precio que debemos " +
                        "pagar aplicado el descuento.");

      Console.Write("Introduce el precio inicial de la prenda: ");
      int numero_prenda_inicial = Convert.ToInt32(Console.ReadLine());
      Console.Write("Introduce el porcentaje de descuento: ");
      double numero_porcentaje_descuento = Convert.ToDouble(Console.ReadLine());

      Convert.ToDouble(numero_prenda_inicial);
      double numero_descuento_aplicado = numero_prenda_inicial - (numero_porcentaje_descuento / 100) * numero_prenda_inicial;

      Console.WriteLine("El prenda de " + numero_prenda_inicial + " euros, aplicado un descuento de " + numero_porcentaje_descuento +
                        "% = " + numero_descuento_aplicado);
      Console.ReadKey();
    }
  }
}
