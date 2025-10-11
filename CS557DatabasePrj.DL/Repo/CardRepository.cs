using Dapper;
using CS557DatabasePrj.BL;

namespace CS557DatabasePrj.DL.Repo
{
    public class CardRepository : BaseRepository
    {
        public async Task<IEnumerable<Card>> GetByAccountAsync(int accountId)
        {
            using var conn = Open();
            return await conn.QueryAsync<Card>("SELECT * FROM Cards WHERE AccountId=@accountId;", new { accountId });
        }

        public async Task<int> InsertAsync(Card c)
        {
            using var conn = Open();
            var sql = @"
INSERT INTO Cards
(CardNumberMasked, CardType, ExpirationUtc, CardholderName, AccountId, OwnerUserId, CreatedUtc, CreatedByUserId, IsActive)
VALUES
(@CardNumberMasked, @CardType, @ExpirationUtc, @CardholderName, @AccountId, @OwnerUserId, @CreatedUtc, @CreatedByUserId, @IsActive);
SELECT LAST_INSERT_ID();";
            return await conn.ExecuteScalarAsync<int>(sql, c);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using var conn = Open();
            return (await conn.ExecuteAsync("DELETE FROM Cards WHERE Id=@id;", new { id })) > 0;
        }
    }
}
