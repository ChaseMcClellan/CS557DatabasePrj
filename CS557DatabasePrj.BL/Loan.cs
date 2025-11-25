using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS557DatabasePrj.BL
{
    public class Loan : AuditableEntity
    {
      public Loan() { }


        public int AccountId { get; set; }// FK -> Account (the loan account)
        public decimal Principal { get; set; }
        public decimal AnnualInterestRate { get; set; }//ex: 0.065m for 6.5%
        public int TermMonths { get; set; }//total months
        public DateTime StartUtc { get; set; }
        public LoanStatus Status { get; set; } = LoanStatus.Pending;

        public Account? Account { get; set; }
        public List<LoanPayment> Payments { get; set; } = new();
    }
}
