using PlaywrightDemoQA.Pages.Widgets;

namespace PlaywrightDemoQA.Tests.Widgets
{
    public class SelectMenuTests : BaseTest
    {
        private SelectMenuPage _selectMenuPage;

        [SetUp]
        public new async Task Setup()
        {
            _selectMenuPage = new SelectMenuPage(Page);
            await _selectMenuPage.Open();
        }
        
        [Test]
        public async Task test_select_value_dropdown()
        {
            await _selectMenuPage.SelectCustomOption(_selectMenuPage.SelectValueInput, "Group 1, option 1");
            await Expect(_selectMenuPage.CurrentValueText).ToHaveTextAsync("Group 1, option 1");

            await _selectMenuPage.SelectCustomOption(_selectMenuPage.SelectValueInput, "Group 2, option 2");
            await Expect(_selectMenuPage.CurrentValueText).ToHaveTextAsync("Group 2, option 2");
        }

        [Test]
        public async Task test_select_one_dropdown()
        {
            await _selectMenuPage.SelectCustomOption(_selectMenuPage.SelectOneInput, "Dr.");
            await Expect(_selectMenuPage.CurrentOneText).ToHaveTextAsync("Dr.");

            await _selectMenuPage.SelectCustomOption(_selectMenuPage.SelectOneInput, "Mrs.");
            await Expect(_selectMenuPage.CurrentOneText).ToHaveTextAsync("Mrs.");
        }

        [Test]
        public async Task test_old_style_select_menu()
        {
            await _selectMenuPage.SelectCustomOption(_selectMenuPage.SelectOneInput, "Dr.");
            
            await _selectMenuPage.OldStyleSelect.SelectOptionAsync(new[] { "Blue" });

            var selectedValue = await _selectMenuPage.OldStyleSelect.InputValueAsync();
            Assert.That(selectedValue, Is.EqualTo("1"));
        }

        [Test]
        public async Task test_multiselect_dropdown()
        {
            await _selectMenuPage.SelectCustomOption(_selectMenuPage.MultiSelectInput, "Black");
            await _selectMenuPage.SelectCustomOption(_selectMenuPage.MultiSelectInput, "Blue");

            await Expect(Page.Locator(".css-1p3m7a8-multiValue")).ToHaveCountAsync(2);

            await Page.Locator(".css-v7duua").First.ClickAsync();
            
            await Expect(Page.Locator(".css-1p3m7a8-multiValue")).ToHaveCountAsync(1);
        }

        // test_standard_multi_select
        // Нз как это сделать
    }
}