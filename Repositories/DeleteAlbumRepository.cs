using Entities.Models;
using Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class DeleteAlbumRepository : Repository<DeletedAlbum>, IDeleteAlbumRepository
    {
        public DeleteAlbumRepository(DbContext context) : base(context)
        {
        }
    }
}
