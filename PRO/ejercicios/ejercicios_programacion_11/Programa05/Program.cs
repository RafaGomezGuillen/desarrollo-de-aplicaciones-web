using System;
using System.Drawing;
using System.IO;

namespace Programa05 {
  class Program {
    private static void Main(string[] args) {
      Console.Write("Introduce le nombre del fichero de origen: ");
      string ficheroOrigen = Console.ReadLine();

      while(!ficheroOrigen.Contains(".txt")) {
        Console.Write("\nIntroduce un fichero con extensión .txt: ");
        ficheroOrigen = Console.ReadLine();
      }

      Console.Write("Introduce le nombre del fichero de destino: ");
      string ficheroDestino = Console.ReadLine();

      while (!ficheroDestino.Contains(".txt") || ficheroDestino.Contains(ficheroOrigen)) {
        Console.Write("\nIntroduce un fichero con extensión .txt y distino que el fichero de origen: ");
        ficheroDestino = Console.ReadLine();
      }

      if(!File.Exists(ficheroOrigen)) {
        StreamWriter sWriterFicheroOrigen = null;
        StreamWriter sWriterFicheroDestino = null;

        try {
          // Si el fichero de origen no existe, lo creo
          sWriterFicheroOrigen = File.CreateText(ficheroOrigen);
          sWriterFicheroOrigen.Close();
          Console.WriteLine(ficheroOrigen + " creado.");
        } catch (Exception ex) {
          Console.WriteLine(ex.Message);
        }
        
        try {
          // Le pido al usuario el contenido del fichero de origen
          Console.WriteLine("Introduzca la información a incluir en el fichero " + ficheroOrigen);
          Console.WriteLine("--------------------------------------------------");
          sWriterFicheroOrigen = new StreamWriter(ficheroOrigen, true);
          string lineasFicheroOrigen = Console.ReadLine();
          sWriterFicheroOrigen.WriteLine(lineasFicheroOrigen);
          sWriterFicheroOrigen.Close();
          Console.WriteLine("Informacion introducida.");
        } catch (Exception ex) {
          Console.WriteLine(ex.Message);
        }
        
        try {
          // Introduzco el contenido del fichero de origen al de destino
          StreamReader sRead = null;
          sRead = new StreamReader(ficheroOrigen);
          string leerFicheroOrigen = "";
          
          while(!sRead.EndOfStream) {
            leerFicheroOrigen += sRead.ReadLine();
          }
          sRead.Close();

          sWriterFicheroDestino = new StreamWriter(ficheroDestino, true);
          sWriterFicheroDestino.WriteLine(leerFicheroOrigen.ToUpper());
          sWriterFicheroDestino.Close();
          Console.WriteLine("Información introducida en " + ficheroDestino);
        } catch (Exception ex) {
          Console.WriteLine(ex.Message);
        }
      } else {
        Console.WriteLine(ficheroOrigen + " no existe.");
      }
    }
  }
}