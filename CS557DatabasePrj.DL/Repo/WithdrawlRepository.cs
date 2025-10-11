using Dapper;
using CS557DatabasePrj.BL;

namespace CS557DatabasePrj.DL.Repo
{
    public class WithdrawalRepository : BaseRepository
    {
        public async Task<int> InsertAsync(Withdrawal w)
        {
            using var conn = Open();
            using var tx = conn.BeginTransaction();
            try
            {
                // 1) Ensure sufficient balance (simple check)
                var bal = await conn.ExecuteScalarAsync<decimal>(
                    "SELECT CurrentBalance FROM Accounts WHERE Id=@id FOR UPDATE;", new { id = w.AccountId }, tx);
                if (bal < w.Amount) throw new InvalidOperationException("Insufficient funds.");

                // 2) Insert withdrawal
                var wid = await conn.ExecuteScalarAsync<int>(@"
INSERT INTO Withdrawals
(AccountId, Amount, Method, ProcessedUtc, CreatedUtc, CreatedByUserId, IsActive)
VALUES
(@AccountId, @Amount, @Method, @ProcessedUtc, @CreatedUtc, @CreatedByUserId, @IsActive);
SELECT LAST_INSERT_ID();", w, tx);

                // 3) Update balance
                await conn.ExecuteAsync(
                    "UPDATE Accounts SET CurrentBalance = CurrentBalance - @amt WHERE Id=@acct;",
                    new { amt = w.Amount, acct = w.AccountId }, tx);

                // 4) History
                var t = new Transaction
                {
                    AccountId = w.AccountId,
                    Kind = TransactionKind.Withdrawal,
                    Amount = w.Amount,
                    Memo = w.Method,
                    PostedUtc = w.ProcessedUtc,
                    RelatedEntityId = wid,
                    CreatedUtc = w.CreatedUtc,
                    CreatedByUserId = w.CreatedByUserId,
                    IsActive = w.IsActive
                };
                await new TransactionRepository().InsertInternalAsync(conn, tx, t);

                tx.Commit();
                return wid;
            }
            catch { tx.Rollback(); throw; }
        }
    }
}
