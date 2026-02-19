using PlaywrightDemoQA.Pages.Elements;

namespace PlaywrightDemoQA.Tests.Elements
{
    public class RadioButtonTests : PageTest
    {
        private RadioButtonPage _radioButtonPage;

        [SetUp]
        public async Task Setup()
        {
            _radioButtonPage = new RadioButtonPage(Page);
            await _radioButtonPage.Open();
        }

        [Test]
        public async Task RadioButtons_Tests()
        {
            await _radioButtonPage.YesR.ClickAsync();
            await Expect(_radioButtonPage.ResultText).ToHaveTextAsync("Yes");

            await _radioButtonPage.ImpressiveR.ClickAsync();
            await Expect(_radioButtonPage.ResultText).ToHaveTextAsync("Impressive");
            
            await Expect(_radioButtonPage.NoR).ToBeDisabledAsync();
        }
    }
}