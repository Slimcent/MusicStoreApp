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
        string DeleteAlbum(int Id);
        string DeleteAlbum(Album album);
        Task<bool> IsDuplcate(string Title);
    }
}
