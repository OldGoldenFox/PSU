using PlaywrightDemoQA.Pages.Interactions;

namespace PlaywrightDemoQA.Tests.Interactions
{
    public class SortableTests : BaseTest
    {
        private SortablePage _sortablePage;

        [SetUp]
        public new async Task Setup()
        {
            _sortablePage = new SortablePage(Page);
            await _sortablePage.Open();
        }

        [Test]
        public async Task test_sort_list_items()
        {
            var itemOne = _sortablePage.ListItems.GetByText("One");
            var itemSix = _sortablePage.ListItems.GetByText("Six");

            await itemOne.DragToAsync(itemSix, new() { TargetPosition = new() { X = 10, Y = 40 } });
            
            var order = await _sortablePage.GetItemsOrder(_sortablePage.ListItems);
            Assert.That(order.Last(), Is.EqualTo("One"));
        }

        [Test]
        public async Task test_sort_grid_items()
        {
            await _sortablePage.TabGrid.ClickAsync();
            
            var itemOne = _sortablePage.GridItems.GetByText("One");
            var itemNine = _sortablePage.GridItems.GetByText("Nine");
            
            await itemOne.DragToAsync(itemNine);

            var order = await _sortablePage.GetItemsOrder(_sortablePage.GridItems);
            Assert.That(order.Last(), Is.EqualTo("One"));
        }

        [Test]
        public async Task test_multiple_sort_operations()
        {
            await _sortablePage.ListItems.GetByText("One").DragToAsync(_sortablePage.ListItems.GetByText("Three"), new() { TargetPosition = new() { X = 10, Y = 40 } });
            await Task.Delay(1000);
            await _sortablePage.ListItems.GetByText("Six").DragToAsync(_sortablePage.ListItems.GetByText("Four"));

            var order = await _sortablePage.GetItemsOrder(_sortablePage.ListItems);
            
            Assert.That(order.IndexOf("One"), Is.EqualTo(2));
            Assert.That(order.IndexOf("Six"), Is.EqualTo(3));
        }
    }
}