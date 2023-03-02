using DotNet.Testcontainers.Builders;
using OpenQA.Selenium.Remote;
using SeleniumGridTemplate.Drivers;

namespace SeleniumGridTemplate.Hooks
{
    [Binding]
    public class TestHooks
    {
        private RemoteWebDriver _driver;
        private ScenarioContext _scenarioContnext;

        public TestHooks(ScenarioContext scenarioContext)
        {
            _scenarioContnext = scenarioContext;
        }

        [BeforeTestRun]
        public static async Task BeforeTestRun()
        {
            // Start docker selenium grid
            var network = new NetworkBuilder()
                .WithName("SeleniumGridNetwork")
                .Build();

            var seleniumHub = new ContainerBuilder()
                .WithImage("selenium/hub:4.3.0-20220726")
                .WithName("selenium-hub")
                .WithPortBinding(4442, 4442)
                .WithPortBinding(4443, 4443)
                .WithPortBinding(4444, 4444)
                .WithNetwork(network)
                .Build();

            var firefoxEnvioronment = new Dictionary<string, string>()
            {
                {"SE_EVENT_BUS_HOST", "selenium-hub"},
                {"SE_EVENT_BUS_PUBLISH_PORT", "4442"},
                {"SE_EVENT_BUS_SUBSCRIBE_PORT", "4443"}
            };

            var firefoxContainerBuilder = new ContainerBuilder()
                .WithImage("selenium/node-firefox:4.3.0-20220726")
                .WithEnvironment(firefoxEnvioronment)
                .WithNetwork(network)
                .Build();

            var firefoxVideoSupport = new Dictionary<string, string>()
            {
                {"DISPLAY_CONTAINER_NAME","firefox" },
                {"FILE_NAME","firefox.mp4" }
            };

            var videoContainerBuilder = new ContainerBuilder()
                .WithImage("selenium/video:ffmpeg-4.3.1-20211217")
                .WithEnvironment(firefoxEnvioronment)
                .WithNetwork(network)
                .Build();

            await network.CreateAsync();
            await seleniumHub.StartAsync();
            await firefoxContainerBuilder.StartAsync();
            await videoContainerBuilder.StartAsync();
        }

        [BeforeScenario]
        public void FirstBeforeScenario()
        {
            _driver = WebDriverFactory.GenerateDriver(string.Empty);
            _scenarioContnext.Add("Driver", _driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driver.Quit();
        }
    }
}
