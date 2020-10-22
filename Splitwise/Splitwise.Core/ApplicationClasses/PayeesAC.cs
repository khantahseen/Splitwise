﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Splitwise.Core.ApplicationClasses
{
    public class PayeesAC
    {
        public int Id { get; set; }
        public int ExpenseId { get; set; }
        public ExpensesAC Expense { get; set; }
        public string PayeeId { get; set; }
        public UsersAC User { get; set; }
        public int PayeeShare { get; set; }
    }
}
