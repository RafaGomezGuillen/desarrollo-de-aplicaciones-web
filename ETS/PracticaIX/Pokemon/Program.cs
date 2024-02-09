namespace Pokemon
{
    class Program
    {
        private static void Main (string[] args)
        {
            int generation = Ficheros.PedirGeneracion();

            Console.WriteLine("El/Los pokemon de mayor ataque de la generación " + generation +
                            " es/son: " + Ficheros.strongestPokemon(Ficheros.FICHERO_ENTRADA, generation));

            Ficheros.filterPokemon(Ficheros.FICHERO_SALIDA);
        }
    }
}