using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace DuneBuggy.Businesslayer.Helpers
{
    public static class PasswordHelper
    {
        public static string GetSHA512Hash(string str)
        {
            using (SHA512Managed sha512 = new SHA512Managed())
            {
                string hash = String.Join(String.Empty, sha512.ComputeHash(Encoding.UTF8.GetBytes(str)).Select(x => x.ToString("X")));
                return hash;
            }
        }
    }
}