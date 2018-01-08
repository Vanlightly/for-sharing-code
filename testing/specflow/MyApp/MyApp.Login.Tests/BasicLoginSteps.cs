using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyApp.Login.Helpers;
using MyApp.Login.Repositories;
using MyApp.Login.Tests.Helper;
using System;
using TechTalk.SpecFlow;

namespace MyApp.Login.Tests
{
    [Binding]
    public class BasicLoginSteps
    {
        [Given(@"that the user '(.*)' exists and his password is '(.*)'")]
        public void GivenThatTheUserExistsAndHisPasswordIs(string p0, string p1)
        {
            CredentialRepository.Credentials.Clear();
            CredentialRepository.Credentials.Add(p0, Hasher.Sha256(p1));
        }
        
        [When(@"the username '(.*)' with password '(.*)' is supplied")]
        public void WhenTheUsernameWithPasswordIsSupplied(string p0, string p1)
        {
            var sut = SutFactory.CreateLoginService();
            var result = sut.Login(p0, p1);
            ScenarioContext.Current.Add("result", result);
        }
        
        [Then(@"the result should be '(.*)'")]
        public void ThenTheResultShouldBe(string p0)
        {
            Assert.AreEqual(p0, ScenarioContext.Current["result"].ToString());
        }
    }
}
