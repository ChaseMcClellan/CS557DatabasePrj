using Dapper;
using CS557DatabasePrj.BL;

namespace CS557DatabasePrj.DL.Repo
{
    public class UserRepository : BaseRepository
    {
        public async Task<User?> GetByIdAsync(int id)
        {
            using var conn = Open();
            return await conn.QuerySingleOrDefaultAsync<User>(
                "SELECT * FROM Users WHERE Id=@id;", new { id });
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            using var conn = Open();
            return await conn.QuerySingleOrDefaultAsync<User>(
                "SELECT * FROM Users WHERE Username=@username;", new { username });
        }

        public async Task<IEnumerable<User>> GetAllAsync(int limit = 100, int offset = 0)
        {
            using var conn = Open();
            return await conn.QueryAsync<User>(
                "SELECT * FROM Users ORDER BY Id LIMIT @limit OFFSET @offset;", new { limit, offset });
        }

        public async Task<int> InsertAsync(User u)
        {
            using var conn = Open();
            var sql = @"
            INSERT INTO Users
            (Username, PasswordHash, FirstName, LastName, Email, Phone, SsnHash, RoleId, HomeBranchId,
             CreatedUtc, CreatedByUserId, IsActive)
            VALUES
            (@Username, @PasswordHash, @FirstName, @LastName, @Email, @Phone, @SsnHash, @RoleId, @HomeBranchId,
             @CreatedUtc, @CreatedByUserId, @IsActive);
            SELECT LAST_INSERT_ID();";
            return await conn.ExecuteScalarAsync<int>(sql, u);
        }

        public async Task<bool> UpdateAsync(User u)
        {
            using var conn = Open();
            var sql = @"
            UPDATE Users SET
             Username=@Username, FirstName=@FirstName, LastName=@LastName, Email=@Email, Phone=@Phone,
             SsnHash=@SsnHash, RoleId=@RoleId, HomeBranchId=@HomeBranchId,
             UpdatedUtc=@UpdatedUtc, UpdatedByUserId=@UpdatedByUserId, IsActive=@IsActive
            WHERE Id=@Id;";
            return (await conn.ExecuteAsync(sql, u)) > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using var conn = Open();
            return (await conn.ExecuteAsync("DELETE FROM Users WHERE Id=@id;", new { id })) > 0;
        }
    }
}

