using Microsoft.Playwright;

namespace PlaywrightDemoQA.Pages.Elements
{
    public class TextBoxPage
    {
        private readonly IPage _page;

        private ILocator FullNameInput => _page.Locator("#userName");
        private ILocator EmailInput => _page.Locator("#userEmail");
        private ILocator CurrentAddressInput => _page.Locator("#currentAddress");
        private ILocator PermanentAddressInput => _page.Locator("#permanentAddress");
    
        public ILocator ResultName => _page.Locator("#output #name");
        public ILocator ResultEmail => _page.Locator("#output #email");
        public ILocator ResultCurrentAddress => _page.Locator("#output #currentAddress");
        public ILocator ResultPermanentAddress => _page.Locator("#output #permanentAddress");
    
        public TextBoxPage(IPage page) => _page = page;
        
        public async Task Open()
        {
            await _page.GotoAsync("https://demoqa.com/");

            await _page.Locator("text=Elements").ClickAsync();
            await _page.Locator("text=Text Box").ClickAsync();
        }

        public async Task FillForm(string name, string email, string currentAddr, string permAddr)
        {
            await FullNameInput.FillAsync(name);
            await EmailInput.FillAsync(email);
            await CurrentAddressInput.FillAsync(currentAddr);
            await PermanentAddressInput.FillAsync(permAddr);
        }
    }
}