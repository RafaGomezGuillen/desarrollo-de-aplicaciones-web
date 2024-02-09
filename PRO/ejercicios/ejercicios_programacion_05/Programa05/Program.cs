using System;

namespace Programa05 {
  class Program {
    public static void Main(string[] args) {
      Console.WriteLine("Dada una cadena por teclado, indicar cuáles son las vocales que contiene.");

      Console.Write("Introduce la cadena: ");
      string cadena_01 = Console.ReadLine();
      bool find_a = false, find_e = false, find_i = false, find_o = false, find_u = false;
      for (int i = 0; i < cadena_01.Length; i++) {
        if ((cadena_01[i] == 'a') || (cadena_01[i] == 'A')) find_a = true;
        if ((cadena_01[i] == 'e') || (cadena_01[i] == 'E')) find_e = true;
        if ((cadena_01[i] == 'i') || (cadena_01[i] == 'I')) find_i = true;
        if ((cadena_01[i] == 'o') || (cadena_01[i] == 'O')) find_o = true;
        if ((cadena_01[i] == 'u') || (cadena_01[i] == 'U')) find_u = true;
      }

      if (find_a == true) Console.WriteLine(cadena_01 + " contiene a.");
      if (find_e == true) Console.WriteLine(cadena_01 + " contiene e.");
      if (find_i == true) Console.WriteLine(cadena_01 + " contiene i.");
      if (find_o == true) Console.WriteLine(cadena_01 + " contiene o.");
      if (find_u == true) Console.WriteLine(cadena_01 + " contiene u.");
    }
  }
}