using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS557DatabasePrj.BL
{
    public class LoanPayment : AuditableEntity
    {
        public int LoanId { get; set; }//FK -> Loan
        public decimal Amount { get; set; }
        public DateTime DueDateUtc { get; set; }
        public DateTime? PaidDateUtc { get; set; }
        public decimal? PrincipalPortion { get; set; }
        public decimal? InterestPortion { get; set; }
        public string? Reference { get; set; }//check #

        public Loan? Loan { get; set; }
    }
}
