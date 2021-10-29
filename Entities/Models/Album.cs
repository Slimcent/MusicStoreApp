﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Album
    {
        public int Id { get; set; }

        [DataType(DataType.Date), Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
