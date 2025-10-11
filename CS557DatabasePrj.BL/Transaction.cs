using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS557DatabasePrj.BL
{
    public class Transaction : AuditableEntity
    {
        public int AccountId { get; set; }// FK -> Account (the affected account)
        public TransactionKind Kind { get; set; }
        public decimal Amount { get; set; }//positive value
        public string? Memo { get; set; }
        public DateTime PostedUtc { get; set; } = DateTime.UtcNow;
        //TODO: should we include?
        public int? RelatedEntityId { get; set; }//can optional link to Deposit/Withdrawal/Transfer/Payment id

        public Account? Account { get; set; }
    }
}
