using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS557DatabasePrj.BL
{
    public class Withdrawal : AuditableEntity
    {
        public int AccountId { get; set; }// FK -> Account
        public decimal Amount { get; set; }
        public string? Method { get; set; }//ATM, Teller
        public DateTime ProcessedUtc { get; set; } = DateTime.UtcNow;

        public Account? Account { get; set; }
    }
}
