using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DoAnASP.Areas.Admin.Data
{
    public class StringProcess
    {
        public static string CreateMD5Hash(string input)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputByte = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hasByte = md5.ComputeHash(inputByte);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hasByte.Length; i++)
            {
                sb.Append(hasByte[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
