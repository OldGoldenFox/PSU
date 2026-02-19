using Microsoft.Playwright;

namespace PlaywrightDemoQA.Pages.Elements
{
    public class UploadDownloadPage
    {
        private IPage _page;

        public ILocator DownloadButton => _page.Locator("#downloadButton");
        public ILocator UploadInput => _page.Locator("#uploadFile");
        public ILocator UploadedFilePath => _page.Locator("#uploadedFilePath");

        public UploadDownloadPage(IPage page) => _page = page;
        
        public async Task Open()
        {
            await _page.GotoAsync("https://demoqa.com/");
            await _page.ClickAsync("text=Elements");

            var radioMenuItem = _page.Locator("span.text:text-is('Upload and Download')");
            await radioMenuItem.ScrollIntoViewIfNeededAsync();
            await radioMenuItem.ClickAsync(new() { Force = true });

            await _page.Locator("h1").WaitForAsync();
        }
    }
}