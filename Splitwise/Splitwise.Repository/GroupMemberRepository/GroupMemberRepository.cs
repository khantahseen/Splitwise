using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Splitwise.DomainModel;
using Splitwise.DomainModel.ApplicationClasses;
using Splitwise.DomainModel.Models;
using Splitwise.Repository.DataRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Repository.GroupMemberRepository
{
    public class GroupMemberRepository : IGroupMemberRepository
    {
        #region Private Variables
        private SplitwiseDbContext _context;
        private readonly IMapper _mapper;
        private readonly IDataRepository _dataRepository;
        #endregion

        #region Constructors
        public GroupMemberRepository(SplitwiseDbContext _context, IMapper _mapper, IDataRepository _dataRepository)
        {
            this._context = _context;
            this._mapper = _mapper;
            this._dataRepository = _dataRepository;
        }
        #endregion

        #region Public Methods
        public void CreateGroupMember(GroupMember GroupMember)
        {
            _context.Add(GroupMember);
        }

        public IEnumerable<GroupMemberAC> GetGroupMembers()
        {
            return _mapper.Map<IEnumerable<GroupMemberAC>>(_context.GroupMember.Include(u => u.User).Include(g => g.Group));
        }
        
        public IEnumerable<GroupMemberAC> GetGroupMembers(int id)
        {
            return _mapper.Map<IEnumerable<GroupMemberAC>>( _context.GroupMember.Include(u => u.User).Where(i => i.GroupId == id));
        }
        
        public bool GroupMemberExists(int id)
        {
            return _context.GroupMember.Any(e => e.Id == id);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public Task DeleteGroupMember(GroupMemberAC GroupMember)
        {
            throw new NotImplementedException();
        }

        public Task DeleteGroupMemberByGroupId(int id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
