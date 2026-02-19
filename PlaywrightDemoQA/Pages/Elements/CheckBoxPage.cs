using Microsoft.Playwright;
using System.Text.RegularExpressions;

namespace PlaywrightDemoQA.Pages.Elements
{
    public class CheckBoxPage
    {
        private readonly IPage _page;

        public CheckBoxPage(IPage page) => _page = page;

        // --- ЛОКАТОРЫ ---

        // Универсальный поиск строки дерева по названию (Home, Desktop, и т.д.)
        private ILocator GetTreeItem(string title) => 
            _page.Locator("div[role='treeitem']").Filter(new() { HasTextString = title }).First;

        // Кнопка развертывания (switcher) для конкретного элемента
        public ILocator GetSwitcher(string title) => 
            GetTreeItem(title).Locator(".rc-tree-switcher");

        // Чекбокс для конкретного элемента
        public ILocator GetCheckbox(string title) => 
            GetTreeItem(title).Locator(".rc-tree-checkbox");

        // Блок с результатом
        public ILocator ResultBlock => _page.Locator("#result");

        // --- МЕТОДЫ ---

        public async Task Open()
        {
            // 1. Идем на главную
            await _page.GotoAsync("https://demoqa.com/");

            // 2. Кликаем по Elements
            await _page.ClickAsync("text=Elements");

            // 3. Переходим в Check Box
            var checkBoxMenuItem = _page.Locator("span.text:text-is('Check Box')");
            await checkBoxMenuItem.ScrollIntoViewIfNeededAsync();
            await checkBoxMenuItem.ClickAsync(new() { Force = true });

            // 4. ВМЕСТО NetworkIdle ждем появления корня дерева
            // Это гораздо быстрее и надежнее
            await _page.Locator(".rc-tree").WaitForAsync(new() { State = WaitForSelectorState.Visible });
        }

        public async Task ToggleItem(string title)
        {
            await GetSwitcher(title).ClickAsync();
        }
    }
}