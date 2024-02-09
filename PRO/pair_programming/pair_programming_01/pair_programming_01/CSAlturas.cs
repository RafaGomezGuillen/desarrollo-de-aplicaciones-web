using static pair_programming_01.Personal;

namespace pair_programming_01
{
    class CSAlturas
    {
        private static decimal CalcularMedia (Personas[] listaPersonas)
        {
            decimal media = 0, suma = 0;
            
            foreach (Personas persona in listaPersonas)
            {
                suma += persona.altura;
            }
            media = suma / listaPersonas.Length;
            return media;
        }
        public static string[] PersonasPorEncimaMedia (Personas[] listaPersonas)
        {
            int cont = 0;
            string[] PersonasPorEncima = new string[cont];
            decimal media = CalcularMedia(listaPersonas);

            for (int i = 0; i < listaPersonas.Length; i++)
            {
                if (listaPersonas[i].altura > media)
                {
                    Array.Resize(ref PersonasPorEncima, i + 1);
                    PersonasPorEncima[i] = listaPersonas[i].nombre + " " + listaPersonas[i].apellidos;
                }
            }
            return PersonasPorEncima;
        }
        public static string[] PersonasPorDebajoMedia (Personas[] listaPersonas)
        {
            int cont = 0;
            string[] PersonasPorDebajo = new string[cont];
            decimal media = CalcularMedia(listaPersonas);
            
            for (int i = 0; i < listaPersonas.Length; i++)
            {
                if (listaPersonas[i].altura < media)
                {
                    Array.Resize(ref PersonasPorDebajo, i + 1);
                    PersonasPorDebajo[i] = listaPersonas[i].nombre + " " + listaPersonas[i].apellidos;
                }
            }
            return PersonasPorDebajo;
        }
        public static void MostrarPersonas (string[] personasFiltradas, string mensajeFiltro)
        {
            foreach (string str in personasFiltradas)
            {
                Console.Write(str + " ");
            }
        }
        public static string MensajeFiltro ()
        {
            string mensajeFiltro = "";
            Console.Write("\n(encima) para mostrar las personas encima de la media \n" +
                          "(debajo) para mostrar las personas debajo de la media\n" +
                          "Introduce: ");
            mensajeFiltro = Console.ReadLine();
            while (mensajeFiltro != "encima" && mensajeFiltro != "debajo")
            {
                Console.Write("\nIntroduce encima o debajo: ");
                mensajeFiltro = Console.ReadLine();
            }
            return mensajeFiltro;
        }
    }
}
