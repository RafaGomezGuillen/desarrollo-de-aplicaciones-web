using System;

namespace Programa01 {
  internal class Funciones {
    /// <summary>
    /// Función para pedir un número, este será entre 10 y 30.
    /// </summary>
    /// <returns>Tamaño del array.</returns>
    public static int SolicitarNumeroCasa() {
      Console.Write("\nIntroduce el número de casas que almacenaremos (10 - 30): ");
      int numeroCasas = 0;
      while (!int.TryParse(Console.ReadLine(), out numeroCasas) || (numeroCasas < 10 || numeroCasas > 30)) {
        Console.Write("\nERROR. El número de casa debe estar entre 10 y 30, además es un número entero: ");
      }
      return numeroCasas;
    }
    /// <summary>
    /// Función para introducir los datos de los dos parámetros.
    /// </summary>
    /// <param name="Casas">Nombre de la casa</param>
    /// <param name="Costo">Costo de la casa</param>
    public static void SolicitarDatos(string[] Casas, double[] Costo) {
      for (int i = 0; i < Casas.Length; i++) {
        Console.Write("\nIntroduce el nombre de las casas (" + (i + 1) + "): ");
        Casas[i] = Console.ReadLine();
        for (int j = 0; j < i; j++) {
          while (Casas[i].Length == 0 || Casas[i].Trim() == "" || Casas[i] == Casas[j]) {
            Console.Write("\nERROR. Introduce una cadena no vacia o que no se repita: ");
            Casas[i] = Console.ReadLine();
          }
        }
        Console.Write("\nIntroduce el costo de las casas (" + (i + 1) + "): ");
        while (!double.TryParse(Console.ReadLine(), out Costo[i]) || Convert.ToInt32(Costo[i]) <= 0) {
          Console.Write("\nERROR. El coste de la casa debe ser positivo: ");
        }
      }
    }
    /// <summary>
    /// Función que pide un limite superior e inferior.
    /// </summary>
    /// <param name="Casas">Nombre de la casa</param>
    /// <param name="Costo">Costo de la casa</param>
    /// <returns>string[] con un listado de los nombres de las casas dentro del limite.</returns>
    public static string[] ListadoLimiteSuperiorInferior(string[] Casas, double[] Costo) {
      string[] listado = new string[0];
      int limiteSuperior = 0, limiteInferior = 0;

      Console.Write("\nIntroduce el limite superior: ");
      while (!int.TryParse(Console.ReadLine(), out limiteSuperior) || (limiteSuperior <= 0)) {
        Console.Write("\nERROR.Introduce un número positivo mayor que 0: ");
      }

      Console.Write("\nIntroduce el limite inferior: ");
      while (!int.TryParse(Console.ReadLine(), out limiteInferior) || (limiteInferior <= 0 || limiteInferior >= limiteSuperior)) {
        Console.Write("\nERROR.Introduce un número positivo mayor que 0 y menor que el limite superior: ");
      }

      for (int i = 0; i < Costo.Length; i++) {
        if (Costo[i] >= limiteInferior && Costo[i] <= limiteSuperior) {
          Array.Resize(ref listado, i + 1);
          listado[i] = Casas[i];
        }
      }
      return listado;
    }
    /// <summary>
    /// Dependiendo del nombre de una casa dirá el número de casas que tienen un costo inferior al de esa casa.
    /// </summary>
    /// <param name="Casas">Nombre de la casa</param>
    /// <param name="Costo">Costo de la casa</param>
    /// <returns>Contador de los costes inferiores a la cadena introducida.</returns>
    public static int NumeroCasasInferior(string[] Casas, double[] Costo) {
      int contador = 0;
      string nombreCasa = Funciones.ComprobacionNombreCasa(Casas);
      int index = Array.IndexOf(Casas, nombreCasa);
      double costoCasa = Costo[index];
      for (int i = 0; i < Costo.Length; i++) {
        if (Costo[i] < costoCasa) {
          contador++;
        }
      }
      return contador;
    }
    /// <summary>
    /// Compruebo que el nombre introducido exista en Casas.
    /// </summary>
    /// <param name="Casas">Nombre de la casa</param>
    /// <returns>El nombre comprobado.</returns>
    private static string ComprobacionNombreCasa(string[] Casas) {
      Console.Write("\nIntroduce un nombre de una casa para decir el número de casas que tienen un costo inferior al de esa casa: ");
      string cadena = "";
      cadena = Console.ReadLine();
      
      while (!Casas.Contains(cadena)) {
        Console.Write("\nERROR. Introduce una cadena existente en casas: ");
        cadena = Console.ReadLine();  
      }
      return cadena;
    }
  }
}
