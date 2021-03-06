﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Splitwise.DomainModel.ApplicationClasses;
using Splitwise.DomainModel.Models;
using Splitwise.Repository.PayerRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Core.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayersController:ControllerBase
    {
        #region Private Variables
        private readonly IPayerRepository _payersRepository;
        #endregion

        #region Constructors
        public PayersController(IPayerRepository payersRepository)
        {
            this._payersRepository = payersRepository;
        }
        #endregion

        #region Public Methods
        // GET: api/Payers
        [HttpGet]
        public IEnumerable<PayersAC> GetPayers()
        {
            return _payersRepository.GetPayers();
        }

        // GET: api/Payers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PayersAC>> GetPayers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var payers = await _payersRepository.GetPayer(id);

            if (payers == null)
            {
                return NotFound();
            }

            return Ok(payers);
        }

        // GET: api/Payers/ByExpenseId/id
        [HttpGet("ByExpenseId/{id}")]
        public ActionResult<IEnumerable<PayersAC>> GetPayersByExpenseId([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var payers = _payersRepository.GetPayersByExpenseId(id);

            if (payers == null)
            {
                return NotFound();
            }

            return Ok(payers);
        }

        // GET: api/Payers/ByPayerId/id
        [HttpGet("ByPayerId/{id}")]
        public ActionResult<IEnumerable<PayersAC>> GetPayersByPayerId([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var payers = _payersRepository.GetPayersByPayerId(id);

            if (payers == null)
            {
                return NotFound();
            }

            return Ok(payers);
        }

        // GET: api/payer/expensebypayerid/{payerId}
        [HttpGet("expensesByPayerId/{payerId}")]
        public async Task<ActionResult<IEnumerable<PayersAC>>> GetExpensesByPayerId(string payerId)
        {
            return Ok(await this._payersRepository.GetExpensesByPayerId(payerId));
        }

        // POST: api/Payers
        [HttpPost]
        public async Task<IActionResult> PostPayers([FromBody] Payers payers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _payersRepository.CreatePayer(payers);
            await _payersRepository.Save();

            return CreatedAtAction("GetPayers", new { id = payers.Id }, payers);
        }

        // DELETE: api/Payers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var payers = await _payersRepository.GetPayer(id);
            if (payers == null)
            {
                return NotFound();
            }

            await _payersRepository.DeletePayer(payers);
            await _payersRepository.Save();

            return Ok(payers);
        }
        #endregion

        #region Private Methods
        private bool PayersExists(int id)
        {
            return _payersRepository.PayerExists(id);
        }
        #endregion 
    }
}
