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
        public async Task Test_Start_ProgressBar()
        {
            await _progressBarPage.StartStopButton.ClickAsync();
            
            await Task.Delay(2000); 
            var progress = await _progressBarPage.GetProgressValueAsync();
            Assert.That(progress, Is.GreaterThan(0), "Прогресс не начал увеличиваться");
            
            await Expect(_progressBarPage.ProgressBar).ToHaveTextAsync("100%", new() { Timeout = 30000 });
                
            await Expect(_progressBarPage.ResetButton).ToHaveTextAsync("Reset");
        }
        
        [Test]
        public async Task Test_Stop_And_Resume_Progress()
        {
            await _progressBarPage.StartStopButton.ClickAsync();

            await _progressBarPage.WaitForProgressValueAsync(50);
    
            await _progressBarPage.StartStopButton.ClickAsync();

            int progressAfterStop = await _progressBarPage.GetProgressValueAsync();
    
            Assert.Multiple(() =>
            {
                Assert.That(progressAfterStop, Is.GreaterThanOrEqualTo(50), "Прогресс не достиг 50%");
                Assert.That(progressAfterStop, Is.LessThan(100), "Прогресс уже успел дойти до 100%");
            });
    
            await _progressBarPage.StartStopButton.ClickAsync();

            await Expect(_progressBarPage.ProgressBar).ToHaveTextAsync("100%", new() { Timeout = 20000 });
        }

        [Test]
        public async Task Test_Reset_Progress_Bar()
        {
            await _progressBarPage.StartStopButton.ClickAsync();
            await Expect(_progressBarPage.ProgressBar).ToHaveTextAsync("100%", new() { Timeout = 30000 });
            
            await _progressBarPage.ResetButton.ClickAsync();
            await Expect(_progressBarPage.ProgressBar).ToHaveTextAsync("0%");
            
            await Expect(_progressBarPage.StartStopButton).ToHaveTextAsync("Start");
        }
    }
}