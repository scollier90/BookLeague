using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLeague.Data
{
    public class Theme
    {
        [Key]
        public int ThemeId { get; set; }
        [Required]
        public string ThemeName { get; set; }
    }
}
