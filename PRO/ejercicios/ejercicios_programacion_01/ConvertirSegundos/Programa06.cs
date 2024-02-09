using System;

namespace ConvertirSegundos {
  class Programa06 {
    public static void Main(String[] args) {
      Console.WriteLine("Dado un número de segundos determinado por teclado, mostrar su correspondencia en horas, " +
                        "minutos y segundos.");

      Console.Write("Introduce numero de segundos: ");
      int numero_segundos = Convert.ToInt32(Console.ReadLine());

      int segundos = numero_segundos % 60;
      int numero_minutos = (numero_segundos % 3600) / 60;
      int numero_horas = numero_segundos / 3600;

      Console.WriteLine(numero_horas + ":" + numero_minutos + ":" + segundos);
      Console.ReadKey();
    }
  }
}
