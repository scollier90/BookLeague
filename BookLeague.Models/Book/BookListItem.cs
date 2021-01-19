using BookLeague.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLeague.Models
{
    public class BookListItem
    {
        [UIHint("Hidden")]
        public int BookId { get; set; }
        [Display(Name = "Creator")]
        public Guid CreatorId { get; set; }
        [Display(Name = "Title")]
        public string BookName { get; set; }
        public _Genre Genre { get; set; }
        public int Rating { get; set; }
        public decimal Price { get; set; }
        [Display(Name = "Page count")]
        public int PageCount { get; set; }
    }
}
