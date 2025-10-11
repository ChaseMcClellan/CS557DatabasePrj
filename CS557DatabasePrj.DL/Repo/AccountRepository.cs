using Dapper;
using CS557DatabasePrj.BL;

namespace CS557DatabasePrj.DL.Repo
{
    public class AccountRepository : BaseRepository
    {
        public async Task<Account?> GetByIdAsync(int id)
        {
            using var conn = Open();
            return await conn.QuerySingleOrDefaultAsync<Account>("SELECT * FROM Accounts WHERE Id=@id;", new { id });
        }

        public async Task<Account?> GetByNumberAsync(string acctNo)
        {
            using var conn = Open();
            return await conn.QuerySingleOrDefaultAsync<Account>("SELECT * FROM Accounts WHERE AccountNumber=@acctNo;", new { acctNo });
        }

        public async Task<IEnumerable<Account>> GetByUserAsync(int ownerUserId)
        {
            using var conn = Open();
            return await conn.QueryAsync<Account>(
                "SELECT * FROM Accounts WHERE OwnerUserId=@ownerUserId ORDER BY Id;", new { ownerUserId });
        }

        public async Task<int> InsertAsync(Account a)
        {
            using var conn = Open();
            var sql = @"
INSERT INTO Accounts
(AccountNumber, AccountType, OwnerUserId, BranchId, CurrentBalance, CurrencyCode, CreatedUtc, CreatedByUserId, IsActive)
VALUES
(@AccountNumber, @AccountType, @OwnerUserId, @BranchId, @CurrentBalance, @CurrencyCode, @CreatedUtc, @CreatedByUserId, @IsActive);
SELECT LAST_INSERT_ID();";
            return await conn.ExecuteScalarAsync<int>(sql, a);
        }

        public async Task<bool> UpdateAsync(Account a)
        {
            using var conn = Open();
            var sql = @"
UPDATE Accounts SET
 AccountNumber=@AccountNumber, AccountType=@AccountType, OwnerUserId=@OwnerUserId, BranchId=@BranchId,
 CurrentBalance=@CurrentBalance, CurrencyCode=@CurrencyCode,
 UpdatedUtc=@UpdatedUtc, UpdatedByUserId=@UpdatedByUserId, IsActive=@IsActive
WHERE Id=@Id;";
            return (await conn.ExecuteAsync(sql, a)) > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using var conn = Open();
            return (await conn.ExecuteAsync("DELETE FROM Accounts WHERE Id=@id;", new { id })) > 0;
        }
    }
}
