using Microsoft.Playwright;

namespace PlaywrightDemoQA.Pages.AlertsFrameWindows
{
    public class ModalDialogsPage
    {
        private readonly IPage _page;
        
        public ILocator ShowSmallModalBtn => _page.Locator("#showSmallModal");
        public ILocator ShowLargeModalBtn => _page.Locator("#showLargeModal");
        
        public ILocator ModalHeader => _page.Locator(".modal-header");
   
        public ILocator CloseXBtn => _page.Locator(".btn-close");
        
        public ModalDialogsPage(IPage page) => _page = page;
        
        public async Task Open()
        {
            await _page.GotoAsync("https://demoqa.com/", new() { WaitUntil = WaitUntilState.DOMContentLoaded });
            await _page.ClickAsync("text=Alerts, Frame & Windows");
        
            var radioMenuItem = _page.Locator("span.text:text-is('Modal Dialogs')");
            await radioMenuItem.ScrollIntoViewIfNeededAsync();
            await radioMenuItem.ClickAsync(new() { Force = true });
        
            await _page.Locator("h1").WaitForAsync();
        }
    }
}