using Microsoft.Playwright;

namespace PlaywrightDemoQA.Tests
{
    [TestFixture]
    public class BaseTest : PageTest
    {
        [SetUp]
        public async Task Setup()
        {
            await Context.Tracing.StartAsync(new()
            {
                Title = TestContext.CurrentContext.Test.ClassName + "." +
                        TestContext.CurrentContext.Test.Name,
                Screenshots = true,
                Snapshots = true,
                Sources = true
            });
        }

        [TearDown]
        public async Task TearDown()
        {
            await Context.Tracing.StopAsync(new()
            {
                Path = Path.Combine(
                    TestContext.CurrentContext.WorkDirectory,
                    "playwright-traces",
                    $"{TestContext.CurrentContext.Test.ClassName}." +
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
                BaseURL = "https://demoqa.com"
            };
        }
    }
}