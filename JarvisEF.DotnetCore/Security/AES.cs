using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace JarvisEF.DotnetCore.Security
{
    /*
     * 사용 샘플
        string 암호키 = "dlwkdruathdWJD!skd923Z@#Q9ak0803";
        string strText = "동해물과 백두산이 !@#$";
        
        var 암호화 = AES256.AES_encrypt(strText, 암호키);
        var 복호화 = AES256.AES_decrypt(암호화, 암호키);
    */
    public class AES
    {
        public static String AES_encrypt(String Input, String key)
        {
            var aes = System.Security.Cryptography.Aes.Create();
            aes.KeySize = 256;
            aes.BlockSize = 128;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            aes.Key = Encoding.UTF8.GetBytes(key);
            //aes.IV = Encoding.UTF8.GetBytes("HrPtH4kvhKjVsPU=");
            //aes.IV = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            aes.IV = new byte[] { 0, 1, 0, 3, 2, 2, 8, 0, 2, 6, 4, 0, 8, 0, 3, 0 };

            var encrypt = aes.CreateEncryptor(aes.Key, aes.IV);
            byte[] xBuff = null;
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, encrypt, CryptoStreamMode.Write))
                {
                    byte[] xXml = Encoding.UTF8.GetBytes(Input);
                    cs.Write(xXml, 0, xXml.Length);
                }

                xBuff = ms.ToArray();
            }

            String Output = Convert.ToBase64String(xBuff);
            return Output;
        }

        public static String AES_decrypt(String Input, String key)
        {
            var aes = System.Security.Cryptography.Aes.Create();
            aes.KeySize = 256;
            aes.BlockSize = 128;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            aes.Key = Encoding.UTF8.GetBytes(key);
            //aes.IV = Encoding.UTF8.GetBytes("HrPtH4kvhKjVsPU=");
            //aes.IV = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            aes.IV = new byte[] { 0, 1, 0, 3, 2, 2, 8, 0, 2, 6, 4, 0, 8, 0, 3, 0 };

            var decrypt = aes.CreateDecryptor();
            byte[] xBuff = null;
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, decrypt, CryptoStreamMode.Write))
                {
                    byte[] xXml = Convert.FromBase64String(Input);
                    cs.Write(xXml, 0, xXml.Length);
                }

                xBuff = ms.ToArray();
            }

            String Output = Encoding.UTF8.GetString(xBuff);
            return Output;
        }
    }
}