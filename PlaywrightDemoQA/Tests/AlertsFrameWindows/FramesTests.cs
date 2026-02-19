using PlaywrightDemoQA.Pages.AlertsFrameWindows;

namespace PlaywrightDemoQA.Tests.AlertsFrameWindows
{
    public class FramesTests : BaseTest
    {
        private FramesPage _framesPage;

        [SetUp]
        public new async Task Setup()
        {
            _framesPage = new FramesPage(Page);
            await _framesPage.Open();
        }

        [Test]
        public async Task BigFrame()
        {
            await Expect(_framesPage.BigFrameHeading).ToContainTextAsync("This is a sample page");
        }

        [Test]
        public async Task SmallFrame()
        {
            await Expect(_framesPage.SmallFrameHeading).ToContainTextAsync("This is a sample page");
        }
    }
}