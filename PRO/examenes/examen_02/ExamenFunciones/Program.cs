namespace ExamenFunciones
{
    public struct AlumnadoBono
    {
        public string nombre;
        public int copiasPagadas;
    }

    class Program
    {

        static void Main(string[] args)
        {
            // Primera fase
            Console.WriteLine("\n\tDebera ir introduciendo los nombres de cada alumno y " +
                "la cantidad de fotocopias disponibles con su bono." +
                "\n\tAl escribir 'FIN' se dara por finalizada la recogida de datos");
            AlumnadoBono[] alumnos = CSInscripcion.LeerDatos();
            CSInscripcion.LimpiarPantalla();
            // Segunda Fase
            CSTienda.Menu(alumnos);
        }
    }
}