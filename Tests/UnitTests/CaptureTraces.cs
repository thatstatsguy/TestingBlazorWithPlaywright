using FluentAssertions;
using Microsoft.Playwright;

namespace UnitTests;


/// <summary>
/// For more information, see https://playwright.dev/dotnet/docs/trace-viewer-intro
///
/// Also see https://trace.playwright.dev/
/// </summary>
[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class CaptureTraces
{
    [Test]
    public async Task CaptureTracesTest()
    {
        //Initialise Playwright
         var playwright = await Playwright.CreateAsync();
        //Initialise a browser - 'Chromium' can be changed to 'Firefox' or 'Webkit'
        
         var browser = await playwright
             .Chromium
             .LaunchAsync(
                 new BrowserTypeLaunchOptions
                 {
                     //switch to false if you want to view the test visually or use the inspector
                     Headless = false // -> Use this option to be able to see your test running
                 }
             );
         
         
         var browserContext = await browser.NewContextAsync(new BrowserNewContextOptions(){});
         await browserContext
             .Tracing
             .StartAsync(
                 new TracingStartOptions
                 {
                     Screenshots = true,
                     Snapshots = true,
                     Sources = true
                 }
             );
         var page = await browserContext.NewPageAsync();
        
        await page.GotoAsync("http://localhost:5078");
        try
        {
            var navLinks = await page.GetByRole(AriaRole.Link).CountAsync();
            //should be 6 links across the home page you can click
            navLinks.Should().Be(1234);
        }
        catch (Exception)
        {
            var path = "C:/Temp/trace.zip";
            await browserContext.Tracing.StopAsync(new TracingStopOptions { Path = path });
            throw;
        }
    }
}





