using PlaywrightDemoQA.Pages.Interactions;
using PlaywrightDemoQA.Pages.Widgets;

namespace PlaywrightDemoQA.Tests.Interactions
{
    public class SelectableTests: BaseTest
    {
        private SelectablePage _selectablePage;

        [SetUp]
        public new async Task Setup()
        {
            _selectablePage = new SelectablePage(Page);
            await _selectablePage.Open();
        }
        
        [Test]
        public async Task Selectable_List_Test()
        {
            await _selectablePage.ListItems.Nth(0).ClickAsync();
            await _selectablePage.ListItems.Nth(1).ClickAsync();

            await Expect(_selectablePage.ListItems.Nth(0)).ToHaveClassAsync(new Regex("active"));
            await Expect(_selectablePage.ListItems.Nth(1)).ToHaveClassAsync(new Regex("active"));
            
            await Expect(_selectablePage.ListItems.Nth(2)).Not.ToHaveClassAsync(new Regex("active"));
        }
    }
}