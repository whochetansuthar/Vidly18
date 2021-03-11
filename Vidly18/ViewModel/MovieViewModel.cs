using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly18.Models;

namespace Vidly18.ViewModel
{
    public class MovieViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}