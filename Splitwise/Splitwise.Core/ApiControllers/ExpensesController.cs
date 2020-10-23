using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Splitwise.DomainModel.ApplicationClasses;
using Splitwise.DomainModel.Models;
using Splitwise.Repository.ExpenseRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Core.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController:ControllerBase
    {
        private readonly IExpenseRepository _expensesRepository;

        public ExpensesController(IExpenseRepository expensesRepository)
        {
            this._expensesRepository = expensesRepository;
        }

        // GET: api/Expenses
        [HttpGet]
        public IEnumerable<ExpensesAC> GetExpenses()
        {
            return _expensesRepository.GetExpenses();
        }

        // GET: api/Expenses/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExpenses([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var expenses = await _expensesRepository.GetExpense(id);

            if (expenses == null)
            {
                return NotFound();
            }

            return Ok(expenses);
        }

        // PUT: api/Expenses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExpenses([FromRoute] int id, [FromBody] Expenses expenses)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != expenses.Id)
            {
                return BadRequest();
            }

            _expensesRepository.UpdateExpense(expenses);

            try
            {
                await _expensesRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpensesExists(id))
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

        // POST: api/Expenses
        [HttpPost]
        public async Task<IActionResult> PostExpenses([FromBody] Expenses expenses)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _expensesRepository.CreateExpense(expenses);
            await _expensesRepository.Save();

            return CreatedAtAction("GetExpenses", new { id = expenses.Id }, expenses);
        }

        // DELETE: api/Expenses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpenses([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var expenses = await _expensesRepository.GetExpense(id);
            if (expenses == null)
            {
                return NotFound();
            }

            await _expensesRepository.DeleteExpense(expenses);
            await _expensesRepository.Save();

            return Ok(expenses);
        }

        private bool ExpensesExists(int id)
        {
            return _expensesRepository.ExpenseExists(id);
        }

    }
}
