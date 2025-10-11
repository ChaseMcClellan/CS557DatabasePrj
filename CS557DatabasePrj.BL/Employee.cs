using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS557DatabasePrj.BL
{
    public class Employee : AuditableEntity
    {
        public string EmployeeNumber { get; set; } = "";// unique within org
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public int BranchId { get; set; }// FK -> Branch
        public int UserId { get; set; }// optional: if employee also has a user login

        public Branch? Branch { get; set; }
        public User? User { get; set; }
    }
}
