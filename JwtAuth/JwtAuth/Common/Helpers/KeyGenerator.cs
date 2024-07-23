using System.Security.Cryptography;

namespace JwtAuth.Common.Helpers
{
    public class KeyGenerator
    {
        /// <summary>
        /// Key generator
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static byte[] GenerateKey(int size)
        {
            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                var key = new byte[size / 8];
                randomNumberGenerator.GetBytes(key);
                return key;
            }
        }
        public static byte[] Key = GenerateKey(256);


    }
}
