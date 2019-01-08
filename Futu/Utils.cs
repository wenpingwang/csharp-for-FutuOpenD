using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Futu
{
    public class Utils
    {
        internal static long currentTimeMillis()
        {

            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return (long)ts.TotalMilliseconds;
        }
        internal static byte[] SHA1_Encrypt(byte[] source)
        {

            HashAlgorithm iSHA = new SHA1CryptoServiceProvider();
            source = iSHA.ComputeHash(source);
            return source;
        }

    }
}
