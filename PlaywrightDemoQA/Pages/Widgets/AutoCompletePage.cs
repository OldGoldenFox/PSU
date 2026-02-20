using Microsoft.Playwright;

namespace PlaywrightDemoQA.Pages.Widgets
{
    public class AutoCompletePage
    {
        private readonly IPage _page;
        public ILocator MultipleInput => _page.Locator("#autoCompleteMultipleInput");
        public ILocator SingleInput => _page.Locator("#autoCompleteSingleInput");
        public ILocator RemoveValueBtn => _page.Locator(".auto-complete__multi-value__remove");
        
        public AutoCompletePage(IPage page) => _page = page;
        
        public async Task Open()
        {
            await _page.GotoAsync("https://demoqa.com/", new() { WaitUntil = WaitUntilState.DOMContentLoaded });
            await _page.ClickAsync("text=Widgets");
        
            var menuItem = _page.Locator("span.text:text-is('Auto Complete')");
            await menuItem.ScrollIntoViewIfNeededAsync();
            await menuItem.ClickAsync(new() { Force = true });
        
            await _page.Locator("h1").WaitForAsync();
        }
    }
}