using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GomezRafael_Musica.Models
{
    [Table("Album")]
    [Index("ArtistId", Name = "IFK_AlbumArtistId")]
    public partial class Album
    {
        public Album ()
        {
            Tracks = new HashSet<Track>();
        }

        [DisplayName("ID")]
        public int AlbumId { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Introduce un nombre entre 3 y 60 caracteres.")]
        [DisplayName("Álbum")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "El artista debe ser seleccionado")]
        [DisplayName("Artista")]
        public int ArtistId { get; set; }

        public virtual Artist? Artist { get; set; }
        public virtual ICollection<Track> Tracks { get; set; }
    }
}
