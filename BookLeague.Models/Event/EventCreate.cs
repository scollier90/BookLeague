using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLeague.Models.Event
{
    public class EventCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter a longer event name.")]
        [MaxLength(100, ErrorMessage = "The event name needs to be shorter.")]
        public string EventName { get; set; }
        [Required]
        public int GroupId { get; set; }
        [Required]
        public int BookId { get; set; }
        public DateTime ScheduledDate { get; set; }
    }
}
