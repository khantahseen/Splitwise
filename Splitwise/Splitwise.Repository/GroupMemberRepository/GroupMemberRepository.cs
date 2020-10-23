using Splitwise.DomainModel.ApplicationClasses;
using Splitwise.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Repository.GroupMemberRepository
{
    public class GroupMemberRepository : IGroupMemberRepository
    {
        public Task CreateGroupMember(GroupMember GroupMemberMapping)
        {
            throw new NotImplementedException();
        }

        public Task DeleteGroupMember(GroupMemberAC GroupMember)
        {
            throw new NotImplementedException();
        }

        public Task DeleteGroupMemberByGroupId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GroupMemberAC> GetGroupMember(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GroupMemberAC> GetGroupMembers()
        {
            throw new NotImplementedException();
        }

        public bool GroupMemberExists(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateGroupMember(GroupMember GroupMemberMapping)
        {
            throw new NotImplementedException();
        }
    }
}
