using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS557DatabasePrj.BL
{
    public class ReconciliationResults
    {
        public BranchInfo BranchInfo { get; set; }
        public List<ReconciliationRecord> ReconciliationReport { get; set; }
        public SummaryReport Summary { get; set; }
        public int DiscrepanciesFound { get; set; } 
    }

    public class BranchInfo
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public string ReconciliationPeriod { get; set; }
    }

    public class ReconciliationRecord
    {
        [DisplayName("Account Number")]
        public string AccountNumber { get; set; }

        [DisplayName("Owner Name")]
        public string OwnerName { get; set; }

        [DisplayName("Stored Balance")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal StoredBalance { get; set; }

        [DisplayName("Calculated Balance")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal CalculatedBalance { get; set; }

        [DisplayName("Discrepancy")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Discrepancy { get; set; }

        [DisplayName("Transaction Count")]
        public int TransactionCount { get; set; }

        public string Status { get; set; }
    }

    public class SummaryReport
    {
        public int TotalAccountsChecked { get; set; }
        public int AccountsWithDiscrepancies { get; set; }
        public int AccountsOK { get; set; }
        public int MinorDiscrepancies { get; set; }
        public int MajorDiscrepancies { get; set; }
        public decimal TotalDiscrepancyAmount { get; set; }
    }
}
