using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag_Go.DAL
{
    public static class Hash
    {
        public static string HashPassword(string pwd)
        {
            return BCrypt.Net.BCrypt.HashPassword(pwd);
        }
        public static bool VerifyPassword(string enteredpassword, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(enteredpassword, hashedPassword);
        }
    }
}
