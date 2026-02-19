using Microsoft.Playwright;

namespace PlaywrightDemoQA.Pages.Forms
{
    public class PracticeFormPage
    {
        private readonly IPage _page;
    
        public ILocator FirstNameInput => _page.Locator("#firstName");
        public ILocator LastNameInput => _page.Locator("#lastName");
        public ILocator EmailInput => _page.Locator("#userEmail");
        public ILocator MobileInput => _page.Locator("#userNumber");
        public ILocator CurrentAddressInput => _page.Locator("#currentAddress");
    
        public ILocator GenderMale => _page.GetByText("Male", new() { Exact = true });
    
        public ILocator HobbySports => _page.GetByText("Sports");

        public ILocator DateOfBirthInput => _page.Locator("#dateOfBirthInput");

        public ILocator SubjectsInput => _page.Locator("#subjectsInput");

        public ILocator UploadPictureInput => _page.Locator("#uploadPicture");

        public ILocator StateDropdown => _page.Locator("#state");
        public ILocator CityDropdown => _page.Locator("#city");
    
        // Ну вот эту штуку я вообще нз как было сделать, ее с геминьки нагло взял
        public ILocator StateCityInput => _page.Locator("input[id^='react-select']");

        public ILocator SubmitButton => _page.Locator("#submit");
    
        public ILocator SuccessModal => _page.Locator(".modal-content");
        public ILocator ModalTable => _page.Locator(".table-responsive");
    
        public PracticeFormPage(IPage page) => _page = page;
    
        public async Task Open()
        {
            await _page.GotoAsync("https://demoqa.com/");
            await _page.ClickAsync("text=Forms");

            var radioMenuItem = _page.Locator("span.text:text-is('Practice Form')");
            await radioMenuItem.ScrollIntoViewIfNeededAsync();
            await radioMenuItem.ClickAsync(new() { Force = true });

            await _page.Locator("h1").WaitForAsync();
        }
    }
}