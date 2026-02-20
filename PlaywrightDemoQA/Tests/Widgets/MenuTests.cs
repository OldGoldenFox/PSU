using PlaywrightDemoQA.Pages.Widgets;

namespace PlaywrightDemoQA.Tests.Widgets
{
    public class MenuTests: BaseTest
    {
        private MenuPage _menuPage;

        [SetUp]
        public new async Task Setup()
        {
            _menuPage = new MenuPage(Page);
            await _menuPage.Open();
        }
        
        [Test]
        public async Task Menu_Navigation_Test()
        {
            await Page.GetByText("Main Item 2").HoverAsync();
            await Page.GetByText("SUB SUB LIST »").HoverAsync();
    
            await Expect(Page.GetByText("Sub Sub Item 2")).ToBeVisibleAsync();
        }
    }
}