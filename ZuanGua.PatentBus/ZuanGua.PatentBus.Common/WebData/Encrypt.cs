using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ZuanGua.PatentBus.Common
{
    public class Encrypt
    {
        #region MD5
        /// <summary>
        /// MD5加密操作
        /// </summary>
        public static string MD5EncryptStr(string source)
        {
            //首先生成一个随机数，并对随机数进行加密
            string randomStr = Md5(new Random().Next(9999).ToString());
            //截取随机数中间位置字符
            randomStr = randomStr.Substring(8, 16);
            //加密数据源
            string epSource = Md5(source);
            //对数据源拆解，并重新组合
            epSource = epSource.Substring(0, 16) + randomStr + epSource.Substring(16, 16);
            return epSource;
        }
        /// <summary>
        /// MD5解密操作
        /// </summary>
        public static bool MD5DecryptStr(string source, string EncryptStr)
        {
            //加密数据源
            string epSource = Md5(source);
            //对已经加密的数据拆解，并重新组合
            string dpSource = EncryptStr.Substring(0, 16) + EncryptStr.Substring(32, 16);
            if (epSource == dpSource)
                return true;
            else
                return false;
        }
        /// <summary>   
        /// MD5加密   
        /// </summary>   
        /// <param name="str"></param>   
        /// <returns></returns>   
        private static string Md5(string str)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.   
            MD5 md5Hasher = MD5.Create();
            // Convert the input string to a byte array and compute the hash.   
            byte[] data = md5Hasher.ComputeHash(Encoding.GetEncoding("UTF-8").GetBytes(str));
            // return BitConverter.ToString(data);//可以直接使用这个方法   
            //  Create a new Stringbuilder to collect the bytes   
            //  and create a string.   
            StringBuilder sBuilder = new StringBuilder();
            // Loop through each byte of the hashed data   
            // and format each one as a hexadecimal string.   
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));//16进制，每次输出两位，整齐
            }
            // Return the hexadecimal string.   
            return sBuilder.ToString();
        }

        /// <summary>
        /// 基础 MD5 加密
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string MD5Str(string str)
        {
            return BitConverter.ToString(MD5.Create().ComputeHash(Encoding.Default.GetBytes(str))).Replace("-", "");
        }
        #endregion

        #region DES
        /// <summary>
        /// 使用默认加密
        /// </summary>
        /// <param name="strText"></param>
        /// <returns></returns>
        public static string DesEncrypt(string strText, string ENCRYPT_KEY, string Type)
        {
            return EncryptTextToMemory(strText, ENCRYPT_KEY, Type);
        }

        /// <summary>
        /// 使用默认解密
        /// </summary>
        /// <param name="strText"></param>
        /// <returns></returns>
        public static string DesDecrypt(string strText, string ENCRYPT_KEY, string Type)
        {
            return DecryptTextFromMemory(strText, ENCRYPT_KEY, Type);
        }
        private static string EncryptTextToMemory(string Data, string strEncrKey, string Type)
        {
            try
            {
                //标准的DES密钥长度为64bit，密钥每个字符占7bit，外加1bit的奇偶校验，64/(7+1)=8。所以必须是8个字符也只能是8个字符。
                byte[] Key = Encoding.UTF8.GetBytes(strEncrKey.Substring(0, 8));

                string vector = string.Empty;
                if (Type == "qy")
                {
                    vector = strEncrKey.Substring(3, 1) + strEncrKey.Substring(6, 1) + strEncrKey.Substring(5, 1) + strEncrKey.Substring(7, 1) + strEncrKey.Substring(2, 1) + strEncrKey.Substring(4, 1) + strEncrKey.Substring(1, 1) + strEncrKey.Substring(0, 1);
                }
                if (Type == "sc")
                {
                    vector = strEncrKey.Substring(4, 1) + strEncrKey.Substring(3, 1) + strEncrKey.Substring(5, 1) + strEncrKey.Substring(2, 1) + strEncrKey.Substring(6, 1) + strEncrKey.Substring(1, 1) + strEncrKey.Substring(7, 1) + strEncrKey.Substring(0, 1);
                }
                if (Type == "pwd")
                {
                    vector = strEncrKey.Substring(7, 1) + strEncrKey.Substring(6, 1) + strEncrKey.Substring(5, 1) + strEncrKey.Substring(4, 1) + strEncrKey.Substring(3, 1) + strEncrKey.Substring(2, 1) + strEncrKey.Substring(1, 1) + strEncrKey.Substring(0, 1);
                }
                if (Type == "all")
                {
                    vector = strEncrKey;
                }

                byte[] IV = Encoding.UTF8.GetBytes(vector.Substring(0, 8));
                // Create a MemoryStream.
                MemoryStream mStream = new MemoryStream();

                // Create a CryptoStream using the MemoryStream 
                // and the passed key and initialization vector (IV).
                CryptoStream cStream = new CryptoStream(mStream,
                    new DESCryptoServiceProvider().CreateEncryptor(Key, IV),
                    CryptoStreamMode.Write);

                // Convert the passed string to a byte array.
                byte[] toEncrypt = Encoding.UTF8.GetBytes(Data);

                // Write the byte array to the crypto stream and flush it.
                cStream.Write(toEncrypt, 0, toEncrypt.Length);
                cStream.FlushFinalBlock();

                // Get an array of bytes from the 
                // MemoryStream that holds the 
                // encrypted data.
                byte[] ret = mStream.ToArray();

                // Close the streams.
                cStream.Close();
                mStream.Close();

                // Return the encrypted buffer.
                return Convert.ToBase64String(ret);
            }
            catch (CryptographicException e)
            {
                return null;
            }
        }

        private static string DecryptTextFromMemory(string sData, string strEncrKey, string Type)
        {
            try
            {
                strEncrKey = strEncrKey.PadLeft(8, '0');
                byte[] Key = Encoding.UTF8.GetBytes(strEncrKey.Substring(0, 8));

                //初始化向量
                string vector = string.Empty;
                if (Type == "qy")
                {
                    vector = strEncrKey.Substring(3, 1) + strEncrKey.Substring(6, 1) + strEncrKey.Substring(5, 1) + strEncrKey.Substring(7, 1) + strEncrKey.Substring(2, 1) + strEncrKey.Substring(4, 1) + strEncrKey.Substring(1, 1) + strEncrKey.Substring(0, 1);
                }
                if (Type == "sc")
                {
                    vector = strEncrKey.Substring(4, 1) + strEncrKey.Substring(3, 1) + strEncrKey.Substring(5, 1) + strEncrKey.Substring(2, 1) + strEncrKey.Substring(6, 1) + strEncrKey.Substring(1, 1) + strEncrKey.Substring(7, 1) + strEncrKey.Substring(0, 1);
                }
                if (Type == "pwd")
                {
                    vector = strEncrKey.Substring(7, 1) + strEncrKey.Substring(6, 1) + strEncrKey.Substring(5, 1) + strEncrKey.Substring(4, 1) + strEncrKey.Substring(3, 1) + strEncrKey.Substring(2, 1) + strEncrKey.Substring(1, 1) + strEncrKey.Substring(0, 1);
                }
                if (Type == "all")
                {
                    vector = strEncrKey;
                }
                byte[] IV = Encoding.UTF8.GetBytes(vector.Substring(0, 8));
                byte[] Data = Convert.FromBase64String(sData);

                // Create a new MemoryStream using the passed 
                // array of encrypted data.
                MemoryStream msDecrypt = new MemoryStream(Data);

                // Create a CryptoStream using the MemoryStream 
                // and the passed key and initialization vector (IV).
                CryptoStream csDecrypt = new CryptoStream(msDecrypt,
                    new DESCryptoServiceProvider().CreateDecryptor(Key, IV),
                    CryptoStreamMode.Read);

                // Create buffer to hold the decrypted data.
                byte[] fromEncrypt = new byte[Data.Length];

                // Read the decrypted data out of the crypto stream
                // and place it into the temporary buffer.
                csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);

                //Convert the buffer into a string and return it.
                //return new ASCIIEncoding().GetString(fromEncrypt);
                return Encoding.UTF8.GetString(fromEncrypt.ToArray());
            }
            catch (CryptographicException e)
            {
                //Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }
        }
        #endregion


        #region base64编码
        /// <summary>
        /// base64编码
        /// </summary>
        /// <returns></returns>
        public static string Base64Encode(string value)
        {
            string result = Convert.ToBase64String(Encoding.Default.GetBytes(value));
            return result;
        }
        /// <summary>
        /// base64解码
        /// </summary>
        /// <returns></returns>
        public static string Base64Decode(string value)
        {
            string result = Encoding.Default.GetString(Convert.FromBase64String(value));
            return result;
        }
        #endregion
    }
}
