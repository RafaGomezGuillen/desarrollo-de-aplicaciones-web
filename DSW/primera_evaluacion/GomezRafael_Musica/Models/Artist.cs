using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GomezRafael_Musica.Models
{
    public partial class Artist
    {
        public Artist ()
        {
            Albums = new HashSet<Album>();
        }

        [Key]
        [DisplayName("ID")]
        public int ArtistId { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Introduce un nombre entre 3 y 60 caracteres.")]
        [DisplayName("Nombre de artista")]
        public string? Name { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}
