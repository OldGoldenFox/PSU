using PlaywrightDemoQA.Pages.Widgets;

namespace PlaywrightDemoQA.Tests.Widgets
{
    public class ProgressBarTests: BaseTest
    {
        private ProgressBarPage _progressBarPage;
        
        [SetUp]
        public async Task SetUp()
        {
            _progressBarPage = new ProgressBarPage(Page);
            await _progressBarPage.Open();
        }
        
        [Test]
        public async Task ProgressBar_FullCycle_Test()
        {
            await _progressBarPage.StartStopButton.ClickAsync();
            await Expect(_progressBarPage.ProgressBar).ToHaveTextAsync("100%", new() { Timeout = 20000 });
            
            await _progressBarPage.ResetButton.ClickAsync();
            await Expect(_progressBarPage.ProgressBar).ToHaveTextAsync("0%");
        }
    }
}