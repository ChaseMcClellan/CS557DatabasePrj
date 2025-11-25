using Dapper;
using CS557DatabasePrj.BL;
using System.Data;

namespace CS557DatabasePrj.DL.Repo
{
    public class TransactionRepository : BaseRepository
    {
        private static decimal GetBalanceDelta(Transaction t)
        {
            int sign = t.Kind switch
            {
                TransactionKind.Deposit => +1,
                TransactionKind.Interest => +1,
                TransactionKind.Withdrawal => -1,
                TransactionKind.Transfer => -1,
                TransactionKind.Fee => -1,
                TransactionKind.Payment => -1,
                _ => 0
            };

            return sign * t.Amount;
        }

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

        public async Task<int> InsertWithBalanceAsync(Transaction t)
        {
            using var conn = Open();
            using var tx = conn.BeginTransaction();

            try
            {
                var sql = @"
INSERT INTO Transactions
(AccountId, Kind, Amount, Memo, PostedUtc, RelatedEntityId, CreatedUtc, CreatedByUserId, IsActive)
VALUES
(@AccountId, @Kind, @Amount, @Memo, @PostedUtc, @RelatedEntityId, @CreatedUtc, @CreatedByUserId, @IsActive);
SELECT LAST_INSERT_ID();";

                int id = await conn.ExecuteScalarAsync<int>(sql, t, tx);

                var delta = GetBalanceDelta(t);

                await conn.ExecuteAsync(
                    "UPDATE Accounts SET CurrentBalance = CurrentBalance + @delta WHERE Id=@acctId;",
                    new { delta, acctId = t.AccountId }, tx);

                tx.Commit();
                return id;
            }
            catch
            {
                tx.Rollback();
                throw;
            }
        }

        public async Task<bool> UpdateAsync(Transaction t)
        {
            using var conn = Open();
            var sql = @"
UPDATE Transactions SET
    AccountId       = @AccountId,
    Kind            = @Kind,
    Amount          = @Amount,
    Memo            = @Memo,
    PostedUtc       = @PostedUtc,
    RelatedEntityId = @RelatedEntityId,
    UpdatedUtc      = @UpdatedUtc,
    UpdatedByUserId = @UpdatedByUserId,
    IsActive        = @IsActive
WHERE Id = @Id;";
            return (await conn.ExecuteAsync(sql, t)) > 0;
        }

        public async Task<IEnumerable<Transaction>> GetAllAsync(int limit = 500, int offset = 0)
        {
            using var conn = Open();
            var sql = @"
SELECT * FROM Transactions
ORDER BY PostedUtc DESC
LIMIT @limit OFFSET @offset;";
            return await conn.QueryAsync<Transaction>(sql, new { limit, offset });
        }

        public async Task<bool> UpdateWithBalanceAsync(Transaction original, Transaction updated)
        {
            using var conn = Open();
            using var tx = conn.BeginTransaction();

            try
            {
                var sql = @"
UPDATE Transactions SET
    AccountId       = @AccountId,
    Kind            = @Kind,
    Amount          = @Amount,
    Memo            = @Memo,
    PostedUtc       = @PostedUtc,
    RelatedEntityId = @RelatedEntityId,
    UpdatedUtc      = @UpdatedUtc,
    UpdatedByUserId = @UpdatedByUserId,
    IsActive        = @IsActive
WHERE Id = @Id;";

                await conn.ExecuteAsync(sql, updated, tx);

                var oldDelta = GetBalanceDelta(original);
                var newDelta = GetBalanceDelta(updated);
                var diff = newDelta - oldDelta;

                if (diff != 0)
                {
                    await conn.ExecuteAsync(
                        "UPDATE Accounts SET CurrentBalance = CurrentBalance + @diff WHERE Id=@acctId;",
                        new { diff, acctId = updated.AccountId }, tx);
                }

                tx.Commit();
                return true;
            }
            catch
            {
                tx.Rollback();
                throw;
            }
        }
        public async Task<int> UndoAsync(Transaction original, int adminUserId)
        {
            var reversal = new Transaction
            {
                AccountId = original.AccountId,
                Kind = original.Kind,
                Amount = original.Amount,
                Memo = $"REVERSAL of Tx #{original.Id}: {original.Memo}",
                PostedUtc = DateTime.UtcNow,
                RelatedEntityId = original.Id,
                CreatedUtc = DateTime.UtcNow,
                CreatedByUserId = adminUserId,
                IsActive = true
            };

            using var conn = Open();
            using var tx = conn.BeginTransaction();

            try
            {
                var sql = @"
INSERT INTO Transactions
(AccountId, Kind, Amount, Memo, PostedUtc, RelatedEntityId, CreatedUtc, CreatedByUserId, IsActive)
VALUES
(@AccountId, @Kind, @Amount, @Memo, @PostedUtc, @RelatedEntityId, @CreatedUtc, @CreatedByUserId, @IsActive);
SELECT LAST_INSERT_ID();";

                int newId = await conn.ExecuteScalarAsync<int>(sql, reversal, tx);

                var originalDelta = GetBalanceDelta(original);
                var undoDelta = -originalDelta;

                await conn.ExecuteAsync(
                    "UPDATE Accounts SET CurrentBalance = CurrentBalance + @delta WHERE Id=@acctId;",
                    new { delta = undoDelta, acctId = original.AccountId }, tx);

                tx.Commit();
                return newId;
            }
            catch
            {
                tx.Rollback();
                throw;
            }
        }
    }
}
