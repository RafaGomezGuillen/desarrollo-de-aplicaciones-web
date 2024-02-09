using System;

namespace MillasMarinasAMetros {
  class Programa07 {
    public static void Main(String[] args) {
      Console.WriteLine("Dado un valor numérico correspondiente a una distancia en millas marinas, pasar este valor a metros.");

      Console.Write("Introduce numero de millas marinas: ");
      double numero_millas_marinas = Convert.ToDouble(Console.ReadLine());

      double numero_metros = numero_millas_marinas * 1852;

      Console.WriteLine(numero_millas_marinas + " millas marinas = " + numero_metros + " metros.");
      Console.ReadKey();
    }
  }
}
