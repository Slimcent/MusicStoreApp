using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IAlbumService
    {
        Task<string> Add(Album album);
        Task<Album> GetAlbumByID(int Id);
        IEnumerable<Album> GetAllAlbums();
        Task<Album> UpdateAlbum(Album album);
        Task<string> DeleteAlbum(int Id);
        Task<string> DeleteAlbum(Album album);
        Task Delete(int id);
        Task<bool> IsDuplcate(string Title);
    }
}
