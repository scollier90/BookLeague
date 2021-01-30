using BookLeague.Data;
using BookLeague.Models.Group;
using Microsoft.AspNet.Identity.EntityFramework;
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
                    Id = _creatorId.ToString()
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Groups.Add(entity);
                return ctx.SaveChanges() == 1;
            }

            //using (var ctx = new ApplicationDbContext())
            //{
            //    ctx.Groups.Add(entity);
            //    if (ctx.SaveChanges() == 1)
            //    {
            //        entity.Users.Add(RetrieveUserById(_creatorId)); //insert method call here)
            //        return true;
            //    }
            //    return false;
            //}
            //Method that: Retrieve ApplicationUser object by ID
        }

        //public ApplicationUser RetrieveUserById(Guid groupmember)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        ApplicationUser query =
        //            ctx
        //                .Users
        //                .Where(e => e.Id == groupmember.ToString()).Single();
        //        return query;
        //    }
        //}

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
                                    //Users = e.Users,
                                }
                        );
                return query.ToArray();
            }
        }

        public GroupDetail GetGroupById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Groups
                        .Single(e => e.GroupId == id);
                return
                    new GroupDetail
                    {
                        GroupId = entity.GroupId,
                        GroupName = entity.GroupName
                    };
            }
        }

        public bool UpdateGroup(GroupEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Groups
                        .Single(e => e.GroupId == model.GroupId && e.CreatorId == _creatorId);
                entity.GroupName = model.GroupName;
                //entity.Id = model.Id; -- future development

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteGroup(int groupId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Groups
                        .Single(e => e.GroupId == groupId && e.CreatorId == _creatorId);

                ctx.Groups.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
