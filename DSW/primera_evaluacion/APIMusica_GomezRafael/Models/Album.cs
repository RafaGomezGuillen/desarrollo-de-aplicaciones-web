using System.ComponentModel.DataAnnotations;

namespace APIMusica_GomezRafael.Models
{
    public partial class Album
    {
        public Album()
        {
            Tracks = new HashSet<Track>();
        }

        [Required]
        public int AlbumId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Introduce un título entre 3 y 100 caracteres.")]
        public string Title { get; set; } = null!;

        [Required]
        public int ArtistId { get; set; }

        public virtual Artist? Artist { get; set; }
        public virtual ICollection<Track> Tracks { get; set; }
    }
    public partial class AlbumDTO
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Introduce un título entre 3 y 100 caracteres.")]
        public string Title { get; set; } = null!;

        [Required]
        public int ArtistId { get; set; }
    }
}
