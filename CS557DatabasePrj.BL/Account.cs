using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS557DatabasePrj.BL
{
    public class Account : AuditableEntity
    {   
        //uniq
        public string AccountNumber { get; set; } = "";
        public AccountType AccountType { get; set; } = AccountType.Checking;
        public int OwnerUserId { get; set; }// FK -> User
        public int? BranchId { get; set; }// FK -> Branch
        public decimal CurrentBalance { get; set; }
        public string CurrencyCode { get; set; } = "USD";

        public User? Owner { get; set; }
        public Branch? Branch { get; set; }

        public List<Card> Cards { get; set; } = new();
        public List<Transaction> Transactions { get; set; } = new();
        public List<Transfer> TransfersFrom { get; set; } = new();
        public List<Transfer> TransfersTo { get; set; } = new();
        public Loan? Loan { get; set; }//if this account is a loan
    }
}
