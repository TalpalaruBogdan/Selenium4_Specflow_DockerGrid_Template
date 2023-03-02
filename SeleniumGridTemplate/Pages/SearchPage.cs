using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace SeleniumGridTemplate.Pages
{
    public class SearchPage
    {
        private RemoteWebDriver driver;

        public SearchPage(RemoteWebDriver driver)
        {
            this.driver = driver;
        }

        private const string URL = "https://www.google.com/";

        public SearchPage NavigateToSearchPage()
        {
            driver.Navigate().GoToUrl(URL);
            return this;
        }
    }
}
