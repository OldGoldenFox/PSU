using Microsoft.Playwright;
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
        public async Task test_switch_between_tabs()
        {
            await Expect(_tabsPage.TabWhat).ToHaveAttributeAsync("aria-selected", "true");

            await _tabsPage.TabOrigin.ClickAsync();
            await Expect(_tabsPage.TabOrigin).ToHaveAttributeAsync("aria-selected", "true");
            await Expect(_tabsPage.TabWhat).ToHaveAttributeAsync("aria-selected", "false");
            
            await _tabsPage.TabUse.ClickAsync();
            await Expect(_tabsPage.TabUse).ToHaveAttributeAsync("aria-selected", "true");
            await Expect(_tabsPage.TabOrigin).ToHaveAttributeAsync("aria-selected", "false");
            
            await Expect(_tabsPage.TabMore).ToHaveAttributeAsync("aria-disabled", "true");
        }
        
        [Test]
        public async Task test_tab_content_display()
        {
            await Expect(_tabsPage.TabPaneWhat).ToBeVisibleAsync();
            await Expect(_tabsPage.TabPaneWhat).ToContainTextAsync("Lorem Ipsum is simply dummy text");
            
            await _tabsPage.TabOrigin.ClickAsync();
            await Expect(_tabsPage.TabPaneWhat).Not.ToBeVisibleAsync();
            await Expect(_tabsPage.TabPaneOrigin).ToBeVisibleAsync();
            await Expect(_tabsPage.TabPaneOrigin).ToContainTextAsync("Contrary to popular belief");
            
            await _tabsPage.TabUse.ClickAsync();
            await Expect(_tabsPage.TabPaneOrigin).Not.ToBeVisibleAsync();
            await Expect(_tabsPage.TabPaneUse).ToBeVisibleAsync();
            await Expect(_tabsPage.TabPaneUse).ToContainTextAsync("It is a long established fact");
        }

        [Test]
        public async Task test_disabled_tab()
        {
            await Expect(_tabsPage.TabPaneWhat).ToBeVisibleAsync();
            await Expect(_tabsPage.TabPaneWhat).ToContainTextAsync("Lorem Ipsum is simply dummy text");
            await Expect(_tabsPage.TabPaneMore).Not.ToBeVisibleAsync();

            await Expect(_tabsPage.TabMore).ToHaveAttributeAsync("aria-disabled", "true");        
            await _tabsPage.TabMore.ClickAsync(new LocatorClickOptions() {Force = true});
            
            await Expect(_tabsPage.TabPaneMore).Not.ToBeVisibleAsync();
            await Expect(_tabsPage.TabPaneWhat).ToBeVisibleAsync();
            await Expect(_tabsPage.TabPaneWhat).ToContainTextAsync("Lorem Ipsum is simply dummy text");
        }
    }
}