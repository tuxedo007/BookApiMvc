﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookApi.Models
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "Rating must be between 1 ad 10 stars")]
        public int Rating { get; set; }

        [StringLength(200, MinimumLength = 0, ErrorMessage = "Headline cannot be more than 200 characters")]
        public string Headline { get; set; }

        [StringLength(2000, MinimumLength = 0, ErrorMessage = "Review cannot be more than 2000 characters")]
        public string ReviewText { get; set; }

        //[Required]
        //[StringLength(200, MinimumLength = 10, ErrorMessage = "Headline needs to be between 10 and 200 characters")]
        //public string Headline { get; set; }

        //[Required]
        //[StringLength(2000, MinimumLength = 50, ErrorMessage = "Review needs to be between 50 and 2000 characters")]
        //public string ReviewText { get; set; }

        //public virtual Reviewer Reviewer { get; set; }
        public virtual Book Book { get; set; }
    }
}
