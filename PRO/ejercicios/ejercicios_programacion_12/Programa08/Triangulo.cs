namespace Programa08
{
    class Triangulo:FigurasGeometricas
    {
        private decimal Base { get; set; }

        private decimal Altura { get; set; }

        public Triangulo ()
        {
            Base = 1;
            Altura = 1;
        }

        public Triangulo (decimal miBase, decimal altura)
        {
            SetBase(miBase);
            SetAltura(altura);
        }

        public void SetBase (decimal miBase)
        {
            if (miBase < 0)
            {
                miBase = 1;
            }
            else
            {
                Base = miBase;
            }
        }

        public void SetAltura (decimal altura)
        {
            if (altura < 0)
            {
                altura = 1;
            }
            else
            {
                Altura = altura;
            }
        }

        public decimal GetBase () { return Base; }

        public decimal GetAltura () { return Altura; }

        public static decimal[] PedirMedidas ()
        {
            decimal[] medidas = new decimal[2];

            Console.Write("\nIntroduce la base: ");
            medidas[0] = Funciones.PedirNumeroDecimal();

            Console.Write("\nIntroduce la altura: ");
            medidas[1] = Funciones.PedirNumeroDecimal();

            return medidas;
        }

        public override string ToString ()
        {
            return $"Triángulo.\n---------------\nBase: {Base}.\nAltura: {Altura}.\n---------------";
        }

        public override decimal CalcularArea ()
        {
            return (Base * Altura) / 2;
        }
    }
}
