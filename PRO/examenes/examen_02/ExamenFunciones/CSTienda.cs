using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenFunciones
{
    internal class CSTienda
    {
        public static void Menu(AlumnadoBono[] alumnos)
        {
            List<string> ventaNombre = new List<string> { };
            List<int> ventaNumCopias = new List<int> { };
            bool fin = false;
            while (!fin)
            {
                Console.WriteLine("\n\tBienvenido a la copisteria. ¿Qué desea hacer?\n\t\t" +
                    "1: Realizar Venta.\n\t\t2:Mostrar Datos de Venta.\n\t\t0: Salir del programa.");
                int opcion = CSInscripcion.LeerEntero("\n\tIntroduce una opción(0-2): ", 0, 2);
                switch (opcion)
                {
                    case 1: RealizarVenta(alumnos, ventaNombre, ventaNumCopias); break;
                    case 2: MostrarDatosVenta(alumnos, ventaNombre, ventaNumCopias); break;
                    case 0: fin = true; break;
                }
            }
            CSInscripcion.LimpiarPantalla();
            Console.WriteLine("\n\tGracias por visitar la copisteria, vuelva pronto ^^.");
        }

        public static void RealizarVenta(AlumnadoBono[] alumnos, List<string> ventaNombre, List<int> ventaNumCopias)
        {
            int eleccion = 0, numCopias, copiasRestantes = 0, copiasRealizadas = 0;
            Console.WriteLine("\n\tSeleccione que alumno realizara la venta");
            MostrarNombres(alumnos);
            eleccion = CSInscripcion.LeerEntero("\n\tIntroduzca un indice dentro del rango: ", 0, alumnos.Length - 1);
            AlumnadoBono seleccionado = alumnos[eleccion];
            Console.WriteLine("\n\t¿Cuántas copias desea realizar?");
            numCopias = CSInscripcion.LeerEntero("Introduzca un número entero no negativo: ", 0);

            for (int i = 0; i < ventaNombre.Count; i++)
                if (seleccionado.nombre == ventaNombre[i])
                    copiasRealizadas += ventaNumCopias[i];
            copiasRestantes = seleccionado.copiasPagadas - copiasRealizadas;
            if (!(copiasRestantes > numCopias))
                Console.WriteLine("\n\tLo sentimos, no tiene el número suficiente de copias en el bono");
            else
            {
                ventaNombre.Add(seleccionado.nombre);
                ventaNumCopias.Add(numCopias);
            }
            CSInscripcion.LimpiarPantalla();
        }

        public static void MostrarNombres(AlumnadoBono[] alumnos)
        {
            for (int i = 0; i < alumnos.Length; i++)
                Console.WriteLine($"\t\tAlumno [{i}]: {alumnos[i].nombre}");
        }

        public static void MostrarDatosVenta(AlumnadoBono[] alumnos, List<string> ventaNombre, List<int> ventaNumCopias)
        {
            Console.WriteLine("ESTADO DE LOS BONOS");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Nombre\tCopias Pagadas\tCopias Realizadas\tCopias Restantes\tVentas Realizadas");
            int copiasRealizadas = 0, copiasRestantes = 0, ventasRealizadas = 0;
            double ventasTotales = 0;
            
            foreach(AlumnadoBono alumno in alumnos)
            {
                copiasRestantes = alumno.copiasPagadas;
                for (int i = 0; i < ventaNombre.Count; ++i)
                {
                    if (alumno.nombre == ventaNombre[i])
                    {
                        ventasRealizadas++;
                        copiasRealizadas += ventaNumCopias[i];
                        copiasRestantes -= ventaNumCopias[i];
                    }
                }
                Console.WriteLine($"{alumno.nombre}\t\t{alumno.copiasPagadas}\t\t{copiasRealizadas}\t\t{copiasRestantes}\t\t{ventasRealizadas}");
                copiasRealizadas = 0;
                copiasRestantes = 0;
                ventasRealizadas = 0;
                Console.WriteLine("\n");
            }
            foreach (int numCopias in ventaNumCopias)
                ventasTotales += numCopias;
            double ganancias = ventasTotales * 0.05;
            Console.WriteLine($"\n\n\nGanancias Totales: {ganancias:f2}");
            CSInscripcion.LimpiarPantalla();
        }
    }
}
