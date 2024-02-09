namespace Programa05
{
	class Funciones
	{
		static List<Juego> listaJuego = new List<Juego>();
		private static void MostrarGeneros ()
		{
			Console.Clear();
			int i = 1;
			Console.WriteLine("Lista de géneros.");
			Genero.listaGeneros.ForEach(genero =>
			{
                Console.WriteLine($"-[{i}]\t{genero.Name}");
				i++;
            });
		}
		private static int PedirGenero ()
		{
			int numero;
			int size = Genero.listaGeneros.Count;
			MostrarGeneros();
			Console.Write($"\nIntroduce uno de los géneros (1 al {size}): ");
			while (!int.TryParse(Console.ReadLine(), out numero) || numero <= 0 || numero > size)
			{
				Console.Write($"\nERROR. Introduce un número del 1 al {size}: ");
			}
			return numero - 1;
		}
		public static void AñadirJuego ()
		{
			Juego Juego = new Juego();
			int indexGenero;

			Console.Write("\nIntroduce el nombre del juego: ");
			Juego.Name = Console.ReadLine();

			indexGenero = PedirGenero();
			Juego.Genero = Genero.listaGeneros.ElementAt(indexGenero);

            Console.Write("\nIntroduce el precio del juego: ");
			Juego.Price = Convert.ToDecimal(Console.ReadLine());

			listaJuego.Add(Juego);

			Menu.Adios();
		}
		public static void MostrarJuegos ()
		{
			listaJuego.ForEach(juego =>
			{
				Console.WriteLine($"--------------\n{juego}\n--------------");
			});
			Menu.Adios();
		}
		private static int PedirJuego ()
		{
			int numero;
			Console.Write($"\nIntroduce uno de los juegos (1 al {listaJuego.Count}): ");
			while (!int.TryParse(Console.ReadLine(), out numero) || numero <= 0 || numero > listaJuego.Count)
			{
				Console.Write($"\nERROR. Introduce un número del 1 al {listaJuego.Count}: ");
			}
			return numero - 1;
		}
		public static void EliminarJuego ()
		{
			int i = 1, indexJuego;

			listaJuego.ForEach(juego =>
			{
                Console.WriteLine($"--------------\n[{i}] {juego}\n--------------");
            });

			indexJuego = PedirJuego();
			listaJuego.RemoveAt(indexJuego);
			Menu.Adios();
		}
	}
}
