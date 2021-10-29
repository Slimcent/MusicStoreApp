using Entities.Models;
using Interfaces;
using Interfaces.Repositories;
using Interfaces.Services;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.Web.Services
{
    public class DeleteAlbumService : IDeleteAlbumService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDeleteAlbumRepository _albumRepo;

        public DeleteAlbumService(IUnitOfWork unitOfWork, IDeleteAlbumRepository albumRepo)
        {
            _unitOfWork = unitOfWork;
            _albumRepo = albumRepo;
        }

        public async Task DeleteAlbum(DeletedAlbum album)
        {
            await _albumRepo.DeleteAlbumAsync(album);
            await _unitOfWork.CommitAsync();
        }

        public List<DeletedAlbum> GetAllAlbums()
        {
            return _albumRepo.GetAll().ToList();
        }
    }
}
