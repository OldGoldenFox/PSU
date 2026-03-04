using Microsoft.Playwright;

namespace PlaywrightDemoQA.Pages.Interactions
{
    public class SortablePage
    {
        private readonly IPage _page;

        public ILocator TabList => _page.Locator("#demo-tab-list");
        public ILocator TabGrid => _page.Locator("#demo-tab-grid");

        public ILocator ListItems => _page.Locator(".vertical-list-container .list-group-item");
        public ILocator GridItems => _page.Locator(".create-grid .list-group-item");

        public SortablePage(IPage page) => _page = page;
        
        public async Task Open()
        {
            await _page.GotoAsync("https://demoqa.com/", new() { WaitUntil = WaitUntilState.DOMContentLoaded });
            await _page.ClickAsync("text=Interactions");
        
            var menuItem = _page.Locator("span.text:text-is('Sortable')");
            await menuItem.ScrollIntoViewIfNeededAsync();
            await menuItem.ClickAsync(new() { Force = true });
        
            await _page.Locator("h1").WaitForAsync();
        }

        public async Task<List<string>> GetItemsOrder(ILocator items)
        {
            return (await items.AllInnerTextsAsync()).ToList();
        }
    }
}