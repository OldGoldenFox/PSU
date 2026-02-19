using Microsoft.Playwright;

namespace PlaywrightDemoQA.Pages.AlertsFrameWindows
{
    public class FramesPage
    {
        private readonly IPage _page;
        
        public IFrameLocator BigFrame => _page.FrameLocator("#frame1");
        public IFrameLocator SmallFrame => _page.FrameLocator("#frame2");
        
        public ILocator BigFrameHeading => BigFrame.Locator("#sampleHeading");
        public ILocator SmallFrameHeading => SmallFrame.Locator("#sampleHeading");
        
        public FramesPage(IPage page) => _page = page;
        
        public async Task Open()
        {
            await _page.GotoAsync("https://demoqa.com/", new() { WaitUntil = WaitUntilState.DOMContentLoaded });
            await _page.ClickAsync("text=Alerts, Frame & Windows");
        
            var radioMenuItem = _page.Locator("span.text:text-is('Frames')");
            await radioMenuItem.ScrollIntoViewIfNeededAsync();
            await radioMenuItem.ClickAsync(new() { Force = true });
        
            await _page.Locator("h1").WaitForAsync();
        }
    }
}