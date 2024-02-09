using System;
using System.Drawing;
using System.IO;
using System.Threading;

namespace Programa02 {
  class Ficheros {
    public const string NOMBRE_FICHERO = "fichero.txt";
    public static bool sobreescribir = true;
    public static bool IniciarFichero() {
      bool valor = true;
      StreamWriter sWrite = null;

      if (!File.Exists(NOMBRE_FICHERO)) {
        try {
          // Si el fichero no existe pos lo creo
          sWrite = File.CreateText(NOMBRE_FICHERO);
          sWrite.Close();
          Console.WriteLine("Fichero creado.");
          Menu.Adios();
        } catch (Exception ex) {
          Console.WriteLine(ex.Message);
          valor = false;
        }
      } else {
        // Si el fichero ya existe pregunto si lo quiere sobreescribir
        string cadena = "";
        Console.Write("\n¿Quieres sobreescribir el fichero? (si o no): ");
        cadena = Console.ReadLine();
       
        while(cadena != "si" && cadena != "no") {
          Console.Write("\nIntroduce (si o no): ");
          cadena = Console.ReadLine();
        }
        
        if (cadena == "no") sobreescribir = false;

        Menu.Adios();
      }
      return valor;
    }
    public static bool EscribirFichero() {
      bool valor = true;
      StreamWriter sWrite = null;

      try {
        sWrite = new StreamWriter(NOMBRE_FICHERO, sobreescribir);
        Console.Clear();
        Console.WriteLine("Introduzca la información a incluir en el fichero.");
        Console.WriteLine("--------------------------------------------------");
        string leerLineas = Console.ReadLine();
        // Escribo los valores separados por coma, sino hay comas no fufa
        while(!leerLineas.Contains(',') || leerLineas.Trim().Length == 0 || leerLineas[leerLineas.Length - 1] == ',') {
          Console.Write("\nIntroduzca los números separados por coma, no vacio y que el último valor no sea una coma: ");
          leerLineas = Console.ReadLine();
        }
        sWrite.Write(leerLineas);
        sWrite.Close();
        Console.WriteLine("Informacion introducida.");
        Menu.Adios();
      } catch (Exception ex) {
        Console.WriteLine(ex.Message);
        valor = false;
      }
      return valor;
    }
    public static bool Maximo() {
      bool valor = true;
      StreamReader sRead = null;
      string lineas = "";

      try {
        sRead = new StreamReader(NOMBRE_FICHERO);
        Console.Clear();
        Console.WriteLine("Máximo del fichero.txt");
        Console.WriteLine("--------------------------------");
        while (!sRead.EndOfStream) {
          lineas += sRead.ReadLine();
        }
        sRead.Close();
        string[] valores = new string[0];
        valores = lineas.Split(",");
        int maximo = 0;
        for (int i = 0; i < valores.Length; i++) {
          if (maximo < Convert.ToInt32(valores[i]) || !int.TryParse(valores[i], out _)) {
            maximo = Convert.ToInt32(valores[i]);
          }
        }
        Console.WriteLine(maximo);
        Menu.Adios();
      } catch (Exception ex) {
        Console.WriteLine(ex.Message);
        valor = false;
      }
      return valor;
    }

    public static bool Minimo() {
      bool valor = true;
      StreamReader sRead = null;
      string lineas = "";

      try {
        sRead = new StreamReader(NOMBRE_FICHERO);
        Console.Clear();
        Console.WriteLine("Mínimo del fichero.txt");
        Console.WriteLine("--------------------------------");
        while (!sRead.EndOfStream) {
          lineas += sRead.ReadLine();
        }
        sRead.Close();
        string[] valores = new string[0];
        valores = lineas.Split(",");
        int minimo = 1000000000;
        for (int i = 0; i < valores.Length; i++) {
          if (minimo > Convert.ToInt32(valores[i]) || !int.TryParse(valores[i], out _)) {
            minimo = Convert.ToInt32(valores[i]);
          }
        }
        Console.WriteLine(minimo);
        Menu.Adios();
      } catch (Exception ex) {
        Console.WriteLine(ex.Message);
        valor = false;
      }
      return valor;
    }

    public static bool Media() {
      bool valor = true;
      StreamReader sRead = null;
      string lineas = "";

      try {
        sRead = new StreamReader(NOMBRE_FICHERO);
        Console.Clear();
        Console.WriteLine("Media del fichero.txt");
        Console.WriteLine("--------------------------------");
        while (!sRead.EndOfStream) {
          lineas += sRead.ReadLine();
        }
        sRead.Close();
        string[] valores = new string[0];
        valores = lineas.Split(",");
        decimal suma = 0;
        for (int i = 0; i < valores.Length; i++) {
          if (!int.TryParse(valores[i], out _)) {
            suma += Convert.ToInt32(valores[i]);
          }
        }
        decimal media = suma / valores.Length;
        Console.WriteLine(media);
        Menu.Adios();
      } catch (Exception ex) {
        Console.WriteLine(ex.Message);
        valor = false;
      }
      return valor;
    }
  }
}