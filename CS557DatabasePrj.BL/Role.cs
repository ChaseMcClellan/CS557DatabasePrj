using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS557DatabasePrj.BL
{
    public class Role : Entity
    {
        //Name can be either "Admin", "User", "Employee"
        public string Name { get; set; } = "";
        public string? Description { get; set; }
        public bool IsAdmin { get; set; } = false;
    }
}
