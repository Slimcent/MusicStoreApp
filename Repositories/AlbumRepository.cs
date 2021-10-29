using Entities.Context;
using Entities.Models;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class AlbumRepository : Repository<Album>, IAlbumRepository
    {
        public AlbumRepository(DbContext context) : base (context)
        {
                
        }
    }
}
