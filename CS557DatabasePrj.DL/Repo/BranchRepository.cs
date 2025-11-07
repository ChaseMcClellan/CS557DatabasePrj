using Dapper;
using CS557DatabasePrj.BL;

namespace CS557DatabasePrj.DL.Repo
{
    public class BranchRepository : BaseRepository
    {
        public async Task<IEnumerable<Branch>> GetAllAsync()
        {
            using var conn = Open();
            return await conn.QueryAsync<Branch>("SELECT * FROM Branches ORDER BY Name;");
        }

        public async Task<Branch?> GetByIdAsync(int id)
        {
            using var conn = Open();
            return await conn.QuerySingleOrDefaultAsync<Branch>(
                "SELECT * FROM Branches WHERE Id=@id;", new { id });
        }

        public async Task<int> InsertAsync(Branch b)
        {
            using var conn = Open();
            var sql = @"
            INSERT INTO Branches
             (Name, AddressLine1, AddressLine2, City, State, PostalCode, Phone, CreatedUtc, CreatedByUserId, IsActive)
             VALUES
             (@Name, @AddressLine1, @AddressLine2, @City, @State, @PostalCode, @Phone, @CreatedUtc, @CreatedByUserId, @IsActive);
            SELECT LAST_INSERT_ID();";
            return await conn.ExecuteScalarAsync<int>(sql, b);
        }

        public async Task<bool> UpdateAsync(Branch b)
        {
            using var conn = Open();
            var sql = @"
            UPDATE Branches SET
             Name=@Name, AddressLine1=@AddressLine1, AddressLine2=@AddressLine2,
             City=@City, State=@State, PostalCode=@PostalCode, Phone=@Phone,
             UpdatedUtc=@UpdatedUtc, UpdatedByUserId=@UpdatedByUserId, IsActive=@IsActive
            WHERE Id=@Id;";
            return (await conn.ExecuteAsync(sql, b)) > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using var conn = Open();
            return (await conn.ExecuteAsync("DELETE FROM Branches WHERE Id=@id;", new { id })) > 0;
        }
    }
}
