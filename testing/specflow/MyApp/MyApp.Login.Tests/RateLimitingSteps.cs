using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyApp.Login.Entities;
using MyApp.Login.Tests.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace MyApp.Login.Tests
{
    [Binding]
    public class RateLimitingSteps
    {
        [Given(@"the limit period is (.*) seconds")]
        public void GivenTheLimitPeriodIsSeconds(int p0)
        {
            ScenarioContext.Current.Add("period", p0);
        }
        
        [Given(@"the limit in that period is (.*)")]
        public void GivenTheLimitInThatPeriodIs(int p0)
        {
            ScenarioContext.Current.Add("limit", p0);
        }
        
        [When(@"(.*) logins with (.*) seconds delay are attempted with user '(.*)' and password '(.*)'")]
        public void WhenLoginsWithSecondsDelayAreAttemptedWithUserAndPassword(int p0, int p1, string p2, string p3)
        {
            int periodSeconds = (int)ScenarioContext.Current["period"];
            int limit = (int)ScenarioContext.Current["limit"];
            var sut = SutFactory.CreateLoginService();

            var results = new List<LoginResult>();
            for (int i = 0; i < p0; i++)
            {
                var result = sut.Login(p2, p3, periodSeconds, limit);
                results.Add(result);
                
                if (i < p0-1)
                    Thread.Sleep(p1 * 1000);
            }

            ScenarioContext.Current.Add("results", results);
        }
        
        [Then(@"the results should be '(.*)'")]
        public void ThenTheResultsShouldBe(List<string> p0)
        {
            var expectedStr = string.Join(",", p0);
            var results = (List<LoginResult>)ScenarioContext.Current["results"];
            var resultsStr = string.Join(",", results.Select(x => x.ToString()));
            Assert.AreEqual(expectedStr, resultsStr);
        }

        [StepArgumentTransformation]
        public List<String> TransformToListOfString(string commaSeparatedList)
        {
            return commaSeparatedList.Split(',').ToList();
        }
    }
}
