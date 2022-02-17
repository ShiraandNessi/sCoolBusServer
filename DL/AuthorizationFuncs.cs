using DL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
   public class AuthorizationFuncs: IAuthorizationFuncs
    {
        public  SchoolBusContext _schoolBusContext { get; set; }
        public  AuthorizationFuncs(SchoolBusContext SchoolBusContext)
        {
            _schoolBusContext = SchoolBusContext;
        }
        public  bool isAthorized(int id,int userType)
        {
            User d = _schoolBusContext.Users.Find(id);
            int x = userType + 1;
            if (d.UserTypeId == x || d.UserTypeId == (int)UserTypeEnum.Manager+1)
            {
                return true;
            }
            else
            {
    
                return false;
            }
        }
        public string GenerateSalt(int nSalt)
        {
            var saltBytes = new byte[nSalt];

            using (var provider = new RNGCryptoServiceProvider())
            {
                provider.GetNonZeroBytes(saltBytes);
            }

            return Convert.ToBase64String(saltBytes);
        }

        public string HashPassword(string password, string salt, int nIterations, int nHash)
        {
            var saltBytes = Convert.FromBase64String(salt);
            //Iteration count is the number of times an operation is performed
            using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, nIterations))
            {
                return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(nHash));
            }
        }

        public static byte[] GetHash(string password, string salt)
        {
            byte[] unhashedBytes = Encoding.Unicode.GetBytes(String.Concat(salt, password));

            SHA256Managed sha256 = new SHA256Managed();
            byte[] hashedBytes = sha256.ComputeHash(unhashedBytes);

            return hashedBytes;
        }

        public static bool CompareHash(string attemptedPassword, byte[] hash, string salt)
        {
            string base64Hash = Convert.ToBase64String(hash);
            string base64AttemptedHash = Convert.ToBase64String(GetHash(attemptedPassword, salt));

            return base64Hash == base64AttemptedHash;
        }
    }
}

