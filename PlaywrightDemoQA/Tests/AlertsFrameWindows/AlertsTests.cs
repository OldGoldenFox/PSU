using PlaywrightDemoQA.Pages.AlertsFrameWindows;

namespace PlaywrightDemoQA.Tests.AlertsFrameWindows
{
    public class AlertsTests : BaseTest
    {
        private AlertsPage _alertsPage;

        [SetUp]
        public new async Task Setup()
        {
            _alertsPage = new AlertsPage(Page);
            await _alertsPage.Open();
        }

        [Test]
        public async Task SimpleAlert_Test()
        {
            Page.Dialog += async (_, dialog) => 
            {
                Assert.That(dialog.Message, Is.EqualTo("You clicked a button"));
                await dialog.AcceptAsync();
            };

            await _alertsPage.SimpleAlertButton.ClickAsync();
        }

        [Test]
        public async Task TimerAlert_Test()
        {
            Page.Dialog += async (_, dialog) => 
            {
                Assert.That(dialog.Message, Is.EqualTo("This alert appeared after 5 seconds"));
                await dialog.AcceptAsync();
            };

            await _alertsPage.TimerAlertButton.ClickAsync();
        }

        [Test]
        public async Task ConfirmOkCancel_Test()
        {
            Page.Dialog += async (_, dialog) => await dialog.DismissAsync();

            await _alertsPage.ConfirmButton.ClickAsync();
        
            await Expect(_alertsPage.ConfirmResult).ToContainTextAsync("You selected Cancel");
        }

        [Test]
        public async Task PromptInput_Test()
        {
            var name = "Danchous";

            Page.Dialog += async (_, dialog) => await dialog.AcceptAsync(name);

            await _alertsPage.PromptButton.ClickAsync();

            await Expect(_alertsPage.PromptResult).ToContainTextAsync($"You entered {name}");
        }
    }
}