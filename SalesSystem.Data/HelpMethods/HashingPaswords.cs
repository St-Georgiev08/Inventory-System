using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem.Data.HelpMethods
{
    public class HashingPaswords
    {
        public async Task<string> HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }

        }

        public async Task<bool> VerifyPassword(string password, string passwordHash)
        {
            string hashOfInput = await HashPassword(password);
            if(StringComparer.OrdinalIgnoreCase.Compare(hashOfInput, passwordHash) == 0)
                return true;
            return false;
        }
    }
}
