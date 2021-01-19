using BookLeague.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLeague.Models.Group
{
    public class GroupCreate
    {
        [Required]
        [Display(Name = "Group Name")]
        [MinLength(2, ErrorMessage = "Please enter a longer group name.")]
        [MaxLength(50, ErrorMessage = "The group name needs to be shorter.")]
        public string GroupName { get; set; }
        public ICollection<ApplicationUser> Users { get; set; }
    }
}
