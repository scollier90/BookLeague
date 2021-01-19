using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLeague.Data
{
    public class Group
    {
        [Key]
        public int GroupId { get; set; }
        [Required]
        public string GroupName { get; set; }
        public Guid CreatorId { get; set; }

        [Required]
        [ForeignKey(nameof(ApplicationUser))]
        public string Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public ICollection<ApplicationUser> Users { get; set; }
    }
}
