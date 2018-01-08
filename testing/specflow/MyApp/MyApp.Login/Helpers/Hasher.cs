using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Login.Helpers
{
    public class Hasher
    {
        /// <summary>
        /// NOT the state of the art in password hashing! Please
        /// do not use this code for secure hashing of passwords, look at multi-round hashing techniques with salt
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string Sha256(string password)
        {
            SHA256Managed crypt = new SHA256Managed();
            string hash = String.Empty;
            byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(password), 0, Encoding.ASCII.GetByteCount(password));
            foreach (byte theByte in crypto)
            {
                hash += theByte.ToString("x2");
            }
            return hash;
        }
    }
}
