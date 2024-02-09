using System;

namespace EjercicioRecuperacion02 {
  class ProgramaRecuperacion02 {
    public static void Main() {
      Console.WriteLine("Introduce tres números.");

      Console.Write("Introduce el primer número: ");
      double numero_01 = Convert.ToDouble(Console.ReadLine());

      Console.Write("Introduce el segundo número: ");
      double numero_02 = Convert.ToDouble(Console.ReadLine());

      Console.Write("Introduce el tercer número: ");
      double numero_03 = Convert.ToDouble(Console.ReadLine());

      if ((numero_01 % 1 == 0) && (numero_02 % 1 == 0) && (numero_03 % 1 == 0)) {
        double suma = 0;
        if ((numero_01 > 16) && (numero_01 % 2 != 0)) {
          suma += numero_01;
        }
        if ((numero_02 > 16) && (numero_02 % 2 != 0)) {
          suma += numero_02;
        }
        if ((numero_03 > 16) && (numero_03 % 2 != 0)) {
          suma += numero_03;
        }
        Console.WriteLine("La suma = " + suma);
      } else {
        Console.WriteLine("No son enteros...");
      }
      Console.ReadKey();
    }
  }
}