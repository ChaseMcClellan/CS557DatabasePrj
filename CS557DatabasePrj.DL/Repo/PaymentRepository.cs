using CS557DatabasePrj.BL;
using Dapper;
using System;
using System.Threading.Tasks;
using System.Data;

namespace CS557DatabasePrj.DL.Repo
{
    public class PaymentRepository : BaseRepository
    {
        public async Task<int> MakePaymentAsync(int accountId, decimal amount, string memo, int createdByUserId)
        {
            using var conn = Open();
            using var tx = conn.BeginTransaction();

            try
            {
                var bal = await conn.ExecuteScalarAsync<decimal>(
                    "SELECT CurrentBalance FROM Accounts WHERE Id=@id FOR UPDATE;",
                    new { id = accountId }, tx);

                if (bal < amount)
                    throw new InvalidOperationException("Insufficient funds.");

                await conn.ExecuteAsync(
                    "UPDATE Accounts SET CurrentBalance = CurrentBalance - @amt WHERE Id=@acct;",
                    new { amt = amount, acct = accountId }, tx);

                var t = new Transaction
                {
                    AccountId = accountId,
                    Kind = TransactionKind.Payment,
                    Amount = amount,
                    Memo = memo,
                    PostedUtc = DateTime.UtcNow,
                    RelatedEntityId = null,
                    CreatedUtc = DateTime.UtcNow,
                    CreatedByUserId = createdByUserId,
                    IsActive = true
                };

                int txId = await new TransactionRepository()
                    .InsertInternalAsync(conn, tx, t);

                tx.Commit();
                return txId;
            }
            catch
            {
                tx.Rollback();
                throw;
            }
        }
    }
}
