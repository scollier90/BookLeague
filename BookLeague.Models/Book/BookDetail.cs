using BookLeague.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLeague.Models.Book
{
    public class BookDetail
    {
        public int BookId { get; set; }
        [Display(Name = "Title")]
        public string BookName { get; set; }
        public _Genre Genre { get; set; }
        public int Rating { get; set; }
        public decimal Price { get; set; }
        [Display(Name = "Page Count")]
        public int PageCount { get; set; }
        public string Description { get; set; }

        //public ICollection<Theme> Themes { get; set; } -- future development
    }
}
