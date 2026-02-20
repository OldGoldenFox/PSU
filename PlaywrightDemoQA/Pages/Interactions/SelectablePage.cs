using Microsoft.Playwright;

namespace PlaywrightDemoQA.Pages.Interactions
{
    public class SelectablePage
    {
        private readonly IPage _page;

        public ILocator ListItems => _page.Locator("#verticalListContainer li:visible");

        public SelectablePage(IPage page) => _page = page;
    
        public async Task Open()
        {
            await _page.GotoAsync("https://demoqa.com/", new() { WaitUntil = WaitUntilState.DOMContentLoaded });
            await _page.ClickAsync("text=Interactions");
        
            var menuItem = _page.Locator("span.text:text-is('Selectable')");
            await menuItem.ScrollIntoViewIfNeededAsync();
            await menuItem.ClickAsync(new() { Force = true });
        
            await _page.Locator("h1").WaitForAsync();
        }
    }
}