using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace SeleniumGridTemplate.Drivers
{
    public class WebDriverFactory
    {
        public static RemoteWebDriver GenerateDriver(string browser)
        {
            DriverOptions? options = null;

            switch (browser)
            {
                default:
                case ("firefox"):
                    {
                        options = new FirefoxOptions();
                        break;
                    }
            }

            var driver = new RemoteWebDriver(new Uri("http://localhost:4444/"), options!);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return driver;
        }
    }
}
