using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLeague.Data;

namespace BookLeague.Models
{
    public class BookCreate
    {
        [Required]
        [Display(Name = "Title")]
        [MinLength(1, ErrorMessage = "Please enter a longer title.")]
        [MaxLength(200, ErrorMessage = "The title needs to be shorter")]
        public string BookName { get; set; }

        [Required]
        public _Genre Genre { get; set; }

        [Required]
        public int Rating { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Page Count")]
        public int PageCount { get; set; }

        [MinLength(50, ErrorMessage = "Please enter more detail for the description.")]
        [MaxLength(1000, ErrorMessage = "Please summarize the description more.")]
        public string Description { get; set; }

        //public ICollection<Theme> Themes { get; set; }
    }
}
