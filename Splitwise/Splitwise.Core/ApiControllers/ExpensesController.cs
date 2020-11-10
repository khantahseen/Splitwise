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

        //GET: api/Expenses
        [HttpGet]
        public IEnumerable<ExpensesAC> GetExpenses()
        {
          return _expensesRepository.GetExpenses();
        }

        // GET: api/Expenses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExpensesAC>> GetExpenses([FromRoute] int id)
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

        // GET: api/Expenses/ByGroupId/id
        [HttpGet("ByGroupId/{id}")]
        public ActionResult<IEnumerable<ExpensesAC>> GetExpensesByGroupId([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var expenses = _expensesRepository.GetExpensesByGroupId(id);

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
            try
            {
                expenses.Id = id;
                await this._expensesRepository.UpdateExpense(expenses);

            }
            catch (Exception)
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

            return Ok(expenses);
        }

        // POST: api/Expenses
        [HttpPost]
        public async Task<ActionResult<Expenses>> PostExpenses([FromBody] Expenses expenses)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newexpense= await _expensesRepository.CreateExpense(expenses);
            

            return Ok(newexpense);
            //CreatedAtAction("GetExpenses", new { id = expenses.Id }, expenses);
        }

        // DELETE: api/Expenses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpenses([FromRoute] int id)
        {
            if (this.ExpensesExists(id))
            {
                await _expensesRepository.DeleteExpense(id);
                return Ok(id);
            }
            return NotFound();
        }

        

        private bool ExpensesExists(int id)
        {
            return _expensesRepository.ExpenseExists(id);
        }

    }
}
