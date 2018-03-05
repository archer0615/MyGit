using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace C_SharpNote.HashPassword
{
    public class Excute
    {
        public static void ConvertPwd()
        {
            string path = Directory.GetCurrentDirectory();
            FileStream fileStream = new FileStream(path + "\\password.txt", FileMode.Create);
            fileStream.Close();
            string password = "013";
            string input = string.Empty;
            Console.WriteLine("輸入-1 結束程式");
            using (StreamWriter sw = new StreamWriter(path + "\\password.txt"))
            {
                do
                {
                    input = string.Empty;
                    Console.WriteLine();
                    Console.WriteLine("請輸入密碼 範例格式 0010001");
                    Console.WriteLine();
                    input = Console.ReadLine();
                    //password += input;
                    //Console.WriteLine(password);
                    if (input != "-1")
                    {
                        sw.WriteLine("密碼: " + input + "            " + "加密後: " + CSharpHash(input));
                    }
                    //password = "009";

                } while (input != "-1");
                sw.Close();
            }
        }
        private static bool condition_1()
        {
            int AMT1 = 1;
            int AMT2 = 0;
            int AMT3 = 0;
            int AMT4 = 0;
            int AMT5 = 0;
            int AMT7 = 0;
            int AMT8 = 0;
            int AMT9 = 0;
            if (AMT1 > 0 || AMT2 > 0 || AMT3 > 0 || AMT4 > 0 ||
                AMT5 > 0 || AMT7 > 0 || AMT8 > 0 || AMT9 > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static bool condition_2()
        {
            string mode = "D";
            if (mode == "D")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static string CSharpHash(string password)
        {
            string hashPassword = "";
            Console.WriteLine($"原始密碼為 : {password}");
            Console.WriteLine();
            byte[] source = Encoding.Default.GetBytes(password);//將字串轉為Byte[]

            //hashPassword = MD5_Hash(source);
            //Console.WriteLine($"MD5加密: {hashPassword}");//輸出結果
            //hashPassword = SHA1_Hash(source);
            //Console.WriteLine($"SHA1加密: {hashPassword}");//輸出結果
            hashPassword = SHA256_Hash(source);
            Console.Write($"SHA256加密: {hashPassword}");//輸出結果
            //hashPassword = SHA384_Hash(source);
            //Console.WriteLine($"SHA384加密: {hashPassword}");//輸出結果
            //hashPassword = SHA512_Hash(source);
            //Console.WriteLine($"SHA512加密: {hashPassword}");//輸出結果
            //Console.Write(hashPassword);
            return hashPassword;
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
