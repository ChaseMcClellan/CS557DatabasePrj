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

        public async Task ApplyLoanFundingAsync(int accountId, decimal amount, int userId, int loanId)
        {
            using var conn = Open();
            using var tx = conn.BeginTransaction();

            // 1) Increase account balance
            await conn.ExecuteAsync(
                "UPDATE Accounts SET CurrentBalance = CurrentBalance + @amount WHERE Id = @id;",
                new { amount, id = accountId }, tx);

            // 2) Insert a deposit row (optional but nice for history)
            var depositId = await conn.ExecuteScalarAsync<int>(@"
INSERT INTO Deposits
    (AccountId, Source, ReceivedUtc, Amount, CreatedUtc)
VALUES
    (@AccountId, @Source, @ReceivedUtc, @Amount, @CreatedUtc);
SELECT LAST_INSERT_ID();",
                new
                {
                    AccountId = accountId,
                    Source = "Loan funding",
                    ReceivedUtc = DateTime.UtcNow,
                    Amount = amount,
                    CreatedUtc = DateTime.UtcNow
                }, tx);

            // 3) Insert a transaction row (if you’re using the transactions table)
            await conn.ExecuteAsync(@"
INSERT INTO Transactions
    (AccountId, Kind, Amount, Memo, PostedUtc,
     RelatedEntityId, CreatedUtc, IsActive, CreatedByUserId)
VALUES
    (@AccountId, 1, @Amount, @Memo, @PostedUtc,
     @RelatedEntityId, @CreatedUtc, 1, @CreatedByUserId);",
                new
                {
                    AccountId = accountId,
                    Amount = amount,
                    Memo = $"Loan #{loanId} funding",
                    PostedUtc = DateTime.UtcNow,
                    RelatedEntityId = depositId,
                    CreatedUtc = DateTime.UtcNow,
                    CreatedByUserId = userId
                }, tx);

            tx.Commit();
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
