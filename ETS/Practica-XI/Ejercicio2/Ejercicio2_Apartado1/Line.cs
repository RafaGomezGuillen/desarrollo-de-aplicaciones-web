using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaExpendedora
{
    internal class Line
    {
        //Atributos
        private Product Product { get; set; }
        private int Stock { get; set; }

        //Constructores
        public Line() { }

        public Line(Product product, int stock)
        {
            this.Product = product;
            this.Stock = stock;
        }

        //Métodos pripios de la clase
        public void ReduceStock()
        {
            this.Stock--;
        }

        //Método ToString
        public override string ToString()
        {
            return $"{Product} -- Stock: {Stock}";
        }

        //getters y setters
        public Product GetProduct()
        {
            return Product;
        }

        public int GetStock()
        {
            return this.Stock;
        }

        public void SetStock(int stock)
        {
            this.Stock = stock;
        }
    }
}
