using BookLeague.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLeague.Models.Book
{
    public class BookEdit
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public _Genre Genre { get; set; }
        public int Rating { get; set; }
        public decimal Price { get; set; }
        public int PageCount { get; set; }
        public string Description { get; set; }
    }
}
