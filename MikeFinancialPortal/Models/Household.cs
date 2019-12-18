using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MikeFinancialPortal.Models
{
    public class Household
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Greeting { get; set; }
        public DateTime Created { get; set; }

        public virtual ICollection<Invitation> Invitations { get; set; }
        public virtual ICollection<BankAccount> BankAccounts { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Budget> Budgets { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }

        public Household ()
        {
            Invitations = new HashSet<Invitation>();
            BankAccounts = new HashSet<BankAccount>();
            Notifications = new HashSet<Notification>();
            Budgets = new HashSet<Budget>();
            Users = new HashSet<ApplicationUser>();

        }

    }
}