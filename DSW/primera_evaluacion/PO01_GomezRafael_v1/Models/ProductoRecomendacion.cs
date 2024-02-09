namespace PO01_GomezRafael_v1.Models
{
    public class ProductoRecomendacion
    {
        public Producto producto { get; set; }

        public List<Recomendacion> recomendaciones { get; set;}
    }
}
