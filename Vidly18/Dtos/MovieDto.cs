using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly18.Dtos
{
    public class MovieDto
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
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }
        public GenreDto Genre { get; set; }
    }
}