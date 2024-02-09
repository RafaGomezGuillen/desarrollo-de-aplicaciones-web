namespace Programa05
{
	class Program
	{
		static void Main (string[] args)
		{
			int opcion;
			bool noError = true;
			do
			{
				Menu.VerMenu();
				opcion = Menu.LeerOpcion();
				Console.Write("\n");
				switch (opcion)
				{
					case 1: Console.Clear(); Funciones.AñadirJuego(); break;
					case 2: Console.Clear(); Funciones.MostrarJuegos(); break;
					case 3: Console.Clear(); Funciones.EliminarJuego(); break;
					case 4: Console.Clear(); noError = false; break;
				}
			} while (noError);
			Menu.Adios();
		}
	}
}