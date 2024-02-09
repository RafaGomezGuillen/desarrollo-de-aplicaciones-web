using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AUT03_04_Rafa_Gomez.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 2, ErrorMessage = "Introduce un género entre 2 y 12 caracteres.")]
        public string Name { get; set; }

        [ForeignKey("GenreId")]
        public List <Game> Games { get; set; }
    }

    public class GenreDTO
    {
        [Required]
        [StringLength(12, MinimumLength = 2, ErrorMessage = "Introduce un género entre 2 y 12 caracteres.")]
        public string Name { get; set; }
    }
}
