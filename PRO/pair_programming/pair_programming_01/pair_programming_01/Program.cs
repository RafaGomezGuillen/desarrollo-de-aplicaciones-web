namespace pair_programming_01
{
    class Personal
    {
        public struct Personas
        {
            public string nombre;
            public string apellidos;
            public decimal altura;
        }
    }
    class Program
    {
        private static void Main(string[] args)
        {
            // Declaraciones
            Personal.Personas[] listaPersonas = new Personal.Personas[0];
            string[] personasFiltradas = new string[0];
            string mensajeFiltro = "";
            int option = -1, personasMuestra = 0;

            // Ejercicio 1
            personasMuestra = CSFunciones.SolicitarNumeroPersonas();

            // Ejercicio 2
            listaPersonas = CSFunciones.LeerDatosMuestra(personasMuestra);

            while (option != 0)
            {
                Console.Write("\n(1) Muestra los datos de la muestra por pantalla.\n" +
                              "(2) Muestra por pantalla los nombres de las personas que reúnen una condición (encima) o (debajo). \n" +
                              "(0) Para salir..." +
                              "\nIntroduce una opcion: ");
                option = CSFunciones.ComprobarOption(ref option);
                switch (option)
                {
                    case 1:
                        Console.Clear();
                        CSFunciones.MostrarDatosMuestra(listaPersonas);
                        Console.Write("Presione una tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        mensajeFiltro = CSAlturas.MensajeFiltro();

                        if (mensajeFiltro == "encima")
                        {
                            Console.WriteLine("Personas por encima de la media: ");
                            CSAlturas.MostrarPersonas(CSAlturas.PersonasPorEncimaMedia(listaPersonas), mensajeFiltro);
                        }
                        else
                        {
                            Console.WriteLine("Personas por debajo de la media: ");
                            CSAlturas.MostrarPersonas(CSAlturas.PersonasPorDebajoMedia(listaPersonas), mensajeFiltro);
                        }
                        Console.Write("Presione una tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 0:
                        Console.Write("Saliendo...");
                        break;
                    default:
                        Console.Write("La opcion introducida no es valida. Presione una tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}