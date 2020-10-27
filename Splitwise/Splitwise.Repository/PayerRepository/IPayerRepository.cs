﻿using Splitwise.DomainModel.ApplicationClasses;
using Splitwise.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Repository.PayerRepository
{
    public interface IPayerRepository
    {
        IEnumerable<PayersAC> GetPayers();
        IEnumerable<PayersAC> GetPayersByExpenseId(int id);
        IEnumerable<PayersAC> GetPayersByPayerId(string id);
        Task<PayersAC> GetPayer(int id);
        void CreatePayer(Payers Payer);
        void UpdatePayer(Payers Payer);
        Task DeletePayer(PayersAC Payer);
        bool PayerExists(int id);
        Task Save();
    }
}
