using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Splitwise.DomainModel.ApplicationClasses;
using Splitwise.DomainModel.Models;
using Splitwise.Repository.GroupRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Core.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController:ControllerBase
    {
        private readonly IGroupRepository _groupRepository;

        public GroupsController(IGroupRepository groupRepository)
        {
            this._groupRepository = groupRepository;
        }

        // GET: api/Groups
        [HttpGet]
        public IEnumerable<GroupsAC> GetGroups()
        {
            return _groupRepository.GetGroups();
        }

        // GET: api/Groups/2
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroupById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var groups =await _groupRepository.GetGroup(id);

            return Ok(groups);
        }

        // GET: api/Groups/ByUserId
        [HttpGet("ByUserId/{id}")]
        public IActionResult GetGroupsByUserId([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var groups = _groupRepository.GetGroupsByUserId(id);

            return Ok(groups);
        }

        // PUT: api/Groups/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroups([FromRoute] int id, [FromBody] Groups group)
        {
            try
            {
                group.Id = id;
                await this._groupRepository.UpdateGroup(group);

            }
            catch (Exception)
            {
                if (!GroupsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(group);
        }

        // POST: api/Groups
        [HttpPost]
        public async Task<IActionResult> PostGroups([FromBody] Groups groups)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _groupRepository.CreateGroup(groups);
            await _groupRepository.Save();
            return Ok();

            //return CreatedAtAction("GetGroups", new { id = groups.Id }, groups);
        }

        // DELETE: api/Groups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroups([FromRoute] int id)
        {
            if (this.GroupsExists(id))
            {
                await _groupRepository.DeleteGroup(id);
                return Ok(id);
            }
            return NotFound();
        }

        private bool GroupsExists(int id)
        {
            return _groupRepository.GroupExists(id);
        }
    }

  
}
