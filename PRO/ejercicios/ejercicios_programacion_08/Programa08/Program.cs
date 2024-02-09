using System;

namespace Programa08 {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("\tEscriba un programa para representar mediante barras de asteriscos 10 números recogidos por teclado con valores enteros entre 1 y 20. " +
                        "Los 10 números se introducen separados por un espacio mediante un string.\r\n");
      
      // Pedir al usuario que introduzca los números separados por espacios
      Console.Write("\nIntroduzca 10 números separados por espacios (enteros entre 1 y 20): ");
      string cadena = Console.ReadLine();

      // Dividir la cadena en un vector de strings utilizando el espacio como separador
      string[] numeros = cadena.Split(' ');

      foreach (string elementos in numeros) {
        int comprobarNumeros = int.Parse(elementos);

        while (comprobarNumeros <= 0 || comprobarNumeros > 20) {
          Console.Write("\nError. Introduce números del 1 al 20: ");
          cadena = Console.ReadLine();
          if (comprobarNumeros > 0 && comprobarNumeros <= 20) {
            break;
          }
        }
      }

      // Recorrer el vector y convertir cada elemento 
      foreach (string val in numeros) {
        // Convertir el string a un entero y guardarlo en convertirNumeros
        int convertirNumeros = int.Parse(val);

        // Imprimir el número y el número de asteriscos 
        Console.Write(convertirNumeros + "\t");
        for (int i = 0; i < convertirNumeros; i++) {
          Console.Write("*");
        }
        Console.WriteLine();
      }
    }
  }
}
