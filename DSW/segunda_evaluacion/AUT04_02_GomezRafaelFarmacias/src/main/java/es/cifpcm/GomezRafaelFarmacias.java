package es.cifpcm;
import es.cifpcm.data.ImplementsPersistence;
import es.cifpcm.data.Persistence;
import es.cifpcm.model.Farmacia;
import es.cifpcm.util.ConsoleUtils;

import java.util.Scanner;

public class GomezRafaelFarmacias {
    private static Persistence pst = new ImplementsPersistence();
    private static Scanner sc = new Scanner(System.in);

    public static void main(String[] args) {
        // Leer los datos del JSON
        pst.openJson();

        int opcion;
        boolean noError = true;

        do {
            printMainMenu();
            opcion = getOpcion();

            ConsoleUtils.clearConsole();

            switch (opcion) {
                case 1:
                    buscarFarmacia();
                    break;
                case 2:
                    listarFarmacias();
                    break;
                case 9:
                    noError = goAdminMenu(noError);
                    break;
                case 0:
                    noError = false;
                    break;
            }

            ConsoleUtils.clearConsole();
        } while (noError);
    }

    private static void buscarFarmacia() {
        if (pst.list().size() > 0) {
            Farmacia farmacia = getFarmaciaInput("Nombre de las farmacias disponibles:");
            System.out.println(farmacia);
        } else {
            System.out.println("No hay farmacias que buscar.");
        }
        ConsoleUtils.Adios();
    }

    private static void insertarFarmacia() {
        String web, horario, telefono, nombre = sc.nextLine();
        float UTM_X, UTM_Y = 0;

        System.out.print("Introduce la web de la farmacia: ");
        web = sc.nextLine();

        System.out.print("Introduce la horario de la farmacia: ");
        horario = sc.nextLine();

        System.out.print("Introduce la télefono de la farmacia: ");
        telefono = sc.nextLine();

        System.out.print("Introduce la nombre de la farmacia: ");
        nombre = sc.nextLine();

        System.out.print("Introduce las coordernadas X de la farmacia: ");
        UTM_X = sc.nextFloat();

        System.out.print("Introduce las coordernadas Y de la farmacia: ");
        UTM_Y = sc.nextFloat();

        Farmacia farmacia = new Farmacia(web, horario, telefono, nombre, UTM_X, UTM_Y);
        pst.add(farmacia);
        ConsoleUtils.Adios();
    }

    private static void borrarFarmacia() {
        if (pst.list().size() > 0) {
            Farmacia farmacia = getFarmaciaInput("Nombre de las farmacias disponibles a eliminar: \n");
            pst.delete(farmacia);
        } else {
            System.out.println("No hay farmacias que borrar.");
        }

        ConsoleUtils.Adios();
    }

    private static void listarFarmacias() {
        System.out.println("Farmacias disponibles: \n");
        for (Farmacia farmacia : pst.list()) {
            System.out.println(farmacia);
        }

        ConsoleUtils.Adios();
    }

    private static boolean goAdminMenu(boolean noError) {
        int opcion;
        printAdminMenu();
        opcion = getOpcionAdmin();

        switch (opcion) {
            case 1:
                insertarFarmacia();
                break;
            case 2:
                borrarFarmacia();
                break;
            case 3:
                listarFarmacias();
                break;
            case 0:
                noError = false;
                break;
        }

        return noError;
    }

    private static void printMainMenu() {
        StringBuilder sb = new StringBuilder();
        sb.append("========== Farmacias de mi ciudad ==========\n");
        sb.append("-- Necesito Paracetamol ya!\n\n");
        sb.append("1. Busque por nombre\n");
        sb.append("2. Lista de farmacias disponibles\n");
        sb.append("0. Salir\n");
        sb.append("-----------------------\n");
        sb.append("9. Admin\n");
        System.out.println(sb);
        System.out.print("Introduzca una opción: ");
    }

    private static void printAdminMenu() {
        StringBuilder sb = new StringBuilder();
        sb.append("========== Farmacias de mi ciudad - ADMIN ==========\n");
        sb.append("1. Añadir farmacias\n");
        sb.append("2. Borrar farmacias\n");
        sb.append("3. Listar farmacias\n");
        sb.append("0. Salir\n");
        System.out.println(sb);
        System.out.print("Introduzca una opción: ");
    }

    private static int getOpcion () {
        int valor;

        do {
            valor = -1;
            int tecla = sc.nextInt();
            valor = switch (tecla) {
                case 1 -> 1;
                case 2 -> 2;
                case 9 -> 9;
                case 0 -> 0;
                default -> valor;
            };
        } while (valor == -1);

        return valor;
    }

    private static int getOpcionAdmin () {
        int valor;

        do {
            valor = -1;
            int tecla = sc.nextInt();
            valor = switch (tecla) {
                case 1 -> 1;
                case 2 -> 2;
                case 3 -> 3;
                case 0 -> 0;
                default -> valor;
            };
        } while (valor == -1);

        return valor;
    }

    private static Farmacia getFarmaciaInput(String informacion) {
        int i = 1;
        System.out.println(informacion + "\n");
        for (Farmacia farmacia : pst.list()) {
            System.out.println(farmacia.getNombre() + " (" + (i++) + ")");
        }

        Scanner scanner = new Scanner(System.in);
        int indice = 0;

        do {
            System.out.print("\nIntroduce el número de farmacia entre 1 y " + pst.list().size() + ": ");
            while (!scanner.hasNextInt()) {
                System.out.print("Eso no es un número. Inténtalo de nuevo: ");
                scanner.next(); // descarta la entrada incorrecta
            }

            indice = scanner.nextInt() - 1;
        } while (indice < 0 || indice >= pst.list().size());

        return pst.list().get(indice);
    }
}
