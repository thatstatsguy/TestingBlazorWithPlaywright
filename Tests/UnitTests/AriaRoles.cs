using FluentAssertions;
using Microsoft.Playwright;

namespace UnitTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class AriaRoles
{
    
    [Test]
    public async Task AriaRoleTest()
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
        
        var navLinks = await page.GetByRole(AriaRole.Link).CountAsync();
        //should be 6 links across the home page you can click
        navLinks.Should().Be(6);
    }
}





