using Microsoft.Playwright;
using PlaywrightDemoQA.Pages.Elements;

namespace PlaywrightDemoQA.Tests.Elements
{
    public class ButtonsTests: BaseTest
    {
        private ButtonsPage _buttonPage;

        [SetUp]
        public async Task SetUp()
        {
            _buttonPage = new ButtonsPage(Page);
            await _buttonPage.Open();
        }
        
        [Test]
        public async Task DoubleClickButton()
        {
            await _buttonPage.DoubleClickButton.DblClickAsync();
            await Expect(_buttonPage.DoubleClickMessage).ToContainTextAsync("You have done a double click");
        }
        
        [Test]
        public async Task RightClickButton()
        {
            await _buttonPage.RightClickButton.ClickAsync(new LocatorClickOptions {Button = MouseButton.Right});
            await Expect(_buttonPage.RightClickMessage).ToContainTextAsync("You have done a right click");
        }
        
        [Test]
        public async Task ClickButton()
        {
            await _buttonPage.ClickButton.ClickAsync();
            await Expect(_buttonPage.ClickMessage).ToContainTextAsync("You have done a dynamic click");
        }
    }
}