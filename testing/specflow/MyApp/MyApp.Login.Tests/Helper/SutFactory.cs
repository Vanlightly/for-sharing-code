using MyApp.Login.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Login.Tests.Helper
{
    public class SutFactory
    {
        public static LoginService CreateLoginService()
        {
            return new LoginService(new CredentialRepository(), new RateMeasureService());
        }
    }
}
