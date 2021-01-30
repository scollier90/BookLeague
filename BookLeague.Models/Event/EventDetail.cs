using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLeague.Models.Event
{
    public class EventDetail
    {
        public int EventId { get; set; }
        [Display(Name = "Event Name")]
        public string EventName { get; set; }
        public int GroupId { get; set; }
        public int BookId { get; set; }
        public DateTime ScheduledDate { get; set; }
    }
}
