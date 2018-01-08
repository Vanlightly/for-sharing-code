using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Login.Entities
{
    public class StoredUserCredential
    {
        public StoredUserCredential(string userName, string hashedPassword)
        {
            UserName = userName;
            HashedPassword = hashedPassword;
        }

        public string UserName { get; set; }
        public string HashedPassword { get; set; }
    }
}
