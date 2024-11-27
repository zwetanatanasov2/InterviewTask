using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

class ProgressContactUsPageTests
{
    ChromeDriver driver;
    string ContactUsPageURL = "https://www.progress.com/company/contact";

    [SetUp]
    public void Initialize()
    {
        driver = new ChromeDriver();
        var ProgressContactUsPage = new ProgressContactUsPage(driver);
        ProgressContactUsPage.LoadPage(ContactUsPageURL);
    }

    [Test]
    public void Test_ContactUsPageIsDisplayed()
    {
        var ProgressContactUsPage = new ProgressContactUsPage(driver);

        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        Assert.That(ProgressContactUsPage.IsDisplayedContactUsPage);
    }

    [Test]
    public void Test_GetInTouchSectionIsDisplayed()
    {
        var ProgressContactUsPage = new ProgressContactUsPage(driver);

        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        ClassicAssert.IsTrue(ProgressContactUsPage.IsDisplayedGetInTouchSection);
    }

    [Test]
    public void Test_ProductDropdownDefaultValueDisplayedOnOpen()
    {
        // Default Value Product Dropdown = "Select product";

        var ProgressContactUsPage = new ProgressContactUsPage(driver);

        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        ClassicAssert.IsTrue(ProgressContactUsPage.IsProductInterestDropDownEmpty());
    }

    [Test]
    public void Test_StateDropdowDisplayedIfUSACountrySelected()
    {
        string countryToSelect = "USA";
        var ProgressContactUsPage = new ProgressContactUsPage(driver);

        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        ProgressContactUsPage.SelectValueCountryDropDown(countryToSelect);
        ClassicAssert.IsTrue(ProgressContactUsPage.IsDisplayedStateDropDown);
    }

    [Test]
    public void Test_EuropeanCountryPrivacyPolicyLinkRedirectsToPrivacyPolicyPage()
    {
        string countryToSelect = "Germany";
        string privacyPolicyURL = "https://www.progress.com/legal/privacy-policy";
        var ProgressContactUsPage = new ProgressContactUsPage(driver);

        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        string originalWindow = driver.CurrentWindowHandle;
        ProgressContactUsPage.SelectValueCountryDropDown(countryToSelect);
        ProgressContactUsPage.ClickPrivasyPolicyEropeLink();
        wait.Until(driver => driver.WindowHandles.Count > 1);
        foreach (string window in driver.WindowHandles)
        {
            if (window != originalWindow)
            {
                driver.SwitchTo().Window(window);
                break;
            }
        }
        string currentPageURL = driver.Url;
        ClassicAssert.AreEqual(privacyPolicyURL, currentPageURL, "Page URL does not match.");
    }

    /* I cannot compleate this test. I'm not able to find the prepopulated value after select of a country.
    [Test]
    public void Test_PhoneFieldPrepopulatedWhenSelectCountry()
    {
        string countryToSelect = "Bulgaria";
        string bulgariaPhoneCode = "+359";
        var ProgressContactUsPage = new ProgressContactUsPage(driver);

        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        ClassicAssert.IsTrue(ProgressContactUsPage.IsPhoneFieldEmpty());
        ProgressContactUsPage.SelectValueCountryDropDown(countryToSelect);
        string prepopulatePhoneCode = ProgressContactUsPage.TakeValuePhoneField();
        ClassicAssert.AreEqual(prepopulatePhoneCode, bulgariaPhoneCode);
    }
    */

    [Test]
    public void Test_FirstNameFieldIsRequered()
    {
        string productDropdownValue = "Chef – DevOps";
        string lastNameFiledValue = "TestLastName";
        string businessEmailFieldValue = "test@progress.com";
        string companyFIeldValue = "TestCompany";
        string iAmDropdownValue = "Independent Software Vendor";
        string countryDropdownValue = "United Kingdom";
        string phoneFieldValue = "123456789";
        var ProgressContactUsPage = new ProgressContactUsPage(driver);

        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        ProgressContactUsPage.SelectValueProductDropDown(productDropdownValue);
        ProgressContactUsPage.PopulateBusinesEmail(businessEmailFieldValue);
        ProgressContactUsPage.PopulateLastName(lastNameFiledValue);
        ProgressContactUsPage.PopulateCompanyName(companyFIeldValue);
        ProgressContactUsPage.SelectValueIAmDropDown(iAmDropdownValue);
        ProgressContactUsPage.SelectValueCountryDropDown(countryDropdownValue);
        ProgressContactUsPage.PopulatePhone(phoneFieldValue);
        // First Name field must be empty on submit.
        ClassicAssert.IsTrue(ProgressContactUsPage.IsFirstNameFieldEmpty());
        ProgressContactUsPage.ClikContactSalesButton();
        ClassicAssert.IsTrue(ProgressContactUsPage.IsDisplayedValidationMessageFirstNameField);
    }
    
    [Test]
    public void Test_EmailFieldValidationMessageInvalidEmailFormat()
    {
        string expectedValidationMessage = "Invalid email format";
        string invalidEmailFormat = "test.progress@com";
        var ProgressContactUsPage = new ProgressContactUsPage(driver);

        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        ClassicAssert.IsTrue(ProgressContactUsPage.IsBusinessEmailFIledEmpty());
        ProgressContactUsPage.PopulateBusinesEmail(invalidEmailFormat);
        ProgressContactUsPage.ClikContactSalesButton();
        string currentValidationMessageText = ProgressContactUsPage.TakeValueValidationMessageEmailFied();
        ClassicAssert.AreEqual(expectedValidationMessage, currentValidationMessageText, "Validation message string does not match");
    } 

    [Test]
    public void Test_ConfirmationPageDisplayedOnSuccessfullSubmitionGetInTouchForm()
    {
        string thankYouPageURL = "https://www.progress.com/company/contact-thank-you";
        string productDropdownValue = "Chef – DevOps";
        string firstNamefieldValue = "TestFirstName";
        string lastNameFiledValue = "TestLastName";
        string businessEmailFieldValue = "test@progress.com";
        string companyFIeldValue = "TestCompany";
        string iAmDropdownValue = "Independent Software Vendor";
        string countryDropdownValue = "Germany";
        string phoneFieldValue = "123456789";
        var ProgressContactUsPage = new ProgressContactUsPage(driver);
        var ProgressThankYouPage = new ProgressThankYouPage(driver);

        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        ProgressContactUsPage.SelectValueProductDropDown(productDropdownValue);
        ProgressContactUsPage.PopulateBusinesEmail(businessEmailFieldValue);
        ProgressContactUsPage.PopulateFirstName(firstNamefieldValue);
        ProgressContactUsPage.PopulateLastName(lastNameFiledValue);
        ProgressContactUsPage.PopulateCompanyName(companyFIeldValue);
        ProgressContactUsPage.SelectValueIAmDropDown(iAmDropdownValue);
        ProgressContactUsPage.SelectValueCountryDropDown(countryDropdownValue);
        ProgressContactUsPage.PopulatePhone(phoneFieldValue);
        ProgressContactUsPage.ClikContactSalesButton();
        wait.Until(driver => ProgressThankYouPage.IsDisplayedConfirmationMessage);
        string reidrectedPageURL = driver.Url;
        ClassicAssert.AreEqual(thankYouPageURL, reidrectedPageURL, "The page URL does not match");
    }

    [TearDown]
    public void EndTest()
    {
        ProgressTakeScreenShot screenShotHelper = new ProgressTakeScreenShot(driver);
        var currentContext = NUnit.Framework.TestContext.CurrentContext;
        if (currentContext.Result.Outcome != NUnit.Framework.Interfaces.ResultState.Success)
        {
            string testName = currentContext.Test.Name;
            screenShotHelper.TakeScreenshot(testName);
        }

        driver.Quit();
    }
}