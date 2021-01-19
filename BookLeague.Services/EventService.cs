using BookLeague.Data;
using BookLeague.Models.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLeague.Services
{
    public class EventService
    {
        private readonly Guid _creatorId;

        public EventService(Guid creatorId)
        {
            _creatorId = creatorId;
        }

        public bool CreateEvent(EventCreate model)
        {
            var entity =
                new Event()
                {
                    EventName = model.EventName,
                    CreatorId = _creatorId,
                    GroupId = model.GroupId,
                    BookId = model.BookId,
                    ScheduledDate = model.ScheduledDate
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Events.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<EventListItem> GetEvents()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Events
                        .Where(e => e.CreatorId == _creatorId)
                        .Select(
                            e =>
                                new EventListItem
                                {
                                    EventId = e.EventId,
                                    EventName = e.EventName,
                                    GroupId = e.GroupId,
                                    BookId = e.BookId,
                                    ScheduledDate = e.ScheduledDate
                                }
                        );
                return query.ToArray();
            }
        }
    }
}
