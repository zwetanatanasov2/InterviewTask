using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

class ProgressContactUsPageTests
{
    private ChromeDriver driver;
    private readonly string contactUsPageURL = "https://www.progress.com/company/contact";
    private ProgressContactUsPage contactUsPage;
    private ProgressGenerateRandomString stringGenerator = new ProgressGenerateRandomString();

    [SetUp]
    public void Initialize()
    {
        driver = new ChromeDriver();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        contactUsPage = new ProgressContactUsPage(driver); 
        contactUsPage.LoadPage(contactUsPageURL);
    }

    [TearDown]
    public void EndTest()
    {
        ProgressTakeScreenShot screenShotHelper = new ProgressTakeScreenShot(driver);
        var CurrentContext = NUnit.Framework.TestContext.CurrentContext;
        if (CurrentContext.Result.Outcome != NUnit.Framework.Interfaces.ResultState.Success)
        {
            string testName = CurrentContext.Test.Name;
            screenShotHelper.TakeScreenshot(testName);
        }

        driver.Quit();
    }

    [Test]
    public void Test_ContactUsPageIsDisplayed()
    {
        Assert.That(contactUsPage.IsDisplayedContactUsPage);
    }

    [Test]
    public void Test_GetInTouchSectionIsDisplayed()
    {
        ClassicAssert.IsTrue(contactUsPage.IsDisplayedGetInTouchSection);
    }

    [Test]
    public void Test_ProductDropdownDefaultValueDisplayedOnOpen()
    {
        // Default Value for Product drop down = "Select product";
        ClassicAssert.IsTrue(contactUsPage.IsProductInterestDropDownEmpty());
    }

    [Test]
    public void Test_StateDropdowDisplayedIfUSACountrySelected()
    {
        string countryToSelect = "USA";

        contactUsPage.SelectValueCountryDropDown(countryToSelect);
        ClassicAssert.IsTrue(contactUsPage.IsDisplayedStateDropDown);
    }

    [Test]
    public void Test_EuropeanCountryPrivacyPolicyLinkRedirectsToPrivacyPolicyPage()
    {
        string countryToSelect = "Germany";
        string privacyPolicyURL = "https://www.progress.com/legal/privacy-policy";

        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        string originalWindow = driver.CurrentWindowHandle;
        contactUsPage.SelectValueCountryDropDown(countryToSelect);
        contactUsPage.ClickPrivasyPolicyEropeLink();
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

    [Test]
    public void Test_PhoneFieldPrepopulatedWhenSelectCountry()
    {
        string countryToSelect = "Bulgaria";
        // There is a space after the phone codes
        string bulgariaPhoneCode = "+359 ";

        ClassicAssert.IsTrue(contactUsPage.IsPhoneFieldEmpty());
        contactUsPage.SelectValueCountryDropDown(countryToSelect);
        string prepopulatePhoneCode = contactUsPage.TakeValuePhoneField();
        ClassicAssert.AreEqual(prepopulatePhoneCode, bulgariaPhoneCode);
    }
    

    [Test]
    public void Test_FirstNameFieldIsRequered()
    {
        string productDropdownValue = "Chef – DevOps";
        string lastNameFiledValue = "TestLastName";
        string businessEmailFieldValue = "test@progress.com";
        string companyFieldValue = "TestCompany";
        string iAmDropdownValue = "Independent Software Vendor";
        string countryDropdownValue = "United Kingdom";
        string phoneFieldValue = "123456789";

        contactUsPage.SelectValueProductDropDown(productDropdownValue);
        contactUsPage.PopulateBusinesEmail(businessEmailFieldValue);
        contactUsPage.PopulateLastName(lastNameFiledValue);
        contactUsPage.PopulateCompanyName(companyFieldValue);
        contactUsPage.SelectValueIAmDropDown(iAmDropdownValue);
        contactUsPage.SelectValueCountryDropDown(countryDropdownValue);
        contactUsPage.PopulatePhone(phoneFieldValue);
        // First Name field must be empty on submit.
        ClassicAssert.IsTrue(contactUsPage.IsFirstNameFieldEmpty());
        contactUsPage.ClikContactSalesButton();
        ClassicAssert.IsTrue(contactUsPage.IsDisplayedValidationMessageFirstNameField);
    }
    
    [Test]
    public void Test_EmailFieldValidationMessageInvalidEmailFormat()
    {
        string expectedValidationMessage = "Invalid email format";
        string invalidEmailFormat = "test.progress@com";

        ClassicAssert.IsTrue(contactUsPage.IsBusinessEmailFIledEmpty());
        contactUsPage.PopulateBusinesEmail(invalidEmailFormat);
        contactUsPage.ClikContactSalesButton();
        string currentValidationMessageText = contactUsPage.TakeValidationMessageEmailFiedText();
        ClassicAssert.AreEqual(expectedValidationMessage, currentValidationMessageText, "Validation message string does not match");
    } 

    [Test]
    public void Test_ConfirmationPageDisplayedOnSuccessfullSubmitGetInTouchForm()
    {
        string thankYouPageURL = "https://www.progress.com/company/contact-thank-you";
        string productDropdownValue = "Chef – DevOps";
        string firstNameFieldValue = "TestFirstName";
        string lastNameFiledValue = "TestLastName";
        string businessEmailFieldValue = "test@progress.com";
        string companyFieldValue = "TestCompany";
        string iAmDropdownValue = "Independent Software Vendor";
        string countryDropdownValue = "Germany";
        string phoneFieldValue = "123456789";
        var ThankYouPage = new ProgressThankYouPage(driver);

        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        contactUsPage.SelectValueProductDropDown(productDropdownValue);
        contactUsPage.PopulateBusinesEmail(businessEmailFieldValue);
        contactUsPage.PopulateFirstName(firstNameFieldValue);
        contactUsPage.PopulateLastName(lastNameFiledValue);
        contactUsPage.PopulateCompanyName(companyFieldValue);
        contactUsPage.SelectValueIAmDropDown(iAmDropdownValue);
        contactUsPage.SelectValueCountryDropDown(countryDropdownValue);
        contactUsPage.PopulatePhone(phoneFieldValue);
        contactUsPage.ClikContactSalesButton();
        wait.Until(driver => ThankYouPage.IsDisplayedConfirmationMessage);
        string reidrectedPageURL = driver.Url;
        ClassicAssert.AreEqual(thankYouPageURL, reidrectedPageURL, "The page URL does not match");
    }

    [Test]
    public void Test_ValidateMessageFieldCounter()
    {
        int defaultCounterNumber = 2000;
        int stringLength = 15;
        string randomString = stringGenerator.GenerateRandomString(stringLength);

        contactUsPage.PopulateMessage(randomString);
        int currentCounterValue = Int32.Parse(contactUsPage.TakeValueMessageFieldCounter());
        ClassicAssert.AreEqual(defaultCounterNumber-stringLength, currentCounterValue);
    }

    [Test]
    public void Test_ValidateFirstNameTrimmedToMaximumAlloed()
    {
        int firstNameMaximumAllowedChar = 50;
        int stringLength = 60;
        string randomString = stringGenerator.GenerateRandomString(stringLength);

        contactUsPage.PopulateFirstName(randomString);
        string currentFirstNameValue = contactUsPage.TakeValueFirstNameField();
        int countFirstNameValue = currentFirstNameValue.Count();
        ClassicAssert.AreEqual(firstNameMaximumAllowedChar, countFirstNameValue);
    }
}