package es.cifpcm.util;
import java.util.Scanner;
public class ConsoleUtils {
    public static void clearConsole() {
        for (int i = 0; i < 3; i++) {
            System.out.println("\n");
        }
    }
    public static void Adios() {
        Scanner scanner = new Scanner(System.in);
        System.out.print("\nPresione cualquier tecla para continuar...");
        scanner.nextLine();
    }
}
