using Microsoft.Playwright;

namespace UnitTests;

/// <summary>
/// Leaving this in here as this is what comes as part of the playwright template
/// </summary>

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Assertions : PageTest
{
    [Test]
    public async Task HomepageHasPlaywrightInTitleAndGetStartedLinkLinkingtoTheIntroPage()
    {
        await Page.GotoAsync("https://playwright.dev");

        // Expect a title "to contain" a substring.
        await Expect(Page).ToHaveTitleAsync(new Regex("Playwright"));

        // create a locator
        var getStarted = Page.Locator("text=Get Started");

        // Expect an attribute "to be strictly equal" to the value.
        // Custom timeout of 30 seconds has been added here to show how the length of time to wait can be adjusted
        await Expect(getStarted).ToHaveAttributeAsync(
            "href",
            "/docs/intro", 
            new LocatorAssertionsToHaveAttributeOptions(){Timeout = 30_000});

        // Click the get started link.
        await getStarted.ClickAsync();

        // Expects the URL to contain intro.
        await Expect(Page).ToHaveURLAsync(new Regex(".*intro"));
    }
}