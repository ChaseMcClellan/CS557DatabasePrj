using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS557DatabasePrj.BL
{
    public class Deposit : AuditableEntity
    {
        public int AccountId { get; set; }// FK -> Account
        public decimal Amount { get; set; }
        public string? Source { get; set; }// Cash, Check #
        public DateTime ReceivedUtc { get; set; } = DateTime.UtcNow;

        public Account? Account { get; set; }
    }
}
