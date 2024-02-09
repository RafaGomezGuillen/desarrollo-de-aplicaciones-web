using System;
using System.Drawing;
using System.IO;

namespace Programa01 {
  class Program {
    private static void Main(string[] args) {
      const string FICHERO_ENTRADA = "entrada.txt";
      const string FICHERO_SALIDA = "salida.txt";
      
      // Leo el fichero y lo creo
      StreamWriter sWrite = null;

      if (File.Exists(FICHERO_ENTRADA)) {
        Console.WriteLine("Fichero entrada existe.");

        // Ya que existe el fichero creo el de salida
        sWrite = File.CreateText(FICHERO_SALIDA);
        sWrite.Close();

        // Leo su contenido
        StreamReader sRead = null;
        string leerLineas = "";
        try {
          sRead = new StreamReader(FICHERO_ENTRADA);
          while (!sRead.EndOfStream) {
            leerLineas += sRead.ReadLine();
          }
          sRead.Close();
        } catch (Exception ex) {
          Console.WriteLine(ex.Message);
        }
        
        // Separo los valores gracias a los ';'
        string[] lineas = new string[0];
        lineas = leerLineas.Split(';');

        try {
          sWrite = new StreamWriter(FICHERO_SALIDA, true);
          int suma = 0;
          for (int i = 0; i < lineas.Length; i += 2) {
            if (!int.TryParse(lineas[i], out _)) {
              Console.WriteLine("Los valores no son números.");
            } else {
              suma = Convert.ToInt32(lineas[i]) + Convert.ToInt32(lineas[i + 1]);
              sWrite.WriteLine(lineas[i] + " + " + lineas[i + 1] + " = " + suma);
            }
          }
          sWrite.Close();
        } catch (Exception ex) {
          Console.WriteLine(ex.Message);
        }
      } else {
        Console.WriteLine("Fichero entrada no existe.");
      }
    }
  }
}