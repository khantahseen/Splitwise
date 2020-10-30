using Splitwise.DomainModel.ApplicationClasses;
using Splitwise.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Repository.GroupMemberRepository
{
    public interface IGroupMemberRepository
    {
        IEnumerable<GroupMemberAC> GetGroupMembers();
        IEnumerable<GroupMemberAC> GetGroupMembers(int id);
        void CreateGroupMember(GroupMember GroupMember);
        Task DeleteGroupMember(GroupMemberAC GroupMember);
        Task DeleteGroupMemberByGroupId(int id);
        bool GroupMemberExists(int id);
        Task Save();
    }
}
