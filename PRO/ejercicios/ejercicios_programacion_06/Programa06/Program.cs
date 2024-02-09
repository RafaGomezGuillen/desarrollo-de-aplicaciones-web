using System;

namespace Programa06 {
  class Program {
    public static void Main(string[] args) {
      Console.WriteLine("Recogidos los datos del nombre de diez alumnos, y la nota que han obtenido en un examen, " +
                        "calcular la media de las notas de los diez alumnos, e indicar el nombre de los alumnos que tienen una nota inferior a la media.");
      int ElementoMaximo = 10;
      decimal[] NotaAlumnos = new decimal[ElementoMaximo];
      string[] NombresAlumnos = new string[ElementoMaximo];
      decimal Elementos = 0, SumaElementos = 0, Media;
      string Nombres;
      int i = 0, j;

      for (j = 0; j < ElementoMaximo; j++) {
        Console.Write("\n Introduzca los nombres del vector (" + j + ") : ");
        Nombres = Console.ReadLine();
        NombresAlumnos[j] = Nombres;
      }

      j = 0;
      while (i < ElementoMaximo && j < ElementoMaximo) {
        Console.Write($"\n Introduzca las notas de: " + NombresAlumnos[j] + " (" + i + ") : ");
        while (!decimal.TryParse(Console.ReadLine(), out Elementos)) {
          Console.Write("Error. Introduzca un número (" + i + ") : ");
        }
        if (Elementos >= 0 && Elementos <= 10) {
          NotaAlumnos[i] = Elementos;
          SumaElementos += NotaAlumnos[i];
          i++;
          j++;
        }
      }

      Media = SumaElementos / ElementoMaximo;
      Console.WriteLine("Media aritmética: " + Media);

      for (i = 0; i < ElementoMaximo; i++) {
        if (Media > NotaAlumnos[i]) Console.Write(NombresAlumnos[i] + " ");
      }
    }
  }
}