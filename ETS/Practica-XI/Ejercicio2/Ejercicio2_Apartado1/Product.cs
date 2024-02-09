using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaExpendedora
{
    internal class Product
    {
        //Atributos
        private string Name { get; set; }
        private decimal Price { get; set; }

        //Constructores
        public Product() { }

        public Product(string name, decimal price)
        {
            this.Name = name;
            SetPrice(price);
        }

        //Métodos pripios de la clase
        public static string PedirNombre()
        {
            string name = "";
            Console.WriteLine("Introduce el nombre del producto");
            name = Console.ReadLine();
            while (String.IsNullOrEmpty(name))
            {
                Console.WriteLine("El nombre no puede ser nulo o vacío.");
                name = Console.ReadLine();
            }
            return name;
        }

        public static decimal PedirPrecio()
        {
            decimal price = 0;

            Console.WriteLine("Introduce el precio del producto");
            while(!decimal.TryParse(Console.ReadLine(), out price) || price<0)
                Console.WriteLine("El precio ha de ser un número positivo");
            return price;
        }

        //Método ToString
        public override string ToString()
        {
            string cadena = "";

            cadena += $"Nombre: {Name} y Precio: {Price}";

            return cadena;
        }

        //Getters y Setters
        public void SetName(string name)
        {
            this.Name = name;
        }

        public string GetName()
        {
            return this.Name;
        }

        public void SetPrice(decimal price)
        {
            if(price >= 0) this.Price = price; 
            else price = 0;
        }

        public decimal GetPrice()
        {
            return this.Price;
        }
    }
}
