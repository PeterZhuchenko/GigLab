﻿using System;
using System.ComponentModel.DataAnnotations;

namespace GitLab.Models.GitModels
{
    public class Gig
    {
        public int Id { get; set; }

        public ApplicationUser Artist { get; set; }

        [Required]
        public string ArtistId { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Venue { get; set; }

        [Required]
        public byte GenreId { get; set; }

        public Genre Genre { get; set; }
    }
}