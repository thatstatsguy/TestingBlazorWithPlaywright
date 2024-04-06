using FluentAssertions;
using Microsoft.Playwright;

namespace UnitTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Filtering
{
    
    [Test]
    public async Task FilteringTest()
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
        // re-evaluated each time it's used - can be reused multiple times in the test
        var navMenuLocator = page.GetByTestId("nav-menu");
        var navLinks = await navMenuLocator.GetByRole(AriaRole.Link).CountAsync();
        //should be 3 links in nav
        navLinks.Should().Be(3);
    }
}





