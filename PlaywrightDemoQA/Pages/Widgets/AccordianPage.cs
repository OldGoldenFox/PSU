using Microsoft.Playwright;

namespace PlaywrightDemoQA.Pages.Widgets
{
    public class AccordianPage
    {
        private readonly IPage _page;

        public ILocator Section2Heading => _page.GetByText("Where does it come from?");
        public ILocator Section3Heading => _page.GetByText("Why do we use it?");

        public ILocator Section1Content => _page.Locator(".accordion-item").Filter(new() { HasText = "What is Lorem Ipsum?" }).Locator(".accordion-body");
        public ILocator Section2Content => _page.Locator(".accordion-item").Filter(new() { HasText = "Where does it come from?" }).Locator(".accordion-body");
        public ILocator Section3Content => _page.Locator(".accordion-item").Filter(new() { HasText = "Why do we use it?" }).Locator(".accordion-body");

        public AccordianPage(IPage page) => _page = page;
    
        public async Task Open()
        {
            await _page.GotoAsync("https://demoqa.com/", new() { WaitUntil = WaitUntilState.DOMContentLoaded });
            await _page.ClickAsync("text=Widgets");
        
            var menuItem = _page.Locator("span.text:text-is('Accordian')");
            await menuItem.ScrollIntoViewIfNeededAsync();
            await menuItem.ClickAsync(new() { Force = true });
        
            await _page.Locator("h1").WaitForAsync();
        }
    }
}