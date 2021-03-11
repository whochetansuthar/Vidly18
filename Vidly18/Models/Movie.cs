using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly18.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        public byte NumberInStock { get; set; }

        public byte AvailableStock { get; set; }

        [Required]
        [Display(Name ="Genre")]
        public byte GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}