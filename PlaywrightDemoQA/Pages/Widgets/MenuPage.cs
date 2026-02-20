using Microsoft.Playwright;

namespace PlaywrightDemoQA.Pages.Widgets
{
    public class MenuPage
    {
        private readonly IPage _page;

        public ILocator MainItem2 => _page.GetByText("Main Item 2");
        public ILocator SubSubList => _page.GetByText("SUB SUB LIST »");
        
        public MenuPage(IPage page) => _page = page;

        public async Task Open()
        {
            await _page.GotoAsync("https://demoqa.com/", new() { WaitUntil = WaitUntilState.DOMContentLoaded });
            await _page.ClickAsync("text=Widgets");
        
            var menuItem = _page.Locator("span.text:text-is('Menu')");
            await menuItem.ScrollIntoViewIfNeededAsync();
            await menuItem.ClickAsync(new() { Force = true });
        
            await _page.Locator("h1").WaitForAsync();
        }
    }
}