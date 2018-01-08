using MyApp.Login.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Login.Repositories
{
    public interface ICredentialRepository
    {
        StoredUserCredential GetStoredCredential(string username);
    }
}
