using PlaywrightDemoQA.Pages.Interactions;

namespace PlaywrightDemoQA.Tests.Interactions
{
    public class ResizableTests : BaseTest
    {
        private ResizablePage _resizablePage;

        [SetUp]
        public new async Task Setup()
        {
            _resizablePage = new ResizablePage(Page);
            await _resizablePage.Open();
        }

        [Test]
        public async Task ResizeBoxWithRestriction()
        {
            await Expect(_resizablePage.RestrictedBox).ToHaveCSSAsync("width", "200px");
            await Expect(_resizablePage.RestrictedBox).ToHaveCSSAsync("height", "200px");
            
            await _resizablePage.RestrictedHandle.HoverAsync();
            await Page.Mouse.DownAsync();
            var currentPos = await _resizablePage.RestrictedHandle.BoundingBoxAsync();
            await Page.Mouse.MoveAsync(currentPos.X + 500, currentPos.Y + 300, new() { Steps = 10 });
            await Page.Mouse.UpAsync();
            await Expect(_resizablePage.RestrictedBox).ToHaveCSSAsync("width", "500px");
            await Expect(_resizablePage.RestrictedBox).ToHaveCSSAsync("height", "300px");
            
            await _resizablePage.RestrictedHandle.HoverAsync();
            await Page.Mouse.DownAsync();
            currentPos = await _resizablePage.RestrictedHandle.BoundingBoxAsync();
            await Page.Mouse.MoveAsync(currentPos.X - 500, currentPos.Y - 300, new() { Steps = 10 });
            await Page.Mouse.UpAsync();
            await Expect(_resizablePage.RestrictedBox).ToHaveCSSAsync("width", "150px");
            await Expect(_resizablePage.RestrictedBox).ToHaveCSSAsync("height", "150px");
        }
        
        [Test]
        public async Task ResizeBox()
        {
            await Expect(_resizablePage.SimpleBox).ToHaveCSSAsync("width", "200px");
            await Expect(_resizablePage.SimpleBox).ToHaveCSSAsync("height", "200px");
            
            await _resizablePage.SimpleHandle.HoverAsync();
            await Page.Mouse.DownAsync();
            var currentPos = await _resizablePage.SimpleHandle.BoundingBoxAsync();
            await Page.Mouse.MoveAsync(currentPos.X + 500, currentPos.Y + 300, new() { Steps = 10 });
            await Page.Mouse.UpAsync();
            await Expect(_resizablePage.SimpleBox).ToHaveCSSAsync("width", "690px");
            await Expect(_resizablePage.SimpleBox).ToHaveCSSAsync("height", "540px");
            
            await _resizablePage.SimpleHandle.HoverAsync();
            await Page.Mouse.DownAsync();
            currentPos = await _resizablePage.SimpleHandle.BoundingBoxAsync();
            await Page.Mouse.MoveAsync(currentPos.X - 700, currentPos.Y - 500, new() { Steps = 10 });
            await Page.Mouse.UpAsync();
            await Expect(_resizablePage.SimpleBox).ToHaveCSSAsync("width", "20px");
            await Expect(_resizablePage.SimpleBox).ToHaveCSSAsync("height", "20px");
        }
    }
}