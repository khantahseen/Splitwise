using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Splitwise.DomainModel.ApplicationClasses;
using Splitwise.DomainModel.Models;
using Splitwise.Repository.PayeeRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Core.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayeesController:ControllerBase
    {
        private readonly IPayeeRepository _payeesRepository;

        public PayeesController(IPayeeRepository payeesRepository)
        {
            this._payeesRepository = payeesRepository;
        }

        // GET: api/Payees
        [HttpGet]
        public IEnumerable<PayeesAC> GetPayees()
        {
            return _payeesRepository.GetPayees();
        }


        // GET: api/Payees/ByExpenseId/id
        [HttpGet("ByExpenseId/{id}")]
        public ActionResult<IEnumerable<PayeesAC>> GetPayeesByExpenseId([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var payees = _payeesRepository.GetPayeesByExpenseId(id);

            if (payees == null)
            {
                return NotFound();
            }

            return Ok(payees);
        }

        // GET: api/Payees/ByExpenseId/id
        [HttpGet("ByPayeeId/{id}")]
        public ActionResult<IEnumerable<PayeesAC>> GetPayeesByPayeeId([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var payees = _payeesRepository.GetPayeesByPayeeId(id);

            if (payees == null)
            {
                return NotFound();
            }

            return Ok(payees);
        }

        // GET: api/payee/expensebypayeeid/{payeeId}
        [HttpGet("expenseByPayeeId/{payeeId}")]
        public async Task<ActionResult<IEnumerable<PayeesAC>>> GetExpensesByPayeeId(string payeeId)
        {
            return Ok(await this._payeesRepository.GetExpensesByPayeeId(payeeId));
        }

        // POST: api/Payees
        [HttpPost]
        public async Task<IActionResult> PostPayees([FromBody] Payees payees)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _payeesRepository.CreatePayee(payees);
            await _payeesRepository.Save();

            return Ok();
            //CreatedAtAction("GetPayees", new { id = payees.Id }, payees);
        }

        private bool PayeesExists(int id)
        {
            return _payeesRepository.PayeeExists(id);
        }
    }
}
