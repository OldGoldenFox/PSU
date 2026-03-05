using Microsoft.Playwright;

namespace PlaywrightDemoQA.Pages.Widgets
{
    public class MenuPage
    {
        private readonly IPage _page;

        public ILocator MainItem1 => _page.GetByText("Main Item 1");
        public ILocator MainItem2 => _page.GetByText("Main Item 2");
        public ILocator MainItem3 => _page.GetByText("Main Item 3");

        public ILocator SubItem1 => _page.GetByText("Sub Item").First;
        public ILocator SubItem2 => _page.GetByText("Sub Item").Last;

        public ILocator SubSubList => _page.GetByText("SUB SUB LIST »");
        
        public ILocator SubSubItem1 => _page.GetByText("Sub Sub Item 1");
        public ILocator SubSubItem2 => _page.GetByText("Sub Sub Item 2");

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

        public async Task NavigateTo(ILocator locator)
        {
            await locator.HoverAsync();
            await Task.Delay(300); 
        }
    }
}