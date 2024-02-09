using System;

namespace Programa03 {
  class Program {
    public static void Main(string[] args) {
      Console.WriteLine("\tDada una cadena de caracteres que contenga el nombre de una persona en formato APELLIDOS, NOMBRE, " +
                        "\nconvertirla en una cadena del tipo NOMBRE APELLIDOS.\r\n");

      // Pido la cadena inicial
      Console.Write("\t\nIntroduce una cadena tipo APELLIDOS, NOMBRE: ");
      string? cadenaInicial = Console.ReadLine();

      // Compruebo que la cadena no sea nula y contega ','
      while (cadenaInicial.Length == 0 || !cadenaInicial.Contains(',')) {
        Console.Write("\n\nERROR. Introduce una cadena no nula y quer contanga coma: ");
        cadenaInicial = Console.ReadLine();
      }

      // Veo la posición de la ','
      int posicionComa = cadenaInicial.IndexOf(",");
      // Guardo el substring despues de coma
      string nombre = cadenaInicial.Substring(posicionComa, cadenaInicial.Length - posicionComa);
      // Quito la coma
      nombre = nombre.Replace(',', ' ');
      // Quito los espacios
      nombre = nombre.Trim();

      // apellido es la primera posición hasta donde está la coma
      string apellido = cadenaInicial.Substring(0, posicionComa);

      // Los imprimo
      Console.WriteLine("\n\n" + nombre.ToUpper() + " " + apellido.ToUpper());

      // Versión optimizada
      string[] cadenaOptimizada = cadenaInicial.Split(',');
      Console.WriteLine(cadenaOptimizada[1].Trim() + " " + cadenaOptimizada[0]);
    }
  }
}