using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CaribeResortLib.Models.Helpers
{
    public class EncriptacionHelper
    {
        public static string SHA256Encrypt(string source)
        {
            try
            {
                StringBuilder Sb = new StringBuilder();
                using (SHA256 hash = SHA256Managed.Create())
                {
                    Encoding enc = Encoding.UTF8;
                    Byte[] result = hash.ComputeHash(enc.GetBytes(source));

                    foreach (Byte b in result)
                        Sb.Append(b.ToString("x2"));
                }
                return Sb.ToString();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message);
                return String.Empty;
            }
        }
    }
}
