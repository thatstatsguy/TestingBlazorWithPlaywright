using FluentAssertions;
using Microsoft.Playwright;

namespace UnitTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class TestId
{
    
    [Test]
    public async Task TestIdTest()
    {
        //Initialise Playwright
         var playwright = await Playwright.CreateAsync();
        //Initialise a browser - 'Chromium' can be changed to 'Firefox' or 'Webkit'

        var browser = await playwright
            .Chromium
            .LaunchAsync();
        
        var browserContext = await browser.NewContextAsync();
        var page = await browserContext.NewPageAsync();
        
        await page.GotoAsync("http://localhost:5078");
        var navText = await page.GetByTestId("fetch-data-nav").InnerTextAsync();

        navText.Should().Be("Fetch data");
    }
}





