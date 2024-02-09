using System;

namespace PorcentajeAlumnos {
  class Programa05 {
    public static void Main(String[] args) {
      Console.WriteLine("Porcentaje de alumnos en el curso actual, pasando por teclado el número de chicas y de chicos.");

      Console.Write("Introduce numero de chicos: ");
      int numero_chicos = Convert.ToInt32(Console.ReadLine());

      Console.Write("Introduce numero de chicas: ");
      int numero_chicas = Convert.ToInt32(Console.ReadLine());

      int total = numero_chicas + numero_chicos;
      decimal porcentaje_chicos = (Convert.ToDecimal(numero_chicos) / total) * 100;
      decimal porcentaje_chicas = (Convert.ToDecimal(numero_chicas) / total) * 100;

      Console.WriteLine("El numero de alumnos es: " + total + " con un porcentaje de chicos del " + porcentaje_chicos + "% y de chicas " + porcentaje_chicas + "%.");
      Console.ReadKey();
    }
  }
}
