using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace certificacaoaspnet.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public String Name { get; set; }

        [Display(Name = "Genre")]
        public Genres Genre { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte GenreId { get; set; }

        [Display(Name ="Release Date")]
        [Required]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Date Added")]
        [Required]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Number in Stock")]
        [Required]
        [Range(1,20)]
        public int NumberInStock { get; set; }
    }
}