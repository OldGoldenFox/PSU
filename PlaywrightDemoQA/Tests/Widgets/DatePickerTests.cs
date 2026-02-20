using Microsoft.Playwright;
using PlaywrightDemoQA.Pages.Widgets;

namespace PlaywrightDemoQA.Tests.Widgets
{
    public class DatePickerTests : BaseTest
    {
        private DatePickerPage _datePage;

        [SetUp]
        public new async Task Setup()
        {
            _datePage = new DatePickerPage(Page);
            await _datePage.Open();
        }
        
        [Test]
        public async Task DatePicker_ManualInput_Test()
        {
            await _datePage.DateInput.ClickAsync();
            
            await Page.Keyboard.PressAsync("Control+A");
            await Page.Keyboard.TypeAsync("06/06/2004");
            await Page.Keyboard.PressAsync("Enter");

            await Expect(_datePage.DateInput).ToHaveValueAsync("06/06/2004");
        }

        [Test]
        public async Task DatePicker_CalendarSelect_Test()
        {
            await _datePage.DateInput.ClickAsync();

            await _datePage.MonthSelect.SelectOptionAsync(new SelectOptionValue {Label = "June"});
            await _datePage.YearSelect.SelectOptionAsync(new SelectOptionValue {Label = "2004"});

            await _datePage.Day27.ClickAsync();

            await Expect(_datePage.DateInput).ToHaveValueAsync(new Regex("06/27/2004"));
        }

        [Test]
        public async Task DatePicker_WithTime_Test()
        {
            await _datePage.DateAndTimeInput.ClickAsync();
            
            await Page.Locator(".react-datepicker__month-read-view").ClickAsync();
            await Page.Locator(".react-datepicker__month-option").GetByText("September", new() { Exact = true }).ClickAsync();

            await _datePage.Day27.ClickAsync();

            await _datePage.TimeListItem("14:30").ClickAsync();

            await Expect(_datePage.DateAndTimeInput).ToHaveValueAsync(new Regex("September 27, 2026 2:30 PM"));
        }
    }
}