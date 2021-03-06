﻿using System.ComponentModel.DataAnnotations;

namespace HomeLibrary.Models
{
    public class CreateBookViewModel
    {
        [Required]
        public string Title { get; set; }
        public string AuthorFirstName { get; set; }
        [Required]
        public string AuthorLastName { get; set; }
        [Required]
        [Range(1800,2019)]
        public int Year { get; set; }
    }
}