using System;
using System.Security.Cryptography;
using System.Text;
using BCrypt.Net;

namespace CS557DatabasePrj.Security
{
    public static class CryptoService
    {
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, workFactor: 12);
        }

        public static bool VerifyPassword(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }

        private static readonly string _ssnSalt = "BANK_APP_SECRET_2025";

        public static string HashSSN(string ssn)
        {
            using var sha = SHA256.Create();
            var raw = Encoding.UTF8.GetBytes(ssn + _ssnSalt);
            var hash = sha.ComputeHash(raw);
            return Convert.ToBase64String(hash);
        }
    }
}
