using Entities.Models;
using Interfaces;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MusicStore.Web.Controllers
{
    public class ExternalMusicController : Controller
    {
        private readonly IAlbumService _albumService;
        private readonly IDeleteAlbumService _deleteAlbumService;
        //private readonly IHttpClientFactory _httpClientFactory;

        public IHttpClientFactory HttpClientFactory { get; }
        public ExternalMusicController(IAlbumService albumService, IDeleteAlbumService deleteAlbumService, IHttpClientFactory httpClientFactory)
        {
            _albumService = albumService;
            _deleteAlbumService = deleteAlbumService;
            HttpClientFactory = httpClientFactory;
            //_httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = HttpClientFactory.CreateClient();       
            var result = await client.GetStringAsync("https://jsonplaceholder.typicode.com/albums");
            var deserialized = JsonConvert.DeserializeObject<List<ApiModel>>(result);

            foreach (var album in deserialized)
            {
                if (await _albumService.IsDuplcate(album.Title))
                {
                    album.IsDuplcate = true;
                    //ModelState.AddModelError("", "Album already exist");
                }
            }

            return View(deserialized);
        }

        public IActionResult External()
        {
            List<DeletedAlbum> allAlbums = _deleteAlbumService.GetAllAlbums();
            return View(allAlbums);
        }

        [HttpPost]
        public async Task <IActionResult> AjaxTest(string title, decimal price, string genre)
        {
            var album = new Album
            {
                Title = title, Genre = genre, Price = price, ReleaseDate = DateTime.Now
            };

            var result = await _albumService.Add(album);
            return View(result);
        }
    }
}
