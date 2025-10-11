using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS557DatabasePrj.BL
{
    public class Branch : AuditableEntity
    {
        public string Name { get; set; } = "";
        public string AddressLine1 { get; set; } = "";
        public string? AddressLine2 { get; set; }
        public string City { get; set; } = "";
        public string State { get; set; } = "";
        public string PostalCode { get; set; } = "";
        public string? Phone { get; set; }

        public List<Employee> Employees { get; set; } = new();
        public List<Account> Accounts { get; set; } = new();
    }
}
