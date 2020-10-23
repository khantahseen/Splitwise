﻿using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> PutGroups([FromRoute] int id, [FromBody] Groups groups)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != groups.Id)
            {
                return BadRequest();
            }

            _groupRepository.UpdateGroup(groups);

            try
            {
                await _groupRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
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

            return NoContent();
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

            return CreatedAtAction("GetGroups", new { id = groups.Id }, groups);
        }

        // DELETE: api/Groups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroups([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var groups = await _groupRepository.GetGroup(id);
            if (groups == null)
            {
                return NotFound();
            }

            await _groupRepository.DeleteGroup(groups);
            await _groupRepository.Save();

            return Ok(groups);
        }

        private bool GroupsExists(int id)
        {
            return _groupRepository.GroupExists(id);
        }
    }

  
}
