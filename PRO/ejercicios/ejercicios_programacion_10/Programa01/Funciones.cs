using System;

namespace Programa01 {
  internal class Funciones {
    public static int NumerosDel1Al100(int valor) {
      if (valor == 100) {
        return 100;
      } else {
        Console.Write(valor + " ");
        return NumerosDel1Al100(valor + 1);
      }
    }
  }
}
