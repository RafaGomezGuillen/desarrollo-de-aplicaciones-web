using System;

namespace EjercicioRecuperacion01 {
  class ProgramaRecuperacion01 {
    public static void Main() {
      Console.WriteLine("Bienvenido al concecionario.");
      Console.Write("Introduzca el numero de neumáticos que desea adquirir: ");
      string cadena_01 = Console.ReadLine();

      if (Int32.TryParse(cadena_01, out int numero_01)) {
        if((numero_01 < 4) && (numero_01 > 0)) {
          double numero_descuento = (50 - (50 * 0.1)) * 2;
          if (numero_01 == 1) {
            Console.WriteLine("El neumático cuesta 50 euros.");
          } else if (numero_01 == 2) {
            Console.WriteLine("El total es: " + numero_descuento);
          } else if (numero_01 == 3) {
            numero_descuento = ((50 - (50 * 0.1)) * 2) + 50;
            Console.WriteLine("El total es: " + numero_descuento);
          } else if (numero_01 == 4) {
            numero_descuento = (50 - (50 * 0.2)) * 4;
            Console.WriteLine("El total es: " + numero_descuento);
          }
        } else {
          Console.WriteLine("No se puede adquirir más de 4 neumáticos");
        }
      } else {
        Console.WriteLine("No ha introducido un número no entero.");
      }
      Console.ReadKey();
    }
  }
}