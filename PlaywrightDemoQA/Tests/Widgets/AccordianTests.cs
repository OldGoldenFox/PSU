using PlaywrightDemoQA.Pages.Widgets;

namespace PlaywrightDemoQA.Tests.Widgets
{
    public class AccordianTests : BaseTest
    {
        private AccordianPage _accordianPage;

        [SetUp]
        public new async Task Setup()
        {
            _accordianPage = new AccordianPage(Page);
            await _accordianPage.Open();
        }
        
        [Test]
        public async Task Accordian_Test()
        {
            await Expect(_accordianPage.Section1Content).ToContainTextAsync("Lorem Ipsum is simply dummy text of the");

            await _accordianPage.Section2Heading.ClickAsync();
            await Expect(_accordianPage.Section2Content).ToContainTextAsync("Contrary to popular belief, Lorem Ipsum is not simply");
            
            await _accordianPage.Section3Heading.ClickAsync();
            await Expect(_accordianPage.Section3Content).ToContainTextAsync("It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.");
        }
    }
}