using Microsoft.Playwright;

namespace PlaywrightDemoQA.Pages.Elements
{
    public class ButtonsPage
    {
        private IPage _page;
        
        public ILocator DoubleClickButton => _page.Locator("#doubleClickBtn");
        public ILocator RightClickButton => _page.Locator("#rightClickBtn");
        public ILocator ClickButton => _page.GetByRole(AriaRole.Button, new PageGetByRoleOptions {Name = "Click Me", Exact = true});
        
        public ILocator DoubleClickMessage  => _page.Locator("#doubleClickMessage");
        public ILocator RightClickMessage => _page.Locator("#rightClickMessage");
        public ILocator ClickMessage => _page.Locator("#dynamicClickMessage");
        
        public ButtonsPage(IPage page) => _page = page;
        
        public async Task Open()
        {
            await _page.GotoAsync("https://demoqa.com/");
            await _page.ClickAsync("text=Elements");

            var radioMenuItem = _page.Locator("span.text:text-is('Buttons')");
            await radioMenuItem.ScrollIntoViewIfNeededAsync();
            await radioMenuItem.ClickAsync(new() { Force = true });

            await _page.Locator("h1").WaitForAsync();
        }
    }
}