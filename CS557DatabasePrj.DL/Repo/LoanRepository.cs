using Dapper;
using CS557DatabasePrj.BL;

namespace CS557DatabasePrj.DL.Repo
{
    public class LoanRepository : BaseRepository
    {
        public async Task<Loan?> GetByAccountAsync(int accountId)
        {
            using var conn = Open();
            return await conn.QuerySingleOrDefaultAsync<Loan>("SELECT * FROM Loans WHERE AccountId=@accountId;", new { accountId });
        }

        public async Task<int> InsertAsync(Loan l)
        {
            using var conn = Open();
            var sql = @"
              INSERT INTO Loans
              (AccountId, Principal, AnnualInterestRate, TermMonths, StartUtc, Status, CreatedUtc, CreatedByUserId, IsActive)
              VALUES
              (@AccountId, @Principal, @AnnualInterestRate, @TermMonths, @StartUtc, @Status, @CreatedUtc, @CreatedByUserId, @IsActive);
              SELECT LAST_INSERT_ID();";
            return await conn.ExecuteScalarAsync<int>(sql, l);
        }

        public async Task<bool> UpdateAsync(Loan l)
        {
            using var conn = Open();
            var sql = @"
            UPDATE Loans SET
             Principal=@Principal, AnnualInterestRate=@AnnualInterestRate, TermMonths=@TermMonths,
             StartUtc=@StartUtc, Status=@Status,
             UpdatedUtc=@UpdatedUtc, UpdatedByUserId=@UpdatedByUserId, IsActive=@IsActive
            WHERE Id=@Id;";
            return (await conn.ExecuteAsync(sql, l)) > 0;
        }
    }
}
