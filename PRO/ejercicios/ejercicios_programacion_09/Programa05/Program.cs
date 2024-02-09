using System;

namespace Programa05 {
  class Program {
    private static void Main(string[] args) {
      Console.WriteLine("\tVamos a utilizar un string para simular una pila de datos. Estos datos serán caracteres. \n" +
                        "En una pila de datos, siempre se introduce en la parte superior de la pila (al final del string), \n" +
                        "y para extraer información, se extrae de la parte superior del string." +
                        "\n\n\tRealizar las funciones de introducir en la pila, extraer de la pila y visualizar el contenido de la pila, \n" +
                        "así como una función para la lectura del carácter a introducir. Solicitar acciones hasta lograr que la pila no contenga nada. \n" +
                        "Al iniciar el programa, hay que solicitar el primer elemento de la pila.\n");
      
      int numeroMenu = 0;
      bool salirMenu = false;
      string pila = " ";
      char caracter = ' ';

      while (salirMenu == false) {
        Console.WriteLine("\n(1) Introducir dato a la pila\n" +
                    "(2) Extraer dato de la pila\n" +
                    "(3) Para visualizar el contenido de la pila\n" +
                    "(4) Para ver el tamaño de la pila\n" +
                    "(0) Para salir del menú.");
        Funciones.ComprobacionEnteroPositivo(ref numeroMenu);
        if (numeroMenu == 0) {
          Console.WriteLine("Haz salido del menú.");
          salirMenu = true;
        }
        if (numeroMenu == 1) {
          Funciones.IntroducirDatoPila(ref pila, caracter);
          Console.Clear();
        }
        if (numeroMenu == 2) {
          Funciones.ExtraerDatoPila(ref pila);
        }
        if (numeroMenu == 3) {
          Funciones.VisualizarPila(pila);
        }
        if (numeroMenu == 4) {
          Funciones.SizePila(pila);
        }
      }
      Funciones.Adios();
    }
  }
  class Funciones {
    public static int ComprobacionEnteroPositivo(ref int numero) {
      Console.Write("\nIntroduce un número: ");
      while (!int.TryParse(Console.ReadLine(), out numero) || (numero < 0)) {
        Console.Write("\nERROR. Introduzca un número positivo: ");
      }
      return numero;
    }
    private static char ComprobacionCaracter(ref char caracter) {
      Console.Write("\nIntroduzca un caracter para introducir en la pila: ");
      while (!char.TryParse(Console.ReadLine(), out caracter)) {
        Console.Write("\nERROR. Introduzca un caracter: ");
      }
      return caracter;
    }
    public static string IntroducirDatoPila(ref string pila, char caracter) {
      ComprobacionCaracter(ref caracter);
      pila += caracter;
      Console.WriteLine("Se ha introducido el caracter " + caracter + ".");
      return pila;
    }
    public static string ExtraerDatoPila(ref string pila) {
      Console.WriteLine("Se ha quitado el caracter " + pila[pila.Length - 1] + ".");
      pila = pila.Substring(0, pila.Length - 1);
      Adios();
      Console.Clear();
      return pila;
    }
    public static void VisualizarPila(string pila) {
      for(int i = pila.Length - 1; i >= 0; i--) {
        Console.WriteLine("|" + pila[i] + "|");
      }
      Adios();
      Console.Clear();
    }
    public static void SizePila(string pila) {
      Console.WriteLine("El tamaño de la pila es " + (pila.Length - 1) + ".");
      Adios();
      Console.Clear();
    }
    public static void Adios() {
      Console.Write("\nIntroduce una tecla para salir...");
      Console.ReadKey();
    }
  }
}