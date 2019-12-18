using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MikeFinancialPortal.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
      
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Full Name")]
        public string DisplayName { get; set; }
        [NotMapped]
        public string Avatar { get; set; }
        public int? HouseholdId { get; set; }

        //Primary Key
        public virtual Household Households { get; set; }

        //Nav Section
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<BankAccount> BankAccounts { get; set; }
        public virtual ICollection<Budget> Budgets { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }

        public ApplicationUser()
        {
            Notifications = new HashSet<Notification>();
            BankAccounts = new HashSet<BankAccount>();
            Budgets = new HashSet<Budget>();
            Transactions = new HashSet<Transaction>();
        }
        
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<BudgetItem> BudgetItems { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Household> Households { get; set; }
        public DbSet<Invitation> Invitations { get; set; }
    }


}