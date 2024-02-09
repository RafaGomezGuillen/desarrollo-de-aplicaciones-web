using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaExpendedora
{
    internal class Machine
    {
        //Atributos
        private int MaxLines { get; set; }
        private int MaxStock { get; set; }
        private List<Line> Lines { get; set; }
        private string Name { get; set; }

        //Constructores
        public Machine() { 
            Lines = new List<Line>();
        }
        public Machine(string name, int maxLines, int maxStock)
        {
            this.Lines = new List<Line>();
            this.Name = name;
            this.MaxLines = maxLines;
            this.MaxStock = maxStock;
        }

        //Métodos pripios de la clase
        public bool IsFull()
        {
            bool isFull = false;
            if(this.Lines.Count >= this.MaxLines)
                isFull = true;
            return isFull;
        }
        public void IncludeLine(Product product)
        {
            Line line = new Line(product, MaxStock);
            this.Lines.Add(line);
        }

        public Line RemoveLine(int linePos) { 
        
            Line line = this.Lines[linePos];
            this.Lines.RemoveAt(linePos);

            return line;
        }

        public static decimal PedirDinero()
        {
            decimal dinero = 0;

            Console.WriteLine("Introduce el dinero");
            while (!decimal.TryParse(Console.ReadLine(), out dinero) || dinero<0)
                Console.WriteLine("El dinero ha de ser un número positivo");
            return dinero;
        }

        public List<Line> LineasComprables(decimal dinero)
        {
            List<Line> linesAux = Lines.FindAll(line => line.GetProduct().GetPrice() <= dinero && line.GetStock() > 0);
            return linesAux;
        }

        public decimal VenderProducto(decimal dinero, int linealPos)
        {
            this.Lines[linealPos].ReduceStock();

            return dinero - this.Lines[linealPos].GetProduct().GetPrice();
        }

        public void FillAllLines()
        {
            this.Lines.ForEach(line => line.SetStock(this.MaxStock));
        }

        //Método ToString
        public override string ToString()
        {
            string cadena = "";
            int cont = 1;

            cadena += "Esta es la máquina" + this.Name+"\n";
            cadena += $"El máximo de líneas es {this.MaxLines}\n";
            cadena += $"El stock máximo por línea es {this.MaxStock}\n";
            cadena += $"El contenido actual de la máquina es el siguiente: \n";

            this.Lines.ForEach(line => cadena += $"Linea {cont++}: {line} \n");

            return cadena;
        }

        //Getters y Setters
        public string GetName() { return Name; }

        public List<Line> GetLines() { return Lines; }
    }
}
