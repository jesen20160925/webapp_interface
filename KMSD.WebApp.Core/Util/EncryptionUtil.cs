using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KMSD.WebApp.Core.Util
{
    public class EncryptionUtil
    {
        public static string MD5(string value)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.Default.GetBytes(value);
            byte[] md5data = md5.ComputeHash(data);
            md5.Clear();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < md5data.Length - 1; i++)
            {
                sb.Append(md5data[i].ToString("x").PadLeft(2, '0'));
            }
            return sb.ToString();
        }
    }
}
