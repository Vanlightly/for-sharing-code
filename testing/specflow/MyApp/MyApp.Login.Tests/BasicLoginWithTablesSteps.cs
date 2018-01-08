using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyApp.Login.Helpers;
using MyApp.Login.Repositories;
using MyApp.Login.Tests.Helper;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace MyApp.Login.Tests
{
    public class UserRecord
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    [Binding]
    public class BasicLoginWithTablesSteps
    {
        [Given(@"the following users exist:")]
        public void GivenTheFollowingUsersExist(Table table)
        {
            CredentialRepository.Credentials.Clear();
            var users = table.CreateSet<UserRecord>();
            foreach(var user in users)
                CredentialRepository.Credentials.Add(user.Username, Hasher.Sha256(user.Password));
        }
    }
}
