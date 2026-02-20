using PlaywrightDemoQA.Pages.Widgets;

namespace PlaywrightDemoQA.Tests.Widgets
{
    public class TabsTests: BaseTest
    {
        private TabsPage _tabsPage;

        [SetUp]
        public async Task SetUp()
        {
            _tabsPage = new TabsPage(Page);
            await _tabsPage.Open();
        }
        
        [Test]
        public async Task Tabs_Switching_Test()
        {
            await Expect(_tabsPage.TabContent).ToContainTextAsync("Lorem Ipsum is simply dummy text");
            
            await _tabsPage.TabOrigin.ClickAsync();
            await Expect(_tabsPage.TabContent).ToContainTextAsync("Contrary to popular belief");

            await _tabsPage.TabUse.ClickAsync();
            await Expect(_tabsPage.TabContent).ToContainTextAsync("It is a long established fact");
            
            await Expect(_tabsPage.More).ToHaveAttributeAsync("aria-disabled", "true");        
        }
    }
}