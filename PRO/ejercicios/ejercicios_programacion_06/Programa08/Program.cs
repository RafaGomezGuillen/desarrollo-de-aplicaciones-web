using System;

namespace Programa08 {
  class Program {
    public static void Main(string[] args) {
      Console.WriteLine("\nIntroduce la siguiente información.");

      Console.Write("\n-Nombres de 4 empleados.");
      const int MAX_EMPLEADOS = 4;
      string[] NombreEmpleados = new string[MAX_EMPLEADOS];
      string Nombres;
      int i;

      for (i = 0; i < MAX_EMPLEADOS; i++) {
        Console.Write("\n Introduzca los nombres del vector (" + i + ") : ");
        Nombres = Console.ReadLine();
        NombreEmpleados[i] = Nombres;
      }

      Console.WriteLine("\n-Ingresos en concepto de sueldo, cobrado por cada empleado, en los últimos 3 meses.");
      decimal Sueldo = 0;
      decimal[] SueldoEmpleados = new decimal[MAX_EMPLEADOS];
      decimal TotalSueldo = 0, MaximoSueldo = SueldoEmpleados[0];
      string MaximoSueldoNombre = "";

      for (i = 0; i < MAX_EMPLEADOS; i++) {
        Console.Write($"\nIntroduzca el sueldo de: " + NombreEmpleados[j] + " (" + i + ") : ");
        while (!decimal.TryParse(Console.ReadLine(), out Sueldo)) {
          Console.Write("Error. Introduzca un número (" + i + ") : ");
        }
        SueldoEmpleados[i] = Sueldo;
        TotalSueldo += SueldoEmpleados[i];
        if (SueldoEmpleados[i] > MaximoSueldo) {
          MaximoSueldo = SueldoEmpleados[i];
          MaximoSueldoNombre = NombreEmpleados[i];
        }
      }

      for (i = 0; i < MAX_EMPLEADOS; i++) {
        Console.Write("\n" + NombreEmpleados[i] + " cobra en tres meses " + SueldoEmpleados[i] + " euros.");
      }

      Console.WriteLine("\n\n" + MaximoSueldoNombre + " es el empleado que más cobra con " + MaximoSueldo + " euros.");
      Console.WriteLine("El total a pagar a los empleados es de " + TotalSueldo + " euros.");
    }
  }
}