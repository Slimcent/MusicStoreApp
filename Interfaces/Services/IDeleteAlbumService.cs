using Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IDeleteAlbumService
    {
        Task DeleteAlbum(DeletedAlbum album);
        List<DeletedAlbum> GetAllAlbums();
    }
}
