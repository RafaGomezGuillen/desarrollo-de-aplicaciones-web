using System;

namespace NotasAlumno {
  class Programa16 {
    public static void Main(String[] args) {
      Console.WriteLine("Dada la nota de un alumno / a, pasar ese dato numérico a nota por nombre" +
                        "(Aprobado, Notable, Sobresaliente, etc.).");

      Console.Write("Introduce la nota: ");
      string cadena_01 = Console.ReadLine();

      if (float.TryParse(cadena_01, out float numero_01)) {
        if ((numero_01 * 100) - Convert.ToInt32(numero_01 * 100) != 0) {
          Console.WriteLine("Error.");
        } else {
          if (numero_01 < 5 && numero_01 >= 0) {
            Console.WriteLine(numero_01 + " es suspenso.");
          }
          else if (numero_01 < 7 && numero_01 >= 5) {
            Console.WriteLine(numero_01 + " es aprobado.");
          }
          else if (numero_01 < 9 && numero_01 >= 7) {
            Console.WriteLine(numero_01 + " es notable.");
          }
          else if (numero_01 < 10 && numero_01 >= 9) {
            Console.WriteLine(numero_01 + " es sobresaliente.");
          }
          else if (numero_01 == 10) {
            Console.WriteLine(numero_01 + " es matricula de honor.");
          }
          else {
            Console.WriteLine("Dato mal introducido.");
          }
        }
      } else {
        Console.WriteLine(cadena_01 + " no es un número.");
      }
      Console.ReadKey();
    }
  }
}
