using Entities.Models;
using Interfaces;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Web.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicStore.Web.Controllers
{
    public class MusicStoreController : Controller
    {
        private readonly IAlbumService _albumService;
        private readonly IDeleteAlbumService _deleteAlbumService;
        public MusicStoreController(IAlbumService albumService, IDeleteAlbumService deleteAlbumService)
        {
            _albumService = albumService;
            _deleteAlbumService = deleteAlbumService;
        }
        public IActionResult Index()
        {
            IEnumerable<Album> allAlbums = _albumService.GetAllAlbums();
            return View(allAlbums);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var albumView = new AlbumViewModel();
            return View(albumView);  
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task <IActionResult> Create(AlbumViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _albumService.Add(model.Album);
                    //return RedirectToAction("Index");
                    return Json(new { success = true });
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            //return View(model);
            return Json(new { success = false });
        }

        [HttpGet]
        public async Task <IActionResult> Edit (int Id)
        {
            var album = await _albumService.GetAlbumByID(Id);
            var model = new AlbumViewModel() { Album = album };
            return View("Edit", model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (AlbumViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
               await _albumService.UpdateAlbum(viewModel.Album);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AlbumDelete(int Id)
        {
            var album = await _albumService.GetAlbumByID(Id);
            var model = new DeleteAlbumViewModel { AlbumViewModel = new AlbumViewModel {Album = album } };
            var albumToDelete = new DeletedAlbum
            {
                AlbumId = album.Id,
                Title = model.AlbumViewModel.Album.Title,
                Price = model.AlbumViewModel.Album.Price,
                Genre = model.AlbumViewModel.Album.Genre,
                ReleaseDate = model.AlbumViewModel.Album.ReleaseDate
            };
            await _deleteAlbumService.DeleteAlbum(albumToDelete);
            //await _albumService.DeleteAlbum();
            return View("SoftDelete", model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int AlbumId)
        {            
            await _albumService.Delete(AlbumId);
            return View();
        }

        //[HttpPost, ValidateAntiForgeryToken]
        //public async Task<IActionResult> AlbumDelete(DeletedAlbum model)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            await _deleteAlbumService.DeleteAlbum(new DeletedAlbum {Album = model.Album } );

        //            return RedirectToAction("Index");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ModelState.AddModelError("", ex.Message);
        //    }
        //    return View(model);
        //}

    }
}
