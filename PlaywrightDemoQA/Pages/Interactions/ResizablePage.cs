using Microsoft.Playwright;

namespace PlaywrightDemoQA.Pages.Interactions;

public class ResizablePage
{
    private readonly IPage _page;

    public ILocator RestrictedBox => _page.Locator("#resizableBoxWithRestriction");
    public ILocator RestrictedHandle => RestrictedBox.Locator(".react-resizable-handle.react-resizable-handle-se");

    public ILocator SimpleBox => _page.Locator("#resizableERROR"); // Специальная ошибка
    public ILocator SimpleHandle => SimpleBox.Locator(".react-resizable-handle.react-resizable-handle-se");
        
    public ResizablePage(IPage page) => _page = page;
    
    public async Task Open()
    {
        await _page.GotoAsync("https://demoqa.com/", new() { WaitUntil = WaitUntilState.DOMContentLoaded });
        await _page.ClickAsync("text=Interactions");
        
        var menuItem = _page.Locator("span.text:text-is('Resizable')");
        await menuItem.ScrollIntoViewIfNeededAsync();
        await menuItem.ClickAsync(new() { Force = true });
        
        await _page.Locator("h1").WaitForAsync();
    }
    
    public async Task ResizeElement(ILocator handle, double xOffset, double yOffset)
    {
        var box = await handle.BoundingBoxAsync();
        if (box != null)
        {
            await handle.HoverAsync();
            await _page.Mouse.DownAsync();
            await _page.Mouse.MoveAsync((float)(box.X + box.Width / 2 + xOffset), (float)(box.Y + box.Height / 2 + yOffset), new() { Steps = 5 });
            await _page.Mouse.UpAsync();
        }
    }
}