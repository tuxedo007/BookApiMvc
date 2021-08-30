using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace BookApi.Models
{
    // GF: see GolfApp for TestConsole example
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //[Required]
        //[StringLength(10, MinimumLength = 3, ErrorMessage = "ISBN must be between 3 and 10 characters")]
        public string Isbn { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "Title cannot be more than 200 characters")]
        public string Title { get; set; }

        public DateTime? DatePublished { get; set; }

        [Required]
        [DefaultValue(true)]
        public bool Available { get; set; }

        //[Required]
        //[Range(1, 10, ErrorMessage = "Value must be between 0.0 to 10.0")]
        //[DefaultValue(0.0)]
        [Column(TypeName = "decimal(5,1)")]
        public decimal AverageRating { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
        // ran out of time
        public virtual ICollection<BookAuthor> BookAuthors { get; set; }
        public virtual ICollection<BookCategory> BookCategories { get; set; }
    }
}
