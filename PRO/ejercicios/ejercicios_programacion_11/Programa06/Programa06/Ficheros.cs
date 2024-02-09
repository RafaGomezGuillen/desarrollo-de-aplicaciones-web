namespace Programa06
{
    class Ficheros
    {
        const string FICHERO_ENTRADA = "Turismo.csv";
        static List<string> lineas = new List<string>();
        static List<string> paises = new List<string>();
        static List<int> años = new List<int>();

        public static bool ExisteFichero ()
        {
            if (File.Exists(FICHERO_ENTRADA))
            {
                return true;
            }
            else
            {
                Console.WriteLine(FICHERO_ENTRADA + " no existe.");
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
                Console.WriteLine("\nERROR: " + ex.Message);
                return false;
            }
        }
        private static void MostrarPaises()
        {
            int line = 1;
            for (int i = 1; i < 21; i++) paises.Add(lineas[i].Split(';')[2]);

            Console.WriteLine("Elige el país o agrupación a selecionar: \n");
            foreach (string pais in paises)
            {
                Console.WriteLine(line + " . " + pais);
                line++;
            }
            Console.Write("\nElige una opción: ");
        }
        public static int ObtenerPais ()
        {
            MostrarPaises();
            int LONGITUD = paises.Count;
            int opcionPais = 0;
            while (!int.TryParse(Console.ReadLine(), out opcionPais) || (opcionPais < 1) || (opcionPais > LONGITUD))
            {
                Console.Write("\nError. Opción debe ser un número entre 1 y 20: ");
            }
            return opcionPais;
        }
        private static void MostrarAños ()
        {
            int line = 1;
            for (int i = 1; i < lineas.Count; i+= 273) años.Add(Convert.ToInt32(lineas[i].Split(';')[0]));

            Console.WriteLine("Elige el año a selecionar: \n");
            foreach (int año in años)
            {
                Console.WriteLine(line + " . " + año);
                line++;
            }
            Console.Write("\nElige una opción: ");
        }
        public static int ObtenerAño ()
        {
            MostrarAños();
            int LONGITUD = años.Count;
            int opcionAño = 0;
            while (!int.TryParse(Console.ReadLine(), out opcionAño) || (opcionAño < 1) || (opcionAño > LONGITUD))
            {
                Console.Write("\nError. Opción debe ser un número entre 1 y 9: ");
            }
            return opcionAño;
        }
        public static void MostrarDatos (int opcionPais, int opcionAño)
        {
            string[] meses = { "\tMes: Enero", "\tMes: Febrero", "\tMes: Marzo", "\tMes: Abril", "\tMes: Mayo", 
                               "\tMes: Junio", "\tMes: Julio", "\tMes: Agosto","\tMes: Septiembre","\tMes: Octubre",
                               "\tMes: Noviembre", "\tMes: Diciembre", };
            string datoPais = paises[opcionPais - 1], datoAño = Convert.ToString(años[opcionAño - 1]);
            Console.WriteLine("\tPAIS: " + datoPais);
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("\tAÑO: " + datoAño);
            Console.WriteLine("----------------------------------------------------------------------------------");

            for (int i = 0; i < lineas.Count; i++)
            {
                string[] datos = lineas[i].Split(';');
                if (datos[2] == datoPais && datos[0] == datoAño && datos[1] != "13")
                {
                    Console.WriteLine(meses[Convert.ToInt32(datos[1]) - 1] + "\t4 estrellas: \t"+ datos[6] + "\t5 estrellas: \t" + datos[7] 
                                     + "\tSUMA: \t" + (Convert.ToInt32(datos[6]) + Convert.ToInt32(datos[7])));
                    Console.WriteLine("----------------------------------------------------------------------------------");
                }
            }
        }
    }
}
