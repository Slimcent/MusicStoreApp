using Entities.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicStore.Web.Models
{
    public class AlbumViewModel
    {
        public Album Album { get; set; }
        public List<SelectListItem> AvailableGenres { get; set; } = new List<SelectListItem>()
        {
            new SelectListItem {Text="Pop", Value="Pop" },
            new SelectListItem {Text="Rock", Value="Rock" },
            new SelectListItem {Text="Classic", Value="Classic" }
        };
    }
}
