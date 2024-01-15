namespace TrackerX.Core.Services.Albums.Models
{
    public class CreateAlbumModel
    {
        public string AlbumName { get; set; }

        public int WritingYear { get; set; }

        public int GenreId { get; set; }

        public int BandId { get; set; }
    }
}
