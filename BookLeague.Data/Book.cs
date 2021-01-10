using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLeague.Data
{
    public enum _Genre
    {
        Adventure,
        Biography,
        Comedy,
        Drama,
        Fantasy,
        GraphicNovel,
        Historical,
        Horror,
        Mystery,
        Poetry,
        ScienceFiction,
        TrueCrime
    };
    
    //seed Theme examples
    //{
    //    GoodVsEvil,
    //    Love,
    //    Redemption,
    //    CourageAndHeroism,
    //    Perserverance,
    //    ComingOfAge,
    //    Revenge,
    //    Friendship,
    //    Death,
    //    Nature,
    //    Regret,
    //    PowerAndCorruption,
    //    Survival,
    //    Prejudice,
    //    IndividualVsSociety,
    //    War
    //}

    public class Book
    {
        [Key]
        public int BookId { get; set; }

        public Guid CreatorId { get; set; }

        [Required]
        public string BookName { get; set; }

        [Required]
        public _Genre Genre { get; set; }

        [Required]
        public int Rating { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int PageCount { get; set; }

        public string Description { get; set; }

        [Required]
        public ICollection<Theme> Themes { get; set; }
    }
}
