using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Splitwise.DomainModel.ApplicationClasses;
using Splitwise.DomainModel.Models;
using Splitwise.Repository.SettlementRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Core.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettlementsController:ControllerBase
    {
        private readonly ISettlementRepository _settlementsRepository;

        public SettlementsController(ISettlementRepository settlementsRepository)
        {
            this._settlementsRepository = settlementsRepository;
        }

        // GET: api/Settlements
        [HttpGet]
        public IEnumerable<SettlementsAC> GetSettlements()
        {
            return _settlementsRepository.GetSettlements();
        }

        // GET: api/Settlements/GetByUserId
        [HttpGet("GetByUserId/{id}")]
        public ActionResult<IEnumerable<SettlementsAC>> GetSettlementsByUserId([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var settlements = _settlementsRepository.GetSettlementsByUserId(id);

            if (settlements == null)
            {
                return NotFound();
            }

            return Ok(settlements);
        }

        // GET: api/Settlements/GetByGroupId
        [HttpGet("GetByGroupId/{id}")]
        public ActionResult<IEnumerable<SettlementsAC>> GetSettlementsByGroupId([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var settlements = _settlementsRepository.GetSettlementsByGroupId(id);

            if (settlements == null)
            {
                return NotFound();
            }

            return Ok(settlements);
        }

        //POST: api/Settlements
        [HttpPost]
        public async Task<IActionResult> PostSettlements([FromBody] Settlements settlements)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _settlementsRepository.CreateSettlement(settlements);
            await _settlementsRepository.Save();

            return Ok();
        }

        private bool SettlementsExists(int id)
        {
            return _settlementsRepository.SettlementExists(id);
        }
    }
}
