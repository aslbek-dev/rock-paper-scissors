using System.Security.Cryptography;
namespace rock_paper_scissors.Models
{
    public class KeyGenerator
    {
        public static byte[] GenerateKey()
        {
            byte[] key = new byte[32];
            using (var randomNumber = RandomNumberGenerator.Create())
            {
                randomNumber.GetBytes(key);
            }
            return key;
        }
    }
}