using PlaywrightDemoQA.Pages.Elements;

namespace PlaywrightDemoQA.Tests.Elements
{
    public class WebTablesTests : BaseTest
    {
        private WebTablesPage _tablePage;
        
        [SetUp]
        public new async Task Setup()
        {
            _tablePage = new WebTablesPage(Page);
            await _tablePage.Open();
        }

        [Test]
        public async Task AddUser_Test()
        {
            await _tablePage.AddButton.ClickAsync();
            await _tablePage.FillForm("Danil", "Vyrodov", "dan@mail.com", "21", "1500000", "IT");
        }

        [Test]
        public async Task EditUser_Test()
        {
            await Page.Locator("#edit-record-2").ClickAsync();
            
            await _tablePage.FirstName.FillAsync("DanDaDan");
            await _tablePage.SubmitButton.ClickAsync();

            await Expect(_tablePage.TableBody).ToContainTextAsync("DanDaDan");
        }

        [Test]
        public async Task SearchUser_Test()
        {
            await _tablePage.SearchBox.FillAsync("Cierra");
            await Expect(_tablePage.TableBody).ToContainTextAsync("Cierra");
        }

        [Test]
        public async Task DeleteUser_Test()
        {
            await Page.Locator("#delete-record-3").ClickAsync();
            await Expect(_tablePage.TableBody).Not.ToContainTextAsync("Kierra");
        }
        
        [Test]
        public async Task ChangingRows_Test()
        { 
            await _tablePage.RowSelect.SelectOptionAsync("20");
            var selectedValue = await _tablePage.RowSelect.InputValueAsync();
            Assert.That(selectedValue, Is.EqualTo("20"));
        }
    }
}