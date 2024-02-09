using System;

namespace Programa09 {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("Un viajero quiere gestionar todos los gastos que hizo en su último viaje con la tarjeta de crédito, pero no sabe cuántos fueron." +
                        "\n\nEstos gatos los puede clasificar en cuatro tipos: \n\n- comida \n- hospedaje \n- transporte \n- ropa. " +
                        "\n\nEscriba un programa, que haga uso de vectores, y le permita al viajero determinar:\n " +
                        "\n– Gastos totales discriminados por tipo.\n– Cantidad de gastos que realizó en comida.\n– Tipo de gasto en el que más invirtió dinero en el viaje.\r\n");

      // Pregunto los gastos de comida y luego los guardo en un vector
      Console.Write("\n\nCuántos gatos hizo en comida: ");
      int totalComida = 0;
      while (!int.TryParse(Console.ReadLine(), out totalComida) || totalComida <= 0) {
        Console.Write("\nERROR. Introduzca un número mayor que 0: ");
      }

      decimal[] gastosComida = new decimal[totalComida];
      decimal sumaComida = 0;
      for(int i = 0; i < totalComida; i++) {
        Console.Write("\nIntroduce los gastos en comida (" + i + ") : ");
        while (!decimal.TryParse(Console.ReadLine(), out gastosComida[i]) || gastosComida[i] <= 0) {
          Console.Write("\nERROR. Introduzca un número mayor que 0: ");
        }
        sumaComida += gastosComida[i];
      }

      Console.Clear();
      // Pregunto los gastos de hospedaje y luego los guardo en un vector
      Console.Write("\n\nCuántos gatos hizo en hospedaje: ");
      int totalHospedaje = 0;
      while (!int.TryParse(Console.ReadLine(), out totalHospedaje) || totalHospedaje <= 0) {
        Console.Write("\nERROR. Introduzca un número mayor que 0: ");
      }

      decimal[] gastosHospedaje = new decimal[totalHospedaje];
      decimal sumaHospedaje = 0;
      for (int i = 0; i < totalHospedaje; i++) {
        Console.Write("\nIntroduce los gastos en hospedaje (" + i + ") : ");
        while (!decimal.TryParse(Console.ReadLine(), out gastosHospedaje[i]) || gastosHospedaje[i] <= 0) {
          Console.Write("\nERROR. Introduzca un número mayor que 0: ");
        }
        sumaHospedaje += gastosHospedaje[i];
      }

      Console.Clear();
      // Pregunto los gastos de transporte y luego los guardo en un vector
      Console.Write("\n\nCuántos gatos hizo en transporte: ");
      int totalTransporte = 0;
      while (!int.TryParse(Console.ReadLine(), out totalTransporte) || totalTransporte <= 0) {
        Console.Write("\nERROR. Introduzca un número mayor que 0: ");
      }

      decimal[] gastosTransporte = new decimal[totalTransporte];
      decimal sumaTransporte = 0;
      for (int i = 0; i < totalTransporte; i++) {
        Console.Write("\nIntroduce los gastos en transporte (" + i + ") : ");
        while (!decimal.TryParse(Console.ReadLine(), out gastosTransporte[i]) || gastosTransporte[i] <= 0) {
          Console.Write("\nERROR. Introduzca un número mayor que 0: ");
        }
        sumaTransporte += gastosTransporte[i];
      }

      Console.Clear();
      // Pregunto los gastos de ropa y luego los guardo en un vector
      Console.Write("\n\nCuántos gatos hizo en ropa: ");
      int totalRopa = 0;
      while (!int.TryParse(Console.ReadLine(), out totalRopa) || totalRopa <= 0) {
        Console.Write("\nERROR. Introduzca un número mayor que 0: ");
      }

      decimal[] gastosRopa = new decimal[totalRopa];
      decimal sumaRopa = 0;
      for (int i = 0; i < totalRopa; i++) {
        Console.Write("\nIntroduce los gastos en ropa (" + i + ") : ");
        while (!decimal.TryParse(Console.ReadLine(), out gastosRopa[i]) || gastosRopa[i] <= 0) {
          Console.Write("\nERROR. Introduzca un número mayor que 0: ");
        }
        sumaRopa += gastosRopa[i];
      }

      Console.Clear();
      // Gastos totales por tipo
      Console.WriteLine("\nGastos totales por tipo.");
      Console.WriteLine("Gastos de comida: " + sumaComida);
      Console.WriteLine("Gastos de hospedaje: " + sumaHospedaje);
      Console.WriteLine("Gastos de transporte: " + sumaTransporte);
      Console.WriteLine("Gastos de ropa: " + sumaRopa);

      // Cantidad de gastos en ropa
      Console.WriteLine("\nCantidad de gastos en ropa: " + totalComida);

      // Tipo de gasto en el que más se invirtió dinero
      decimal max = Math.Max(sumaComida, sumaHospedaje);
      decimal max2 = Math.Max(sumaTransporte, sumaRopa);
      decimal max3 = Math.Max(max, max2);

      if (max3 == sumaComida) {
        Console.WriteLine("\nComida es el gasto en el más se invirtió.");
      } else if (max3 == sumaHospedaje) {
        Console.WriteLine("\nHospedaje es el gasto en el más se invirtió.");
      } else if (max3 == sumaTransporte) {
        Console.WriteLine("\nTransporte es el gasto en el más se invirtió.");
      } else {
        Console.WriteLine("\nRopa es el gasto en el más se invirtió.");
      }
    }
  }
}
