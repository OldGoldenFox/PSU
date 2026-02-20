using Microsoft.Playwright;

namespace PlaywrightDemoQA.Pages.Widgets
{
    public class SliderPage
    {
        private readonly IPage _page;

        public ILocator Slider => _page.Locator("input.range-slider");
        public ILocator SliderValue => _page.Locator("#sliderValue");
        
        public SliderPage(IPage page) => _page = page;
        
        public async Task Open()
        {
            await _page.GotoAsync("https://demoqa.com/", new() { WaitUntil = WaitUntilState.DOMContentLoaded });
            await _page.ClickAsync("text=Widgets");
        
            var menuItem = _page.Locator("span.text:text-is('Slider')");
            await menuItem.ScrollIntoViewIfNeededAsync();
            await menuItem.ClickAsync(new() { Force = true });
        
            await _page.Locator("h1").WaitForAsync();
        }
    }
}