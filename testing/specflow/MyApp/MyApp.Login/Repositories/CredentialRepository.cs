using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Login.Entities;
using MyApp.Login.Helpers;

namespace MyApp.Login.Repositories
{
    public class CredentialRepository : ICredentialRepository
    {
        public static Dictionary<string, string> Credentials = new Dictionary<string, string>();

        public StoredUserCredential GetStoredCredential(string username)
        {
            if(Credentials.ContainsKey(username))
            {
                return new StoredUserCredential(username, Credentials[username]);
            }

            return null;
        }
    }
}
