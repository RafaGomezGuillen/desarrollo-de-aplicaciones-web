using System;
using System.IO;

namespace Programa03 {
  class Program {
    private static void Main(string[] args) {
      const string FICHERO_ENTRADA = "entrada.txt";
      StreamReader sRead = null;

      if(File.Exists(FICHERO_ENTRADA)) {
        // Leo el contendio del fichero
        // leerLineas va a leer las lineas una a una y comprobar con numLinea y comprobacion que todo este bien
        string leerLineasComprobacion = "";
        int numLinea = 0, comprobacion = 0;
        try {
          sRead = new StreamReader(FICHERO_ENTRADA);
          while (!sRead.EndOfStream) {
            leerLineasComprobacion = sRead.ReadLine();
            if (!leerLineasComprobacion.Contains(", ")) {
              Console.WriteLine("La linea " + numLinea + " no cumple las condiciones.");
              comprobacion++;
            }
            numLinea++;
          }
          sRead.Close();
          if (comprobacion == 0) {
            Console.WriteLine(FICHERO_ENTRADA + " Tiene , y espacios");
            try {
              StreamReader sRead1 = null;
              sRead1 = new StreamReader(FICHERO_ENTRADA);
              string leerLineas = "";
              while(!sRead1.EndOfStream) {
                leerLineas = sRead1.ReadLine();

                // En lineas separo el nombre con el resto del contenido
                string[] lineas = new string[0];
                lineas = leerLineas.Split(',');

                // Nombre guardo los nombres de los alumnos
                string[] nombre = new string[lineas.Length / 2];
                for (int i = 0; i < nombre.Length; i++) {
                  nombre[i] = lineas[0];
                }

                // Valores contiene todo el contenido separado por ' '
                string[] valores = new string[0];
                int[] notas = new int[3];
                valores = leerLineas.Split(' ');
                int j = 0;
                for (int i = 0; i < valores.Length; i++) {
                  // La posicion 0 y 1 contiene el nombre y apellido, la 5 un ' '
                  // Guardo en nota los números 
                  if (i != 0 && i != 1 && i != 5 && !int.TryParse(valores[i], out _)) {
                    notas[j] = Convert.ToInt32(valores[i]);
                    j++;
                  }
                }

                // Imprimo los suspendidos, pongo breack porque sino se imprimen tres veces
                for (int i = 0; i < notas.Length; i++) {
                  if (notas[i] < 5) {
                    Console.WriteLine(nombre[0]);
                    break;
                  }
                }
              }
              sRead1.Close();
            } catch (Exception ex) {
              Console.WriteLine(ex.Message);
            }
          } else {
            Console.WriteLine(FICHERO_ENTRADA + " no cumple las condiciones");
          }
        } catch (Exception ex) {
          Console.WriteLine(ex.Message);
        }
      } else {
        Console.WriteLine(FICHERO_ENTRADA + " no existe.");
      }
    }
  }
}