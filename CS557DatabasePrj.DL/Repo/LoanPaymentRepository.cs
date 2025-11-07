using Dapper;
using CS557DatabasePrj.BL;

namespace CS557DatabasePrj.DL.Repo
{
    public class LoanPaymentRepository : BaseRepository
    {
        public async Task<IEnumerable<LoanPayment>> GetByLoanAsync(int loanId)
        {
            using var conn = Open();
            return await conn.QueryAsync<LoanPayment>(
                "SELECT * FROM LoanPayments WHERE LoanId=@loanId ORDER BY DueDateUtc;", new { loanId });
        }

        public async Task<int> InsertAsync(LoanPayment p, int accountIdForPayment)
        {
            using var conn = Open();
            using var tx = conn.BeginTransaction();
            try
            {
                // Record payment row
                var pid = await conn.ExecuteScalarAsync<int>(@"
                INSERT INTO LoanPayments
                 (LoanId, Amount, DueDateUtc, PaidDateUtc, PrincipalPortion, InterestPortion, Reference, CreatedUtc, CreatedByUserId, IsActive)
                 VALUES
                 (@LoanId, @Amount, @DueDateUtc, @PaidDateUtc, @PrincipalPortion, @InterestPortion, @Reference, @CreatedUtc, @CreatedByUserId, @IsActive);
                SELECT LAST_INSERT_ID();", p, tx);

                // Decrease payer account balance
                await conn.ExecuteAsync(
                    "UPDATE Accounts SET CurrentBalance = CurrentBalance - @a WHERE Id=@id;",
                    new { a = p.Amount, id = accountIdForPayment }, tx);

                // History entry
                var t = new Transaction
                {
                    AccountId = accountIdForPayment,
                    Kind = TransactionKind.Payment,
                    Amount = p.Amount,
                    Memo = $"Loan payment (LoanId={p.LoanId}) Ref: {p.Reference}",
                    PostedUtc = p.PaidDateUtc ?? p.DueDateUtc,
                    RelatedEntityId = pid,
                    CreatedUtc = p.CreatedUtc,
                    CreatedByUserId = p.CreatedByUserId,
                    IsActive = p.IsActive
                };
                await new TransactionRepository().InsertInternalAsync(conn, tx, t);

                tx.Commit();
                return pid;
            }
            catch { tx.Rollback(); throw; }
        }
    }
}
