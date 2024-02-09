using System;

namespace Programa05 {
  class Program {
    public static void Main(string[] args) {
      Console.WriteLine("Crear un programa que pida al usuario 10 números decimales, " +
                        "calcule su media y luego muestre los que están por encima de la media.");
      const int ElementoMaximo = 10;
      decimal[] NumerosDeciamales = new decimal[ElementoMaximo];
      decimal Elementos = 0, SumaElementos = 0, Media;

      for (int i = 0; i < ElementoMaximo; i++) {
        Console.Write($"\n Introduzca los elementos del vector (" + i + ") : ");
        while (!decimal.TryParse(Console.ReadLine(), out Elementos)) {
          Console.Write("Error. Introduzca un número (" + i + ") : ");
        }
        NumerosDeciamales[i] = Elementos;
        SumaElementos += NumerosDeciamales[i];
      }

      Media = SumaElementos / ElementoMaximo;
      Console.WriteLine("Media aritmética: " + Media);
      
      for (int i = 0; i < ElementoMaximo; i++) {
        if (Media < NumerosDeciamales[i]) Console.Write(NumerosDeciamales[i] + " ");
      }
    }
  }
}