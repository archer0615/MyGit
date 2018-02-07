using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AngularMvcWeb.Extensions.helper
{
    public class EncryptionHelper
    {
        public static string GetSHA256Hash(string input)
        {
            SHA256 sha256 = new SHA256CryptoServiceProvider();
            var hash = sha256.ComputeHash(Encoding.Default.GetBytes(input));
            string result = Convert.ToBase64String(hash);

            return result;
        }
        public static string GetMD5Hash(string input)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            string result = string.Concat(hash.Select(x => x.ToString("X2")));

            return result;
        }
        /// <summary>
        /// HMACSHA並轉換Base64String
        /// </summary>
        /// <param name="APIKey"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string EncryptionHMACSHA1Base64(string APIKey, string data)
        {
            byte[] key = Encoding.UTF8.GetBytes(APIKey);
            HMACSHA1 sha1 = new HMACSHA1(key);
            byte[] source = Encoding.UTF8.GetBytes(data);
            byte[] crypto = sha1.ComputeHash(source);
            return Convert.ToBase64String(crypto);
        }
    }
}