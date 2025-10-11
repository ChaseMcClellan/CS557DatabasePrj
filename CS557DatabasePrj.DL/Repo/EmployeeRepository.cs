using Dapper;
using CS557DatabasePrj.BL;

namespace CS557DatabasePrj.DL.Repo
{
    public class EmployeeRepository : BaseRepository
    {
        public async Task<IEnumerable<Employee>> GetByBranchAsync(int branchId)
        {
            using var conn = Open();
            return await conn.QueryAsync<Employee>(
                "SELECT * FROM Employees WHERE BranchId=@branchId ORDER BY LastName, FirstName;", new { branchId });
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            using var conn = Open();
            return await conn.QuerySingleOrDefaultAsync<Employee>("SELECT * FROM Employees WHERE Id=@id;", new { id });
        }

        public async Task<int> InsertAsync(Employee e)
        {
            using var conn = Open();
            var sql = @"
INSERT INTO Employees
(EmployeeNumber, FirstName, LastName, BranchId, UserId, CreatedUtc, CreatedByUserId, IsActive)
VALUES
(@EmployeeNumber, @FirstName, @LastName, @BranchId, @UserId, @CreatedUtc, @CreatedByUserId, @IsActive);
SELECT LAST_INSERT_ID();";
            return await conn.ExecuteScalarAsync<int>(sql, e);
        }

        public async Task<bool> UpdateAsync(Employee e)
        {
            using var conn = Open();
            var sql = @"
UPDATE Employees SET
 EmployeeNumber=@EmployeeNumber, FirstName=@FirstName, LastName=@LastName,
 BranchId=@BranchId, UserId=@UserId,
 UpdatedUtc=@UpdatedUtc, UpdatedByUserId=@UpdatedByUserId, IsActive=@IsActive
WHERE Id=@Id;";
            return (await conn.ExecuteAsync(sql, e)) > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using var conn = Open();
            return (await conn.ExecuteAsync("DELETE FROM Employees WHERE Id=@id;", new { id })) > 0;
        }
    }
}
