using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BusinessLayer.Utilities
{
    public class HashingHelper
    {
        // **** AdminLogin****
        public static void CreatePasswordAndMailHash(string email, string password, out byte[] emailHash, out byte[] passwordHash, out byte[] passwordSalt )
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                emailHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(email));
            }
        }

        public static bool VerifyPasswordAndMailHash(string email, string password, byte[] emailHash, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedPasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedPasswordHash.Length; i++)
                {
                    if (computedPasswordHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }

                var computedEmailHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(email));
                for (int i = 0; i < computedEmailHash.Length; i++)
                {
                    if (computedEmailHash[i] != emailHash[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        // **WriterLogin****
        public static void CreatePasswordHash( string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedPasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedPasswordHash.Length; i++)
                {
                    if (computedPasswordHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
