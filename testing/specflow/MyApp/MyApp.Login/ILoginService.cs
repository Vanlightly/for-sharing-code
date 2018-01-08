using MyApp.Login.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Login
{
    public interface ILoginService
    {
        LoginResult Login(string username, string password, int limitMinutes, int limit);
    }
}
