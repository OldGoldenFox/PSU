using Microsoft.Playwright;

namespace PlaywrightDemoQA.Pages.Widgets
{
    public class SelectMenuPage
    {
        private readonly IPage _page;
        
        public ILocator SelectValueInput => _page.Locator("#withOptGroup");
        public ILocator CurrentValueText => _page.Locator("#withOptGroup .css-hlgwow");
        
        public ILocator SelectOneInput => _page.Locator("#selectOne");
        public ILocator CurrentOneText => _page.Locator("#selectOne .css-hlgwow");
        
        public ILocator OldStyleSelect => _page.Locator("#oldSelectMenu");
        
        public ILocator MultiSelectInput => _page.Locator(".css-b62m3t-container").Last;
        
        public ILocator StandardMultiSelect => _page.Locator("#cars");

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

        public async Task SelectCustomOption(ILocator input, string optionText)
        {
            await input.ClickAsync(new () { Force = true });
            await _page.Keyboard.TypeAsync(optionText);
            await _page.Keyboard.PressAsync("Enter");
        }
    }
}