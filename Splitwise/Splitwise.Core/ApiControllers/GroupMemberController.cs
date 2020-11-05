using Microsoft.AspNetCore.Mvc;
using Splitwise.DomainModel.ApplicationClasses;
using Splitwise.DomainModel.Models;
using Splitwise.Repository.GroupMemberRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Core.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupMemberController:ControllerBase
    {
        private readonly IGroupMemberRepository _groupMemberRepository;

        public GroupMemberController(IGroupMemberRepository groupMemberRepository)
        {
            this._groupMemberRepository = groupMemberRepository;
        }

  
        
        // GET: api/GroupMember/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<GroupMemberAC>> GetGroupMember([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var groupMemberMappings = _groupMemberRepository.GetGroupMembers(id);

            if (groupMemberMappings == null)
            {
                return NotFound();
            }

            return Ok(groupMemberMappings);
        }

        // POST: api/GroupMember
        [HttpPost]
        public async Task<IActionResult> PostGroupMember([FromBody] GroupMember groupMember)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _groupMemberRepository.CreateGroupMember(groupMember);
            await _groupMemberRepository.Save();

            return Ok();
        }

        // DELETE: api/GroupMember/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroupMember([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var groupMember = _groupMemberRepository.GetGroupMembers(id);
            if (groupMember == null)
            {
                return NotFound();
            }

            await _groupMemberRepository.DeleteGroupMember((GroupMemberAC)groupMember);
            await _groupMemberRepository.Save();

            return Ok(groupMember);
        }

        private bool GroupMemberExists(int id)
        {
            return _groupMemberRepository.GroupMemberExists(id);
        }

    }
}
