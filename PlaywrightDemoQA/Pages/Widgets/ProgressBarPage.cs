using Microsoft.Playwright;

namespace PlaywrightDemoQA.Pages.Widgets
{
    public class ProgressBarPage
    {
        private readonly IPage _page;

        public ILocator StartStopButton => _page.Locator("#startStopButton");
        public ILocator ProgressBar => _page.Locator(".progress-bar");
        public ILocator ResetButton => _page.Locator("#resetButton");

        public ProgressBarPage(IPage page) => _page = page;
        
        public async Task Open()
        {
            await _page.GotoAsync("https://demoqa.com/", new() { WaitUntil = WaitUntilState.DOMContentLoaded });
            await _page.ClickAsync("text=Widgets");
        
            var menuItem = _page.Locator("span.text:text-is('Progress Bar')");
            await menuItem.ScrollIntoViewIfNeededAsync();
            await menuItem.ClickAsync(new() { Force = true });
        
            await _page.Locator("h1").WaitForAsync();
        }
    }
}