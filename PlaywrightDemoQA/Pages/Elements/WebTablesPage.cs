using Microsoft.Playwright;

namespace PlaywrightDemoQA.Pages.Elements
{
    public class WebTablesPage
    {
        private readonly IPage _page;

        public ILocator AddButton => _page.Locator("#addNewRecordButton");
        public ILocator SubmitButton => _page.Locator("#submit");
        public ILocator SearchBox => _page.Locator("#searchBox");
        public ILocator FirstName => _page.Locator("#firstName");
        public ILocator LastName => _page.Locator("#lastName");
        public ILocator Email => _page.Locator("#userEmail");
        public ILocator Age => _page.Locator("#age");
        public ILocator Salary => _page.Locator("#salary");
        public ILocator Department => _page.Locator("#department");
        public ILocator TableBody => _page.Locator("tbody");
        public ILocator AllRows => _page.Locator("tbody tr");
        public ILocator RowSelect => _page.Locator(".pagination select");
        
        public WebTablesPage(IPage page) => _page = page;

        public async Task FillForm(string fName, string lName, string email, string age, string salary, string dep)
        {
            await FirstName.FillAsync(fName);
            await LastName.FillAsync(lName);
            await Email.FillAsync(email);
            await Age.FillAsync(age);
            await Salary.FillAsync(salary);
            await Department.FillAsync(dep);
            await SubmitButton.ClickAsync();
        }
        
        public async Task Open()
        {
            await _page.GotoAsync("https://demoqa.com/");
            await _page.ClickAsync("text=Elements");

            var radioMenuItem = _page.Locator("span.text:text-is('Web Tables')");
            await radioMenuItem.ScrollIntoViewIfNeededAsync();
            await radioMenuItem.ClickAsync(new() { Force = true });

            await _page.Locator("h1").WaitForAsync();
        }
    }
}