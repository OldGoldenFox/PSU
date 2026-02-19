using PlaywrightDemoQA.Pages.AlertsFrameWindows;

namespace PlaywrightDemoQA.Tests.AlertsFrameWindows
{
    public class ModalDialogsTests : BaseTest
    {
        private ModalDialogsPage _modalPage;

        [SetUp]
        public new async Task Setup()
        {
            _modalPage = new ModalDialogsPage(Page);
            await _modalPage.Open();
        }

        [Test]
        public async Task SmallModal()
        {
            await _modalPage.ShowSmallModalBtn.ClickAsync();
            await Expect(_modalPage.ModalHeader).ToContainTextAsync("Small Modal");
            await _modalPage.CloseXBtn.ClickAsync();
        }

        [Test]
        public async Task LargeModal()
        {
            await _modalPage.ShowLargeModalBtn.ClickAsync();
            await Expect(_modalPage.ModalHeader).ToContainTextAsync("Large Modal");
            await _modalPage.CloseXBtn.ClickAsync();
        }
    }
}