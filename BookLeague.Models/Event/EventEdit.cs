using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLeague.Models.Event
{
    public class EventEdit
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public int GroupId { get; set; }
        public int BookId { get; set; }
        public DateTime ScheduledDate { get; set; }
    }
}
