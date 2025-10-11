using CS557DatabasePrj.DL.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS557DatabasePrj.DL.Repo
{
    public abstract class BaseRepository
    {
        protected IDbConnection Open() => DbConnectionFactory.CreateConnection();
    }
}
