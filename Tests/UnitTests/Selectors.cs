using FluentAssertions;
using Microsoft.Playwright;

namespace UnitTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Selectors
{
    
    [Test]
    public async Task SelectorTest()
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
         var browserContext = await browser.NewContextAsync();
         var page = await browserContext.NewPageAsync();
        
        await page.GotoAsync("http://localhost:5078");

        //Uncomment the following code to open the inspector
        await page.PauseAsync();

        var linkText = await page.Locator("a.font-weight-bold.link-dark").TextContentAsync();
        linkText.Should().Be("brief survey");
    }
}





