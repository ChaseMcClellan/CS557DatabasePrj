using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS557DatabasePrj.BL
{
    public abstract class AuditableEntity : Entity
    {
        public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;
        public int? CreatedByUserId { get; set; }
        public DateTime? UpdatedUtc { get; set; }
        public int? UpdatedByUserId { get; set; }
        public bool IsActive { get; set; } = true;
    }

    public enum AccountType
    {
        Checking = 1,
        Savings = 2,
        Credit = 3,
        Loan = 4,
        CertificateOfDeposit = 5
    }

    public enum CardType
    {
        Debit = 1,
        Credit = 2
    }

    public enum TransactionKind
    {
        Deposit = 1,
        Withdrawal = 2,
        Transfer = 3,
        Fee = 4,
        Interest = 5,
        Payment = 6
    }

    public enum LoanStatus
    {
        Pending = 1,
        Active = 2,
        Closed = 3,
        Delinquent = 4
    }
}
