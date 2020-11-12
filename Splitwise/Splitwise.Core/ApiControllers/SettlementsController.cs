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
        #region Private Variables
        private readonly ISettlementRepository _settlementsRepository;
        #endregion

        #region Constructors
        public SettlementsController(ISettlementRepository settlementsRepository)
        {
            this._settlementsRepository = settlementsRepository;
        }
        #endregion


        #region Public Methods
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

            await _settlementsRepository.CreateSettlement(settlements);
            //await _settlementsRepository.Save();

            return Ok();
        }
        #endregion

        #region Private Methods
        private bool SettlementsExists(int id)
        {
            return _settlementsRepository.SettlementExists(id);
        }
        #endregion
    }
}
