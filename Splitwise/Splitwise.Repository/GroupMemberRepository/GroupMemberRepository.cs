﻿using AutoMapper;
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
        private SplitwiseDbContext _context;
        private readonly IMapper _mapper;
        private readonly IDataRepository _dataRepository;

        public GroupMemberRepository(SplitwiseDbContext _context, IMapper _mapper, IDataRepository _dataRepository)
        {
            this._context = _context;
            this._mapper = _mapper;
            this._dataRepository = _dataRepository;
        }

        public void CreateGroupMember(GroupMember GroupMember)
        {
            _context.Add(GroupMember);
            //throw new NotImplementedException();
        }

        public IEnumerable<GroupMemberAC> GetGroupMembers()
        {
            return _mapper.Map<IEnumerable<GroupMemberAC>>(_context.GroupMember.Include(u => u.User).Include(g => g.Group));
            //throw new NotImplementedException();
        }
        public IEnumerable<GroupMemberAC> GetGroupMembers(int id)
        {

            return _mapper.Map<IEnumerable<GroupMemberAC>>( _context.GroupMember.Include(u => u.User).Where(i => i.GroupId == id));
            //throw new NotImplementedException();
           
        }
        public bool GroupMemberExists(int id)
        {
            return _context.GroupMember.Any(e => e.Id == id);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
            //throw new NotImplementedException();
        }

        public Task DeleteGroupMember(GroupMemberAC GroupMember)
        {
            throw new NotImplementedException();
        }

        public Task DeleteGroupMemberByGroupId(int id)
        {

            throw new NotImplementedException();
        }

        public IEnumerable<GroupMemberAC> GetGroupMemberMappings()
        {
            throw new NotImplementedException();
        }
    }
}
