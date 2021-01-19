using BookLeague.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLeague.Models.Group
{
    public class GroupDetail
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public ICollection<ApplicationUser> Users { get; set; }

    }
}
