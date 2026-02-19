using Microsoft.Playwright;

namespace PlaywrightDemoQA.Pages.Elements
{
    public class RadioButtonPage
    {
        private IPage _page;

        public ILocator YesR => _page.Locator("label[for='yesRadio']");
        public ILocator ImpressiveR => _page.Locator("label[for='impressiveRadio']");
        public ILocator NoR => _page.Locator("label[for='noRadio']");
        public ILocator ResultText => _page.Locator(".text-success"); 
    
        public RadioButtonPage(IPage page) => _page = page; 
        
        public async Task Open()
        {
            await _page.GotoAsync("https://demoqa.com/");
            await _page.ClickAsync("text=Elements");

            var radioMenuItem = _page.Locator("span.text:text-is('Radio Button')");
            await radioMenuItem.ScrollIntoViewIfNeededAsync();
            await radioMenuItem.ClickAsync(new() { Force = true });

            await _page.Locator("h1").WaitForAsync();
        }
    }
}