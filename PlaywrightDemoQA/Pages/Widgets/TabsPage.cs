using Microsoft.Playwright;

namespace PlaywrightDemoQA.Pages.Widgets
{
    public class TabsPage
    {
        private readonly IPage _page;

        public ILocator TabWhat => _page.Locator("#demo-tab-what");
        public ILocator TabOrigin => _page.Locator("#demo-tab-origin");
        public ILocator TabUse => _page.Locator("#demo-tab-use");
        public ILocator TabMore => _page.Locator("#demo-tab-more");

        //public ILocator TabContent => _page.Locator(".tab-content");
        public ILocator TabPaneWhat => _page.Locator("#demo-tabpane-what");
        public ILocator TabPaneOrigin => _page.Locator("#demo-tabpane-origin");
        public ILocator TabPaneUse => _page.Locator("#demo-tabpane-use");
        public ILocator TabPaneMore => _page.Locator("#demo-tabpane-more");


        
        public TabsPage(IPage page) => _page = page;
        
        public async Task Open()
        {
            await _page.GotoAsync("https://demoqa.com/", new() { WaitUntil = WaitUntilState.DOMContentLoaded });
            await _page.ClickAsync("text=Widgets");
        
            var menuItem = _page.Locator("span.text:text-is('Tabs')");
            await menuItem.ScrollIntoViewIfNeededAsync();
            await menuItem.ClickAsync(new() { Force = true });
        
            await _page.Locator("h1").WaitForAsync();
        }
    }
}