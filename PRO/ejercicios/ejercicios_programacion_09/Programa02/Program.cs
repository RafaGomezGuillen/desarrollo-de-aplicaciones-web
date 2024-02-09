using System;

namespace Programa02 {
  class Program {
    private static void Main(string[] args) {
      Console.WriteLine("\tRealizar el mismo ejercicio anterior, pero al pasar a la función los grados Celcius, \n" +
                        "también se le pasará una “F” para pasar a grados Fahrenheit, o una “K” para pasar a grados Kelvin.\n");

      decimal gradosCelcius = 0;
      Funciones.ComprobacionDecimal(ref gradosCelcius);
      char grados = ' ';
      Funciones.ComprobacionLetra(ref grados);
      Funciones.ConvertirFahrenheitKelvin(grados, gradosCelcius);
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
    public static char ComprobacionLetra(ref char grados) {
      Console.Write("\nIntroduzca un F para Fahrenheit o K para Kelvin: ");
      while (!char.TryParse(Console.ReadLine(), out grados) || ((grados != 'F') && (grados != 'K'))) {
        Console.Write("\nERROR. Introduzca F o K: ");
      }
      return grados;
    }
    public static void ConvertirFahrenheitKelvin(char grados, decimal num1) {
      if (grados == 'F') {
        decimal fahrenheit = (num1 * 9 / 5) + 32;
        Console.WriteLine(num1 + " grados Celcius son " + fahrenheit + " grados Fahrenheit.");
      } else {
        const double NUMERO_2 = 273.15;
        decimal kelvin = num1 + Convert.ToDecimal(NUMERO_2);
        Console.WriteLine(num1 + " grados Celcius son " + kelvin + " grados Kelvin.");
      }
    }
    public static void Adios() {
      Console.Write("\nIntroduce una tecla para salir...");
      Console.ReadKey();
    }
  }
}