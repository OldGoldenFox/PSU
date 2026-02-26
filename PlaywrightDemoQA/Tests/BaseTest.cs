using Allure.NUnit;
using Microsoft.Playwright;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PlaywrightDemoQA.Tests
{
    [AllureNUnit]
    [TestFixture]
    public class BaseTest : PageTest
    {
        protected IConfiguration Configuration;

        [OneTimeSetUp]
        public void LoggingSetup()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var headless = Configuration["TestSettings:Headless"] ?? "false";
            Environment.SetEnvironmentVariable("HEADLESS", headless == "true" ? "1" : "0");


            var browser = Configuration["TestSettings:Browser"]?.ToLower() ?? "chromium";
            Environment.SetEnvironmentVariable("BROWSER", browser);
        }

        [SetUp]
        public async Task Setup()
        {
            var timeout = float.Parse(Configuration["TestSettings:Timeout"] ?? "30000");
            Page.SetDefaultTimeout(timeout);

            await Context.Tracing.StartAsync(new()
            {
                Title = $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.Name}",
                Screenshots = true,
                Snapshots = true,
                Sources = true
            });
        }

        [TearDown]
        public async Task TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                var screenshotPath = Path.Combine(TestContext.CurrentContext.WorkDirectory, "screenshots", 
                    $"{TestContext.CurrentContext.Test.Name}.png");
                
                await Page.ScreenshotAsync(new() { Path = screenshotPath, FullPage = true });
                TestContext.AddTestAttachment(screenshotPath);
            }

            await Context.Tracing.StopAsync(new()
            {
                Path = Path.Combine(
                    TestContext.CurrentContext.WorkDirectory,
                    "playwright-traces",
                    $"{TestContext.CurrentContext.Test.Name}.zip"
                )
            });
        }

        public override BrowserNewContextOptions ContextOptions()
        {
            return new BrowserNewContextOptions()
            {
                ViewportSize = new ViewportSize { Width = 1920, Height = 1080 },
                Locale = "ru-RU",
                TimezoneId = "Europe/Moscow",
                ColorScheme = ColorScheme.Light,
                BaseURL = Configuration["TestSettings:BaseUrl"] 
            };
        }
        
        protected T GetTestData<T>(string sectionName)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Data", "testData.json");
            var json = File.ReadAllText(path);
            var jObject = JObject.Parse(json);
            return jObject[sectionName].ToObject<T>();
        }
    }
}