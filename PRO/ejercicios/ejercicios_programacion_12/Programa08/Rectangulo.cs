namespace Programa08
{
    class Rectangulo:FigurasGeometricas
    {
        private decimal Ancho { get; set; }

        private decimal Largo { get; set; }

        public Rectangulo ()
        {
            Ancho = 1;
            Largo = 1;
        }

        public Rectangulo (decimal Ancho, decimal Largo)
        {
            SetAncho(Ancho);
            SetLargo(Largo);
        }

        public void SetAncho (decimal ancho)
        {
            if (ancho < 0)
            {
                ancho = 1;
            }
            else
            {
                Ancho = ancho;
            }
        }

        public void SetLargo (decimal largo)
        {
            if (largo < 0)
            {
                largo = 1;
            }
            else
            {
                Largo = largo;
            }
        }

        public decimal GetAncho () { return Ancho; }

        public decimal GetLargo () { return Largo; }

        public static decimal[] PedirMedidas ()
        {
            decimal[] medidas = new decimal[2];

            Console.Write("\nIntroduce el ancho: ");
            medidas[0] = Funciones.PedirNumeroDecimal();

            Console.Write("\nIntroduce el largo: ");
            medidas[1] = Funciones.PedirNumeroDecimal();

            return medidas;
        }

        public override string ToString ()
        {
            return $"Rectángulo.\n---------------\nAncho: {Ancho}.\nLargo: {Largo}.\n---------------";
        }

        public override decimal CalcularArea ()
        {
            return Ancho * Largo;
        }
    }
}
