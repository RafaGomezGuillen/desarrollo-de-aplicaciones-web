using System;

namespace ejercicio02 {
  class Program {
    public static void Main(string[] args) {
      const int MAX_ELEMENTO = 8;
      int[] VectorInicial = new int[MAX_ELEMENTO];
      int Elementos = 0;

      for (int i = 0; i < MAX_ELEMENTO; i++) {
        Console.Write("\nIntroduce los elementos del vector: (" + i + ") : ");
        while ((!Int32.TryParse(Console.ReadLine(), out Elementos)) || (Elementos > 99 || Elementos < -99) || (Elementos / 10 == 0)) {
          Console.WriteLine("El número introducido no tiene dos cifras o no es número (" + i + ") : ");
        }
        VectorInicial[i] = Elementos;
      }

      Console.Write("\nIntroduce el valor de referencia: ");
      int ValorDeReferencia = 0;
      while ((!Int32.TryParse(Console.ReadLine(), out ValorDeReferencia)) || (ValorDeReferencia > 99 || ValorDeReferencia < -99) || (ValorDeReferencia / 10 == 0)) {
        Console.WriteLine("El valor de referencia está mal.");
      }

      Console.Write("\nVector inicial: ");
      for (int i = 0; i < MAX_ELEMENTO; i++) {
        Console.Write(VectorInicial[i] + " ");
      }

      Console.Write("\nDato de referencia: " + ValorDeReferencia);

      int Cont = 0;
      int aux = 0;
      int SumaDelVectoFinal = 0;

      Console.Write("\nVector final: ");
      for (int i = 0; i < MAX_ELEMENTO; i++) {
        if (VectorInicial[i] > ValorDeReferencia) {
          Cont++;
          int[] VectorFinal = new int[Cont];
          for (int j = 0; j < Cont; j++) {
            aux = VectorInicial[i];
            VectorInicial[i] = VectorFinal[j];
            VectorFinal[j] = aux;
            SumaDelVectoFinal += VectorFinal[j];
            if (VectorFinal[j] != 0) {
              Console.Write(VectorFinal[j] + " ");
            }
          }
        }
      }

      Console.Write("\nSuma del vector final: " + SumaDelVectoFinal);
    }
  }
}