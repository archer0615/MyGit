using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerDAL.Helpers
{
    public class HashPassword
    {
        public static string HashPwd(string inputPwd)
        {
            string hashPwd = string.Empty;
            hashPwd = CSharpHash(inputPwd);
            return hashPwd;
        }

        private static string CSharpHash(string inputPwd)
        {
            byte[] source = Encoding.Default.GetBytes(inputPwd);
            return SHA256_Hash(source);
        }

        private static string SHA256_Hash(byte[] source)
        {
            SHA256 sha256 = new SHA256CryptoServiceProvider();//建立SHA256
            byte[] crypto = sha256.ComputeHash(source);//進行SHA256加密
            return Convert.ToBase64String(crypto);//把加密後的字串從Byte[]轉為字串
        }
    }
}
