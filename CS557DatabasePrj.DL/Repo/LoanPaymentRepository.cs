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
        public async Task<int> InsertAsync(LoanPayment p, int fromAccountId)
        {
            using var conn = Open();
            using var tx = conn.BeginTransaction();

            // 1) Lock the paying account and check funds
            var balance = await conn.ExecuteScalarAsync<decimal>(
                "SELECT CurrentBalance FROM Accounts WHERE Id=@id FOR UPDATE;",
                new { id = fromAccountId }, tx);

            if (balance < p.Amount)
                throw new InvalidOperationException("Insufficient funds");

            // 2) Withdraw from paying account
            await conn.ExecuteAsync(
                "UPDATE Accounts SET CurrentBalance = CurrentBalance - @amount WHERE Id=@id;",
                new { amount = p.Amount, id = fromAccountId }, tx);

            // 3) Reduce loan principal
            await conn.ExecuteAsync(@"
UPDATE Loans
SET Principal  = GREATEST(0, Principal - @principalPortion),
    UpdatedUtc = @now,
    UpdatedByUserId = @userId
WHERE Id = @loanId;",
                new
                {
                    principalPortion = p.PrincipalPortion,
                    now = DateTime.UtcNow,
                    userId = p.CreatedByUserId,
                    loanId = p.LoanId
                }, tx);

            // 4) Insert loan payment record
            var sql = @"
INSERT INTO LoanPayments
    (LoanId, Amount, PaidDateUtc,
     PrincipalPortion, InterestPortion, Reference,
     DueDateUTC, CreatedUtc, IsActive, CreatedByUserId)
VALUES
    (@LoanId, @Amount, @PaidDateUtc,
     @PrincipalPortion, @InterestPortion, @Reference,
     @DueDateUtc, @CreatedUtc, @IsActive, @CreatedByUserId);
SELECT LAST_INSERT_ID();";

            var paymentId = await conn.ExecuteScalarAsync<int>(sql, p, tx);

            tx.Commit();
            return paymentId;
        }

    }
}
