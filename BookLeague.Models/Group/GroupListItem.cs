using BookLeague.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLeague.Models.Group
{
    public class GroupListItem
    {
        public int GroupId { get; set; }
        [Display(Name = "Group Name")]
        public string GroupName { get; set; }
        public ICollection<ApplicationUser> Users { get; set; }
    }
}
