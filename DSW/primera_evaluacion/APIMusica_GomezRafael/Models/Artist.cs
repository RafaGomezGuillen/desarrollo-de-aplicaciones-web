using System.ComponentModel.DataAnnotations;

namespace APIMusica_GomezRafael.Models
{
    public partial class Artist
    {
        public Artist ()
        {
            Albums = new HashSet<Album>();
        }

        [Required]
        public int ArtistId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Introduce un nombre entre 3 y 100 caracteres.")]
        public string? Name { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }

    public partial class ArtistDTO
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Introduce un nombre entre 3 y 100 caracteres.")]
        public string? Name { get; set; }
    }
}
