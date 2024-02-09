using System;

namespace Programa11 {
  class Program {
    public static void Main(string[] args) {
      Console.WriteLine("Introducir por teclado una frase y a continuación visualizar cada palabra de la frase, "+
                        "una debajo de otra, seguida cada palabra del número de letras que compone dicha palabra.");

      Console.Write("Introduce una frase: ");
      string? cadena_01 = Console.ReadLine();
      string cadena_02 = "";
      int contador = 0;

      for (int i = 0; i<cadena_01.Length; i++) {
        if (cadena_01[i]!=' ') {
          cadena_02+=cadena_01[i];
          contador++;
        } else {
          Console.WriteLine(cadena_02+", número de letras: "+contador);
          cadena_02="";
          contador=0;
        }
      }
      Console.WriteLine(cadena_02+", número de letras: "+contador);
    }
  }
}
