using Microsoft.Playwright;

namespace PlaywrightDemoQA.Pages.AlertsFrameWindows
{
    public class AlertsPage
    {
        private readonly IPage _page;
    
        public ILocator SimpleAlertButton => _page.Locator("#alertButton");
        public ILocator TimerAlertButton => _page.Locator("#timerAlertButton");
        public ILocator ConfirmButton => _page.Locator("#confirmButton");
        public ILocator PromptButton => _page.Locator("#promtButton");
    
        public ILocator ConfirmResult => _page.Locator("#confirmResult");
        public ILocator PromptResult => _page.Locator("#promptResult");
    
        public AlertsPage(IPage page) => _page = page;
    
        public async Task Open()
        {
            await _page.GotoAsync("https://demoqa.com/");
            await _page.ClickAsync("text=Alerts, Frame & Windows");

            var radioMenuItem = _page.Locator("span.text:text-is('Alerts')");
            await radioMenuItem.ScrollIntoViewIfNeededAsync();
            await radioMenuItem.ClickAsync(new() { Force = true });

            await _page.Locator("h1").WaitForAsync();
        }
    }
}