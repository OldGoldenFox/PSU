namespace RTPO
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class ExampleTests : PageTest
    {
        [Test]
        public async Task MainPage_ShouldHaveTitle()
        {
            await Page.GotoAsync("https://playwright.dev");
            
            await Expect(Page).ToHaveTitleAsync(new Regex("Playwright"));
        }
    }
}