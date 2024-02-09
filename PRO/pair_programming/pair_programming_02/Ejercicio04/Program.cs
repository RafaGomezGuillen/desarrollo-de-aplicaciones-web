class Program
{
    private static void Main (string[] args)
    {
        const string FICHERO_ENTRADA = "Datos notas.csv";
        const string FICHERO_SALIDA = "salida.txt";
        StreamReader sRead = null;

        if (File.Exists(FICHERO_ENTRADA))
        {
            try
            {
                sRead = new StreamReader(FICHERO_ENTRADA);
                StreamWriter sWrite = null;
                string lineasFicheroEntrada = "";
                int contador = 1;
                string[] vectorAlumnado = new string[0];
                decimal notaEjercicios = 0, notaIntervenciones = 0, notaExamenes = 0, total = 0;

                while (!sRead.EndOfStream)
                {

                    lineasFicheroEntrada = sRead.ReadLine();
                    Array.Resize(ref vectorAlumnado, vectorAlumnado.Length + 1);
                    vectorAlumnado = lineasFicheroEntrada.Split(';');

                    try
                    {
                        sWrite = new StreamWriter(FICHERO_SALIDA, true);
                        notaEjercicios = (Convert.ToDecimal(vectorAlumnado[1]) + Convert.ToDecimal(vectorAlumnado[2]) + Convert.ToDecimal(vectorAlumnado[3])) / 3 * 0.3m;
                        notaIntervenciones = (Convert.ToDecimal(vectorAlumnado[4]) + Convert.ToDecimal(vectorAlumnado[5]) + Convert.ToDecimal(vectorAlumnado[6])) / 3 * 0.2m;
                        notaExamenes = (Convert.ToDecimal(vectorAlumnado[7]) + Convert.ToDecimal(vectorAlumnado[8])) / 2 * 0.5m;

                        total = Math.Truncate(notaEjercicios + notaIntervenciones + notaExamenes);

                        if (contador % 2 == 1) sWrite.WriteLine(vectorAlumnado[0] + "; " + total);

                        contador++;

                        sWrite.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                sRead.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        else
        {
            Console.WriteLine("El fichero de entrada no existe.");
        }
    }
}