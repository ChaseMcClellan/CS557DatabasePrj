using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS557DatabasePrj.BL
{
    public class Transfer : AuditableEntity
    {
        //no separate join needed in BL
        public int FromAccountId { get; set; }// FK -> Account
        public int ToAccountId { get; set; }// FK -> Account
        public int InitiatedByUserId { get; set; }// FK -> User
        public decimal Amount { get; set; }
        public string? Memo { get; set; }
        public DateTime ExecutedUtc { get; set; } = DateTime.UtcNow;

        public Account? FromAccount { get; set; }
        public Account? ToAccount { get; set; }
        public User? InitiatedBy { get; set; }
    }
}
