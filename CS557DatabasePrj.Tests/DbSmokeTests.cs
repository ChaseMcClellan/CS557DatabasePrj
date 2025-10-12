using System;
using System.Threading.Tasks;
using Dapper;
using Xunit;
using CS557DatabasePrj.DL;

namespace CS557DatabasePrj.Tests
{
    public class DbSmokeTests
    {
        [Fact(DisplayName = "DB connects and returns 1")]
        public async Task Connects_And_Selects_One()
        {
            using var conn = DbConnectionFactory.CreateConnection();
            var one = await conn.ExecuteScalarAsync<int>("SELECT 1;");
            Assert.Equal(1, one);
        }

        [Fact(DisplayName = "Schema seeded: Users has at least one row")]
        public async Task UsersTable_Seeded()
        {
            using var conn = DbConnectionFactory.CreateConnection();
            var count = await conn.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM Users;");
            Assert.True(count >= 1, "Expected at least 1 seeded user.");
        }
    }
}
