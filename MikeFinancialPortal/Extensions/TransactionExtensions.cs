using MikeFinancialPortal.Enum;
using MikeFinancialPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MikeFinancialPortal.Extensions
{
    public static class TransactionExtensions
    {
        public static ApplicationDbContext db = new ApplicationDbContext();

        public static void UpdateBalances(this Transaction transaction)
        {
            UpdateBankBalance(transaction);
            UpdateBudgetBalance(transaction);
            UpdateBudgetItemBalance(transaction);
        }

        private static void CreateNotification(Transaction transaction, string body, string subject)
        {
            var houseId = db.Users.Find(transaction.OwnerId).HouseholdId ?? 0;
            var notification = new Notification
            {
                Body = body,
                Created = DateTime.Now,
                HouseholdId = houseId,
                IsRead = false,
                RecipientId = transaction.OwnerId,
                Subject = subject
            };
            db.Notifications.Add(notification);
        }

        private static void UpdateBankBalance(Transaction transaction)
        {
            var bank = db.BankAccounts.Find(transaction.BankAccountId);
            if (transaction.TransactionTypes == TransactionType.Deposit)
                bank.CurrentBalance += transaction.Amount;
            else
                bank.CurrentBalance -= transaction.Amount;

            db.SaveChanges();
        }

        private static void UpdateBudgetBalance(Transaction transaction)
        {
            if (transaction.TransactionTypes == TransactionType.Deposit || transaction.BudgetItemId == null)
                return;
            var budgetId = db.BudgetItems.Find(transaction.BudgetItems).BudgetId;
            var budget = db.Budgets.Find(budgetId);
            budget.CurrentAmount += transaction.Amount;
            db.SaveChanges();
        }

        private static void UpdateBudgetItemBalance(Transaction transaction)
        {
            if (transaction.TransactionTypes == TransactionType.Deposit || transaction.BudgetItemId == null)
                return;

            var budgetItem = db.BudgetItems.Find(transaction.BudgetItemId);
            budgetItem.CurrentAmount += transaction.Amount;
            db.SaveChanges();
        }

        
    }
}