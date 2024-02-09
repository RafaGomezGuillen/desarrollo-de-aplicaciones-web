using System;

namespace Programa10 {
  class Program {
    public static void Main(string[] args) {
      Console.WriteLine("Dada una frase y una palabra, eliminar esa palabra de la frase tantas veces como aparezca, " +
                        "diciendo la frase sin ellas y el número de veces que se ha eliminado. Por ejemplo: dada la frase: “Hola amigo." +
                        "Como estas amigo. Yo estoy muy bien amigo.”, y la palabra “amigo”, debe devolver: “Hola. Como estas. Yo estoy muy bien.” " +
                        "y mostrar el valor 3, por eliminarlo tres veces. Se debe eliminar la palabra, y el espacio en blanco anterior si lo hubiera.");

      Console.Write("Introduce una frase: ");
      string? cadena_01 = Console.ReadLine();
      Console.Write("Introduce una palabra para eliminarla de la frase: ");
      string? cadena_02 = Console.ReadLine();
      string cadena_03 = "";
      for (int i = 0; i < cadena_01.Length; i++) {
        if (cadena_01[i] == cadena_02[0]) {
          for (int j = 0; j < cadena_02.Length; j++) {
            i++;
          }
        } else {
          cadena_03 += cadena_01[i];
        }
      }
      Console.WriteLine(cadena_03);
    }
  }
}
