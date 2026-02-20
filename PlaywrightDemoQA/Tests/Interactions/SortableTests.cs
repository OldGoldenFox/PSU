using PlaywrightDemoQA.Pages.Interactions;

namespace PlaywrightDemoQA.Tests.Interactions
{
    public class SortableTests: BaseTest
    {
        private SortablePage _sortablePage;

        [SetUp]
        public new async Task Setup()
        {
            _sortablePage = new SortablePage(Page);
            await _sortablePage.Open();
        }
        
        [Test]
        public async Task Sortable_MoveItem_Test()
        {
            var itemOne = _sortablePage.ListItems.GetByText("One");
            var itemFour = _sortablePage.ListItems.GetByText("Four");

            await itemOne.DragToAsync(itemFour, new() { TargetPosition = new() { X = 10, Y = 40 } });
            
            await Expect(_sortablePage.ListItems.Nth(3)).ToHaveTextAsync("One");
        }
    }
}