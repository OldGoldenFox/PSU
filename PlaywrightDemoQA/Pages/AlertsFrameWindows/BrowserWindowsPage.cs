using Microsoft.Playwright;

namespace PlaywrightDemoQA.Pages.AlertsFrameWindows
{
    public class BrowserWindowsPage
    {
        private IPage _page;
        
        public ILocator NewTabButton => _page.Locator("#tabButton");
        public ILocator NewWindowButton => _page.Locator("#windowButton");
        // Тоже интересная вещь, которую я бы не понял
        public ILocator SampleHeading(IPage targetPage) => targetPage.Locator("#sampleHeading");
        
        public BrowserWindowsPage(IPage page) => _page = page;
        
        public async Task Open()
        {
            await _page.GotoAsync("https://demoqa.com/", new() { WaitUntil = WaitUntilState.DOMContentLoaded });
            await _page.ClickAsync("text=Alerts, Frame & Windows");
        
            var radioMenuItem = _page.Locator("span.text:text-is('Browser Windows')");
            await radioMenuItem.ScrollIntoViewIfNeededAsync();
            await radioMenuItem.ClickAsync(new() { Force = true });
        
            await _page.Locator("h1").WaitForAsync();
        }
    }
}