using System;

namespace Entities.Models
{
    public class DeletedAlbum
    {
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }
}
