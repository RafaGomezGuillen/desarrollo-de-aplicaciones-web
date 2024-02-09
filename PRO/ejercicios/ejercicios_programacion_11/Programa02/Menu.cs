using System;

namespace Programa02 {
  class Menu {
    public static void VerMenu() {
      Console.Clear();
      Console.WriteLine("-----------------------------------------");
      Console.WriteLine("-         Fichero prueba.txt            -");
      Console.WriteLine("-----------------------------------------");
      Console.WriteLine("-----------------------------------------");
      Console.WriteLine("- Pulsar las siguientes opciones        -");
      Console.WriteLine("-----------------------------------------");
      Console.WriteLine("- 1. Crear fichero.                     -");
      Console.WriteLine("- 2. Introducir valores.                -");
      Console.WriteLine("- 3. Calcular máximo.                   -");
      Console.WriteLine("- 4. Calcular mínimo.                   -");
      Console.WriteLine("- 5. Calcualr media.                    -");
      Console.WriteLine("- 6. Salir.                             -");
      Console.WriteLine("-----------------------------------------");
    }
    public static int LeerOpcion() {
      ConsoleKeyInfo tecla;
      int valor;

      do {
        valor = 0;
        tecla = Console.ReadKey(true);
        switch (tecla.KeyChar) {
          case '1': valor = 1; break;
          case '2': valor = 2; break;
          case '3': valor = 3; break;
          case '4': valor = 4; break;
          case '5': valor = 5; break;
          case '6': valor = 6; break;
        }
      } while (valor == 0);
      return valor;
    }
    public static void Adios() {
      Console.Write("Pulsa una tecla para finalizar...");
      Console.ReadKey();
    }
  }
}