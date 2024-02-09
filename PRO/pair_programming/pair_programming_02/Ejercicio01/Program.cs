class Program
{
    private static void Main (string[] args)
    {
        const string FICHERO_1 = "1.txt";
        const string FICHERO_2 = "2.txt";
        const string FICHERO_3 = "diferencias.txt";
        StreamReader sRead1 = null;
        StreamReader sRead2 = null;
        StreamWriter sWrite1 = null;
        string leerLinea1 = "";
        string leerLinea2 = "";

        if (File.Exists(FICHERO_1) && File.Exists(FICHERO_2))
        {
            Console.WriteLine("Los ficheros existen.");
            try
            {
                sRead1 = new StreamReader(FICHERO_1);
                sRead2 = new StreamReader(FICHERO_2);
                sWrite1 = new StreamWriter(FICHERO_3);
                int contDistinto = 1, contIguales = 0;

                while (!sRead1.EndOfStream || !sRead2.EndOfStream)
                {
                    leerLinea1 = sRead1.ReadLine();
                    leerLinea2 = sRead2.ReadLine();

                    if (leerLinea1 != leerLinea2)
                    {
                        sWrite1.WriteLine(contDistinto + ";" + leerLinea1 + ";" + leerLinea2);
                    }
                    else
                    {
                        contIguales++;
                    }
                    contDistinto++;
                }
                sRead1.Close();
                sRead2.Close();
                sWrite1.Close();

                Console.WriteLine("Los ficheros se han leido correctamete :-)");
                Console.WriteLine("El numero de lineas iguales son " + contIguales);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        else
        {
            Console.WriteLine("Los ficheros no existen.");
        }

        Console.Write("Pulse una tecla para finalizar...");
        Console.ReadKey();
    }
}