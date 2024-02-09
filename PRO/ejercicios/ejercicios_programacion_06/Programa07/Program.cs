using System;

namespace Programa07 {
  class Program {
    public static void Main(string[] args) {
      Console.WriteLine("Crear un string con 100 letras entre la A y la Z de forma aleatoria. " +
                        "A continuación, calcular cuántas veces aparece cada letra en dicho string, " +
                        "y mostrar este resultado por pantalla, indicando la letra, y el número de veces que aparece.");
      
      const int ElementoMaximo = 100;
      char[] ListaLetrasAleatorias = new char[ElementoMaximo];
      Random LetrasAleatorias = new Random();
      string CaracteresLetras = "QWERTYUIOPASDFGHJKLZXCVBNM";
      int Contador = 0;

      Console.WriteLine("\n\nVector de cadenas.\n");
      for (int i = 1; i <= ElementoMaximo; i++) {
        ListaLetrasAleatorias[i - 1] = Convert.ToChar(LetrasAleatorias.Next('A', 'Z'));
      }

      for (int i = 0; i < ElementoMaximo; i++) {
        Console.Write(ListaLetrasAleatorias[i] + " ");
      }

      for (int j = 0; j < CaracteresLetras.Length; j++) {
        for (int i = 0; i < ElementoMaximo - 1; i++) {
          if (ListaLetrasAleatorias[i] == CaracteresLetras[j]) {
            Contador++;
          } 
        }
        Console.Write("\nLa letra " + CaracteresLetras[j] + " aparece " + Contador + " veces.");
        Contador = 0;
      }
    }
  }
}