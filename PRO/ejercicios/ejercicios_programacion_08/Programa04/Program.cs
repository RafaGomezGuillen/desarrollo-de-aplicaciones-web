using System;

namespace Programa04 {
  class Program {
    public static void Main(string[] args) {
      Console.WriteLine("\tIntroducir por teclado una frase y a continuación visualizar cada palabra de la frase, una debajo de otra, " +
                        "\nseguida cada palabra del número de letras que compone dicha palabra.\r\n");

      // Pido la cadena inicial
      Console.Write("\t\nIntroduce una cadena: ");
      string cadenaInicial = Console.ReadLine();

      // Compruebo que la cadena no sea nula
      while (cadenaInicial == null) {
        Console.Write("\n\nERROR. Introduce una cadena no nula y quer contanga coma: ");
        cadenaInicial = Console.ReadLine();
      }

      // cadena imprime cada palabra
      string cadena = "";
      // contador imprime la longitud
      int contador = 0;
      foreach(char caracter in cadenaInicial) {
        // Si el caracter detecta un espacio en blanco, cadena y contador suman
        if (caracter != ' ') {
          cadena += caracter;
          contador++;
        } else {
          Console.WriteLine(cadena + ", número de letras: " + contador);
          cadena = "";
          contador = 0;
        }
      }
      Console.WriteLine(cadena + ", número de letras: " + contador);
    }
  }
}