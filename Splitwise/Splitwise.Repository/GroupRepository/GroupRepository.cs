using Splitwise.DomainModel.ApplicationClasses;
using Splitwise.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Repository.GroupRepository
{
    class GroupRepository : IGroupRepository
    {
        public void CreateGroup(Groups Group)
        {
            throw new NotImplementedException();
        }

        public Task DeleteGroup(GroupsAC Group)
        {
            throw new NotImplementedException();
        }

        public Task<GroupsAC> GetGroup(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GroupsAC> GetGroups()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GroupsAC> GetGroupsByUserId(string id)
        {
            throw new NotImplementedException();
        }

        public Task GetGroupWithDetails(int id)
        {
            throw new NotImplementedException();
        }

        public bool GroupExists(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateGroup(Groups Group)
        {
            throw new NotImplementedException();
        }
    }
}
