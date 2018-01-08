using MyApp.Login.Entities;
using MyApp.Login.Helpers;
using MyApp.Login.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Login
{
    public class LoginService : ILoginService
    {
        private ICredentialRepository _credentialRepository;
        private IRateMeasureService _rateMeasureService;

        public LoginService(ICredentialRepository credentialRepository,
            IRateMeasureService rateMeasureService)
        {
            _credentialRepository = credentialRepository;
            _rateMeasureService = rateMeasureService;
        }

        // obviously when displaying the result to the user you should not differentiate
        // between wrong username and wrong password!!!
        public LoginResult Login(string username, string password, int limitSeconds=0, int limit=0)
        {
            username = username.ToLower();

            if (limitSeconds > 0)
            {
                _rateMeasureService.Increment(username);
                if (!_rateMeasureService.InsideLimit(username, limitSeconds, limit))
                    return LoginResult.ReachedRateLimit;
            }

            var credential = _credentialRepository.GetStoredCredential(username);
            if (credential == null)
                return LoginResult.UserDoesNotExist;

            var hashedPassword = Hasher.Sha256(password);
            if (!credential.HashedPassword.Equals(hashedPassword))
                return LoginResult.WrongPassword;

            return LoginResult.Success;
        }
    }
}
