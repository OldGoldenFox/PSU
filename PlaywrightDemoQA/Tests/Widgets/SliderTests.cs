using PlaywrightDemoQA.Pages.Widgets;

namespace PlaywrightDemoQA.Tests.Widgets
{
    public class SliderTests: BaseTest
    {
        private SliderPage _sliderPage;

        [SetUp]
        public async Task SetUp()
        {
            _sliderPage = new SliderPage(Page);
            await _sliderPage.Open();
        }
        
        [Test]
        public async Task Slider_Move_Test()
        {
            await _sliderPage.Slider.ClickAsync();
            
            for (int i = 0; i < 5; i++)
            {
                await Page.Keyboard.PressAsync("ArrowRight");
            }

            await Expect(_sliderPage.SliderValue).ToHaveValueAsync("55");
        }
    }
}