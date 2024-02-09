using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AUT02_02_GomezRafael_ModernFamily.Models
{
    public class Personaje
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Introduce un nombre entre 3 y 60 caracteres.")]
        [DisplayName("Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El nombre de la familia es requerido")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Introduce un nombre entre 3 y 60 caracteres.")]
        [DisplayName("Familia")]
        public string Family { get; set; }

        [Required(ErrorMessage = "El número de hijos es requerido")]
        [Range(0, int.MaxValue, ErrorMessage = "El número de hijos debe ser un número entero positivo.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "El número de hijos debe ser un número entero positivo.")]
        [DisplayName("Número de hijos")]
        public int NChildren { get; set; }
    }
}
