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
    
            await Expect(_selectablePage.ActiveItems).ToHaveCountAsync(2);
        }

        [Test]
        public async Task test_select_grid_items()
        {
            await _selectablePage.TabGrid.ClickAsync();

            await _selectablePage.GridItems.Nth(0).ClickAsync();
            await _selectablePage.GridItems.Nth(2).ClickAsync();
            await _selectablePage.GridItems.Nth(4).ClickAsync();

            await Expect(_selectablePage.ActiveItems).ToHaveCountAsync(3);

            await _selectablePage.GridItems.Nth(0).ClickAsync();

            await Expect(_selectablePage.ActiveItems).ToHaveCountAsync(2);
    
            await Expect(_selectablePage.GridItems.Nth(0)).Not.ToHaveClassAsync(new Regex("active"));
            
            // Проверка гита CICD
        }
    }
}