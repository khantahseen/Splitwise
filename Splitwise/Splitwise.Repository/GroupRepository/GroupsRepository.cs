using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Splitwise.DomainModel;
using Splitwise.DomainModel.ApplicationClasses;
using Splitwise.DomainModel.Models;
using Splitwise.Repository.DataRepository;
using Splitwise.Repository.GroupMemberRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Repository.GroupRepository
{
    public class GroupsRepository : IGroupRepository
    {
        private readonly SplitwiseDbContext _context;
        private readonly IMapper _mapper;
        private readonly IGroupMemberRepository _groupMemberRepository;
      

        public GroupsRepository(SplitwiseDbContext _context, IMapper _mapper)
        {
            this._context = _context;
            this._mapper = _mapper;
        }

        public GroupsRepository()
        {
        }

        public void CreateGroup(Groups Group)
        {
            _context.Add(Group);
            //throw new NotImplementedException();
        }

        public IEnumerable<GroupsAC> GetGroups()
        {
            return _mapper.Map<IEnumerable<GroupsAC>>(_context.Groups);
            //throw new NotImplementedException();
        }

        public async Task<GroupsAC> GetGroup(int id)
        {
            return _mapper.Map<GroupsAC>(await _context.Groups.Include(u => u.User).FirstOrDefaultAsync(i => i.Id == id));
            //throw new NotImplementedException();
        }

        public bool GroupExists(int id)
        {
            return _context.Groups.Any(e => e.Id == id);
            //throw new NotImplementedException();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
            //throw new NotImplementedException();
        }
        public IEnumerable<GroupsAC> GetGroupsByUserId(string id)
        {
            return _mapper.Map<IEnumerable<GroupsAC>>(_groupMemberRepository.GetGroupMembers().Where(g => g.MemberId == id).Select(k => k.Group).ToList());
            //throw new NotImplementedException();
        }
        
        public Task DeleteGroup(GroupsAC Group)
        {
            throw new NotImplementedException();
        }

        public Task GetGroupWithDetails(int id)
        {
            throw new NotImplementedException();
        }
        public void UpdateGroup(Groups Group)
        {
            throw new NotImplementedException();
        }
    }
}
