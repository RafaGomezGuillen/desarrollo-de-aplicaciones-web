namespace Programa05
{
	class Juego
	{
		private string name;
		private Genero genero;
		private decimal price;
		/// <summary>
		/// Nombre del juego.
		/// </summary>
		public string Name
		{
			get => name;
			set
			{
				while (value.Trim().Length == 0 || value == null)
				{
					Console.Write("\nEl nombre del juego no puede ser nulo: ");
					value = Console.ReadLine();
				}
				name = value;
			}
		}
		/// <summary>
		/// Género del juego.
		/// </summary>
		public Genero Genero
		{
			get => genero;
			set { genero = value; }
		}
		/// <summary>
		/// Precio del juego.
		/// </summary>
		public decimal Price
		{
			get => price;
			set
			{
				while (value < 0)
				{
					Console.Write("\nEl precio del juego debe ser un número entero positivo: ");
					value = Convert.ToDecimal(Console.ReadLine());
				}
				price = value;
			}
		}
		/// <summary>
		/// Imprime todos los valores del objeto.
		/// </summary>
		/// <returns>
		/// Cadena de texto de los valores.
		/// </returns>
		public override string ToString () => $"Nombre: {Name}.\nGénero: {Genero.Name}.\nPrecio: {Price}.";
	}
}
