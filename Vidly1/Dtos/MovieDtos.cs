﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly1.Dtos
{
    public class MovieDtos
    {

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        

        
        [Required]
        public byte GenreId { get; set; }

        

        
        [Required]
        public DateTime ReleaseDate { get; set; }

      
        [Range(1, 20)]
        public byte NumberInStock { get; set; }
    }
}