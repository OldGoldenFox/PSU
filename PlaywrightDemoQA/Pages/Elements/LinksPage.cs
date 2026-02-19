using Microsoft.Playwright;

namespace PlaywrightDemoQA.Pages.Elements
{
    public class LinksPage
    {
        private IPage _page;
        
        public ILocator SimpleLink => _page.Locator("#simpleLink");
        public ILocator DynamicLink => _page.Locator("#dynamicLink");
        // Прочитал что еще так можно
        // public ILocator DynamicLink => _page.GetByRole(AriaRole.Link, new() { NameRegex = new Regex("^Home") });
        // Скорее всего так и надо, но я лучше воспользуюсь id xd
        
        public ILocator Created => _page.Locator("#created");

        public ILocator LinkResponse  => _page.Locator("#linkResponse");
        
        public LinksPage(IPage page) => _page = page;
        
        public async Task Open()
        {
            await _page.GotoAsync("https://demoqa.com/");
            await _page.ClickAsync("text=Elements");

            var radioMenuItem = _page.Locator("span.text:text-is('Links')");
            await radioMenuItem.ScrollIntoViewIfNeededAsync();
            await radioMenuItem.ClickAsync(new() { Force = true });

            await _page.Locator("h1").WaitForAsync();
        }
    }
}