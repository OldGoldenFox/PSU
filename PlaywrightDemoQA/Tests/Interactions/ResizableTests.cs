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
        public async Task test_resize_box_with_restrictions()
        {
            var box = _resizablePage.RestrictedBox;
            var handle = _resizablePage.RestrictedHandle;

            await _resizablePage.ResizeElement(handle, -100, -100);
            var size = await box.BoundingBoxAsync();
            Assert.That(size.Width, Is.EqualTo(150).Within(2));
            Assert.That(size.Height, Is.EqualTo(150).Within(2));

            await _resizablePage.ResizeElement(handle, 400, 200);
            size = await box.BoundingBoxAsync();
            Assert.That(size.Width, Is.EqualTo(500).Within(2));
            Assert.That(size.Height, Is.EqualTo(300).Within(2));
        }

        [Test]
        public async Task test_resize_without_restrictions()
        {
            var box = _resizablePage.SimpleBox;
            var handle = _resizablePage.SimpleHandle;
    
            await box.ScrollIntoViewIfNeededAsync();

            var initialSize = await box.BoundingBoxAsync();

            await _resizablePage.ResizeElement(handle, 100, 100);
            var newSize = await box.BoundingBoxAsync();
    
            Assert.That(newSize.Width, Is.EqualTo(initialSize.Width + 100).Within(2));
            Assert.That(newSize.Height, Is.EqualTo(initialSize.Height + 100).Within(2));
        }
    }
}