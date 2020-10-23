using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Splitwise.DomainModel.ApplicationClasses;
using Splitwise.DomainModel.Models;

namespace Splitwise.Repository.GroupRepository
{
    public interface IGroupRepository
    {
        IEnumerable<GroupsAC> GetGroups();
        IEnumerable<GroupsAC> GetGroupsByUserId(string id);
        Task<GroupsAC> GetGroup(int id);

        //To be included later
        //Task<GroupAndMembersAC> GetGroupWithDetails(int id);
        void CreateGroup(Groups Group);
        void UpdateGroup(Groups Group);
        Task DeleteGroup(GroupsAC Group);
       
        bool GroupExists(int id);
        Task GetGroupWithDetails(int id);
    }
}
