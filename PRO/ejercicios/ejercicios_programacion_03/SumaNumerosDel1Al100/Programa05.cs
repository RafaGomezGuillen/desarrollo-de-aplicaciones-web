using System;

namespace SumaNumerosDel1Al110 {
  class Programa05 {
    public static void Main(string[] args) {
      Console.WriteLine("Presenta por pantalla las suma de los número del 1 al 100.");
      int suma = 0;
      for (int i = 1; i <= 100; i++) {
        suma += i;
      }
      Console.WriteLine("Suma = " + suma);
    }
  }
}