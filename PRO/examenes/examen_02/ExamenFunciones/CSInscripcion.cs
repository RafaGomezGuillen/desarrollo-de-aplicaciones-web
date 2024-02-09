using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenFunciones
{
    internal class CSInscripcion
    {
        public static AlumnadoBono[] LeerDatos()
        {
            AlumnadoBono[] alumnos = new AlumnadoBono[0];
            AlumnadoBono alumno = new AlumnadoBono { };
            bool fin = false;

            do
            {
                alumno.nombre = LeerNombre(alumnos);
                if (alumno.nombre == "FIN")
                    fin = true;
                else
                {
                    alumno.copiasPagadas = LeerEntero("\n\tIntroduce un número superior o igual a 10 de fotocopias: ", 10);
                    Array.Resize(ref alumnos, alumnos.Length + 1);
                    alumnos[^1] = alumno;
                }
            } while (!fin);

            return alumnos;
        }

        public static string LeerCadena(string msg)
        {
            Console.WriteLine(msg);
            Console.Write("\n\tIntroduzca el nombre del alumno: ");
            string nombre = Console.ReadLine();

            while (nombre.Trim().Length == 0)
            {
                Console.Write("\n\t El nombre no puede ser una cadena vacía: ");
                nombre = Console.ReadLine() ?? "";
            }
            return nombre;
        }

        public static string LeerNombre(AlumnadoBono[] alumnos, string msg = "")
        {
            string nombre = LeerCadena(msg);
            foreach (string nomb in alumnos.Select(a => a.nombre).ToArray())
                if (nomb == nombre)
                    return LeerNombre(alumnos, "\n\tEse nombre ya ha sido introducido");

            return nombre;
        }

        public static int LeerEntero(string msg, int? min = null, int? max = null)
        {
            int num;

            do
            {
                Console.Write(msg);
            } while (!Int32.TryParse(Console.ReadLine(), out num) || num < min || num > max);
            return num;
        }

        public static void LimpiarPantalla()
        {
            Console.WriteLine("Pulse una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
