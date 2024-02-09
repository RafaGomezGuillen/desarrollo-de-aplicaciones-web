using System;

class Program {
  public static void Main(String[] args) {
    Console.WriteLine("Bienvenido a mi programa usuario :)");
    int numero_edad = Convert.ToInt32(Console.ReadLine());

    if (numero_edad >= 18) {
      Console.WriteLine("Bienvenido al club, amigo.");

      Console.Write("Introduce numero, para ver si es multiplo de 5: ");
      int numero_01 = Convert.ToInt32((Console.ReadLine()));

      Console.Write("Introduce numero, para ver su cubo: ");
      int numero_02 = Convert.ToInt32((Console.ReadLine()));
      
      if (numero_01 % 5 == 0) {
        Console.WriteLine(numero_01 + " es multiplo de 5.");
      } else {
        Console.WriteLine(numero_01 + " no es multiplo de 5.");
      }

      double cubo = Math.Pow(numero_02, 3);
      Console.WriteLine("El cubo de " + numero_02 + " = " + cubo);

    } else {
      Console.WriteLine("Lo siento chaval");
    }
    Console.ReadKey();
  }
}

