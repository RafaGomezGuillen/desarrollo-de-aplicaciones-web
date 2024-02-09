namespace Programa05
{
	class Genero
	{
		public static List<Genero> listaGeneros = new()
		{
			new Genero("Aventuras") ,
			new Genero("Plataformas"),
			new Genero("RPG"),
			new Genero("Shooter"),
			new Genero("Mundo abierto")
		};
		private string name;
		/// <summary>
		/// Géneros disponibles.
		/// </summary>
		public string Name
		{
			get => name;
			set
			{
				while (value.Trim().Length == 0 || value == null)
				{
					Console.Write("\nEl nombre del género no puede ser nulo: ");
					value = Console.ReadLine();
				}
				name = value;
			}
		}
		Genero (string name) { this.name = name; }
	}
}
