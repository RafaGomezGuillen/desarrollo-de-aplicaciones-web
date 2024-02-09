using static pair_programming_01.Personal;

namespace pair_programming_01
{
    class CSFunciones
    {
        public static int SolicitarNumeroPersonas ()
        {
            int nPersonas = 0;
            Console.Write("\nIntroduce el número de personas a tratar: ");
            while (!int.TryParse(Console.ReadLine(), out nPersonas) || (nPersonas <= 0))
            {
                Console.Write("Error. El elemento introducido no es valido: ");
            }
            return nPersonas;
        }
        public static Personas[] LeerDatosMuestra (int personasMuestra)
        {
            Personas[] persona = new Personas[personasMuestra];

            for (int i = 0; i < personasMuestra; i++)
            {
                Console.Write("\nIntroduce el nombre de la persona {0}: ", i + 1);
                persona[i].nombre = Console.ReadLine();
                while (persona[i].nombre.Length == 0)
                {
                    Console.Write("\nError. El nombre no debe estar vacio.\nIntentelo de nuevo: ");
                    persona[i].nombre = Console.ReadLine();
                }
                Console.Write("\nIntroduce el apellido de la persona {0}: ", i + 1);
                persona[i].apellidos = Console.ReadLine();
                while (persona[i].apellidos.Length == 0)
                {
                    Console.Write("\nError. El apellido no debe estar vacio.\nIntentelo de nuevo: ");
                    persona[i].apellidos = Console.ReadLine();
                }
                Console.Write("\nIntroduce la altura de la persona {0}: ", i + 1);
                while (!decimal.TryParse(Console.ReadLine(), out persona[i].altura) || (persona[i].altura <= 0 || persona[i].altura >= 3))
                {
                    Console.Write("\nError. El elemento introducido no es valido\nIntentelo de nuevo: ");
                }
            }
            return persona;
        }
        public static void MostrarDatosMuestra (Personas[] listaPersonas)
        {
            foreach (Personas persona in listaPersonas)
            {
                Console.WriteLine("Persona {0} {1}, con altura {2}m.", persona.nombre, persona.apellidos, persona.altura);
            }
        }
        public static int ComprobarOption (ref int option)
        {
            while (!int.TryParse(Console.ReadLine(), out option))
            {
                Console.Write("\nERROR. Introduce un número entero: ");
            }
            return option;
        }
    }
}
