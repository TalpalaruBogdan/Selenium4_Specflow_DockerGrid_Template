using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using SeleniumGridTemplate.Pages;
using System;
using TechTalk.SpecFlow;

namespace SeleniumGridTemplate.StepDefinitions
{
    [Binding]
    public class GoogleSearchStepDefinitions
    {
        private SearchPage _searchPage;
        private ScenarioContext _scenarioContext;
        private RemoteWebDriver _driver;

        public GoogleSearchStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<RemoteWebDriver>("Driver");
            _searchPage = new SearchPage(_driver);
        }

        [Given(@"I am on the google search page")]
        public void GivenIAmOnTheGoogleSearchPage()
        {
            _searchPage.NavigateToSearchPage();
        }

        [When(@"I search for term '([^']*)'")]
        public void WhenISearchForTerm(string music)
        {
            throw new PendingStepException();
        }

        [Then(@"Then I should see results for search '([^']*)'")]
        public void ThenThenIShouldSeeResultsForSearch(string music)
        {
            throw new PendingStepException();
        }
    }
}
