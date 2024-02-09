using System;

namespace Programa01 {
  class Program {
    private static void Main(string[] args) {
      // Declaración de variables.
      string[] Casas;
      double[] Costo;

      // LLamo a la función SolicitarNumeroCasa para guardarlo en la varible tamaño. Este será el tamaño de los arrays.
      int tamaño = Funciones.SolicitarNumeroCasa();
      Casas = new string[tamaño];
      Costo = new double[tamaño];

      // Paso Casas y Costo en SolicitarDatos para que el usuario introduzca los valores de los dos arrays.
      Funciones.SolicitarDatos(Casas, Costo);

      // Paso Casas y Costo en ListadoLimiteSuperiorInferior y lo guardo el resultado en listado
      string[] listado = Funciones.ListadoLimiteSuperiorInferior(Casas, Costo);

      // Paso Casas y Costo en NumeroCasasInferior y lo guardo el resultado en contadorCasasInferiores,
      int contadorCasasInferiores = Funciones.NumeroCasasInferior(Casas, Costo);

      // Imprimo los resultados.
      Console.Write("\nListado de las casas inferiores y superiores establecido: ");
      foreach(string str in listado) {
        Console.Write(str + " ");
      }
      Console.WriteLine("\nNúmero de casas inferior: " + contadorCasasInferiores);
    }
  }
}