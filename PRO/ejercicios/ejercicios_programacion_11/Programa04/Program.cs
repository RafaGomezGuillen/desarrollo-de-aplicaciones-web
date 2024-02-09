using System;
using System.IO;
using System.Threading;

namespace Programa04 {
  class Program {
    static void Main(string[] args) {
      const string FICHERO_1 = "fichero1.txt";
      const string FICHERO_2 = "fichero2.txt";
      const string FICHERO_SALIDA = "salida.txt";

      if (File.Exists(FICHERO_1) && File.Exists(FICHERO_2)) {
        StreamReader sReadFichero1 = null;
        StreamReader sReadFichero2 = null;

        string leerLineasFichero1 = "", leerLineasFichero2 = "";

        try {
          // Leo el fichero 1
          sReadFichero1 = new StreamReader(FICHERO_1);
          while (!sReadFichero1.EndOfStream) {
            leerLineasFichero1 += sReadFichero1.ReadLine();
          }
          sReadFichero1.Close();
          string[] lineasFichero1 = new string[0];
          lineasFichero1 = leerLineasFichero1.Split(' ');
          // Leo el fichero 2
          sReadFichero2 = new StreamReader(FICHERO_2);
          while (!sReadFichero2.EndOfStream) {
            leerLineasFichero2 += sReadFichero2.ReadLine();
          }
          sReadFichero2.Close();
          string[] lineasFichero2 = new string[0];
          lineasFichero2 = leerLineasFichero2.Split(' ');
          // Creo el fichero de salida y le escribo la información
          StreamWriter sWrite = null;
          try {
            sWrite = File.CreateText(FICHERO_SALIDA);
            sWrite.Close();
            sWrite = new StreamWriter(FICHERO_SALIDA, true);

            if (lineasFichero1.Length == lineasFichero2.Length) {
              // Si el tamaño de los fichero son iguales los imprimo tranquilito
              for (int i = 0, j = 0; i < lineasFichero1.Length && j < lineasFichero2.Length; i++, j++) {
                sWrite.Write(lineasFichero1[i] + " " + lineasFichero2[j] + " ");
              }
            } else {
              // Sino los imprimo tanquilito y... (creo que está parte se puede optimizar)
              for (int i = 0, j = 0; i < lineasFichero1.Length && j < lineasFichero2.Length; i++, j++) {
                sWrite.Write(lineasFichero1[i] + " " + lineasFichero2[j] + " ");
              }
              // Si el tamaño del fichero 1 > fichero 2 imprimo desde el tamaño del fichero 2 hasta el tamaño del 1.
              if (lineasFichero1.Length > lineasFichero2.Length) {
                for (int i = lineasFichero2.Length; i < lineasFichero1.Length; i++) {
                  sWrite.Write(lineasFichero1[i]);
                }
              } else {
                for (int i = lineasFichero1.Length; i < lineasFichero2.Length; i++) {
                  sWrite.Write(lineasFichero2[i]);
                }
              }
            }
            sWrite.Close();
          } catch (Exception ex) {
            Console.WriteLine(ex.Message);
          }
        } catch (Exception ex) {
          Console.WriteLine(ex.Message);
        }
      } else {
        Console.WriteLine("Deben existir los dos ficheros.");
      }
    }
  }
} 