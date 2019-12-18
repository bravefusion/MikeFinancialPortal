using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MikeFinancialPortal.Models
{
    public class BudgetItem
    {
        public int Id { get; set; }
        public int BudgetId { get; set; }
        public DateTime Created { get; set; }
        public string Name { get; set; }
        public float TargetAmount { get; set; }
        public float CurrentAmount { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }

        public BudgetItem()
        {
            Transactions = new HashSet<Transaction>();
        }
        //Nav Section
        public virtual Budget Budgets { get; set; }
    }
}