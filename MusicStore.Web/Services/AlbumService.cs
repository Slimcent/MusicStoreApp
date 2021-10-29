using Entities.Context;
using Entities.Models;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.Web.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAlbumRepository _albumRepo;
        private readonly MusicStoreDbContext _dbContext;

        public AlbumService(IUnitOfWork unitOfWork, IAlbumRepository albumRepo, MusicStoreDbContext dbContext)
        {
            _unitOfWork = unitOfWork;
            _albumRepo = albumRepo;
            _dbContext = dbContext;
        }

        public async Task<string> Add (Album album)
        {
           await _albumRepo.AddAsync(album);
           await _unitOfWork.CommitAsync();

            return "Add Sucessful";
        }

        public async Task<Album> GetAlbumByID(int Id)
        {
           return await _albumRepo.GetAsync(Id);
        }

        public string DeleteAlbum(int Id)
        {
            Album toDelete = (Album)_albumRepo.Find(a => a.Id == Id);
            int deletedItems = 0;
            try
            {
                if (toDelete != null)
                {
                    _albumRepo.Delete(toDelete);
                    deletedItems = _unitOfWork.Commit();
                    if (deletedItems > 0)
                        return string.Format(Resource.SuccessDeleteMessage, toDelete.Id);
                    return Resource.FailDeleteMessage;
                }
            }
            catch (DbException ex)
            {

                return Resource.RepositoryExceptionMessage;
            }
            catch (Exception ex)
            {
                return Resource.InternalServerError;
            }
            return "";
        }

        public string DeleteAlbum(Album album)
        {
            return DeleteAlbum(album.Id);
        }

        public async Task<Album> UpdateAlbum(Album album)
        {
            _albumRepo.Update(album);
            var changes = await _unitOfWork.CommitAsync();
            if (changes > 0)
                return album;
            else
                return null;
        }

        
        public IEnumerable<Album> GetAllAlbums()
        {
            return _albumRepo.GetAll().AsEnumerable();
        }

        public async Task<bool> IsDuplcate(string title)
        {
           var duplicate =  await  _dbContext.Albums.FirstOrDefaultAsync((album) => album.Title == title);
            if (duplicate != null)
                return true;

            return false;
            
        }
    }
}
