using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace C_SharpNote.HashPassword
{
    public enum EncoderType
    {
        //可逆編碼(對稱金鑰)
        AES,
        DES,
        RC2,
        TripleDES,

        //可逆編碼(非對稱金鑰)
        RSA,

        //不可逆編碼(雜湊值)
        MD5,
        SHA1,
        SHA256,
        SHA384,
        SHA512
    }
    public class Encoder
    {
        public string Key { get; set; }
        public string IV { get; set; }
        public void GenerateKey(EncoderType type)
        {
            switch (type)
            {
                case EncoderType.AES:
                    using (AesCryptoServiceProvider csp = new AesCryptoServiceProvider())
                    {
                        csp.GenerateIV();
                        IV = Convert.ToBase64String(csp.IV);
                        csp.GenerateKey();
                        Key = Convert.ToBase64String(csp.Key);
                    }
                    break;
                case EncoderType.DES:
                    using (DESCryptoServiceProvider csp = new DESCryptoServiceProvider())
                    {
                        csp.GenerateIV();
                        IV = Convert.ToBase64String(csp.IV);
                        csp.GenerateKey();
                        Key = Convert.ToBase64String(csp.Key);
                    }
                    break;
                case EncoderType.RC2:
                    using (RC2CryptoServiceProvider csp = new RC2CryptoServiceProvider())
                    {
                        csp.GenerateIV();
                        IV = Convert.ToBase64String(csp.IV);
                        csp.GenerateKey();
                        Key = Convert.ToBase64String(csp.Key);
                    }
                    break;
                case EncoderType.TripleDES:
                    using (TripleDESCryptoServiceProvider csp = new TripleDESCryptoServiceProvider())
                    {
                        csp.GenerateIV();
                        IV = Convert.ToBase64String(csp.IV);
                        csp.GenerateKey();
                        Key = Convert.ToBase64String(csp.Key);
                    }
                    break;
                case EncoderType.RSA:
                    using (RSACryptoServiceProvider csp = new RSACryptoServiceProvider())
                    {
                        IV = "";
                        Key = csp.ToXmlString(true);
                    }
                    break;
                default:
                    break;
            }
        }
        public string Encrypt(EncoderType type, string encrypt)
        {
            string ret = "";
            byte[] inputByteArray = Encoding.UTF8.GetBytes(encrypt);
            byte[] rgbKey = Convert.FromBase64String(Key);
            byte[] rgbIV = Convert.FromBase64String(IV);
            switch (type)
            {
                case EncoderType.AES:
                    using (AesCryptoServiceProvider csp = new AesCryptoServiceProvider())
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            using (CryptoStream cs = new CryptoStream(ms, csp.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write))
                            {
                                cs.Write(inputByteArray, 0, inputByteArray.Length);
                                cs.FlushFinalBlock();
                                ret = Convert.ToBase64String(ms.ToArray());
                            }
                        }
                    }
                    break;
                case EncoderType.DES:
                    using (DESCryptoServiceProvider csp = new DESCryptoServiceProvider())
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            using (CryptoStream cs = new CryptoStream(ms, csp.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write))
                            {
                                cs.Write(inputByteArray, 0, inputByteArray.Length);
                                cs.FlushFinalBlock();
                                ret = Convert.ToBase64String(ms.ToArray());
                            }
                        }
                    }
                    break;
                case EncoderType.RC2:
                    using (RC2CryptoServiceProvider csp = new RC2CryptoServiceProvider())
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            using (CryptoStream cs = new CryptoStream(ms, csp.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write))
                            {
                                cs.Write(inputByteArray, 0, inputByteArray.Length);
                                cs.FlushFinalBlock();
                                ret = Convert.ToBase64String(ms.ToArray());
                            }
                        }
                    }
                    break;
                case EncoderType.TripleDES:
                    using (TripleDESCryptoServiceProvider csp = new TripleDESCryptoServiceProvider())
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            using (CryptoStream cs = new CryptoStream(ms, csp.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write))
                            {
                                cs.Write(inputByteArray, 0, inputByteArray.Length);
                                cs.FlushFinalBlock();
                                ret = Convert.ToBase64String(ms.ToArray());
                            }
                        }
                    }
                    break;
                case EncoderType.RSA:
                    using (RSACryptoServiceProvider csp = new RSACryptoServiceProvider())
                    {
                        csp.FromXmlString(Key);
                        ret = Convert.ToBase64String(csp.Encrypt(inputByteArray, false));
                    }
                    break;
                case EncoderType.MD5:
                    using (MD5CryptoServiceProvider csp = new MD5CryptoServiceProvider())
                    {
                        ret = BitConverter.ToString(csp.ComputeHash(inputByteArray)).Replace("-", string.Empty);
                    }
                    break;
                case EncoderType.SHA1:
                    using (SHA1CryptoServiceProvider csp = new SHA1CryptoServiceProvider())
                    {
                        ret = BitConverter.ToString(csp.ComputeHash(inputByteArray)).Replace("-", string.Empty);
                    }
                    break;
                case EncoderType.SHA256:
                    using (SHA256CryptoServiceProvider csp = new SHA256CryptoServiceProvider())
                    {
                        ret = BitConverter.ToString(csp.ComputeHash(inputByteArray)).Replace("-", string.Empty);
                    }
                    break;
                case EncoderType.SHA384:
                    using (SHA384CryptoServiceProvider csp = new SHA384CryptoServiceProvider())
                    {
                        ret = BitConverter.ToString(csp.ComputeHash(inputByteArray)).Replace("-", string.Empty);
                    }
                    break;
                case EncoderType.SHA512:
                    using (SHA512CryptoServiceProvider csp = new SHA512CryptoServiceProvider())
                    {
                        ret = BitConverter.ToString(csp.ComputeHash(inputByteArray)).Replace("-", string.Empty);
                    }
                    break;
            }
            return ret;
        }
        public string Decrypt(EncoderType type, string decrypt)
        {
            string ret = "";
            byte[] inputByteArray = Convert.FromBase64String(decrypt);
            byte[] rgbKey = Convert.FromBase64String(Key);
            byte[] rgbIV = Convert.FromBase64String(IV);

            switch (type)
            {
                //可逆編碼(對稱金鑰)
                case EncoderType.AES:
                    using (AesCryptoServiceProvider csp = new AesCryptoServiceProvider())
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            using (CryptoStream cs = new CryptoStream(ms, csp.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write))
                            {
                                cs.Write(inputByteArray, 0, inputByteArray.Length);
                                cs.FlushFinalBlock();
                                ret = Encoding.UTF8.GetString(ms.ToArray());
                            }
                        }
                    }
                    break;
                case EncoderType.DES:
                    using (DESCryptoServiceProvider csp = new DESCryptoServiceProvider())
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            using (CryptoStream cs = new CryptoStream(ms, csp.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write))
                            {
                                cs.Write(inputByteArray, 0, inputByteArray.Length);
                                cs.FlushFinalBlock();
                                ret = Encoding.UTF8.GetString(ms.ToArray());
                            }
                        }
                    }
                    break;
                case EncoderType.RC2:
                    using (RC2CryptoServiceProvider csp = new RC2CryptoServiceProvider())
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            using (CryptoStream cs = new CryptoStream(ms, csp.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write))
                            {
                                cs.Write(inputByteArray, 0, inputByteArray.Length);
                                cs.FlushFinalBlock();
                                ret = Encoding.UTF8.GetString(ms.ToArray());
                            }
                        }
                    }
                    break;
                case EncoderType.TripleDES:
                    using (TripleDESCryptoServiceProvider csp = new TripleDESCryptoServiceProvider())
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            using (CryptoStream cs = new CryptoStream(ms, csp.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write))
                            {
                                cs.Write(inputByteArray, 0, inputByteArray.Length);
                                cs.FlushFinalBlock();
                                ret = Encoding.UTF8.GetString(ms.ToArray());
                            }
                        }
                    }
                    break;
                //可逆編碼(非對稱金鑰)
                case EncoderType.RSA:
                    using (RSACryptoServiceProvider csp = new RSACryptoServiceProvider())
                    {
                        csp.FromXmlString(Key);
                        ret = Encoding.UTF8.GetString(csp.Decrypt(inputByteArray, false));
                    }
                    break;
            }
            return ret;
        }
    }
}
