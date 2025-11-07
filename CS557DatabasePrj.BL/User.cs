using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CS557DatabasePrj.BL
{
    public class User : AuditableEntity
    {
        public User(string u, string p, string first, string last, string email, string phone, string Ssn, int Role, int Branch ) {

            this.FirstName = first;
            this.LastName = last;
            this.Email = email;
            this.Phone = phone;
            this.HomeBranchId = Branch;
            this.RoleId = Role;
            this.Username = u;
            this.PasswordHash = p;
            this.SsnHash = Ssn;
            //think this needs owner id for pk to reference in accounts

        }

        public User() { }


        public string Username { get; set; } = "";//uniq
        public string PasswordHash { get; set; } = "";//store hash
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? SsnHash { get; set; }//hash
        public int RoleId { get; set; }// FK -> Role
        public int? HomeBranchId { get; set; }// FK -> Branch

        // Navigation (not required by Dapper, useful in BL/UI)
        public Role? Role { get; set; }
        public Branch? HomeBranch { get; set; }

        public List<Account> Accounts { get; set; } = new();
        public List<Card> Cards { get; set; } = new();
    }
}
