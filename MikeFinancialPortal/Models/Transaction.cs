using MikeFinancialPortal.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MikeFinancialPortal.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int BankAccountId { get; set; }
        public int? BudgetItemId { get; set; }
        public string OwnerId { get; set; }
        public TransactionType TransactionTypes { get; set; }
        public DateTime Created { get; set; }
        public float Amount { get; set; }
        public string Memo { get; set; }
        
        //Nav Section
        public virtual BankAccount BankAccounts { get; set; }
        public virtual BudgetItem BudgetItems { get; set; }
        public virtual ApplicationUser Owner { get; set; }
        
    }
}