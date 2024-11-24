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
        ClassicAssert.IsTrue(ProgressContactUsPage.GetInTouchSectionIsDisplayed);
    }

    [Test]
    public void Test_ProductDropDownDefaultValueIsDisplayedOnOpen()
    {
        // Default Value Product Dropdown = "Select product";

        var ProgressContactUsPage = new ProgressContactUsPage(driver);

        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        ProgressContactUsPage.LoadPage(ContactUsPageURL);
        ClassicAssert.IsTrue(ProgressContactUsPage.IsProductInterestDropDownEmpty());
    }

    [Test]
    public void Test_AllRequeredFieldsValidation()
    {
        var ProgressContactUsPage = new ProgressContactUsPage(driver);

        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        ProgressContactUsPage.LoadPage(ContactUsPageURL);
        ClassicAssert.IsTrue(ProgressContactUsPage.IsProductInterestDropDownEmpty());
        ClassicAssert.IsTrue(ProgressContactUsPage.IsBusinessEmailFIledEmpty());
        ClassicAssert.IsTrue(ProgressContactUsPage.IsFirstNameFieldEmpty());
        ClassicAssert.IsTrue(ProgressContactUsPage.IsLastNameFieldEmpty());
        ClassicAssert.IsTrue(ProgressContactUsPage.IsCompanyFieldEmpty());
        ClassicAssert.IsTrue(ProgressContactUsPage.IsiAmDropDownEmpty());
        ClassicAssert.IsTrue(ProgressContactUsPage.IsCountryTerritoryDropDownEmpty());
        ClassicAssert.IsTrue(ProgressContactUsPage.IsPhoneFieldEmpty());
        ProgressContactUsPage.ClikContactSalesButton();
        
        
    }

    [TearDown]
    public void EndTest()
    {
        driver.Close();
    }
}