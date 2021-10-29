using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Entities.Context
{
    public class MusicStoreDbContext : DbContext
    {
        public MusicStoreDbContext(DbContextOptions options) : base (options)
        {
                
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<DeletedAlbum> DeletedAlbums { get; set; }
    }
}
