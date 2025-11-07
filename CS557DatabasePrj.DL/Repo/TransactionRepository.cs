using Dapper;
using CS557DatabasePrj.BL;

namespace CS557DatabasePrj.DL.Repo
{
    public class TransactionRepository : BaseRepository
    {
        public async Task<IEnumerable<Transaction>> GetByAccountAsync(int accountId, int limit = 100, int offset = 0)
        {
            using var conn = Open();
            return await conn.QueryAsync<Transaction>(
                @"SELECT * FROM Transactions
                  WHERE AccountId=@accountId
                  ORDER BY PostedUtc DESC
                  LIMIT @limit OFFSET @offset;", new { accountId, limit, offset });
        }

        public async Task<int> InsertAsync(Transaction t)
        {
            using var conn = Open();
            var sql = @"
            INSERT INTO Transactions
             (AccountId, Kind, Amount, Memo, PostedUtc, RelatedEntityId, CreatedUtc, CreatedByUserId, IsActive)
             VALUES
             (@AccountId, @Kind, @Amount, @Memo, @PostedUtc, @RelatedEntityId, @CreatedUtc, @CreatedByUserId, @IsActive);
            SELECT LAST_INSERT_ID();";
            return await conn.ExecuteScalarAsync<int>(sql, t);
        }
    }
}
