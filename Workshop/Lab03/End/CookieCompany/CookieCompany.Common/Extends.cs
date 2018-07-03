using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CookieCompany.Common
{
    public static class Extends
    {

        public static string GetToken(this string value)
            => Convert.ToBase64String(Aes.Create().Key);

        public static bool IsPar(this int value)
            => value % 2 == 0;
    }
}
