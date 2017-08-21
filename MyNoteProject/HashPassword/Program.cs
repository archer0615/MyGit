using System;
using System.Text;
using System.Security.Cryptography;

namespace HashPassword
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = "test123";
            string hashPassword = "";
            Console.WriteLine($"原始密碼為 : {password}");
            Console.WriteLine();
            byte[] source = Encoding.Default.GetBytes(password);//將字串轉為Byte[]

            hashPassword= MD5_Hash(source);
            Console.WriteLine($"MD5加密: {hashPassword}");//輸出結果
            hashPassword= SHA1_Hash(source);
            Console.WriteLine($"SHA1加密: {hashPassword}");//輸出結果
            hashPassword = SHA256_Hash(source);
            Console.WriteLine($"SHA256加密: {hashPassword}");//輸出結果
            hashPassword = SHA384_Hash(source);
            Console.WriteLine($"SHA384加密: {hashPassword}");//輸出結果
            hashPassword = SHA512_Hash(source);
            Console.WriteLine($"SHA512加密: {hashPassword}");//輸出結果
            Console.WriteLine();
        }
        private static string MD5_Hash(byte[] source)
        {
            MD5 md5 = MD5.Create();//建立MD5
            byte[] crypto = md5.ComputeHash(source);//進行MD5加密
            return Convert.ToBase64String(crypto);//把加密後的字串從Byte[]轉為字串
        }
        private static string SHA1_Hash(byte[] source)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();//建立SHA1
            byte[] crypto = sha1.ComputeHash(source);//進行SHA1加密
            return Convert.ToBase64String(crypto);//把加密後的字串從Byte[]轉為字串
        }
        private static string SHA256_Hash(byte[] source)
        {
            SHA256 sha256 = new SHA256CryptoServiceProvider();//建立SHA256
            byte[] crypto = sha256.ComputeHash(source);//進行SHA256加密
            return Convert.ToBase64String(crypto);//把加密後的字串從Byte[]轉為字串
        }
        private static string SHA384_Hash(byte[] source)
        {
            SHA384 sha384 = new SHA384CryptoServiceProvider();//建立SHA384
            byte[] crypto = sha384.ComputeHash(source);//進行SHA384加密
            return Convert.ToBase64String(crypto);//把加密後的字串從Byte[]轉為字串
        }
        private static string SHA512_Hash(byte[] source)
        {
            SHA512 sha512 = new SHA512CryptoServiceProvider();//建立一個SHA512
            byte[] crypto = sha512.ComputeHash(source);//進行SHA512加密
            return Convert.ToBase64String(crypto);//把加密後的字串從Byte[]轉為字串
        }
    }
}
