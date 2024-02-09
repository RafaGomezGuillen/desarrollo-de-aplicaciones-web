class Program
{
    private static void Main (string[] args)
    {
        const string FICHERO_ENTRADA = "paro.csv";
        const string FICHERO_SALIDA = "SALIDA.txt";
        StreamReader sRead = null;
        StreamWriter sWriter = null;
        string[] vectorDatos = new string[0];
        string[] meses = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
        int[] años = { 2008, 2009, 2010, 2011, 2012, 2013, 2014, 2015, 2016, 2017, 2018 };
        string leerLineas = "";
        int cont = 1, index = 6, index2 = 126;

        if (File.Exists(FICHERO_ENTRADA))
        {
            Console.WriteLine(FICHERO_ENTRADA + " existe.");
            try
            {
                sRead = new StreamReader(FICHERO_ENTRADA);

                while (!sRead.EndOfStream)
                {
                    leerLineas = sRead.ReadLine();

                    if (cont != 1)
                    {
                        Array.Resize(ref vectorDatos, (vectorDatos.Length + 1));

                        vectorDatos = leerLineas.Split(',');
                        sWriter = new StreamWriter(FICHERO_SALIDA, true);

                        if (cont == 2) sWriter.WriteLine("AÑO\tMES\tMUNICIPIO\tDATO");

                        for (int i = 0; i < años.Length - 1; i++)
                        {
                            for (int j = 0; j < meses.Length; j++)
                            {
                                sWriter.WriteLine(años[i] + ";" + meses[j] + ";" + vectorDatos[5] + ";" + vectorDatos[index]);
                                index = (index < 125) ? ++index : 6;
                            }
                        }
                        for (int i = años.Length - 1; i < años.Length; i++)
                        {
                            for (int j = 0; j < 6; j++)
                            {
                                sWriter.WriteLine(años[i] + ";" + meses[j] + ";" + vectorDatos[5] + ";" + vectorDatos[index2]);
                                index2 = (index2 < 132) ? ++index2 : 126;
                            }
                        }
                        sWriter.Close();
                    }
                    cont++;
                }
                sRead.Close();
                Console.WriteLine("Traspaso de datos exitoso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }
        else
        {
            Console.WriteLine("El fichero de entrado no existe.");
        }

        Console.Write("\n\nPulse una tecla para finalizar...");
        Console.ReadKey();
    }
}