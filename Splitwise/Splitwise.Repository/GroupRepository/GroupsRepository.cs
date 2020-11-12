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
        #region Private Variables
        private readonly SplitwiseDbContext _context;
        private readonly IMapper _mapper;
        private readonly IGroupMemberRepository _groupMemberRepository;
        #endregion

        #region Constructors
        public GroupsRepository(SplitwiseDbContext _context, IMapper _mapper, IGroupMemberRepository _groupMemberRepository)
        {
            this._context = _context;
            this._mapper = _mapper;
            this._groupMemberRepository = _groupMemberRepository;
        }
        #endregion

        #region Public Methods
        public async Task<int> CreateGroup(Groups Group)
        {
            _context.Add(Group);
            await _context.SaveChangesAsync();
            var groupName = Group.Name;
            var adminID = Group.AdminId;
            var groupID = this.GetGroups().Where(i => i.Name == groupName).Select(g => g.Id).FirstOrDefault();
            GroupMember gm = new GroupMember();
            gm.GroupId = groupID;
            gm.MemberId = adminID;
            this._groupMemberRepository.CreateGroupMember(gm);
            await _context.SaveChangesAsync();
            return groupID;
        }

        public IEnumerable<GroupsAC> GetGroups()
        {
            return _mapper.Map<IEnumerable<GroupsAC>>(_context.Groups);
        }

        public async Task<GroupsAC> GetGroup(int id)
        {
            return _mapper.Map<GroupsAC>(await _context.Groups.Include(u => u.User).FirstOrDefaultAsync(i => i.Id == id));
        }

        public bool GroupExists(int id)
        {
            return _context.Groups.Any(e => e.Id == id);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<GroupsAC>> GetGroupsByUserId(string id)
        {
            return _mapper.Map<IEnumerable<GroupsAC>>( this._groupMemberRepository.GetGroupMembers().Where(g => g.MemberId == id).Select(k => k.Group).ToList());
        }
        
        public async Task DeleteGroup(int id)
        {
            //group
            var groups = _context.Groups.Find(id);
            _context.Groups.Remove(groups);
            //members of group
            IEnumerable<GroupMember> members = _context.GroupMember.Where(m => m.GroupId == id);
            _context.GroupMember.RemoveRange(members);
            //settlements
            IEnumerable<Settlements> settlements = _context.Settlements.Where(m => m.GroupId == id);
            _context.GroupMember.RemoveRange(members);
            //expenses
            IEnumerable<Expenses> expense = _context.Expenses.Where(e => e.GroupId == id);
            _context.Expenses.RemoveRange(expense);

            //payers and payees
            foreach (var item in expense)
            {
                IEnumerable<Payers> payer = _context.Payers.Where(p => p.ExpenseId == item.Id);
                _context.Payers.RemoveRange(payer);

                IEnumerable<Payees> payee = _context.Payees.Where(pa => pa.ExpenseId == item.Id);
                _context.Payees.RemoveRange(payee);
            }
           await Save();
        }

        public Task GetGroupWithDetails(int id)
        {
            throw new NotImplementedException();
        }
        public async Task UpdateGroup(Groups Group)
        {
            var group = this._context.Groups.Where(e => e.Id == Group.Id).FirstOrDefault();
            group.Name = Group.Name;
            this._context.Groups.Update(group);
            await _context.SaveChangesAsync();
        }
        #endregion
    }
}
