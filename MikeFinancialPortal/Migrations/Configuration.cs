namespace MikeFinancialPortal.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MikeFinancialPortal.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Configuration;

    internal sealed class Configuration : DbMigrationsConfiguration<MikeFinancialPortal.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MikeFinancialPortal.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            #region Role Creation
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }

            if (!context.Roles.Any(r => r.Name == "Household Owner"))
            {
                roleManager.Create(new IdentityRole { Name = "Household Owner" });
            }

            if (!context.Roles.Any(r => r.Name == "House Member"))
            {
                roleManager.Create(new IdentityRole { Name = "House Memeber" });
            }

            if (!context.Roles.Any(r => r.Name == "Guest"))
            {
                roleManager.Create(new IdentityRole { Name = "Guest" });
            }
            #endregion
            #region User Creation
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!context.Users.Any(u => u.Email == "michaelhntn1990@gmail.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "michaelhntn1990@gmail.com",
                    Email = "michaelhntn1990@gmail.com",
                    FirstName = "Michael",
                    LastName = "Hinton",
                    DisplayName = "Michael H"
                }, WebConfigurationManager.AppSettings["AdminPassword"]);
            }

            if (!context.Users.Any(u => u.Email == "jhowse@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "jhowse@mailinator.com",
                    Email = "jhowse@mailinator.com",
                    FirstName = "Jordan",
                    LastName = "Howse",
                    DisplayName = "Jordan H"
                }, WebConfigurationManager.AppSettings["HouseOwnPassword"]);
            }
            
            if (!context.Users.Any(u => u.Email == "sorahowse@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "sorahowse@mailinator.com",
                    Email = "sorahowse@mailinator.com",
                    FirstName = "Sora",
                    LastName = "Howse",
                    DisplayName = "Sora H"
                }, WebConfigurationManager.AppSettings["HouseMemPassword"]);
            }

            if (!context.Users.Any(u => u.Email == "mjjackson@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "mjjackson@mailinator.com",
                    Email = "mjjackson@mailinator.com",
                    FirstName = "Mike",
                    LastName = "Jackson",
                    DisplayName = "Mike J"
                }, WebConfigurationManager.AppSettings["GuestPassword"]);
            }

            #endregion

            #region Assign roles to Users
            var adminId = userManager.FindByEmail("michaelhntn1990@gmail.com").Id;
            userManager.AddToRole(adminId, "Admin");

            var houseOwnerId = userManager.FindByEmail("jhowse@mailinator.com").Id;
            userManager.AddToRole(houseOwnerId, "Household Owner");

            var houseMemberId = userManager.FindByEmail("sorahowse@mailinator.com").Id;
            userManager.AddToRole(houseMemberId, "House Memeber");

            var guestId = userManager.FindByEmail("mjjackson@mailinator.com").Id;
            userManager.AddToRole(guestId, "Guest");

            #endregion

        }
    }
}
