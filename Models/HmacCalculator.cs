using System;
using System.Security.Cryptography;
using System.Text;

namespace rock_paper_scissors.Models
{
    public class HmacCalculator
    {
        public static string CalculateHMAC(string move, byte[] key)
        {
            byte[] moveBytes = Encoding.UTF8.GetBytes(move);
            using (var hmac = new HMACSHA256(key))
            {
                byte[] hmacBytes = hmac.ComputeHash(moveBytes);
                return BitConverter.ToString(hmacBytes).Replace("-", "");
            }
        }
    }
}