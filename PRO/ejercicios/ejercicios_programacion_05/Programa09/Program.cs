using System;

namespace Programa09 {
  class Program {
    public static void Main(string[] args) {
      Console.WriteLine("Dada una cadena de caracteres que contenga el nombre de una persona en formato APELLIDOS, NOMBRE, " +
                        "convertirla en una cadena del tipo NOMBRE APELLIDOS.");

      Console.Write("Introduce una cadena en formato APELLIDOS, NOMBRE: ");
      string? cadena_01 = Console.ReadLine();
      string apellido = "";
      string nombre = "";
      int i = 0;
      while (i < cadena_01.Length){
        if (cadena_01[i] == ',') break;
        apellido += cadena_01[i];
        i++;
      }
      while (i < cadena_01.Length) {
        if (cadena_01 != apellido && cadena_01[i] != ',' && cadena_01[i] != ' ') nombre += cadena_01[i];
        i++;
      }
      Console.WriteLine(nombre.ToUpper() + " " + apellido.ToUpper());
    }
  }
}