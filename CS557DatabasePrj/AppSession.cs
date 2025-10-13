using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CS557DatabasePrj.BL;

namespace CS557DatabasePrj.UI
{
    public static class AppSession
    {
        public static User? CurrentUser { get; set; }
    }
}
