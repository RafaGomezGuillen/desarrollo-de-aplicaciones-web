using System;

namespace EjercicioAEntregar02 {
  class Programa02 {
    public static void Main(String[] args) {
      Console.Write("Introduce el número de invitados de la boda: ");
      string cadena_01 = Console.ReadLine();

      if (int.TryParse(cadena_01, out int numero_01)) {
        if (numero_01 > 0) {
          const int piso_tarta = 12; // No le asigno el valor como constante a piso_tarta y pedirle al usuario por teclado 
                                     // el número de pisos de la tarta por comensal.
          int numero_piso = numero_01 / piso_tarta;
          
          if (numero_01 > (piso_tarta * numero_piso)) numero_piso = numero_piso + 1;
          
          Console.WriteLine("Si hay " + numero_01 + " comensales, la tarta debe tener " + numero_piso +
                            " pisos.");
        } else {
          Console.WriteLine("Error." + numero_01 + " debe ser positivo.");
        }
      } else {
        Console.WriteLine("Error. " + cadena_01 + " no es un número o no es entero.");
      }
      Console.ReadKey();
    }
  }
}
