using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Dtos
{
    public class BookRatingDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Rating { get; set; }
    }
}
