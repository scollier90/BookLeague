using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLeague.Models.Event
{
    public class EventListItem
    {
        [Display(Name = "Event Id")]
        public int EventId { get; set; }
        [Display(Name = "Event Name")]
        public string EventName { get; set; }
        [Display(Name = "Group Name")]
        public int GroupId { get; set; }
        [Display(Name = "Book Name")]
        public int BookId { get; set; }
        [Display(Name = "Scheduled Date")]
        public DateTime ScheduledDate { get; set; }
    }
}
