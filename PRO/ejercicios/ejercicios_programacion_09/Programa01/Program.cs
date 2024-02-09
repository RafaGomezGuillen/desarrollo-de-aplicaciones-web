using System;

namespace Programa01 {
  class Program {
    private static void Main(string[] args) {
      Console.WriteLine("\tDada una temperatura en grados Celcius, realizar una función que convierta esa cantidad a grados Fahrenheit \n" +
                        "y otra a grados Kelvin.\n");

      decimal gradosCelcius = 0;
      Funciones.ComprobacionDecimal(ref gradosCelcius);
      Console.WriteLine(gradosCelcius + " grados Celcius son " + Funciones.ConvertirFahrenheit(gradosCelcius) + " grados Fahrenheit.");
      Console.WriteLine(gradosCelcius + " grados Celcius son " + Funciones.ConvertirKelvin(gradosCelcius) + " grados Kelvin.");
      Funciones.Adios();
    }
  }
  class Funciones {
    public static void ComprobacionDecimal(ref decimal num1) {
      Console.Write("\nIntroduzca un número: ");
      while (!decimal.TryParse(Console.ReadLine(), out num1)) {
        Console.Write("\nERROR. Introduzca un número: ");
      }
    }
    public static decimal ConvertirFahrenheit(decimal num1) {
      decimal fahrenheit = (num1 * 9 / 5) + 32;
      return fahrenheit;
    }
    public static decimal ConvertirKelvin(decimal num1) {
      const double NUMERO_2 = 273.15;
      decimal kelvin = num1 + Convert.ToDecimal(NUMERO_2);
      return kelvin;
    }
    public static void Adios() {
      Console.Write("\nIntroduce una tecla para salir...");
      Console.ReadKey();
    }
  }
}