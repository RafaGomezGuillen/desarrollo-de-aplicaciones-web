namespace RafaelGomezGuillenFicheros
{
    class Ficheros
    {
        // Fichero original
        const string FICHERO_ENTRADA = "edades-medias-de-la-poblacion.csv";
        // Fichero con todos los datos correctos
        //const string FICHERO_ENTRADA = "edades-medias-de-la-poblacion-bien.csv";
        public const string FICHERO_SALIDA = "media_poblacion.csv";
        public const string FICHERO_ERRORES = "errores.log";
        static List<string> lineas = new List<string>();
        static List<string> nombreMunicio = new List<string>();
        /// <summary>
        /// Comprobación si existe un fichero
        /// </summary>
        /// <returns>true: si existe; false: si no existe</returns>
        public static bool ExisteFichero ()
        {
            if (File.Exists(FICHERO_ENTRADA))
            {
                Console.WriteLine(FICHERO_ENTRADA + " existe.");
                return true;
            }
            else
            {
                ImprimirErrores("Fichero de entrada no existe.");
                return false;
            }
        }
        /// <summary>
        /// Leer todas las líneas del fichero de entrada
        /// </summary>
        /// <returns>true: si no hay problemas de lectura, false: si hay problemas de lectura</returns>
        public static bool LeerFichero ()
        {
            try
            {
                lineas = File.ReadAllLines(FICHERO_ENTRADA).ToList();
                Console.WriteLine("\nSe han leído todas las líneas.");
                return true;
            }
            catch (Exception ex)
            {
                ImprimirErrores(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// Creo un fichero
        /// </summary>
        /// <param name="fichero">Nombre del fichero</param>
        /// <returns>true: si no hay problemas de creación; false: si hay problemas de creación</returns>
        public static bool CrearFichero (string fichero)
        {
            bool valor = true;
            StreamWriter sw;

            try
            {
                sw = new StreamWriter(fichero, true);
                sw.Close();
                Console.WriteLine(fichero + " creado.");
            }
            catch (Exception ex)
            {
                ImprimirErrores(ex.Message);
                return false;
            }

            return valor;
        }
        /// <summary>
        /// Leo los datos del fichero
        /// </summary>
        /// <returns>true: si todos los datos son correctos; false: si hay algún dato incorrecto</returns>
        public static bool DatosFichero ()
        {
            lineas.Remove(lineas[0]);
            double valores = 0;
            bool correcto = false;

            for (int i = 0; i < lineas.Count; i++)
            {
                for (int j = 2; j < 20; j++)
                {
                    if (double.TryParse(lineas[i].Split(';')[j], out valores) && valores > 0)
                    {
                        correcto = true;
                    }
                    else
                    {
                        if (valores < 0) ImprimirErrores("Línea: " + (i + 1) + " es un número negativo.");
                        correcto = false;
                    }

                    if (!double.TryParse(lineas[i].Split(';')[j], out _)) ImprimirErrores("Línea: " + (i + 1) + " no es un número válido.");
                }
                if (lineas[i].Split(';')[1].Trim().Length > 0)
                {
                    nombreMunicio.Add(lineas[i].Split(';')[1].Trim());
                }
                else
                {
                    ImprimirErrores("Línea: " + (i + 1) + " el municipio es una cadena vacía.");
                    correcto = false;
                }
            }
            return correcto;
        }
        /// <summary>
        /// Imprimo los errores en .log
        /// </summary>
        /// <param name="str">Mensaje de error</param>
        private static void ImprimirErrores (string str)
        {
            StreamWriter sWriter;
            try
            {
                sWriter = new StreamWriter(FICHERO_ERRORES, true);
                sWriter.WriteLine(str);
                sWriter.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        /// <summary>
        /// Imprimo los datos en el fichero de salida
        /// </summary>
        public static void ImprimirDatos ()
        {
            StreamWriter sWriter;

            try
            {
                sWriter = new(FICHERO_SALIDA);
                sWriter.WriteLine("Municipio; Media");
                for (int i = 0; i < lineas.Count; i++)
                {
                    double promedioTotal = 0;
                    string[] promedio = lineas[i].Split(';');
                    for (int j = 2; j < 20; j++)
                    {
                        promedioTotal += Convert.ToDouble(promedio[j]);
                    }

                    double promedioFinal = promedioTotal / 18;
                    promedioFinal = Math.Round(promedioFinal, 2);

                    sWriter.WriteLine(nombreMunicio[i] + ";" + promedioFinal);
                }
                sWriter.Close();
            }
            catch (Exception ex)
            {
                ImprimirErrores(ex.Message);
            }
        }
    }
}
