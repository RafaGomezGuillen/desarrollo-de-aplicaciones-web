using System;

namespace Programa02 {
  class Program {
    public static void Main(string[] args) {
      Console.WriteLine("Crear un programa que calcule la letra de un DNI a partir de un número introducido por el usuario. " +
                        "\nEl número se solicitará en una sola petición y se comprobará que cumple con el formato necesario (8 dígitos y una letra). " +
                        "\nEl programa comprobará que lo introducido es un DNI correcto, calculando el valor de la letra y comprobando con lo introducido por el usuario." +
                        "\nPara calcular la letra, se debe tomar el resto de dividir nuestro número de DNI entre 23. El resultado debe estar por tanto entre 0 y 22. ");

      string dni = "";
      string numerosDni = "";
      // Introduzco el DNI entero
      Console.Write("\nIntroduce el DNI: ");
      dni = Console.ReadLine(); 

      // Guardo en numerosDNI los números del DNI
      for (int i = 0; i < dni.Length - 1; i++) {
        numerosDni += dni[i];
      }

      // Convierto estos números a entero. ERROR: si el usuario no introduce un número 
      int numeros;
      numeros = Convert.ToInt32(numerosDni);

      string letras = "TRWAGMYFPDXBNJZSQVHLCKE";
      string ultimaLetra = "";

      // Si los numeros % 23 es igual a i (posición) correcto
      for (int i = 0; i < letras.Length; i++) {
        if (numeros % 23 == i) {
          ultimaLetra += letras[i];
        }
      }
      
      // Digo si es incorrecto o no
      if (ultimaLetra != Convert.ToString(dni[dni.Length - 1])) {
        Console.Write("Error. La letra no coincide. Este DNI " + dni + " es incorrecto.");
      } else {
        Console.WriteLine(dni + " correcto");
      }  
    }
  }
}