using System.ComponentModel;

namespace GomezRafael_Musica.Models
{
    public partial class Track
    {
        public int TrackId { get; set; }
        [DisplayName("Canción")]
        public string Name { get; set; } = null!;
        public int? AlbumId { get; set; }
        public int MediaTypeId { get; set; }
        public int? GenreId { get; set; }
        public string? Composer { get; set; }
        public int Milliseconds { get; set; }
        public int? Bytes { get; set; }
        public decimal UnitPrice { get; set; }

        public virtual Album? Album { get; set; }
    }
}
