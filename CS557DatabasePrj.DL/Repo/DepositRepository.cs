using CS557DatabasePrj.BL;
using Dapper;
using System.Data;

namespace CS557DatabasePrj.DL.Repo
{
    public class DepositRepository : BaseRepository
    {
        public async Task<int> InsertAsync(Deposit d)
        {
            using var conn = Open();
            using var tx = conn.BeginTransaction();

            try
            {
                // 1) Insert deposit
                var depId = await conn.ExecuteScalarAsync<int>(@"
INSERT INTO Deposits
(AccountId, Amount, Source, ReceivedUtc, CreatedUtc, CreatedByUserId, IsActive)
VALUES
(@AccountId, @Amount, @Source, @ReceivedUtc, @CreatedUtc, @CreatedByUserId, @IsActive);
SELECT LAST_INSERT_ID();", d, tx);

                // 2) Update balance
                await conn.ExecuteAsync(
                    "UPDATE Accounts SET CurrentBalance = CurrentBalance + @amt WHERE Id=@acct;",
                    new { amt = d.Amount, acct = d.AccountId }, tx);

                // 3) Add to transaction history
                var t = new Transaction
                {
                    AccountId = d.AccountId,
                    Kind = TransactionKind.Deposit,
                    Amount = d.Amount,
                    Memo = d.Source,
                    PostedUtc = d.ReceivedUtc,
                    RelatedEntityId = depId,
                    CreatedUtc = d.CreatedUtc,
                    CreatedByUserId = d.CreatedByUserId,
                    IsActive = d.IsActive
                };
                await new TransactionRepository().InsertInternalAsync(conn, tx, t);

                tx.Commit();
                return depId;
            }
            catch { tx.Rollback(); throw; }
        }
    }

    // Internal helper to avoid new connection for the same tx
    internal static class TransactionRepoExtensions
    {
        internal static async Task<int> InsertInternalAsync(this TransactionRepository _, IDbConnection conn, IDbTransaction tx, Transaction t)
        {
            var sql = @"
INSERT INTO Transactions
(AccountId, Kind, Amount, Memo, PostedUtc, RelatedEntityId, CreatedUtc, CreatedByUserId, IsActive)
VALUES
(@AccountId, @Kind, @Amount, @Memo, @PostedUtc, @RelatedEntityId, @CreatedUtc, @CreatedByUserId, @IsActive);
SELECT LAST_INSERT_ID();";
            return await conn.ExecuteScalarAsync<int>(sql, t, tx);
        }
    }
}

