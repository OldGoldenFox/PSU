using Microsoft.Playwright;
using System.Text.RegularExpressions;

namespace PlaywrightDemoQA.Pages.Elements
{
    public class CheckBoxPage
    {
        private readonly IPage _page;

        private ILocator GetTreeItem(string title) => 
            _page.Locator("div[role='treeitem']").Filter(new() { HasTextString = title }).First;

        public ILocator GetSwitcher(string title) => GetTreeItem(title).Locator(".rc-tree-switcher");

        public ILocator GetCheckbox(string title) => GetTreeItem(title).Locator(".rc-tree-checkbox");

        public ILocator ResultBlock => _page.Locator("#result");

        public CheckBoxPage(IPage page) => _page = page;

        public async Task Open()
        {
            await _page.GotoAsync("https://demoqa.com/");
            await _page.ClickAsync("text=Elements");
            var checkBoxMenuItem = _page.Locator("span.text:text-is('Check Box')");
            await checkBoxMenuItem.ScrollIntoViewIfNeededAsync();
            await checkBoxMenuItem.ClickAsync(new() { Force = true });
            await _page.Locator(".rc-tree").WaitForAsync(new() { State = WaitForSelectorState.Visible });
        }

        public async Task ToggleItem(string title)
        {
            await GetSwitcher(title).ClickAsync();
        }
    }
}