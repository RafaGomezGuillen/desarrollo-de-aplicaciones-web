namespace Programa01
{
    class Cliente
    {
        private string Nombre {  get; set; }
        private string Apellidos { get; set; }
        private int Id { get; set; }
        public Cliente()
        {
            Nombre = "Nombre por defecto";
            Apellidos = "Apellidos por defecto";
            Id = 0;
        }
        public Cliente (string nombre, string apellidos, int id)
        {
            SetNombre(nombre);
            SetApellidos(apellidos);
            Id = id;
        }
        public void SetNombre (string nombre)
        {
            if (string.IsNullOrEmpty(nombre.Trim()))
            {
                Nombre = "Error";
            }
            else
            {
                Nombre = nombre;
            }
        }
        public void SetApellidos(string apellidos) 
        {
            if (string.IsNullOrEmpty(apellidos.Trim()))
            {
                Apellidos = "Error";
            }
            else
            {
                Apellidos = apellidos;
            }
        }
        public void SetId(int id) {  Id = id; }
        public string GetNombre() { return Nombre; }
        public string GetApellidos() {  return Apellidos; }
        public int GetId() { return Id; }
        public override string ToString () => $"[{Id}] Nombre: {Nombre}, apellidos: {Apellidos}";
    }
}
