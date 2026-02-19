using PlaywrightDemoQA.Pages.Forms;

namespace PlaywrightDemoQA.Tests.Forms
{
    public class PracticeFormTests: BaseTest
    {
        private PracticeFormPage _practiceFormPage;

        [SetUp]
        public async Task SetUp()
        {
            _practiceFormPage = new PracticeFormPage(Page);
            await _practiceFormPage.Open();
        }
        
        [Test]
        public async Task FillFullForm()
        {
            await _practiceFormPage.FirstNameInput.FillAsync("Danil");
            await _practiceFormPage.LastNameInput.FillAsync("Pavlovich");
            await _practiceFormPage.EmailInput.FillAsync("dan@mail.com");
            await _practiceFormPage.GenderMale.ClickAsync();
            await _practiceFormPage.MobileInput.FillAsync("87072573615");

            // Вот этот блок тоже думал как сделать, че-то пытался через выбор даты, а потом узнал что можно проще
            await _practiceFormPage.DateOfBirthInput.ClickAsync();
            await Page.Keyboard.PressAsync("Control+A");
            await Page.Keyboard.TypeAsync("06 Jun 2004");
            await Page.Keyboard.PressAsync("Enter");
            
            await _practiceFormPage.SubjectsInput.FillAsync("Maths");
            await Page.Keyboard.PressAsync("Enter");
            
            await _practiceFormPage.HobbySports.ClickAsync();
            
            var photoPath = Path.Combine(Directory.GetCurrentDirectory(), "test_photo.jpg");
            await File.WriteAllTextAsync(photoPath, "Ты снова смотришь -_-");
            await _practiceFormPage.UploadPictureInput.SetInputFilesAsync(photoPath);
            
            await _practiceFormPage.CurrentAddressInput.FillAsync("Улица Пушкина, дом Колотушкина");
            
            await _practiceFormPage.StateDropdown.ClickAsync();
            await Page.Keyboard.TypeAsync("NCR");
            await Page.Keyboard.PressAsync("Enter");
            
            await _practiceFormPage.CityDropdown.ClickAsync();
            await Page.Keyboard.TypeAsync("Delhi");
            await Page.Keyboard.PressAsync("Enter");
            
            await _practiceFormPage.SubmitButton.ClickAsync();
            
            await Expect(_practiceFormPage.SuccessModal).ToBeVisibleAsync();
            await Expect(_practiceFormPage.ModalTable).ToContainTextAsync("Danil Pavlovich");
            await Expect(_practiceFormPage.ModalTable).ToContainTextAsync("dan@mail.com");
        }
    }
}