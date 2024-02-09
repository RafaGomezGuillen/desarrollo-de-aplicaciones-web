using System;

namespace ejercicio01 {
  class Program {
    public static void Main(string[] args) {
      Console.Write("Introduzca una cadena: ");
      string CadenaInicial = "";
      string CadenaFinal = "";
      CadenaInicial = Console.ReadLine();

      while (CadenaInicial.Length == 0) {
        Console.WriteLine("La cadena es nula.");
        CadenaInicial = Console.ReadLine();
      }

      int cont = 0;

      for (int i = 0; i < CadenaInicial.Length; i++) {
        if (CadenaInicial[i] == 'a' || CadenaInicial[i] == 'e' || CadenaInicial[i] == 'i' || CadenaInicial[i] == 'o' || CadenaInicial[i] == 'u') {
          cont++;
          CadenaFinal += cont;
        } else {
          CadenaFinal += CadenaInicial[i];
        }
      }

      Console.WriteLine("Cadena inicial: " + CadenaInicial);
      Console.WriteLine("Cadena final: " + CadenaFinal);
    }
  }
}