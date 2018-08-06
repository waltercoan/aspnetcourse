﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace certificacaoaspnet.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        public String Name { get; set; }

        [Required]
        public byte GenreId { get; set; }

        public GenresDto Genre { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        [Range(1, 20)]
        public int NumberInStock { get; set; }
    }
}