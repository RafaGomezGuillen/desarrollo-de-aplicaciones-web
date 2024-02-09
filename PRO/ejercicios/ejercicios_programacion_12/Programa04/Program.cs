namespace Programa04
{
    class Program
    {
        private static void Main (string[] args)
        {
            int numeroProductos = Funciones.NumeroProductos();
            Funciones.IntroducirDatos(numeroProductos);
            Funciones.MostrarDatosFinales();
        }
    }
}