﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly18.Models
{
    public class Rented
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int MovieId { get; set; }
        public DateTime DateRented { get; set; }
        public DateTime? DateReturned { get; set; }
    }
}