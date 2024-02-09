namespace Programa08
{
    class Circulo:FigurasGeometricas
    {
        private decimal Radio { get; set; }

        public Circulo ()
        {
            Radio = 1;
        }

        public Circulo (decimal radio)
        {
            SetRadio(radio);
        }

        public void SetRadio (decimal radio)
        {
            if (radio < 0)
            {
                radio = 1;
            }
            else
            {
                Radio = radio;
            }
        }

        public decimal GetRadio () { return Radio; }

        public static decimal PedirMedidas ()
        {
            decimal medida;
            Console.Write("\nIntroduce el radio: ");
            medida = Funciones.PedirNumeroDecimal();
            return medida;
        }

        public override string ToString ()
        {
            return $"Círculo.\n---------------\nRadio: {Radio}.\n---------------";
        }

        public override decimal CalcularArea ()
        {
            return Convert.ToDecimal(Math.PI) * Radio * Radio;
        }
    }
}
