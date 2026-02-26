using PlaywrightDemoQA.Pages.Elements;

namespace PlaywrightDemoQA.Tests.Elements
{
    public class CheckBoxTests : BaseTest
    {
        private CheckBoxPage _page;

        [SetUp]
        public new async Task Setup()
        {
            _page = new CheckBoxPage(Page);
            await _page.Open();
        }

        [Test]
        public async Task Test_Expand_And_Collapse()
        {
            await Expect(Page.GetByText("Desktop")).Not.ToBeVisibleAsync();

            await _page.ToggleItem("Home");
            await Expect(Page.GetByText("Desktop")).ToBeVisibleAsync();

            await _page.ToggleItem("Home");
            await Expect(Page.GetByText("Desktop")).Not.ToBeVisibleAsync();
        }

        [Test]
        public async Task Test_Select_Individual_Checkboxes()
        {
            await _page.ToggleItem("Home");
            
            await _page.GetCheckbox("Desktop").ClickAsync();

            await Expect(_page.ResultBlock).ToContainTextAsync("desktop");
            await Expect(_page.ResultBlock).ToContainTextAsync("notes");
            await Expect(_page.ResultBlock).ToContainTextAsync("commands");
        }

        [Test]
        public async Task Test_Select_Parent_Checkbox()
        {
            await _page.GetCheckbox("Home").ClickAsync();

            await Expect(_page.ResultBlock).ToContainTextAsync("home");
            await Expect(_page.ResultBlock).ToContainTextAsync("desktop");
            await Expect(_page.ResultBlock).ToContainTextAsync("documents");
            await Expect(_page.ResultBlock).ToContainTextAsync("downloads");
        }

        [Test]
        public async Task Test_Result_Output_Consistency()
        {
            await _page.ToggleItem("Home");
            await _page.ToggleItem("Documents");
            
            await _page.GetCheckbox("Office").ClickAsync();

            var expectedResults = new[] { "office", "public", "private", "classified", "general" };
            foreach (var item in expectedResults)
            {
                await Expect(_page.ResultBlock).ToContainTextAsync(item);
            }
        }
    }
}