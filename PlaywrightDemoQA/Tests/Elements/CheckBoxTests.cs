using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using PlaywrightDemoQA.Pages.Elements;

namespace PlaywrightDemoQA.Tests.Elements
{
    public class CheckBoxTests : PageTest
    {
        private CheckBoxPage _page;

        [SetUp]
        public async Task Setup()
        {
            _page = new CheckBoxPage(Page);
            await _page.Open();
        }

        // 1. Раскрытие/скрытие дерева элементов
        [Test]
        public async Task Test_Expand_And_Collapse()
        {
            // Сначала проверим, что Desktop не виден
            await Expect(Page.GetByText("Desktop")).Not.ToBeVisibleAsync();

            // Раскрываем Home
            await _page.ToggleItem("Home");
            await Expect(Page.GetByText("Desktop")).ToBeVisibleAsync();

            // Скрываем Home
            await _page.ToggleItem("Home");
            await Expect(Page.GetByText("Desktop")).Not.ToBeVisibleAsync();
        }

        // 2. Выбор отдельных чекбоксов
        [Test]
        public async Task Test_Select_Individual_Checkboxes()
        {
            await _page.ToggleItem("Home"); // Раскрываем, чтобы увидеть дочерние
            
            // Кликаем по конкретному элементу (например, Desktop)
            await _page.GetCheckbox("Desktop").ClickAsync();

            // 4. Проверка отображения результата выбора
            await Expect(_page.ResultBlock).ToContainTextAsync("desktop");
            await Expect(_page.ResultBlock).ToContainTextAsync("notes");
            await Expect(_page.ResultBlock).ToContainTextAsync("commands");
        }

        // 3. Выбор родительского элемента (выбираются все дочерние)
        [Test]
        public async Task Test_Select_Parent_Checkbox()
        {
            // Кликаем по самому верхнему родителю - Home
            await _page.GetCheckbox("Home").ClickAsync();

            // Проверяем, что в результате отобразились ключевые дочерние элементы
            // (home выберет абсолютно всё)
            await Expect(_page.ResultBlock).ToContainTextAsync("home");
            await Expect(_page.ResultBlock).ToContainTextAsync("desktop");
            await Expect(_page.ResultBlock).ToContainTextAsync("documents");
            await Expect(_page.ResultBlock).ToContainTextAsync("downloads");
        }

        // 4. Проверка отображения результата (комбинированный тест)
        [Test]
        public async Task Test_Result_Output_Consistency()
        {
            await _page.ToggleItem("Home");
            await _page.ToggleItem("Documents");
            
            // Выбираем конкретный файл внутри документов
            await _page.GetCheckbox("Office").ClickAsync();

            // Проверяем, что в блоке результата появились именно офисные файлы
            var expectedResults = new[] { "office", "public", "private", "classified", "general" };
            foreach (var item in expectedResults)
            {
                await Expect(_page.ResultBlock).ToContainTextAsync(item);
            }
        }
    }
}