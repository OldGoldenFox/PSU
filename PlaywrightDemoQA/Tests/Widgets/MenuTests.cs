using Microsoft.Playwright;
using PlaywrightDemoQA.Pages.Widgets;

namespace PlaywrightDemoQA.Tests.Widgets
{
    public class MenuTests : BaseTest
    {
        private MenuPage _menuPage;

        [SetUp]
        public new async Task Setup()
        {
            _menuPage = new MenuPage(Page);
            await _menuPage.Open();
        }

        [Test]
        public async Task test_main_menu_items_clickable()
        {
            await Expect(_menuPage.MainItem1).ToBeVisibleAsync();
            await Expect(_menuPage.MainItem2).ToBeVisibleAsync();
            await Expect(_menuPage.MainItem3).ToBeVisibleAsync();
        }

        [Test]
        public async Task test_submenu_navigation()
        {
            await _menuPage.NavigateTo(_menuPage.MainItem2);
            await Expect(_menuPage.SubItem1).ToBeVisibleAsync();
        }

        [Test]
        public async Task test_nested_submenu()
        {
            await _menuPage.NavigateTo(_menuPage.MainItem2);
            
            await _menuPage.NavigateTo(_menuPage.SubSubList);

            await Expect(_menuPage.SubSubItem1).ToBeVisibleAsync();
            await Expect(_menuPage.SubSubItem2).ToBeVisibleAsync();
        }

        [Test]
        public async Task test_menu_disappears_on_mouse_leave()
        {
            await _menuPage.NavigateTo(_menuPage.MainItem2);
            await Expect(_menuPage.SubItem1).ToBeVisibleAsync();

            await Page.Mouse.MoveAsync(0, 0);

            await Expect(_menuPage.SubItem1).Not.ToBeVisibleAsync();
        }

        [Test]
        public async Task test_multiple_tooltips_sequence() 
        {
            await _menuPage.NavigateTo(_menuPage.MainItem1);
            await _menuPage.NavigateTo(_menuPage.MainItem2);
            await Expect(_menuPage.SubItem1).ToBeVisibleAsync();
            
            await _menuPage.NavigateTo(_menuPage.MainItem3);

            await Expect(_menuPage.SubItem1).Not.ToBeVisibleAsync();
        }
    }
}