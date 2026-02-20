using PlaywrightDemoQA.Pages.Widgets;

namespace PlaywrightDemoQA.Tests.Widgets
{
    public class SelectMenuTests: BaseTest
    {
        private SelectMenuPage _selectMenuPage;

        [SetUp]
        public new async Task Setup()
        {
            _selectMenuPage = new SelectMenuPage(Page);
            await _selectMenuPage.Open();
        }
        
        [Test]
        public async Task SelectValue_Test()
        {
            await _selectMenuPage.SelectValue.ClickAsync();
            await Page.Keyboard.PressAsync("Enter");
            await Expect(_selectMenuPage.SelectOption).ToContainTextAsync("Group 1, option 1");
        }
    }
}