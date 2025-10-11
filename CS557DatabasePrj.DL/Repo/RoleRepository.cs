using Dapper;
using CS557DatabasePrj.BL;

namespace CS557DatabasePrj.DL.Repo
{
    public class RoleRepository : BaseRepository
    {
        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            using var conn = Open();
            return await conn.QueryAsync<Role>("SELECT * FROM Roles ORDER BY Name;");
        }
        public async Task<Role?> GetByIdAsync(int id)
        {
            using var conn = Open();
            return await conn.QuerySingleOrDefaultAsync<Role>("SELECT * FROM Roles WHERE Id=@id;", new { id });
        }
        public async Task<int> InsertAsync(Role r)
        {
            using var conn = Open();
            return await conn.ExecuteScalarAsync<int>(
                "INSERT INTO Roles (Name, Description, IsAdmin) VALUES (@Name,@Description,@IsAdmin); SELECT LAST_INSERT_ID();", r);
        }
        public async Task<bool> UpdateAsync(Role r)
        {
            using var conn = Open();
            return (await conn.ExecuteAsync("UPDATE Roles SET Name=@Name, Description=@Description, IsAdmin=@IsAdmin WHERE Id=@Id;", r)) > 0;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            using var conn = Open();
            return (await conn.ExecuteAsync("DELETE FROM Roles WHERE Id=@id;", new { id })) > 0;
        }
    }
}
