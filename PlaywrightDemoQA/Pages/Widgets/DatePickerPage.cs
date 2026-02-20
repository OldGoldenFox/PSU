using Microsoft.Playwright;

namespace PlaywrightDemoQA.Pages.Widgets
{
    public class DatePickerPage
    {
        private readonly IPage _page;

        public ILocator DateInput => _page.Locator("#datePickerMonthYearInput");
        public ILocator DateAndTimeInput => _page.Locator("#dateAndTimePickerInput");

        public ILocator MonthSelect => _page.Locator(".react-datepicker__month-select");
        public ILocator YearSelect => _page.Locator(".react-datepicker__year-select");
        
        public ILocator Day27 => _page.Locator(".react-datepicker__month").GetByText("27", new() { Exact = true }).First;
        
        public ILocator TimeListItem(string time) => _page.Locator(".react-datepicker__time-list-item").GetByText(time, new() { Exact = true });
        
        public DatePickerPage(IPage page) => _page = page;
        
        public async Task Open()
        {
            await _page.GotoAsync("https://demoqa.com/", new() { WaitUntil = WaitUntilState.DOMContentLoaded });
            await _page.ClickAsync("text=Widgets");
        
            var menuItem = _page.Locator("span.text:text-is('Date Picker')");
            await menuItem.ScrollIntoViewIfNeededAsync();
            await menuItem.ClickAsync(new() { Force = true });
        
            await _page.Locator("h1").WaitForAsync();
        }
    }
}