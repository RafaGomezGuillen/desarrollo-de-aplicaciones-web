using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GomezRafael_Musica.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es requerido")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Introduce un título entre 3 y 60 caracteres.")]
        [DisplayName("Título")]
        public string Title { get; set; }

        [Required(ErrorMessage = "La descripción es requerida")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Introduce una descripción entre 3 y 200 caracteres.")]
        [DisplayName("Descripción")]
        public string Description { get; set; }

        [Required(ErrorMessage = "La valoración es requerida")]
        [Range(1, 5, ErrorMessage = "Introduce una valoración entre 1 y 5.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "El número debe ser entero.")]
        [DisplayName("Valoración")]
        public int Value { get; set; }

        [Required(ErrorMessage = "El artista debe ser seleccionado")]
        [DisplayName("Id del artista")]
        public int ArtistId { get; set; }
    }
}
