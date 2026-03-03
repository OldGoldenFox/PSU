using Microsoft.Playwright;

namespace PlaywrightDemoQA.Pages.Widgets
{
    public class ToolTipsPage
    {
        private readonly IPage _page;

        public ILocator HoverButton => _page.Locator("#toolTipButton");
        public ILocator HoverTextField => _page.Locator("#toolTipTextField");
        public ILocator ContraryLink => _page.Locator("text=Contrary");
        public ILocator SectionLink => _page.Locator("text=1.10.32");
        public ILocator ToolTip => _page.Locator(".tooltip-inner");

        public ToolTipsPage(IPage page) => _page = page;
        
        public async Task Open()
        {
            await _page.GotoAsync("https://demoqa.com/", new() { WaitUntil = WaitUntilState.DOMContentLoaded });
            await _page.ClickAsync("text=Widgets");
        
            var menuItem = _page.Locator("span.text:text-is('Tool Tips')");
            await menuItem.ScrollIntoViewIfNeededAsync();
            await menuItem.ClickAsync(new() { Force = true });
        
            await _page.Locator("h1").WaitForAsync();
        }
    }
}