using PlaywrightDemoQA.Pages.Elements;

namespace PlaywrightDemoQA.Tests.Elements
{
    public class LinksTests : BaseTest
    {
        private LinksPage _linksPage;

        [SetUp]
        public new async Task Setup()
        {
            _linksPage = new LinksPage(Page);
            await _linksPage.Open();
        }

        [Test]
        public async Task SimpleLink()
        {
            var newTask = Page.WaitForPopupAsync();
            await _linksPage.SimpleLink.ClickAsync();
            
            var newPage = await newTask;
            await newPage.WaitForLoadStateAsync();
            Assert.That(newPage.Url, Is.EqualTo("https://demoqa.com/"));
            
            await newPage.CloseAsync();
        }
        
        [Test]
        public async Task DynamicLink()
        {
            var newTask = Page.WaitForPopupAsync();
            await _linksPage.SimpleLink.ClickAsync();
            
            var newPage = await newTask;
            await newPage.WaitForLoadStateAsync();
            Assert.That(newPage.Url, Is.EqualTo("https://demoqa.com/"));
            
            await newPage.CloseAsync();
        }

        [Test]
        public async Task ApiLink_Created()
        {
            await _linksPage.Created.ClickAsync();

            await Expect(_linksPage.LinkResponse)
                .ToContainTextAsync("Link has responded with staus 201 and status text Created");
        }
    }
}