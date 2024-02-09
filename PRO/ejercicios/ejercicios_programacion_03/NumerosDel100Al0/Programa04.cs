using System;

namespace NumerosDel100Al0 {
  class Programa04 {
    public static void Main(string[] args) {
      Console.WriteLine("Presenta por pantalla los números del 100 al 0.");

      for (int i = 100; i >= 0; i--) {
        Console.WriteLine(i);
      }
    }
  }
}