using PlaywrightDemoQA.Pages.Widgets;

namespace PlaywrightDemoQA.Tests.Widgets
{
    public class AutoCompleteTests: BaseTest
    {
        private AutoCompletePage _autoCompletePage;

        [SetUp]
        public async Task SetUp()
        {
            _autoCompletePage = new AutoCompletePage(Page);
            await _autoCompletePage.Open();
        }
        
        [Test]
        public async Task AutoComplete_Multiple()
        {
            await _autoCompletePage.MultipleInput.FillAsync("Red");
            await Page.Locator(".auto-complete__option").GetByText("Red", new() { Exact = true }).ClickAsync();

            await _autoCompletePage.MultipleInput.FillAsync("Blue");
            await Page.Locator(".auto-complete__option").GetByText("Blue", new() { Exact = true }).ClickAsync();

            var labels = Page.Locator(".auto-complete__multi-value__label");
            await Expect(labels).ToHaveCountAsync(2);
    
            await _autoCompletePage.RemoveValueBtn.First.ClickAsync();
            await Expect(labels).ToHaveCountAsync(1);
        }
        
        [Test]
        public async Task AutoComplete_Single()
        {
            await _autoCompletePage.SingleInput.ClickAsync();
            await Page.Keyboard.TypeAsync("Re");
            await Page.Keyboard.PressAsync("Enter");

            await Expect(Page.Locator(".auto-complete__single-value")).ToContainTextAsync("Red");
        }
    }
}