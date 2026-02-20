using Microsoft.Playwright;
using PlaywrightDemoQA.Pages.Widgets;

namespace PlaywrightDemoQA.Tests.Widgets
{
    public class ToolTipsTests: BaseTest
    {
        private ToolTipsPage _toolTipsTests;

        [SetUp]
        public new async Task Setup()
        {
            _toolTipsTests = new ToolTipsPage(Page);
            await _toolTipsTests.Open();
        }
        
        [Test]
        public async Task Button_Hover_Test()
        {
            await _toolTipsTests.HoverButton.HoverAsync();
            await Expect(_toolTipsTests.ToolTip).ToHaveTextAsync("You hovered over the Button");
        }
        
        [Test]
        public async Task TextField_Hover_Test()
        {
            await _toolTipsTests.HoverTextField.HoverAsync();
            await Expect(_toolTipsTests.ToolTip).ToHaveTextAsync("You hovered over the text field");
        }
    }
}