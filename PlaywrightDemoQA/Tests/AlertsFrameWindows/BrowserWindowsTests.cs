using PlaywrightDemoQA.Pages.AlertsFrameWindows;

namespace PlaywrightDemoQA.Tests.AlertsFrameWindows
{
    public class BrowserWindowsTests : BaseTest
    {
        private BrowserWindowsPage _browserWindowsPage;

        [SetUp]
        public new async Task Setup()
        {
            _browserWindowsPage = new BrowserWindowsPage(Page);
            await _browserWindowsPage.Open();
        }

      [Test]
        public async Task OpenNewTab_And_VerifyContent()
        {
            var pageTask = Context.WaitForPageAsync();
            await _browserWindowsPage.NewTabButton.ClickAsync();
            var newTab = await pageTask;
            await Expect(_browserWindowsPage.SampleHeading(newTab)).ToContainTextAsync("This is a sample page");
            await newTab.CloseAsync();
        }

        [Test]
        public async Task OpenNewWindow_And_VerifyContent()
        {
            var windowTask = Context.WaitForPageAsync();
            await _browserWindowsPage.NewWindowButton.ClickAsync();
            var newWindow = await windowTask;
            await Expect(_browserWindowsPage.SampleHeading(newWindow)).ToContainTextAsync("This is a sample page");
            await newWindow.CloseAsync();
        }
    }
}