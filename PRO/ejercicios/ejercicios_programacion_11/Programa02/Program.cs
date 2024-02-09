using System;

namespace Programa02 {
  class Program {
    private static void Main(string[] args) {
      int opcion = 0;
      bool noError = true;

      do {
        Menu.VerMenu();
        opcion = Menu.LeerOpcion();
        Console.Write("\n");
        switch (opcion) {
          case 1: noError = Ficheros.IniciarFichero(); break;
          case 2: noError = Ficheros.EscribirFichero(); break;
          case 3: noError = Ficheros.Maximo(); break;
          case 4: noError = Ficheros.Minimo(); break;
          case 5: noError = Ficheros.Media(); break;
          case 6: Console.Clear(); noError = false; break;
        }
      } while (noError);
      Menu.Adios();
    }
  }
}
