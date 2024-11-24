using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

class ProgressContactUsPageTests
{
    IWebDriver driver;
    string ContactUsPageURL = "https://www.progress.com/company/contact";

    [SetUp]
    public void Initialize()
    {
        driver = new ChromeDriver();
    }

    [Test]
    public void Test_ContactUsPageIsDisplayed()
    {
        var ProgressContactUsPage = new ProgressContactUsPage(driver);

        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        ProgressContactUsPage.LoadPage(ContactUsPageURL);
        Assert.That(ProgressContactUsPage.ContactUsPageIsDisplayed);
    }

    [Test]
    public void Test_GetInTouchSectionIsDisplayed()
    {
        var ProgressContactUsPage = new ProgressContactUsPage(driver);

        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        ProgressContactUsPage.LoadPage(ContactUsPageURL);
        Assert.That(ProgressContactUsPage.GetInTouchSectionIsDisplayed);
    }

    [Test]
    public void Test_ProductDropDownDefaultValueIsDisplayedOnOpen()
    {
        string DefaultValueProductDropdown = "Select product";

        var ProgressContactUsPage = new ProgressContactUsPage(driver);

        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        ProgressContactUsPage.LoadPage(ContactUsPageURL);
        var productDropDown = ProgressContactUsPage.SelectedPdoructDropDown;
        IWebElement selectedOption = productDropDown.SelectedOption;
        ClassicAssert.AreEqual(DefaultValueProductDropdown, selectedOption, "The product dropdown default value doesn't match");
    }

    [TearDown]
    public void EndTest()
    {
        driver.Close();
    }
}