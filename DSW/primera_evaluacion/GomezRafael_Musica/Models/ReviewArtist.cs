namespace GomezRafael_Musica.Models
{
    public class ReviewArtist
    {
        public Artist artist { get; set; }
        public List<Review> reviewList { get; set; }
    }
}
