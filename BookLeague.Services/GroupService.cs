using BookLeague.Data;
using BookLeague.Models.Group;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLeague.Services
{
    public class GroupService
    {
        private readonly Guid _creatorId;

        public GroupService(Guid creatorId)
        {
            _creatorId = creatorId;
        }

        public bool CreateGroup(GroupCreate model)
        {
            var entity =
                new Group()
                {
                    GroupName = model.GroupName,
                    CreatorId = _creatorId,
                    Users = model.Users
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Groups.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GroupListItem> GetGroup()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Groups
                        .Where(e => e.CreatorId == _creatorId)
                        .Select(
                            e =>
                                new GroupListItem
                                {
                                    GroupId = e.GroupId,
                                    GroupName = e.GroupName,
                                    Users = e.Users,
                                }
                        );
                return query.ToArray();
            }
        }
    }
}
