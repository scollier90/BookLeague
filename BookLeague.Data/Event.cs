using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLeague.Data
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        [Required]
        public string EventName { get; set; }

        [Required]
        [ForeignKey(nameof(Group))]
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }

        [Required]
        [ForeignKey(nameof(Book))]
        public int BookId { get; set; }
        public virtual Book Book { get; set; }

        public DateTime ScheduledDate { get; set; }
    }
}
