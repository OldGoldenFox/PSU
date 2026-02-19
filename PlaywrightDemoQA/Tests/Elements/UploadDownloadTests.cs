using PlaywrightDemoQA.Pages.Elements;

namespace PlaywrightDemoQA.Tests.Elements
{
    public class UploadDownloadTests: BaseTest
    {
        private UploadDownloadPage _uploadDownloadPage;

        [SetUp]
        public new async Task Setup()
        {
            _uploadDownloadPage = new UploadDownloadPage(Page);
            await _uploadDownloadPage.Open();
        }

        [Test]
        public async Task DownloadFile()
        {
            var downloadTask = Page.WaitForDownloadAsync();
            await _uploadDownloadPage.DownloadButton.ClickAsync();
            var download = await downloadTask;

            Assert.That(download.SuggestedFilename, Is.EqualTo("sampleFile.jpeg"));
        }

        [Test]
        public async Task UploadFile_And_Verify()
        {
            var testFile = Path.Combine(Directory.GetCurrentDirectory(), "testFile.txt");
            await File.WriteAllTextAsync(testFile, "Че смотришь -_-");

            try 
            {
                await _uploadDownloadPage.UploadInput.SetInputFilesAsync(testFile);
                await Expect(_uploadDownloadPage.UploadedFilePath).ToContainTextAsync("testFile.txt");
            }
            finally 
            {
                if (File.Exists(testFile)) File.Delete(testFile);
            }
        }
    }
}