using System.ComponentModel.DataAnnotations;

namespace AUT03_04_Rafa_Gomez.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "Introduce un título entre 5 y 15 caracteres.")]
        public string Title { get; set; }

        [Required]
        public int GenreId { get; set; }

        public Genre? Genre { get; set; }
    }

    public class GameDTO
    {
        [Required]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "Introduce un título entre 5 y 15 caracteres.")]
        public string Title { get; set; }

        [Required]
        public int GenreId { get; set; }
    }
}
