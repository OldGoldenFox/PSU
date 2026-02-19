using PlaywrightDemoQA.Pages.Elements;

namespace PlaywrightDemoQA.Tests.Elements
{
    public class TextBoxTests : BaseTest
    {
        private TextBoxPage _textBoxPage;

        [SetUp]
        public new async Task Setup()
        {
            _textBoxPage = new TextBoxPage(Page);
            await _textBoxPage.Open();
        }

        [Test]
        public async Task TextBox_FillForm_DisplaysData()
        {
            await _textBoxPage.FillForm("Danil Pavlovich", "dan@mail.com", "Pavlodar", "Astana");
            
            await Page.Locator("#submit").ClickAsync(); 
        
            await Expect(_textBoxPage.ResultName).ToContainTextAsync("Danil Pavlovich");
            await Expect(_textBoxPage.ResultEmail).ToContainTextAsync("dan@mail.com");
            await Expect(_textBoxPage.ResultCurrentAddress).ToContainTextAsync("Pavlodar");
            await Expect(_textBoxPage.ResultPermanentAddress).ToContainTextAsync("Astana");
        }

        [Test]
        public async Task TextBox_InvalidEmail_ShowsErrorAndNoOutput()
        {
            await _textBoxPage.FillForm("Danil Pavlovich", "test-example.com", "Pavlodar", "Astana");
            
            await Page.Locator("#submit").ClickAsync(); 
            
            await Expect(Page.Locator("#userEmail")).ToHaveClassAsync(new Regex("field-error"));
        }
    }
}