namespace RafaGomezExamen
{
    class Ficheros
    {
        const string FICHERO_ENTRADA = "poblacion-cifras-absolutas.csv";
        public const string FICHERO_SALIDA = "poblacion_datos_procesados.csv";
        static List<string> lineas = new List<string>();

        public static bool ExisteFichero ()
        {
            if (File.Exists(FICHERO_ENTRADA))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Fichero de entrada no existe.");
                return false;
            }
        }
        public static bool LeerFichero ()
        {
            try
            {
                lineas = File.ReadAllLines(FICHERO_ENTRADA).ToList();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public static bool CrearFichero (string fichero)
        {
            bool valor = true;
            StreamWriter sw;

            try
            {
                sw = new StreamWriter(fichero, true);
                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return valor;
        }
        public static bool ComprobarDatos()
        {
            bool correcto = true;
            for (int i = 1; i < lineas.Count; i++)
            {
                string[] datos = lineas[i].Split(';');
                for (int j = 2; j < 20; j++)
                {
                    if (!int.TryParse(lineas[i].Split(';')[j], out int valores) || valores < 0)
                    {
                        Console.WriteLine("Línea: " + (i + 1) + " Dato negativo o no numérico");
                        correcto = false;
                    }
                }
                if (datos[1].Trim().Length <= 0)
                {
                    Console.WriteLine("Línea: " + (i + 1) + " Municipio vacío.");
                    correcto = false;
                }
            }
            return correcto;
        }
        public static bool ImprimirDatos ()
        {
            StreamWriter sWriter;
            try
            {
                sWriter = new(FICHERO_SALIDA);
                sWriter.WriteLine("Municipio;AñoMin;ValorMin;AñoMax;ValorMax;Media");
                for (int i = 1; i < lineas.Count; i++)
                {
                    string[] datos = lineas[i].Split(';');
                    decimal promedioTotal = 0;
                    int min = 1000000, max = 0;
                    
                    for (int j = 2; j < 20; j++)
                    {
                        promedioTotal += Convert.ToDecimal(datos[j]);
                        if (max < Convert.ToInt32(datos[j]))
                        {
                            max = Convert.ToInt32(datos[j]);
                        }

                        if (min > Convert.ToInt32(datos[j]))
                        {
                            min = Convert.ToInt32(datos[j]);
                        }
                    }
                    decimal promedioFinal = promedioTotal / 18;
                    promedioFinal = Math.Round(promedioFinal, 2);
                    sWriter.WriteLine(datos[1].Trim() + ";" + "AñoMax" + ";" + min + ";" + "AñoMax" + ";" + max + ";" + promedioFinal);
                }
                sWriter.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public static decimal PedirNumero ()
        {
            decimal numero = 0;
            Console.Write("\nIntroduce un número: ");
            while (!decimal.TryParse(Console.ReadLine(), out numero) || numero <= 0)
            {
                Console.Write("ERROR: ");
            }
            return numero;
        }
        public static bool ImprimirConsola(decimal num)
        {
            for (int i = 1; i < lineas.Count; i++)
            {
                string[] datos = lineas[i].Split(';');
                decimal promedioTotal = 0;
                for (int j = 2; j < 20; j++)
                {
                    promedioTotal += Convert.ToDecimal(datos[j]);
                }
                decimal promedioFinal = promedioTotal / 18;
                promedioFinal = Math.Round(promedioFinal, 2);
                if (num < promedioFinal)
                {
                    Console.WriteLine(datos[1].Trim() + "\t-->\t" + promedioFinal);
                }
            }
            return true;
        }
    }
}
