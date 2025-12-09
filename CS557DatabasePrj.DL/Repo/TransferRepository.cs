using Dapper;
using CS557DatabasePrj.BL;

namespace CS557DatabasePrj.DL.Repo
{
    public class TransferRepository : BaseRepository
    {
        public async Task<int> InsertAsync(Transfer tr)
        {
            using var conn = Open();
            using var tx = conn.BeginTransaction();

            try
            {
                // Lock both accounts (order by id to avoid deadlocks)
                var fromBal = await conn.ExecuteScalarAsync<decimal>(
                    "SELECT CurrentBalance FROM Accounts WHERE Id=@id FOR UPDATE;", new { id = tr.FromAccountId }, tx);
                await conn.ExecuteScalarAsync<decimal>(
                    "SELECT CurrentBalance FROM Accounts WHERE Id=@id FOR UPDATE;", new { id = tr.ToAccountId }, tx);

                if (fromBal < tr.Amount) throw new InvalidOperationException("Insufficient funds.");

                // 1) Insert transfer
                var tid = await conn.ExecuteScalarAsync<int>(
                  @"
                  INSERT INTO Transfers
                  (FromAccountId, ToAccountId, InitiatedByUserId, Amount, Memo, ExecutedUtc, CreatedUtc, CreatedByUserId, IsActive)
                  VALUES
                  (@FromAccountId, @ToAccountId, @InitiatedByUserId, @Amount, @Memo, @ExecutedUtc, @CreatedUtc, @CreatedByUserId, @IsActive);
                  SELECT LAST_INSERT_ID();", tr, tx);

                // 2) Update balances
                await conn.ExecuteAsync("UPDATE Accounts SET CurrentBalance = CurrentBalance - @a WHERE Id=@id;",
                    new { a = tr.Amount, id = tr.FromAccountId }, tx);
                await conn.ExecuteAsync("UPDATE Accounts SET CurrentBalance = CurrentBalance + @a WHERE Id=@id;",
                    new { a = tr.Amount, id = tr.ToAccountId }, tx);

                // 3) History (two rows)
                var hist = new TransactionRepository();
                await hist.InsertInternalAsync(conn, tx, new Transaction
                {
                    AccountId = tr.FromAccountId,
                    Kind = TransactionKind.Transfer,
                    Amount = tr.Amount,
                    Memo = $"Transfer to #{tr.ToAccountId}: {tr.Memo}",
                    PostedUtc = tr.ExecutedUtc,
                    RelatedEntityId = tid,
                    CreatedUtc = tr.CreatedUtc,
                    CreatedByUserId = tr.CreatedByUserId,
                    IsActive = tr.IsActive
                });
                await hist.InsertInternalAsync(conn, tx, new Transaction
                {
                    AccountId = tr.ToAccountId,
                    Kind = TransactionKind.Transfer,
                    Amount = tr.Amount,
                    Memo = $"Transfer from #{tr.FromAccountId}: {tr.Memo}",
                    PostedUtc = tr.ExecutedUtc,
                    RelatedEntityId = tid,
                    CreatedUtc = tr.CreatedUtc,
                    CreatedByUserId = tr.CreatedByUserId,
                    IsActive = tr.IsActive
                });

                tx.Commit();
                return tid;
            }
            catch { tx.Rollback(); throw; }
        }
    }
}
