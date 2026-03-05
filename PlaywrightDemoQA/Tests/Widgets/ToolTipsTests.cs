using Microsoft.Playwright;
using PlaywrightDemoQA.Pages.Widgets;
using System.Text.RegularExpressions;

namespace PlaywrightDemoQA.Tests.Widgets
{
    public class ToolTipsTests : BaseTest
    {
        private ToolTipsPage _toolTipsPage;

        [SetUp]
        public new async Task Setup()
        {
            _toolTipsPage = new ToolTipsPage(Page);
            await _toolTipsPage.Open();
        }

        [Test]
        public async Task test_button_hover_tooltip()
        {
            await _toolTipsPage.HoverButton.HoverAsync();
            await Expect(_toolTipsPage.ToolTip).ToHaveTextAsync("You hovered over the Button");
            await Expect(_toolTipsPage.HoverButton).ToHaveAttributeAsync("aria-describedby", new Regex("ToolTip"));
            await Page.Mouse.MoveAsync(0, 0);
            await Expect(_toolTipsPage.ToolTip).Not.ToBeVisibleAsync();
        }

        [Test]
        public async Task test_text_field_hover_tooltip()
        {
            await _toolTipsPage.HoverTextField.HoverAsync();
            await Expect(_toolTipsPage.ToolTip).ToHaveTextAsync("You hovered over the text field");
            // Проверить корректное позиционирование подсказки
            // Нз как сделать это, сам не совсем понимаю что это значит
        }

        [Test]
        public async Task test_contrary_link_tooltip()
        {
            await _toolTipsPage.ContraryLink.HoverAsync();
            await Expect(_toolTipsPage.ToolTip).ToHaveTextAsync("You hovered over the Contrary");
        }

        [Test]
        public async Task test_section_number_tooltip()
        {
            await _toolTipsPage.SectionLink.HoverAsync();
            await Expect(_toolTipsPage.ToolTip).ToHaveTextAsync("You hovered over the 1.10.32");
        }

        [Test]
        public async Task test_multiple_tooltips_sequence()
        {
            await _toolTipsPage.HoverButton.HoverAsync();
            await Expect(_toolTipsPage.ToolTip).ToHaveTextAsync("You hovered over the Button");
            
            await _toolTipsPage.HoverTextField.HoverAsync();
            await Task.Delay(1000);
            await Expect(_toolTipsPage.ToolTip).ToHaveTextAsync("You hovered over the text field");
            
            await Expect(_toolTipsPage.ToolTip).Not.ToHaveTextAsync("You hovered over the Button");
            
            await _toolTipsPage.ContraryLink.HoverAsync();
            await Task.Delay(1000);

            await Expect(_toolTipsPage.ToolTip).ToHaveTextAsync("You hovered over the Contrary");
        }
    }
}