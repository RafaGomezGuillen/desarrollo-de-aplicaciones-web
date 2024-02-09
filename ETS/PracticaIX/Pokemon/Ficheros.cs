namespace Pokemon
{
    public class Ficheros
    {
        public const string FICHERO_ENTRADA = "pokemon.csv";
        public const string FICHERO_SALIDA = "pokemonDosTipos.csv";
        static List<string> lineas = new List<string>();
        public static int PedirGeneracion ()
        {
            int genetaion = 0;
            Console.Write("Introduce generación de pokemon: ");
            while (!int.TryParse(Console.ReadLine(), out genetaion) || genetaion <= 0 || genetaion > 6)
            {
                Console.Write("\nERROR. Introduce un número entre 1 y 6: ");
            }
            return genetaion;
        }
        public static string strongestPokemon (string rutaFichero, int generation)
        {
            string valores = "";
            try
            {
                List<int> ataque = new List<int>();
                lineas = File.ReadAllLines(rutaFichero).ToList();
                for (int i = 1; i < lineas.Count; i++)
                {
                    string[] datos = lineas[i].Split(',');
                    if (datos[12] == "False" && datos[11] == Convert.ToString(generation))
                    {
                        int ataqueDatos = Convert.ToInt32(datos[6]);
                        ataque.Add(ataqueDatos);
                    }
                }

                int maxAtaque = ataque.Max();
                for (int i = 1; i < lineas.Count; i++)
                {
                    string[] datos = lineas[i].Split(',');
                    if (datos[12] == "False" && datos[11] == Convert.ToString(generation) && maxAtaque == Convert.ToInt32(datos[6]))
                    {
                        valores += datos[1] + ". ";
                    }
                }
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
            return valores;
        }
        public static void filterPokemon (string rutaFichero)
        {
            StreamWriter sWriter;
            try
            {
                sWriter = new StreamWriter(rutaFichero);
                lineas = File.ReadAllLines(FICHERO_ENTRADA).ToList();
                for (int i = 1; i < lineas.Count; i++)
                {
                    string[] datos = lineas[i].Split(',');
                    if (datos[2] != "" && datos[3] != "")
                    {
                        sWriter.WriteLine(datos[1]);
                    }
                }
                sWriter.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }
    }
}
