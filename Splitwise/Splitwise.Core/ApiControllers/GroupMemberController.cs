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
        #region Private Variables
        private readonly IGroupMemberRepository _groupMemberRepository;
        #endregion

        #region Constructors
        public GroupMemberController(IGroupMemberRepository _groupMemberRepository)
        {
            this._groupMemberRepository = _groupMemberRepository;
        }
        #endregion

        #region Public Methods
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
        #endregion

        #region Private Methods
        private bool GroupMemberExists(int id)
        {
            return _groupMemberRepository.GroupMemberExists(id);
        }
        #endregion

    }
}
