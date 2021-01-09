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
        public int BookId { get; set; }
        [Display(Name = "Title")]
        public string BookName { get; set; }
        public int Rating { get; set; }
    }
}
