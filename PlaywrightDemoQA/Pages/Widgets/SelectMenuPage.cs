using Microsoft.Playwright;

namespace PlaywrightDemoQA.Pages.Widgets
{
    public class SelectMenuPage
    {
        private readonly IPage _page;
        
        public ILocator SelectValue => _page.Locator("#withOptGroup");
        public ILocator SelectOption => _page.Locator("#withOptGroup .css-hlgwow");
        
        
        public SelectMenuPage(IPage page) => _page = page;
        
        public async Task Open()
        {
            await _page.GotoAsync("https://demoqa.com/", new() { WaitUntil = WaitUntilState.DOMContentLoaded });
            await _page.ClickAsync("text=Widgets");
        
            var menuItem = _page.Locator("span.text:text-is('Select Menu')");
            await menuItem.EvaluateAsync("el => el.scrollIntoView({ block: 'center' })");
            await menuItem.ClickAsync();

            await _page.Locator("h1").WaitForAsync();
        }
    }
}