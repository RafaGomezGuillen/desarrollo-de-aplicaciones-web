namespace Ejercicio02
{
    class Program
    {
        private static void Main (string[] args)
        {
            const string FICHERO = "fichero.txt";
            StreamReader sRead = null;
            string linea = "";
            int numeroLineas = Funciones.LeerNumeroLineas();
            int contLineas = 0;
            string[] vectorLineas = new string[0];

            if (File.Exists(FICHERO))
            {
                Console.WriteLine("El fichero existe.");
                try
                {
                    sRead = new StreamReader(FICHERO);

                    while (!sRead.EndOfStream)
                    {
                        linea = sRead.ReadLine();
                        Array.Resize(ref vectorLineas, vectorLineas.Length + 1);
                        vectorLineas[contLineas] = linea;
                        contLineas++;
                    }
                    sRead.Close();
                    Console.WriteLine("El fichero se a leido.");
                    Console.WriteLine("----------------------\n\n");
                    if (numeroLineas >= contLineas)
                    {
                        sRead = new StreamReader(FICHERO);
                        while (!sRead.EndOfStream)
                        {
                            linea = sRead.ReadLine();
                            Console.WriteLine(linea);
                        }
                        sRead.Close();
                    }
                    else
                    {
                        for (int i = contLineas - numeroLineas; i < vectorLineas.Length; i++)
                        {
                            Console.WriteLine(vectorLineas[i]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("El ficehro no existe.");
            }

            Console.Write("\n\nPulse una tecla para finalizar...");
            Console.ReadKey();
        }
    }
}
